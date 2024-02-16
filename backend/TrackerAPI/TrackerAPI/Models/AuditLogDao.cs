using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace TrackerAPI.Models
{
    public class AuditLogDao
    {
        private readonly string connectionString = Table.connect;

        public void LogAudit(AuditLog auditLog)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "INSERT INTO audit ([Date and Time], UserName, Module, Action) VALUES (@DateAndTime, @UserName, @Module, @Action)";

                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@DateAndTime", auditLog.Date_And_Time);
                        cmd.Parameters.AddWithValue("@UserName", auditLog.UserName);
                        cmd.Parameters.AddWithValue("@Module", auditLog.Module);
                        cmd.Parameters.AddWithValue("@Action", auditLog.Action);

                        connection.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error logging audit information: {ex.Message}");
                throw; // Rethrow the exception to propagate it to the caller
            }
        }

        public List<AuditLog> GetAllAuditLogs()
        {
            return GetAuditLogs(null);
        }

        public List<AuditLog> GetAuditLogsForToday()
        {
            DateTime today = DateTime.Today;
            return GetAuditLogs(today);
        }

        public List<AuditLog> GetAuditLogsForYesterday()
        {
            DateTime yesterday = DateTime.Today.AddDays(-1);
            return GetAuditLogs(yesterday);
        }

        public List<AuditLog> GetAuditLogsForCustomDate(DateTime customDate)
        {
            return GetAuditLogs(customDate);
        }

        private List<AuditLog> GetAuditLogs(DateTime? date)
        {
            List<AuditLog> auditLogs = new List<AuditLog>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "SELECT * FROM audit";

                    if (date.HasValue)
                    {
                        query += " WHERE CONVERT(date, [Date and Time]) = @Date";
                    }

                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        if (date.HasValue)
                        {
                            cmd.Parameters.AddWithValue("@Date", date.Value);
                        }

                        connection.Open();

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                DateTime logDateTime = reader.GetDateTime(0);
                                string userName = reader.GetString(1);
                                string module = reader.GetString(2);
                                string action = reader.GetString(3);

                                auditLogs.Add(new AuditLog
                                {
                                    Date_And_Time = logDateTime,
                                    UserName = userName,
                                    Module = module,
                                    Action = action
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
                throw;
            }

            return auditLogs;
        }
    }
}
