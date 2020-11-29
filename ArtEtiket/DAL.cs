using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace ArtEtiket
{
    public class DAL
    {
        public static DataTable SubeListesi()
        {
            var _sqlProvider = new SqlProvider("SELECT DISTINCT SUBEKODU FROM (SELECT TOP 2000 SUBEKODU FROM VFR_KASA_ANALIZ ORDER BY TARIH DESC) TBL UNION ALL SELECT ' ' ORDER BY SUBEKODU", false);
            var dt = new DataTable();
            dt.Load(_sqlProvider.ExecuteReader());
            return dt;
        }

        public static bool TekrarEtiketYazdirilacakKaydiBul(string partino, ref int stokid, ref double miktar)
        {
            var _sqlProvider = new SqlProvider("SELECT TOP 1 * FROM PARTI_NO_TERAZI WHERE PARTINO = @PARTINO " , false);
            _sqlProvider.AddParameter("PARTINO", partino);
            var dt = new DataTable();
            dt.Load(_sqlProvider.ExecuteReader());
            if (dt.Rows.Count == 1)
            {
                stokid = Convert.ToInt32(dt.Rows[0]["STOKID"].ToString());
                miktar = Convert.ToDouble(dt.Rows[0]["MIKTAR"].ToString());
            }
            return (dt.Rows.Count == 1);
        }
    }
}
