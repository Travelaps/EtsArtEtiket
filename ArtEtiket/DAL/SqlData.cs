using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using ArtEtiket.DAL;

namespace ArtEtiket.DAL
{
    public class SqlData
    {
        private static SqlProvider _sqlProvider;

        public static List<MODEL.AdetSecimleri> Uretim_AdetSecimAlternatifleri(int stokid, string alanadi="ADET")
        {
            /*_sqlProvider = new SqlProvider(
            " SELECT ARTETIKETDETAY.*, STOK.BIRIM " +
            " FROM ARTETIKETDETAY INNER JOIN STOK ON ARTETIKETDETAY.STOKID = STOK.STOKID " +
            " WHERE ARTETIKETDETAY.STOKID = @STOKID "
             );
            _sqlProvider.AddParameter("STOKID", stokid);*/

           

            var dt = new DataTable();
            dt.Load(_sqlProvider.ExecuteReader());

            List<MODEL.AdetSecimleri> list = new List<MODEL.AdetSecimleri>();

            if (dt.Rows.Count > 0)
            {
                for (int i = 1; i < 10; i++)
                {
                    if (dt.Rows[0][alanadi + i.ToString()].ToString() != "")
                        if (dt.Rows[0][alanadi + i.ToString()].ToString() != "0")
                        {
                            MODEL.AdetSecimleri a = new MODEL.AdetSecimleri();
                            a.Aciklama = (((dt.Rows[0]["BIRIM"].ToString().ToUpper() == "LT") && (alanadi == "ADET")) ? "Kap" : "Tepsi")  + " No "  + i.ToString();
                            a.Adet = Convert.ToInt32(dt.Rows[0][alanadi + i.ToString()].ToString());
                            a.Tur = ( (dt.Rows[0]["BIRIM"].ToString().ToUpper() == "LT") && (alanadi == "ADET")) ? "LT" : alanadi;
                            list.Add(a);
                        }
                }
            }

            return list;
        }
    }
}
