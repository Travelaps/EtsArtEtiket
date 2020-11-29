using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ArtEtiket
{
    public class DepofisIsl
    {
        public DepofisIsl()
        {
            FMiktar = Miktar;
            FbFiyat = BFiyat;
        }

        public int Depofisid { get; set; }
        public int Stokid { get; set; }
        public double Miktar { get; set; }
        public string FBirim { get; set; }
        public double FMiktar { get; set; }
        public double BFiyat { get; set; }
        public double FbFiyat { get; set; }
        public string Barkod { get; set; }

    }
}
