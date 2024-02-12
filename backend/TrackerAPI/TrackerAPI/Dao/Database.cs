using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace TrackerAPI.Dao
{
    public class Database
    {
        private readonly static string connectionString = "Data Source=LAPTOP-MK5JCOPU\\SQLEXPRESS;Initial Catalog=Guha;Integrated Security=True";

        private static SqlConnection con = null;
        private Database()
        {

        }

        // Lock object for thread safety
        private static readonly object lockObject = new object();

        public static SqlConnection Connection
        {
            get
            {
                if (con == null)
                {
                    lock (lockObject)
                    {
                        con = new SqlConnection(connectionString);
                        con.Open();
                    }
                }
                return con;
            }
        }
    }
}