using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace TrackerAPI.Dao
{
    public class Dao1
    {
        private readonly SqlConnection connection;

        public Dao1()
        {
            connection = Database.Connection;
        }

        public IEnumerable<Data> Show()
        {
            List<Data> records = new List<Data>();
            string query = "select * from Notification";

            using (SqlCommand sql = new SqlCommand(query, connection))
            {
                try
                {
                    connection.Open();

                    using (SqlDataReader reader = sql.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Data record = new Data
                            {
                                NId = int.Parse(reader["NId"].ToString()),
                                Username = reader["Username"].ToString(),
                                Time = DateTime.Parse(reader["Time"].ToString()),
                                Message = reader["Message"].ToString(),
                                Priority = reader["Priority"].ToString(),
                                isRead = reader.GetBoolean(reader.GetOrdinal("isRead"))
                            };

                            records.Add(record);
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Log the exception or rethrow if necessary
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }

            return records;
        }

        public void Insert(Data data)
        {
            String query = "INSERT INTO Notification (Username, Time, Message, Priority) VALUES(@Username, @Time, @Message,@Priority)";

            try
            {
                using (SqlCommand sql = new SqlCommand(query, connection))
                {
                    sql.Parameters.AddWithValue("@Username", data.Username);
                    sql.Parameters.AddWithValue("@Time", data.Time);
                    sql.Parameters.AddWithValue("@Message", data.Message);
                    sql.Parameters.AddWithValue("@Priority", data.Priority);


                    connection.Open();
                    sql.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                // Log the exception or rethrow if necessary
                Console.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        public void update(Data data)
        {
            String query = "UPDATE Notification SET isRead= @isRead WHERE NId= @NId";

            try
            {
                using (SqlCommand sql = new SqlCommand(query, connection))
                {
                    sql.Parameters.AddWithValue("@isRead", data.isRead);
                    sql.Parameters.AddWithValue("@NId", data.NId);



                    connection.Open();
                    sql.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                // Log the exception or rethrow if necessary
                Console.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close();
            }

        }

        public IEnumerable<Data> getId(int Id)
        {
            List<Data> records = new List<Data>();
            string query = "select * from Notification WHERE userid=@userid";

            using (SqlCommand sql = new SqlCommand(query, connection))
            {
                try
                {
                    connection.Open();

                    sql.Parameters.AddWithValue("@userid", Id);

                    using (SqlDataReader reader = sql.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Data record = new Data
                            {
                                NId = int.Parse(reader["NId"].ToString()),
                                Username = reader["Username"].ToString(),
                                Time = DateTime.Parse(reader["Time"].ToString()),
                                Message = reader["Message"].ToString(),
                                Priority = reader["Priority"].ToString(),
                                isRead = reader.GetBoolean(reader.GetOrdinal("isRead"))
                            };

                            records.Add(record);
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Log the exception or rethrow if necessary
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }

            return records;

        }
    }
}