using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace TrackerAPI.Models
{
    public  class DocumentsDao
    {
    
     public static string connectionString = ConfigurationManager.ConnectionStrings["conString"].ConnectionString;

        public static SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
    }

}












