using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ArtEtiket
{
    public static class PartiNo
    {
        private static SqlProvider _sqlProvider;
        public static string PartiNoUret(DateTime tarih, string tableName)
        {
            string partiNo = "";
            _sqlProvider = new SqlProvider("SELECT MAX(SIRANO) FROM PARTI_NO WHERE TABLENAME=@TABLENAME AND TARIH=@TARIH", false);
            _sqlProvider.AddParameter("TARIH", tarih);
            _sqlProvider.AddParameter("TABLENAME", tableName);
            string pNo = _sqlProvider.ExecuteScalar().ToString();
            if (pNo == "")
            {
                switch (tableName)
                {
                    case "HAMMADDEPARTINO":
                        partiNo = string.Format("{0:ddMMyy}{1}", tarih, "1001");
                        break;
                    case "PARCALAMAPARTINO":
                        partiNo = string.Format("{0:ddMMyy}{1}", tarih, "2001");
                        break;
                    case "PROCESSPARTINO":
                        partiNo = string.Format("{0:ddMMyy}{1}", tarih, "3001");
                        break;
                }

                PartiNoInsert(partiNo, tarih, tableName);

            }
            else
            {
                int parti = Convert.ToInt32(pNo.Substring(6, 4)) + 1;
                partiNo = string.Format("{0:ddMMyy}{1}", tarih, parti);
                PartiNoInsert(partiNo, tarih, tableName);
            }
            return partiNo;
        }

        private static void PartiNoInsert(string pNo, DateTime tarih, string tableName)
        {
            _sqlProvider = new SqlProvider("INSERT INTO PARTI_NO (TARIH,TABLENAME,SIRANO) VALUES (@TARIH,@TABLENAME,@PARTINO)", false);
            _sqlProvider.AddParameter("TARIH", tarih.Date);
            _sqlProvider.AddParameter("PARTINO", pNo);
            _sqlProvider.AddParameter("TABLENAME", tableName);
            _sqlProvider.ExecuteNonQuery();
        }
    }
}
