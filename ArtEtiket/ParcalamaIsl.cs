using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ArtEtiket
{
    public class ParcalamaIsl
    {
        public ParcalamaIsl()
        {
            PMiktar = 0;
        }
        public int ParcalamaIslId { get; set; }
        public int ParcalamaId { get; set; }
        public int StokId { get; set; }
        public double Miktar { get; set; }
        public double PMiktar { get; set; }
        public double BFiyat { get; set; }
        public double Katsayi { get; set; }
        public int FireStokSatiri { get; set; }
    }
}
