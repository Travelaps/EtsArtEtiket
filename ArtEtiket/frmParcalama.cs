using System;
using System.Data;
using System.Globalization;
using System.Windows.Forms;

namespace ArtEtiket
{
    public partial class frmParcalama : Form
    {
        private SqlProvider _sqlProvider;
        DataTable _dtFatList;
        private DataTable _dtParcalamaList;
        private int AlimDepoID = Properties.Settings.Default.AlimDepoID;
        // (PARÇALANACAK) yazanlar oldu    private string ParcalanacakSTOKIDS = Properties.Settings.Default.ParcalanacakStokListesi;

        private int ParcalamaTransferDepoId = 0;
        private int ParcalamaTuketimDepoId = 0;
        private int ParcalamaUretimDepoId = 0;

        public frmParcalama()
        {
            InitializeComponent();
            dateTimePicker1.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1); ;
            dateTimePicker2.Value = DateTime.Now.Date;

            ParcalamaTransferDepoId = dbOperation.DepoIDbul(dbOperation.ReadConfigParam("ArtEtiket", "Parcalama", "Parcalama Islemi Transfer Deposu", "ANADEPO"));
            ParcalamaTuketimDepoId = dbOperation.DepoIDbul(dbOperation.ReadConfigParam("ArtEtiket", "Parcalama", "Parcalama Islemi Tüketim Deposu", "ÜRETİM"));
            ParcalamaUretimDepoId = dbOperation.DepoIDbul(dbOperation.ReadConfigParam("ArtEtiket", "Parcalama", "Parcalama Islemi Uretim Deposu", "ANADEPO"));
        }

