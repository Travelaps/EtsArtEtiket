using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ArtEtiket.MODEL
{
    public class UretimTalepIsl
    {
        private SqlProvider _sqlProvider;

        public UretimTalepIsl()
        {
            Aciklama = "TERAZI";
            DepoMiktar = 0;
            MinMiktar = 0;
            TavMiktar = 0;
            PrcMiktar = 0;
            KulMiktar = 0;
        }
        public int UretimTalepid { get; set; }
        public int Stokid { get; set; }
        public string Birim { get; set; }
        public double Miktar { get; set; }
        public double DepoMiktar { get; set; }
        public double MinMiktar { get; set; }
        public double TavMiktar { get; set; }
        public double PrcMiktar { get; set; }
        public double KulMiktar { get; set; }
        public string Aciklama { get; set; }
        public string Barkod { get; set; }

        public string Insert()
        {
            try
            {
                _sqlProvider = new SqlProvider("INSERT INTO URETIMTALEPISL (URETIMTALEPID,STOKID,BIRIM,MIKTAR,DEPOMIKTAR,MINMIKTAR,TAVMIKTAR,PRCMIKTAR,KULMIKTAR,ACIKLAMA,BARKOD)  VALUES (@URETIMTALEPID,@STOKID,@BIRIM,@MIKTAR,@DEPOMIKTAR,@MINMIKTAR,@TAVMIKTAR,@PRCMIKTAR,@KULMIKTAR,@ACIKLAMA,@BARKOD) ", false);
                _sqlProvider.AddParameter("URETIMTALEPID", UretimTalepid);
                _sqlProvider.AddParameter("STOKID", Stokid);
                _sqlProvider.AddParameter("BIRIM", Birim);
                _sqlProvider.AddParameter("MIKTAR", Miktar);
                _sqlProvider.AddParameter("DEPOMIKTAR", DepoMiktar);
                _sqlProvider.AddParameter("MINMIKTAR", MinMiktar);
                _sqlProvider.AddParameter("TAVMIKTAR", TavMiktar);
                _sqlProvider.AddParameter("PRCMIKTAR", PrcMiktar);
                _sqlProvider.AddParameter("KULMIKTAR", KulMiktar);
                _sqlProvider.AddParameter("ACIKLAMA", Aciklama);
                _sqlProvider.AddParameter("BARKOD", Barkod);
                _sqlProvider.ExecuteNonQuery();
                return "OK";
            }
            catch (Exception e)
            {
                return e.InnerException.Message;
            }           
        }
    }
}
