using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace ArtEtiket
{
    public static class SiraNo
    {
        private static SqlProvider _sqlProvider;
        public static int SiraNoVer(string tableName)
        {
            int siraNo = 0;
            var sqlProvider = new SqlProvider("SELECT SIRANO FROM SAYACLAR WHERE TABLENAME=@TABLENAME", false);
            sqlProvider.AddParameter("TABLENAME", tableName);
            var result = sqlProvider.ExecuteScalar();
            if (result == null)
            {
                SAYACLARInsert(tableName);
                siraNo = 1;
            }
            else
               siraNo = Convert.ToInt32(result);
            
            sqlProvider = new SqlProvider("UPDATE SAYACLAR SET SIRANO=@SIRANO WHERE TABLENAME=@TABLENAME", false);
            sqlProvider.AddParameter("TABLENAME", tableName);
            sqlProvider.AddParameter("SIRANO", siraNo + 1);
            sqlProvider.ExecuteNonQuery();
            return siraNo;
        }

        private static void SAYACLARInsert(string tableName)
        {
            _sqlProvider = new SqlProvider("INSERT INTO SAYACLAR (TABLENAME,SIRANO) VALUES (@TABLENAME,@SIRANO)", false);
            _sqlProvider.AddParameter("TABLENAME", tableName);
            _sqlProvider.AddParameter("SIRANO", 1);
            _sqlProvider.ExecuteNonQuery();
        }

        public static string DepofisEno()
        {
            SqlProvider sqlProvider = new SqlProvider("SELECT MAX(ENO)+1 FROM DEPOFIS WHERE SUBEID=01 AND LEN(ENO)=7 AND ENO<='9999999999999'", false);
            return sqlProvider.ExecuteScalar().ToString();
        }
    }

}