        //TEOMAN OK 03.04.2016 14:40
        private void btnFilter_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                switch (tabControl1.SelectedIndex)
                {
                    case 0:
                        //FaturaListesi(dateTimePicker1.Value.Date, dateTimePicker2.Value.Date, AlimDepoID.ToString());
                        _dtFatList = dbOperation.PartiNoUretilecekALISFaturalariListesi(dateTimePicker1.Value.Date, dateTimePicker2.Value.Date, AlimDepoID.ToString());
                        dataGridView1.DataSource = _dtFatList;
                        toolStripStatusLabel1.Text = _dtFatList.Rows.Count.ToString();
                        break;
                    case 1:
                        _dtParcalamaList = dbOperation.ParcalanacakHammaddeListesi(dateTimePicker1.Value.Date, dateTimePicker2.Value.Date, AlimDepoID.ToString());
                        dataGridView2.DataSource = _dtParcalamaList;
                        break;
                }
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
            
        }

        #region Faturaya PartiNO Uretme Metodları
        //private void FaturaListesi(DateTime tarih1, DateTime tarih2, string DepoID)
        //{
        //    const int fisturu_Fatura = 051;            //  FATURA DEMEK  :  FISTURID = 051 
        //    const int fisdurum_FaturaISLEMDE = 0;      //      ISLEMDE         :  FISDURUMID = 0 
        //    const int fisdurum_FaturaMUHASEBELESTI = 1;//      MUHASEBELESTI   :  FISDURUMID = 1 
        //    const int fisdurum_FaturaONAYLANDI = 2;    //      ONAYLANDI       :  FISDURUMID = 2 
        //    const int fisdurum_FaturaIRSALIYE = -1;    //      IRSALIYE        :  FISDURUMID = -1 
        //    const int fisdurum_FaturaSILINDI = -2;     //      SILINDI         :  FISDURUMID = -2

        //    _sqlProvider = new SqlProvider(
        //        " SELECT DISTINCT 'FATURA',F.FATID,F.TARIH,FATNO,UNVANI,F.TOPLAM,F.KDV,F.GTOPLAM "+
        //        " FROM FATURA F "+
        //        "    INNER      JOIN FATISL FI ON FI.FATID=F.FATID "+
        //        "    LEFT OUTER JOIN HAREKET H ON H.ETSID=F.FATID "+
        //        " WHERE FISTURID IN (51) AND DEPOID=@DEPOID AND F.TARIH BETWEEN @TAR1 AND @TAR2 AND H.ETSID IS NULL AND ISNULL(FI.BARKOD,'')='' AND FI.IRSISLID IS NULL AND FISDURUMID IN (0,1) "+
                
        //        " UNION ALL "+
                
        //        " SELECT DISTINCT 'IRSALIYE',F.FATID,F.TARIH,FATNO,UNVANI,F.TOPLAM,F.KDV,F.GTOPLAM "+
        //        " FROM FATURA F "+
        //        "    INNER      JOIN FATISL FI ON FI.FATID=F.FATID "+
        //        "    LEFT OUTER JOIN HAREKET H ON H.ETSID=F.FATID "+
        //        " WHERE FISTURID IN (51) AND DEPOID=@DEPOID AND F.TARIH BETWEEN @TAR1 AND @TAR2 AND H.ETSID IS NULL AND ISNULL(FI.BARKOD,'')='' AND FISDURUMID IN (-1)", false);
        //    _sqlProvider.AddParameter("TAR1", tarih1);
        //    _sqlProvider.AddParameter("TAR2", tarih2);
        //    _sqlProvider.AddParameter("DEPOID", DepoID);
        //    _dtFatList = new DataTable();
        //    _dtFatList.Load(_sqlProvider.ExecuteReader());
        //    dataGridView1.DataSource = _dtFatList;
        //    toolStripStatusLabel1.Text = _dtFatList.Rows.Count.ToString();
        //}

        private void tSBtnDetay_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                int fatid = Convert.ToInt32(dataGridView1.CurrentRow.Cells["FATID"].Value);
                frmFaturaDetay faturaDetay = new frmFaturaDetay(fatid);
                faturaDetay.ShowDialog();
            }
        }

        //TEOMAN OK 03.04.2016 14:08
        private void btnPNoUret_Click(object sender, EventArgs e)
        {
            progressBar1.Maximum = _dtFatList.Rows.Count;
            toolStripStatusLabel1.Text = string.Format("({0}{1})", _dtFatList.Rows.Count, " adet fatura için Parti Numarası üretilecek.");
            foreach (DataRow rowFatura in _dtFatList.Rows)
            {
                #region ESKİ HAREKET Tablo kullanılan hali
                //_sqlProvider = new SqlProvider("INSERT INTO HAREKET (ETSID,TARIH,TUR,GDEPOID,ENO,URETIMID,YAZ) VALUES (@FATID,@TARIH,'ALIS',@DEPOID,@FATNO,0,1) SELECT IDENT_CURRENT('HAREKET')", false);
                //_sqlProvider.AddParameter("FATID", rowFatura["FATID"]);
                //_sqlProvider.AddParameter("TARIH", rowFatura["TARIH"]);
                //_sqlProvider.AddParameter("FATNO", rowFatura["FATNO"]);
                //_sqlProvider.AddParameter("DEPOID", AlimDepoID);
                //int hareketID = Convert.ToInt32(_sqlProvider.ExecuteScalar());

                //_sqlProvider = new SqlProvider("SELECT * FROM FATISL WHERE FATID=@FATID", false);
                //_sqlProvider.AddParameter("FATID", rowFatura["FATID"]);
                //DataTable dtFatIsl = new DataTable();
                //dtFatIsl.Load(_sqlProvider.ExecuteReader());
                //foreach (DataRow rowFatIsl in dtFatIsl.Rows)
                //{
                //    toolStripStatusLabel1.Text = string.Format("Fat No {0}", rowFatura["FATNO"]);
                //    string pNo = PartiNo.PartiNoUret(Convert.ToDateTime(rowFatura["TARIH"]).Date, "HAMMADDEPARTINO");
                //    _sqlProvider = new SqlProvider("UPDATE FATISL SET BARKOD=@PARTINO WHERE FATISLID=@FATISLID", false);
                //    _sqlProvider.AddParameter("PARTINO", pNo);
                //    _sqlProvider.AddParameter("FATISLID", rowFatIsl["FATISLID"]);
                //    _sqlProvider.ExecuteNonQuery();
                //    _sqlProvider = new SqlProvider("INSERT INTO HAREKETISL (HAREKETID,STOKID,ETIKETADET,MIKTAR,BIRIM,BFIYAT,PARTINO,YAZDIRILDI) VALUES (@HAREKETID,@STOKID,1,@MIKTAR,@BIRIM,@BFIYAT,@PARTINO,1)", false);
                //    _sqlProvider.AddParameter("HAREKETID", hareketID);
                //    _sqlProvider.AddParameter("STOKID", rowFatIsl["STOKID"]);
                //    _sqlProvider.AddParameter("MIKTAR", rowFatIsl["FADET"]);
                //    _sqlProvider.AddParameter("BIRIM", rowFatIsl["FBIRIM"]);
                //    _sqlProvider.AddParameter("BFIYAT", rowFatIsl["FBFIYAT"]);
                //    _sqlProvider.AddParameter("PARTINO", pNo);
                //    _sqlProvider.ExecuteNonQuery();
                //}
                #endregion
                var fatid = Convert.ToInt32(rowFatura["FATID"]);
                var fattarih = Convert.ToDateTime(rowFatura["TARIH"]);
                dbOperation.ALISFaturaSatirlarinaPartiNoUret(fatid, fattarih);

                toolStripStatusLabel1.Text = string.Format("Fat No {0}", rowFatura["FATNO"]);
                progressBar1.Value++;
            }

            _dtFatList = dbOperation.PartiNoUretilecekALISFaturalariListesi(dateTimePicker1.Value.Date, dateTimePicker2.Value.Date, AlimDepoID.ToString());
            dataGridView1.DataSource = _dtFatList;
            toolStripStatusLabel1.Text = _dtFatList.Rows.Count.ToString();
            progressBar1.Value = 0;
        }
        #endregion


        #region Parcalama Islemleri
        
        //private void ParcalamaListesi(DateTime tar1, DateTime tar2, string DepoID)
        //{
        //    _sqlProvider = new SqlProvider(
        //        " SELECT DISTINCT CASE WHEN IRSALIYE=0 THEN 'FATURA' WHEN IRSALIYE=1 THEN 'IRSALIYE' END TURU,  F.FATID,FATNO,F.TARIH,F.UNVANI,FI.STOKID,S.ADI,FI.FADET,FI.FBIRIM,FI.FBFIYAT,F.SAAT,FI.BARKOD,S.STDFIREORANI,REPLACE(S.KODU,'S','') KODU "+
        //        " FROM FATURA F "+
        //        "    INNER      JOIN FATISL   FI ON FI.FATID=F.FATID "+
        //        "    LEFT OUTER JOIN PARCALAMA P ON P.STOKID=FI.STOKID AND P.TARIH=F.TARIH AND P.ACIKLAMA=FI.BARKOD "+
        //        "    INNER      JOIN STOK S      ON S.STOKID=FI.STOKID "+
        //        " WHERE FISDURUMID>=-1 AND FI.IRSISLID IS NULL AND FISTURID=51 AND F.DEPOID=@DEPOID AND P.ACIKLAMA IS NULL AND FI.STOKID IN (" + ParcalanacakSTOKIDS+") AND F.TARIH BETWEEN @TAR1 AND @TAR2", false);

        //    _sqlProvider.AddParameter("TAR1", tar1);
        //    _sqlProvider.AddParameter("TAR2", tar2);
        //    _sqlProvider.AddParameter("DEPOID", DepoID);
        //    _dtParcalamaList = new DataTable();
        //    _dtParcalamaList.Load(_sqlProvider.ExecuteReader());
        //    dataGridView2.DataSource = _dtParcalamaList;
        //}

        private void btnParcala_Click(object sender, EventArgs e)
        {
            progressBar1.Maximum = _dtParcalamaList.Rows.Count;
            progressBar1.Value = 0;
            foreach (DataRow row in _dtParcalamaList.Rows)
            {
                toolStripStatusLabel1.Text = row["STOKID"].ToString();
                #region Parçalama //ÖNCE Parcalama MASTER kayıt oluşturalım ANA GIREN ETIN PARCALAMA KAYDI

                // once recetesi var mı kontrol edelim yoksa HİÇ BAŞLAMAYALIM TABİ... 

                DataTable dtReceteDetayi = dbOperation.UrunKodunaGoreReceteDetayiGetir(row["STOKKODU"].ToString().Replace("S", ""));


                if (dtReceteDetayi.Rows.Count > 0)
                {

                    Parcalama parcalama = new Parcalama
                    {
                        Depoid = ParcalamaTuketimDepoId,
                        Durum = "ONAYLANDI",
                        Tarih = Convert.ToDateTime(row["TARIH"]),
                        Saat = Convert.ToDateTime(DateTime.Now.ToShortDateString()), //Convert.ToDateTime(row["SAAT"]),
                        Aciklama = row["BARKOD"].ToString(),
                        Stokid = Convert.ToInt32(row["STOKID"]),
                        Miktar = Convert.ToDouble(row["MIKTAR"]), //FADET
                        BFiyat = Convert.ToDouble(row["FIYAT"]),  //FBFIYAT
                        OnayTarih = Convert.ToDateTime(row["TARIH"]),
                        OnaySaat = Convert.ToDateTime(DateTime.Now.ToShortDateString()) //Convert.ToDateTime(row["SAAT"])
                    };
                    dbOperation.ParcalamaInsert(parcalama);
                    #endregion

                    #region Transfer Fişi //Parçalanan ET kalemi için önce ÜRETİM deposuna ANADEPO dan TRANSFER FİŞİ ni keselim 
                    Depofis depofisTransfer = new Depofis
                    {
                        Tarih = Convert.ToDateTime(row["TARIH"]).Date,
                        Islem = "TRANSFER",
                        Aciklama = "PARÇALAMA("+parcalama.Parcalamaid.ToString()+")",

                        CDepoid = ParcalamaTransferDepoId,
                        GDepoid = ParcalamaTuketimDepoId,

                        Eno = parcalama.Parcalamaid.ToString(CultureInfo.InvariantCulture)
                    };
                    //depofis.InsertToDatabase();
                    dbOperation.DepofisInsert(depofisTransfer);

                    DepofisIsl depofisIslTransfer = new DepofisIsl
                    {
                        Depofisid = depofisTransfer.Depofisid,
                        Stokid = Convert.ToInt32(row["STOKID"]),
                        Miktar = Convert.ToDouble(row["MIKTAR"]),
                        FBirim = row["BIRIM"].ToString(),
                        BFiyat = Convert.ToDouble(row["FIYAT"]),
                        Barkod = row["BARKOD"].ToString()
                    };
                    dbOperation.DepoFisIslInsert(depofisIslTransfer);

                    dbOperation.DepofisUpdate(depofisTransfer.Depofisid);

                    dbOperation.ParcalamayaTransferIDYaz(parcalama.Parcalamaid, depofisTransfer.Depofisid);

                    #endregion

                    #region Tüketim Fişi //Parçalanan ET kalemi için TÜKETİM FİŞİ ni keselim 
                    Depofis depofisTuketim = new Depofis
                    {
                        Tarih = Convert.ToDateTime(row["TARIH"]).Date,
                        Islem = "TÜKETİM",
                        Aciklama = "PARÇALAMA",

                        CDepoid = ParcalamaTuketimDepoId,
                        Eno = parcalama.Parcalamaid.ToString(CultureInfo.InvariantCulture)
                    };
                    //depofis.InsertToDatabase();
                    dbOperation.DepofisInsert(depofisTuketim);

                    DepofisIsl depofisIsltuketim = new DepofisIsl
                    {
                        Depofisid = depofisTuketim.Depofisid,
                        Stokid = Convert.ToInt32(row["STOKID"]),
                        Miktar = Convert.ToDouble(row["MIKTAR"]),
                        FBirim = row["BIRIM"].ToString(),
                        BFiyat = Convert.ToDouble(row["FIYAT"]),
                        Barkod = row["BARKOD"].ToString()
                    };
                    dbOperation.DepoFisIslInsert(depofisIsltuketim);
                    dbOperation.DepofisUpdate(depofisTuketim.Depofisid);

                    dbOperation.ParcalamayaTuketimIDYaz(parcalama.Parcalamaid, depofisTuketim.Depofisid);

                    #endregion

                    #region ÜretimFişi  //Parcalanan ET e ait olan parçalama reçetesindekileri ÜRETİM yapalım.
                    Depofis depofisUretim = new Depofis
                    {
                        Tarih = Convert.ToDateTime(row["TARIH"]).Date,
                        Islem = "ÜRETİM",
                        Aciklama = "PARÇALAMA",

                        GDepoid = ParcalamaUretimDepoId,
                        Eno = parcalama.Parcalamaid.ToString(CultureInfo.InvariantCulture)
                    };
                    dbOperation.DepofisInsert(depofisUretim);
                    dbOperation.ParcalamayaUretimIDYaz(parcalama.Parcalamaid, depofisUretim.Depofisid);


                    //Parcalama recetesindeki satirlar kadar hem PARCALAMAISL hem de TUKETIMFISISL kayıtlarını oluşturalım
                    // Burada hem recetedeki ORAN a göre miktar her çıkan ürün için GIREN ETin miktarından hesaplanıyor
                    // hem de KATSAYI sına FIRE olmasına göre birim fiyat tekrar hesaplanıyor  YA DA SIFIRlanıyor.
                    //_sqlProvider = new SqlProvider("SELECT * FROM QMUH_RECETE WHERE URUNKODU=@URUNKODU", false);
                    //_sqlProvider.AddParameter("URUNKODU", row["STOKKODU"].ToString().Replace("S",""));


                    foreach (DataRow rowReceteSatir in dtReceteDetayi.Rows)
                    {
                        double parcalanacakMiktar = Convert.ToDouble(row["MIKTAR"]);
                        double fBfiyat = Convert.ToDouble(row["FIYAT"]);
                        double katsayi = Convert.ToDouble(rowReceteSatir["RECETEKATSAYISI"]);
                        double oran = Convert.ToDouble(rowReceteSatir["ORAN"]);
                        double miktar = parcalanacakMiktar * oran;
                        double bFiyat = 0;
                        if (katsayi == 1)
                        {
                            bFiyat = (parcalanacakMiktar * fBfiyat) / (miktar * katsayi);
                        }


                        ParcalamaIsl parcalamaIsl = new ParcalamaIsl
                        {
                            ParcalamaIslId = SiraNo.SiraNoVer("PARCALAMAISL"),
                            ParcalamaId = parcalama.Parcalamaid,
                            StokId = Convert.ToInt32(rowReceteSatir["STOKID"]),
                            Miktar = miktar,
                            BFiyat = bFiyat,
                            Katsayi = katsayi,
                            FireStokSatiri = Convert.ToInt32(rowReceteSatir["FIRE"])
                        };
                        dbOperation.ParcalamaIslInsert(parcalamaIsl);

                        DepofisIsl depofisIsluretim = new DepofisIsl
                        {
                            Depofisid = depofisUretim.Depofisid,
                            Stokid = Convert.ToInt32(rowReceteSatir["STOKID"]),
                            Miktar = miktar,
                            FBirim = rowReceteSatir["XBIRIM"].ToString(),
                            BFiyat = bFiyat,
                            Barkod = (Convert.ToInt32(rowReceteSatir["FIRE"]) == 0) ? PartiNo.PartiNoUret(Convert.ToDateTime(row["TARIH"]).Date, "PARCALAMAPARTINO") : ""
                        };

                        dbOperation.DepoFisIslInsert(depofisIsluretim);
                        dbOperation.DepofisUpdate(depofisUretim.Depofisid);
                    };
                    #endregion

                    dbOperation.ParcalamaUpdate(parcalama.Parcalamaid);
                }
                else
                    MessageBox.Show(row["STOKKODU"].ToString().Replace("S", "") + " kodu ile Ürün Kartları listesinde alınan stoğa ait PARÇALAMA reçetesi yapılmamış. Önce reçeteyi yapınız!");
                progressBar1.Value++;
            }

            //ParcalamaListesi(dateTimePicker1.Value.Date, dateTimePicker2.Value.Date, AlimDepoID.ToString());
            _dtParcalamaList = dbOperation.ParcalanacakHammaddeListesi(dateTimePicker1.Value.Date, dateTimePicker2.Value.Date, AlimDepoID.ToString());
            dataGridView2.DataSource = _dtParcalamaList;

        }


        #endregion

        private void tSBtnKapat_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

//private void frmParcalama_Load(object sender, EventArgs e)
//{
//    switch (tabControl1.SelectedIndex)
//    {
//        case 0:
//            FaturaListesi(dateTimePicker1.Value.Date, dateTimePicker2.Value.Date);
//            break;
//        case 1:
//            ParcalamaListesi(dateTimePicker1.Value.Date, dateTimePicker2.Value.Date);
//            break;
//    }
//}


//private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
//{
//    switch (tabControl1.SelectedIndex)
//    {
//        case 0:
//            FaturaListesi(dateTimePicker1.Value.Date, dateTimePicker2.Value.Date);
//            break;
//        case 1:
//            ParcalamaListesi(dateTimePicker1.Value.Date, dateTimePicker2.Value.Date);
//            break;
//    }
//}
