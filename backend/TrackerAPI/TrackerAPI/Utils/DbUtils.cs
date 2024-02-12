using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace TrackerAPI.Utils
{
    public class DbUtils
    {
        private static readonly string connectionString = "Data Source=KAVYANITHI\\SQLEXPRESS;Initial Catalog=master;Integrated Security=True";

        public static SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}
