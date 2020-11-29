using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Xml;

namespace ArtEtiket
{
    public class SqlConControl
    {
        private SqlConnection _sqlConnection;
        //public string Server { get; set; }
        //public string LoginName { get; set; }
        //public string Password { get; set; }
        //public string Database { get; set; }

        public bool ConnectionControl(string connstr = null)
        {
            try
            {
                _sqlConnection = new SqlConnection((connstr==null) ? Properties.Settings.Default.SqlConStr : connstr);
                try
                {
                    _sqlConnection.Open();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
