using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ArtEtiket.MODEL
{
    public class UretimTalep
    {
        private SqlProvider _sqlProvider;

        public UretimTalep()
        {
            

            Yetkili = "Arteus";
            Aciklama = "TERAZI";
            Durum = "NEW";
        }
        public int UretimTalepid { get; set; }
        public string Durum { get; set; }
        public DateTime Tarih { get; set; }
        public DateTime TeslimTarihi { get; set; }
        public int Depoid { get; set; }
        public string Yetkili { get; set; }
        public string Aciklama { get; set; }

        public int Insert()
        {
            UretimTalepid = SiraNo.SiraNoVer("URETIMTALEP");

            _sqlProvider = new SqlProvider("INSERT INTO URETIMTALEP (URETIMTALEPID,DURUM,TARIH,TESLIMTARIHI,DEPOID,YETKILI,ACIKLAMA)  VALUES (@URETIMTALEPID,@DURUM,@TARIH,@TESLIMTARIHI,@DEPOID,@YETKILI,@ACIKLAMA) ", false);
            _sqlProvider.AddParameter("URETIMTALEPID", UretimTalepid);
            _sqlProvider.AddParameter("DURUM", Durum);
            _sqlProvider.AddParameter("TARIH", Tarih);
            _sqlProvider.AddParameter("TESLIMTARIHI", TeslimTarihi);
            _sqlProvider.AddParameter("DEPOID", Depoid);
            _sqlProvider.AddParameter("YETKILI", Yetkili);
            _sqlProvider.AddParameter("ACIKLAMA", Aciklama);
            _sqlProvider.ExecuteNonQuery();
            return UretimTalepid;
        }
        public int Exist()
        {
            try
            {
                _sqlProvider = new SqlProvider("SELECT URETIMTALEPID FROM URETIMTALEP WHERE TARIH = @TARIH AND DEPOID = @DEPOID ", false);
                _sqlProvider.AddParameter("TARIH", Tarih);
                _sqlProvider.AddParameter("DEPOID", Depoid);
                int n = Convert.ToInt32(_sqlProvider.ExecuteScalar());

                if (n != 0)
                    UretimTalepid = n;

                return n;
            }
            catch (Exception)
            {
                return 0;
            }
            
        }
    }
}
