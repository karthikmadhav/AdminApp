using Admin.App.DataAccessLayer.Interface;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Admin.App.DataAccessLayer.Provider
{
    public class ConnectionFactory: IConnectionFactory
    {
        private readonly string connectionString = ConfigurationManager.ConnectionStrings["AppCon"].ConnectionString;
        public ConnectionFactory()
        {

        }
       public IDbConnection GetConnection()
        {
                var factory = DbProviderFactories.GetFactory("System.Data.SqlClient");
                var conn = factory.CreateConnection();
                conn.ConnectionString = connectionString;
                conn.Open();
                return conn;
        }
        public SqlConnection GetDBConnection()
        {
            SqlConnection con = new SqlConnection(connectionString);
            return con;
        }
    }
}
