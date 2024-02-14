using TrackerAPI.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;


namespace TrackerAPI.Models.mapper
{
    public class UserMapper
    {
        public static UserData MapToUser(SqlDataReader reader)
        {
            UserData user = new UserData();
            user.UserID = reader.GetInt32(reader.GetOrdinal("userid"));
            user.UserName = reader["username"] as string;
            user.Password = reader["password"] as string;
            user.Role = reader["role"] as string;
           

            return user;
        }
    }
}
