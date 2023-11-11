using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stock
{
    internal class DBManager
    {
        public SqlConnection OpenDbConnection()
        {
            string connectionString = @"Data Source =(localdb)\MSSQLLocalDB;
                                        Initial Catalog = Stock;
                                        Integrated Security = SSPI;";
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            return connection;
        }
    }
}
