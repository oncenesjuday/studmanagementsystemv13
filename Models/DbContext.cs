using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;

namespace studmanagementsystemv13.Models
{
    public class DbContext
    {
        public readonly MySqlConnection _connection;

        public DbContext(string connection)
        {
            _connection = new MySqlConnection(connection);
        }

        public bool TestConnection()
        {
            try
            {
                _connection.Open();
                _connection.Clone();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
