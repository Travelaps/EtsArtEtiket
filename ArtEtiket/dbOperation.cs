using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace ArtEtiket
{
    public static class dbOperation
    {
        private static SqlProvider _sqlProvider;

        public static DataTable SubeListesi()
        {
            var _sqlProvider = new SqlProvider("SELECT DISTINCT SUBEKODU FROM (SELECT TOP 2000 SUBEKODU FROM VFR_KASA_ANALIZ ORDER BY TARIH DESC) TBL UNION ALL SELECT ' ' ORDER BY SUBEKODU", false);
            var dt = new DataTable();
            dt.Load(_sqlProvider.ExecuteReader());
            return dt;
        }

        public static int ReadConfigParamInt(string Progname, string SectionStr, string Keyname, string DefaultValue = "")
        {
            var str = ReadConfigParam(Progname, SectionStr, Keyname, DefaultValue);
            return Convert.ToInt32(str);
        }

        public static string ReadConfigParam(string Progname, string SectionStr, string Keyname, string DefaultValue = "")
        {
            string result = "";
            _sqlProvider = new SqlProvider("SELECT VALUESTR FROM CONFIG WHERE PROGNAME=@PROGNAME AND SECTIONSTR=@SECTIONSTR AND KEYNAME=@KEYNAME ", false);
            _sqlProvider.AddParameter("PROGNAME", Progname);
            _sqlProvider.AddParameter("SECTIONSTR", SectionStr);
            _sqlProvider.AddParameter("KEYNAME", Keyname);

            using (var dt = new DataTable())
            {
                dt.Load(_sqlProvider.ExecuteReader());
                if (dt.Rows.Count >= 1)
                {
                    result = dt.Rows[0]["VALUESTR"].ToString();
                }
                else
                {
                    result = DefaultValue;
                    _sqlProvider =
                        new SqlProvider(
                            "INSERT INTO CONFIG (PROGNAME,SECTIONSTR,KEYNAME,VALUESTR) VALUES(@PROGNAME,@SECTIONSTR,@KEYNAME,@VALUESTR) ",
                            false);
                    _sqlProvider.AddParameter("PROGNAME", Progname);
                    _sqlProvider.AddParameter("SECTIONSTR", SectionStr);
                    _sqlProvider.AddParameter("KEYNAME", Keyname);
                    _sqlProvider.AddParameter("VALUESTR", result);
                    _sqlProvider.ExecuteNonQuery();
                }
            }
            return result;
        }

        internal static int DepoIDbul(string depoadi)
        {
            _sqlProvider = new SqlProvider("SELECT DEPOID FROM DEPO WHERE DEPOADI = @DEPOADI ", false);
            _sqlProvider.AddParameter("DEPOADI", depoadi);
            return Convert.ToInt32(_sqlProvider.ExecuteScalar());
        }

        public static bool TekrarEtiketYazdirilacakKaydiBul(string partino, ref int stokid, ref double miktar)
        {
            var _sqlProvider = new SqlProvider("SELECT TOP 1 * FROM PARTI_NO_TERAZI WHERE PARTINO = @PARTINO ", false);
            _sqlProvider.AddParameter("PARTINO", partino);
            using (var dt = new DataTable())
            {
                dt.Load(_sqlProvider.ExecuteReader());
                if (dt.Rows.Count == 1)
                {
                    stokid = Convert.ToInt32(dt.Rows[0]["STOKID"].ToString());
                    miktar = Convert.ToDouble(dt.Rows[0]["MIKTAR"].ToString());
                }
                return (dt.Rows.Count == 1);
            }
        }

        public static DataTable PartiNoUretilecekALISFaturalariListesi(DateTime tarih1, DateTime tarih2, string DepoID)
        {
            //SELECT DISTINCT TARIH, FISTIPI, ISLEM, FATNO, FATID, DEPOID, DEPOADI, KODU, CARIUNVANI, TOPLAM
            //FROM QMUH_STOKISL
            //WHERE TARIH BETWEEN '2016-04-01' AND '2016-04-03' AND FISTIPI = 'FATURA' AND ISLEM = 'ALIS' AND BARKOD IS NULL
            _sqlProvider = new SqlProvider(
                " SELECT DISTINCT TARIH, FISTIPI, ISLEM, FATNO, FATID, DEPOID, DEPOADI, KODU, CARIUNVANI, round(SUM(TOPLAM),2) TOPLAM"+
                " FROM QMUH_STOKISL" +
                " WHERE TARIH BETWEEN @TARIH1 AND @TARIH2 AND FISTIPI = 'FATURA' AND ISLEM = 'ALIS' AND BARKOD IS NULL AND DEPOID = @DEPOID "+
                " GROUP BY TARIH, FISTIPI, ISLEM, FATNO, FATID, DEPOID, DEPOADI, KODU, CARIUNVANI "
                );
            _sqlProvider.AddParameter("TARIH1", tarih1);
            _sqlProvider.AddParameter("TARIH2", tarih2);
            _sqlProvider.AddParameter("DEPOID", DepoID);
            var d = new DataTable();
            d.Load(_sqlProvider.ExecuteReader());
            return d;
        }
        public static bool ALISFaturaSatirlarinaPartiNoUret(int fatid, DateTime faturatarihi)
        {
            _sqlProvider = new SqlProvider("SELECT * FROM FATISL WHERE FATID=@FATID AND ISNULL(BARKOD,'')='' ", false);
            _sqlProvider.AddParameter("FATID", fatid);
            DataTable dtFatIsl = new DataTable();
            dtFatIsl.Load(_sqlProvider.ExecuteReader());
            foreach (DataRow rowFatIsl in dtFatIsl.Rows)
            {
                string pNo = PartiNo.PartiNoUret(faturatarihi, "HAMMADDEPARTINO");
                _sqlProvider = new SqlProvider("UPDATE FATISL SET BARKOD=@PARTINO WHERE FATISLID=@FATISLID", false);
                _sqlProvider.AddParameter("PARTINO", pNo);
                _sqlProvider.AddParameter("FATISLID", rowFatIsl["FATISLID"]);
                _sqlProvider.ExecuteNonQuery();

                dbOperation.PartiNoOlusumuKaydet(pNo,Convert.ToInt32(rowFatIsl["STOKID"]),Convert.ToDouble(rowFatIsl["ADET"]),0, faturatarihi, faturatarihi);
            }
            return true;
        }

        public static void PartiNoOlusumuKaydet(string partino, int stokid, double miktar, double daramiktar, DateTime uretimtarihi , DateTime sktarihi, bool koliicinde = false, int koligrupid = 0)
        {
            _sqlProvider = new SqlProvider("INSERT INTO [PARTI_NO_TERAZI] ([PARTINO],[STOKID],[MIKTAR],[DARA],[BURUTMIKTAR],[URETIMTARIHI],[SONKULLANMATARIHI],[KOLIICINDE],[KOLIGRUPID]) " +
                " VALUES (@PARTINO,@STOKID,@MIKTAR,@DARA,@BURUTMIKTAR,@URETIMTARIHI,@SONKULLANMATARIHI,@KOLIICINDE,@KOLIGRUPID)", false);
            _sqlProvider.AddParameter("PARTINO", partino);
            _sqlProvider.AddParameter("STOKID", stokid);
            _sqlProvider.AddParameter("MIKTAR", miktar);
            _sqlProvider.AddParameter("DARA", daramiktar);
            _sqlProvider.AddParameter("BURUTMIKTAR", miktar+daramiktar);
            _sqlProvider.AddParameter("URETIMTARIHI", uretimtarihi);
            _sqlProvider.AddParameter("SONKULLANMATARIHI", sktarihi);
            _sqlProvider.AddParameter("KOLIICINDE", koliicinde);
            _sqlProvider.AddParameter("KOLIGRUPID", koligrupid);
            _sqlProvider.ExecuteNonQuery();
        }

        public static DataTable ParcalanacakHammaddeListesi(DateTime tar1, DateTime tar2, string DepoID)
        {
            //SELECT SI.TARIH,FATNO,CARIUNVANI,BARKOD,STOKKODU,ADI,SBIRIMI BIRIM, GCADET MIKTAR,ROUND(NFIYAT, 2) FIYAT, ROUND(GCADET * NFIYAT, 2) TUTAR,*
            //FROM QMUH_STOKISL SI
            //   LEFT OUTER JOIN PARCALAMA P ON P.STOKID = SI.STOKID AND P.TARIH = SI.TARIH AND P.ACIKLAMA = SI.BARKOD
            //WHERE SI.TARIH BETWEEN '2016-04-01' AND '2016-04-03' AND FISTIPI = 'FATURA' AND ISLEM = 'ALIS' AND SI.DEPOID = 1 AND BARKOD IS NOT NULL

              _sqlProvider = new SqlProvider(
                " SELECT SI.TARIH,FATNO,CARIUNVANI,BARKOD,SI.STOKID,STOKKODU,ADI,SBIRIMI BIRIM, GCADET MIKTAR,ROUND(NFIYAT, 2) FIYAT, ROUND(GCADET * NFIYAT, 2) TUTAR " +
                " FROM QMUH_STOKISL SI " +
                "    LEFT OUTER JOIN PARCALAMA P ON P.STOKID = SI.STOKID AND P.TARIH = SI.TARIH AND P.ACIKLAMA = SI.BARKOD " +
                " WHERE SI.TARIH BETWEEN @TARIH1 AND @TARIH2 AND FISTIPI = 'FATURA' AND ISLEM = 'ALIS' AND SI.DEPOID = @DEPOID AND BARKOD IS NOT NULL AND ADI LIKE '%(PAR_ALANACAK)%' AND P.ACIKLAMA IS NULL " +
                " ORDER BY SI.TARIH, SI.ADI ", false);

            _sqlProvider.AddParameter("TARIH1", tar1);
            _sqlProvider.AddParameter("TARIH2", tar2);
            _sqlProvider.AddParameter("DEPOID", DepoID);
            var dt = new DataTable();
            dt.Load(_sqlProvider.ExecuteReader());
            return dt;  //dataGridView2.DataSource = dt;
        }

        public static DataTable UrunKodunaGoreReceteDetayiGetir(string urunkodu)
        {
            // SELECT URUNID, U.KODU URUNKODU, U.ADI URUNADI, RECETE.STOKID, S.KODU, S.ADI, RECETE.ORAN, RECETE.RECETEKATSAYISI
            // FROM  RECETE 
            //  INNER JOIN STOK U ON RECETE.URUNID = U.STOKID
            //  INNER JOIN STOK S ON RECETE.STOKID = S.STOKID
            // WHERE URUNID = 3760
            _sqlProvider = new SqlProvider(
             " SELECT URUNID, U.KODU URUNKODU, U.ADI URUNADI, RECETE.STOKID, S.KODU, S.ADI, RECETE.ORAN, RECETE.RECETEKATSAYISI, RECETE.FIRE, RECETE.XBIRIM " +
             " FROM  RECETE " +
             "    INNER JOIN STOK U ON RECETE.URUNID = U.STOKID " +
             " INNER JOIN STOK S ON RECETE.STOKID = S.STOKID " +
             "  WHERE U.KODU = @URUNKODU ", false);

            _sqlProvider.AddParameter("URUNKODU", urunkodu);
            var dt = new DataTable();
            dt.Load(_sqlProvider.ExecuteReader());
            return dt;  
        }

        public static int Stok_Katsayi2_Bul(int stokid)
        {
            try
            {
                _sqlProvider = new SqlProvider("SELECT KATSAYI2 FROM STOK WHERE STOKID = @STOKID ", false);
                _sqlProvider.AddParameter("STOKID", stokid);
                int num = Convert.ToInt32(_sqlProvider.ExecuteScalar());
                return (num==0) ? 1 : num ;
            }
            catch (Exception)
            {
                return 1;
            }

        }


        #region PARCALAMA Islemleri için DEPOFIS ve PARCALAMA insert işlemleri
        public static int DepofisInsert(Depofis depofis)
        {
            _sqlProvider = new SqlProvider("INSERT INTO DEPOFIS (DEPOFISID,TARIH,ISLEM,YETKILI,ENO,ACIKLAMA,GDEPOID,CDEPOID,TADET,TTUTAR,DURUMU,DURUM,SUBEID)  VALUES (@DEPOFISID,@TARIH,@ISLEM,@YETKILI,@ENO,@ACIKLAMA,@GDEPOID,@CDEPOID,@TADET,@TTUTAR,@DURUMU,@DURUM,@SUBEID) ", false);
            _sqlProvider.AddParameter("DEPOFISID", depofis.Depofisid);
            _sqlProvider.AddParameter("TARIH", depofis.Tarih);
            _sqlProvider.AddParameter("ISLEM", depofis.Islem);
            _sqlProvider.AddParameter("YETKILI", depofis.Yetkili);
            _sqlProvider.AddParameter("ENO", depofis.Eno);
            _sqlProvider.AddParameter("ACIKLAMA", depofis.Aciklama);
            if (depofis.Islem == "TÜKETİM")
            {
                _sqlProvider.AddParameter("CDEPOID", depofis.CDepoid);
                _sqlProvider.AddParameter("GDEPOID", DBNull.Value);
            }
            else if (depofis.Islem == "ÜRETİM")
            {
                _sqlProvider.AddParameter("CDEPOID", DBNull.Value);
                _sqlProvider.AddParameter("GDEPOID", depofis.GDepoid);
            }
            else if (depofis.Islem == "TRANSFER")
            {
                _sqlProvider.AddParameter("CDEPOID", depofis.CDepoid);
                _sqlProvider.AddParameter("GDEPOID", depofis.GDepoid);
            }
            _sqlProvider.AddParameter("TADET", depofis.Tadet);
            _sqlProvider.AddParameter("TTUTAR", depofis.Ttutar);
            _sqlProvider.AddParameter("DURUMU", depofis.Durumu);
            _sqlProvider.AddParameter("DURUM", depofis.Durum);
            _sqlProvider.AddParameter("SUBEID", depofis.Subeid);
            _sqlProvider.ExecuteNonQuery();
            return depofis.Depofisid;
        }
        public static void DepoFisIslInsert(DepofisIsl depofisIsl)
        {
            _sqlProvider = new SqlProvider("INSERT INTO DEPOFISISL (DEPOFISID,STOKID,MIKTAR,FBIRIM,FMIKTAR,BFIYAT,FBFIYAT,BARKOD) VALUES    (@DEPOFISID,@STOKID,@MIKTAR,@FBIRIM,@FMIKTAR,@BFIYAT,@FBFIYAT,@BARKOD)", false);
            _sqlProvider.AddParameter("DEPOFISID", depofisIsl.Depofisid);
            _sqlProvider.AddParameter("STOKID", depofisIsl.Stokid);
            _sqlProvider.AddParameter("MIKTAR", depofisIsl.Miktar);
            _sqlProvider.AddParameter("FBIRIM", depofisIsl.FBirim);
            _sqlProvider.AddParameter("FMIKTAR", depofisIsl.Miktar);
            _sqlProvider.AddParameter("BFIYAT", depofisIsl.BFiyat);
            _sqlProvider.AddParameter("FBFIYAT", depofisIsl.BFiyat);
            _sqlProvider.AddParameter("BARKOD", depofisIsl.Barkod);
            _sqlProvider.ExecuteNonQuery();
        }
        public static void DepofisUpdate(int depofisid)
        {
            _sqlProvider = new SqlProvider(
                " UPDATE DEPOFIS " +
                " SET " +
                "   TADET  = DI.TADET," +
                "   TTUTAR = DI.TTUTAR " +
                " FROM DEPOFIS D " +
                "    INNER JOIN (SELECT FI.DEPOFISID,COUNT(*) TADET,SUM(FMIKTAR*FBFIYAT) TTUTAR " +
                "                FROM DEPOFISISL FI GROUP BY FI.DEPOFISID) DI ON DI.DEPOFISID=D.DEPOFISID " +
                " WHERE D.DEPOFISID=@DEPOFISID", false);
            _sqlProvider.AddParameter("DEPOFISID", depofisid);
            _sqlProvider.ExecuteNonQuery();
        }

        public static void ParcalamaInsert(Parcalama parcalama)
        {
            _sqlProvider = new SqlProvider("INSERT INTO PARCALAMA (PARCALAMAID,DURUM,TARIH,SAAT,ACIKLAMA,DEPOID,YETKILI,STOKID,DEPOMIKTAR,MIKTAR,BFIYAT,MAMULMIKTAR,MAMULTOPLAM,FIREMIKTAR,FIREORAN) " +
                                            "VALUES (@P1,@P2,@P3,@P4,@P5,@P6,@P7,@P8,@P9,@P10,@P11,@P12,@P13,@P14,@P15)");
            _sqlProvider.AddParameter("P1", parcalama.Parcalamaid);
            _sqlProvider.AddParameter("P2", parcalama.Durum);
            _sqlProvider.AddParameter("P3", parcalama.Tarih);
            _sqlProvider.AddParameter("P4", parcalama.Saat);
            _sqlProvider.AddParameter("P5", parcalama.Aciklama);
            _sqlProvider.AddParameter("P6", parcalama.Depoid);
            _sqlProvider.AddParameter("P7", parcalama.Yetkili);
            _sqlProvider.AddParameter("P8", parcalama.Stokid);
            _sqlProvider.AddParameter("P9", parcalama.DepoMiktar);
            _sqlProvider.AddParameter("P10", parcalama.Miktar);
            _sqlProvider.AddParameter("P11", parcalama.BFiyat);
            _sqlProvider.AddParameter("P12", parcalama.MamulMiktar);
            _sqlProvider.AddParameter("P13", parcalama.MamulToplam);
            _sqlProvider.AddParameter("P14", parcalama.FireMiktar);
            _sqlProvider.AddParameter("P15", parcalama.FireOran);
            _sqlProvider.ExecuteNonQuery();
        }

        internal static void ParcalamayaTransferIDYaz(int parcalamaid, object depofisid)
        {
            _sqlProvider = new SqlProvider("UPDATE PARCALAMA SET TRANSFERDEPOFISID=@TRANSFERDEPOFISID WHERE PARCALAMAID=@PARCALAMAID");
            _sqlProvider.AddParameter("TRANSFERDEPOFISID", depofisid);
            _sqlProvider.AddParameter("PARCALAMAID", parcalamaid);
            _sqlProvider.ExecuteNonQuery();
        }

        internal static void ParcalamayaTuketimIDYaz(int parcalamaid, int depofisid)
        {
            _sqlProvider = new SqlProvider("UPDATE PARCALAMA SET TUKETIMDEPOFISID=@TUKETIMDEPOFISID WHERE PARCALAMAID=@PARCALAMAID");
            _sqlProvider.AddParameter("TUKETIMDEPOFISID", depofisid);
            _sqlProvider.AddParameter("PARCALAMAID", parcalamaid);
            _sqlProvider.ExecuteNonQuery();
        }

        internal static void ParcalamayaUretimIDYaz(int parcalamaid, int depofisid)
        {
            _sqlProvider = new SqlProvider("UPDATE PARCALAMA SET URETIMDEPOFISID=@URETIMDEPOFISID WHERE PARCALAMAID=@PARCALAMAID");
            _sqlProvider.AddParameter("URETIMDEPOFISID", depofisid);
            _sqlProvider.AddParameter("PARCALAMAID", parcalamaid);
            _sqlProvider.ExecuteNonQuery();
        }

        public static void ParcalamaIslInsert(ParcalamaIsl parcalamaIsl)
        {
            _sqlProvider = new SqlProvider("INSERT INTO PARCALAMAISL (PARCALAMAISLID,PARCALAMAID,STOKID,MIKTAR,PMIKTAR,BFIYAT,KATSAYI,FIRESTOKSATIRI) VALUES (@PARCALAMAISLID,@PARCALAMAID,@STOKID,@MIKTAR,@PMIKTAR,@BFIYAT,@KATSAYI,@FIRESTOKSATIRI)");
            _sqlProvider.AddParameter("PARCALAMAISLID", parcalamaIsl.ParcalamaIslId);
            _sqlProvider.AddParameter("PARCALAMAID", parcalamaIsl.ParcalamaId);
            _sqlProvider.AddParameter("STOKID", parcalamaIsl.StokId);
            _sqlProvider.AddParameter("MIKTAR", parcalamaIsl.Miktar);
            _sqlProvider.AddParameter("PMIKTAR", parcalamaIsl.PMiktar);
            _sqlProvider.AddParameter("BFIYAT", parcalamaIsl.BFiyat);
            _sqlProvider.AddParameter("KATSAYI", parcalamaIsl.Katsayi);
            _sqlProvider.AddParameter("FIRESTOKSATIRI", parcalamaIsl.FireStokSatiri);
            _sqlProvider.ExecuteNonQuery();
        }
        public static void ParcalamaUpdate(int parcalamaid)
        {
            _sqlProvider = new SqlProvider(
                " UPDATE PARCALAMA SET " +
                "  DURUM       = P.DURUM," +
                "  ONAYTARIH   = TARIH," +
                "  ONAYSAAT    = SAAT," +
                "  URETIMDEPOFISID  = P.URETIMID," +
                "  TUKETIMDEPOFISID = P.TUKETIMID," +
                "  MAMULMIKTAR = P.YARIMAMULMIKTAR," +
                "  MAMULTOPLAM = P.YARIMAMULTUTAR," +
                "  FIREMIKTAR  = P.FIREMIKTAR," +
                "  FIREORAN    = P.FIREORAN " +
                " FROM PARCALAMA " +
                "    INNER JOIN " +
                "     (SELECT PARCALAMA.PARCALAMAID,'ONAYLANDI' DURUM,TARIH ONAYTARIH,SAAT ONAYSAAT," +
                "        (SELECT DEPOFISID FROM DEPOFIS WHERE ISLEM='ÜRETİM' AND REPLACE(DEPOFIS.ENO,'PARÇALAMA','')=PARCALAMA.PARCALAMAID) URETIMID, " +
                "        (SELECT DEPOFISID FROM DEPOFIS WHERE ISLEM='TÜKETİM' AND REPLACE(DEPOFIS.ENO,'PARÇALAMA','')=PARCALAMA.PARCALAMAID) TUKETIMID," +
                "        SUM(CASE WHEN FIRESTOKSATIRI=0 THEN PARCALAMAISL.MIKTAR END) YARIMAMULMIKTAR, " +
                "        SUM(CASE WHEN FIRESTOKSATIRI=0 THEN PARCALAMAISL.MIKTAR*PARCALAMAISL.BFIYAT END) YARIMAMULTUTAR," +
                "        SUM(CASE WHEN FIRESTOKSATIRI=1 THEN PARCALAMAISL.MIKTAR END) FIREMIKTAR," +
                "        (SUM(CASE WHEN FIRESTOKSATIRI=1 THEN PARCALAMAISL.MIKTAR END)*100)/SUM(PARCALAMAISL.MIKTAR) FIREORAN " +
                "      FROM PARCALAMA INNER JOIN PARCALAMAISL ON PARCALAMAISL.PARCALAMAID=PARCALAMA.PARCALAMAID " +
                "      GROUP BY TARIH,SAAT,PARCALAMA.PARCALAMAID) AS P ON P.PARCALAMAID=PARCALAMA.PARCALAMAID " +
                " WHERE PARCALAMA.PARCALAMAID=@ID ");
            _sqlProvider.AddParameter("ID", parcalamaid);
            _sqlProvider.ExecuteNonQuery();
        }

        internal static void ParcalamaUpdate(object parcalamaid)
        {
            throw new NotImplementedException();
        }

        internal static void UretimTalebiniOlustur(string partino, int stokid, string birim, double miktar, DateTime uretimtarihi, int UretimTalepDepoId)
        {
            MODEL.UretimTalep M = new MODEL.UretimTalep()
            {
                Tarih = uretimtarihi,
                TeslimTarihi = uretimtarihi,
                Depoid = UretimTalepDepoId,
            };
            if (M.Exist() == 0)
                M.Insert();
            MODEL.UretimTalepIsl D = new MODEL.UretimTalepIsl()
            {
                UretimTalepid = M.UretimTalepid,
                Barkod = partino,
                Stokid = stokid,
                Birim = birim,
                Miktar = miktar,
            };
            D.Insert();
        }
        #endregion
    }
}
