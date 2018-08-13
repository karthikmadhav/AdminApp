using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Admin.App.DataAccessLayer.Interface
{
    public interface IConnectionFactory
    {
        IDbConnection GetConnection();
        SqlConnection GetDBConnection();
    }
}
