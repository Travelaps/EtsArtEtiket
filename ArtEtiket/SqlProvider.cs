using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;

namespace ArtEtiket
{
    public class SqlProvider
    {
        private readonly SqlCommand _command;
        private readonly SqlConnection _connection;
        private string Server { get; set; }
        private string LoginName { get; set; }
        private string Password { get; set; }
        private string Database { get; set; }

        public SqlProvider(string commandText, bool isProcedure = false)
        {
            _connection = new SqlConnection(Properties.Settings.Default.SqlConStr);
            _command = new SqlCommand(commandText, _connection);
            _command.CommandType = isProcedure ? CommandType.StoredProcedure : CommandType.Text;
        }

        public void AddParameter(string parameterName, object value)
        {
            _command.Parameters.AddWithValue("@" + parameterName, value);
        }

        public void OpenConnection()
        {
            if (_connection.State == ConnectionState.Closed)
            {
                _connection.Open();
            }
        }

        public void CloseConnection()
        {
            if (_connection.State == ConnectionState.Open)
            {
                _connection.Close();
            }
        }
        public bool ExecuteNonQuery()
        {
            try
            {
                OpenConnection();
                _command.ExecuteNonQuery();
                Result.UserMessage = _connection.Database + " - " + _command.CommandText + " - Command(s) completed successfully.";
                return true;

            }
            catch (SqlException exception)
            {
                Result.UserMessage = _connection.Database + " - " + exception.Message;
                return false;
            }
            catch (Exception exception)
            {
                Result.UserMessage = _connection.Database + " - " + exception.Message;
                return false;
            }
            finally
            {
                CloseConnection();
            }
        }

        public object ExecuteScalar()
        {
            object result = null;
            try
            {
                OpenConnection();
                result = _command.ExecuteScalar();
            }
            catch (SqlException)
            {
                result = null;
            }
            catch (Exception)
            {
                result = null;
            }
            finally
            {
                CloseConnection();
            }
            return result;
        }

        public SqlDataReader ExecuteReader()
        {
            OpenConnection();
            return _command.ExecuteReader(CommandBehavior.CloseConnection);
        }


    }

    static class Result
    {
        public static int Sonuc { get; set; }
        public static bool IsSucceeded { get; set; }
        public static string UserMessage { get; set; }
    }

}
