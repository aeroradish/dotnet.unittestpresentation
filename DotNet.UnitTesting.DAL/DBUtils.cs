using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet.UnitTesting.DAL
{
    public class DBUtils
    {
        public static SqlConnection GetConnection()
        {
            return new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["FlorenceConnectionString"].ConnectionString);
        }

    }
}
