using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ArtEtiket
{
    public class Parcalama
    {
        private SqlProvider _sqlProvider;
        public Parcalama()
        {
            Parcalamaid = SiraNo.SiraNoVer("PARCALAMA");
            //_sqlProvider = new SqlProvider("SELECT VALUESTR FROM CONFIG WHERE KEYNAME='Hammadde Tuketim Depo ID'", false);
            //Depoid = Convert.ToInt32(_sqlProvider.ExecuteScalar());
            Depoid = 0;
            Yetkili = "Arteus";
            DepoMiktar = 0;
            MamulMiktar = 0;
            MamulToplam = 0;
            FireMiktar = 0;
            FireOran = 0;
        }
        public int Parcalamaid { get; set; }
        public string Durum { get; set; }
        public DateTime Tarih { get; set; }
        public DateTime Saat { get; set; }
        public DateTime OnayTarih { get; set; }
        public DateTime OnaySaat { get; set; }
        public string Aciklama { get; set; }
        public int Depoid { get; set; }
        public string Yetkili { get; set; }
        public int Stokid { get; set; }
        public double DepoMiktar { get; set; }
        public double Miktar { get; set; }
        public double BFiyat { get; set; }
        public double MamulMiktar { get; set; }
        public double MamulToplam { get; set; }
        public double FireMiktar { get; set; }
        public double FireOran { get; set; }

    }
}
