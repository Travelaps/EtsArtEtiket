using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ArtEtiket
{
    public class Depofis
    {
        private SqlProvider _sqlProvider;

        public Depofis()
        {
            Depofisid = SiraNo.SiraNoVer("DEPOFIS");

            //_sqlProvider = new SqlProvider("SELECT VALUESTR FROM CONFIG WHERE KEYNAME='Yarı Mamul Uretim Depo ID'", false);
            //GDepoid = Convert.ToInt32(_sqlProvider.ExecuteScalar());

            //_sqlProvider = new SqlProvider("SELECT VALUESTR FROM CONFIG WHERE KEYNAME='Hammadde Tuketim Depo ID'", false);
            //CDepoid = Convert.ToInt32(_sqlProvider.ExecuteScalar());


            Yetkili = "Arteus";
            //Aciklama = "PARÇALAMA";
            Tadet = 0;
            Ttutar = 0;
            Durum = 0;
            Durumu = 0;
            Subeid = 1;
        }
        public int Depofisid { get; set; }
        public DateTime Tarih { get; set; }
        public string Islem { get; set; }
        public string Yetkili { get; set; }
        public string Eno { get; set; }
        public string Aciklama { get; set; }
        public int GDepoid { get; set; }
        public int CDepoid { get; set; }
        public double Tadet { get; set; }
        public double Ttutar { get; set; }
        public int Durumu { get; set; }
        public int Durum { get; set; }
        public int Subeid { get; set; }

        public int InsertToDatabase()
        {
            _sqlProvider = new SqlProvider("INSERT INTO DEPOFIS (DEPOFISID,TARIH,ISLEM,YETKILI,ENO,ACIKLAMA,GDEPOID,CDEPOID,TADET,TTUTAR,DURUMU,DURUM,SUBEID)  VALUES (@DEPOFISID,@TARIH,@ISLEM,@YETKILI,@ENO,@ACIKLAMA,@GDEPOID,@CDEPOID,@TADET,@TTUTAR,@DURUMU,@DURUM,@SUBEID) ", false);
            _sqlProvider.AddParameter("DEPOFISID", Depofisid);
            _sqlProvider.AddParameter("TARIH", Tarih);
            _sqlProvider.AddParameter("ISLEM", Islem);
            _sqlProvider.AddParameter("YETKILI", Yetkili);
            _sqlProvider.AddParameter("ENO", Eno);
            _sqlProvider.AddParameter("ACIKLAMA", Aciklama);
            if (Islem == "TÜKETİM")
            {
                _sqlProvider.AddParameter("CDEPOID", CDepoid);
                _sqlProvider.AddParameter("GDEPOID", DBNull.Value);
            }
            else if (Islem == "ÜRETİM")
            {
                _sqlProvider.AddParameter("CDEPOID", DBNull.Value);
                _sqlProvider.AddParameter("GDEPOID", GDepoid);
            }
            _sqlProvider.AddParameter("TADET", Tadet);
            _sqlProvider.AddParameter("TTUTAR", Ttutar);
            _sqlProvider.AddParameter("DURUMU", Durumu);
            _sqlProvider.AddParameter("DURUM", Durum);
            _sqlProvider.AddParameter("SUBEID", Subeid);
            _sqlProvider.ExecuteNonQuery();
            return Depofisid;
        }
    }
}
