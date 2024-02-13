using TrackerAPI.Models;
using TrackerAPI.Models.mapper;
using TrackerAPI.Utils;
using System;
using System.Data.SqlClient;

namespace TrackerAPI.DataAccessLayer
{
    public class AuthDAO
    {
        public User GetUserByUsername(string username)
        {
            using (var connection = DbUtils.GetConnection())
            {
                User user = null;
                string query = "SELECT * FROM Login WHERE username = @UserName";

                try
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Use SqlParameter to avoid SQL injection
                        command.Parameters.AddWithValue("@UserName", username);

                        SqlDataReader reader = command.ExecuteReader();

                        while (reader.Read())
                        {
                            user = UserMapper.MapToUser(reader);
                        }

                        reader.Close();

                    }
                }
                catch (Exception ex)
                {
                    // Handle exceptions, e.g., log or rethrow
                    throw ex;
                }

                return user;
            }
        }
    }
}
