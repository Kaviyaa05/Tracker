using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace TrackerAPI.Models
{
    public class Dao
    {
        public class TaskDao
        {

            /* private readonly string connectionString= Table.connect;

                public TaskDao(string connectionString)

                    {
                        this.connectionString = connectionString;
                    }
            */
            private string connectionString = Table.connect;
            public IEnumerable<Task> GetAllTasks()
            {
                List<Task> tasks = new List<Task>();



                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "SELECT * FROM Tasks";
                    SqlCommand command = new SqlCommand(query, connection);
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        tasks.Add(MapTask(reader));
                    }
                }

                return tasks;
            }

            public Task GetTaskById(int taskId)
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "SELECT * FROM Tasks WHERE TaskID = @TaskID";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@TaskID", taskId);
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        return MapTask(reader);
                    }
                }

                return null;
            }

            public void AddTask(Task task)
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "INSERT INTO Tasks (ProjectID, UserID, Name, Description, Priority, Type, StartDate, Owner, EndDate) VALUES (@ProjectID, @UserID, @Name, @Description, @Priority, @Type, @StartDate, @Owner, @EndDate)";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@ProjectID", task.ProjectID);
                    command.Parameters.AddWithValue("@UserID", task.UserID);
                    command.Parameters.AddWithValue("@Name", task.Name);
                    command.Parameters.AddWithValue("@Description", task.Description);
                    command.Parameters.AddWithValue("@Priority", task.Priority);
                    command.Parameters.AddWithValue("@Type", task.Type);
                    command.Parameters.AddWithValue("@StartDate", task.StartDate);
                    command.Parameters.AddWithValue("@Owner", task.Owner);
                    command.Parameters.AddWithValue("@EndDate", task.EndDate);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }

            public void UpdateTask(Task task)
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "UPDATE Tasks SET ProjectID = @ProjectID, UserID = @UserID, Name = @Name, Description = @Description, Priority = @Priority, Type = @Type, StartDate = @StartDate, Owner = @Owner, EndDate = @EndDate WHERE TaskID = @TaskID";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@ProjectID", task.ProjectID);
                    command.Parameters.AddWithValue("@UserID", task.UserID);
                    command.Parameters.AddWithValue("@Name", task.Name);
                    command.Parameters.AddWithValue("@Description", task.Description);
                    command.Parameters.AddWithValue("@Priority", task.Priority);
                    command.Parameters.AddWithValue("@Type", task.Type);
                    command.Parameters.AddWithValue("@StartDate", task.StartDate);
                    command.Parameters.AddWithValue("@Owner", task.Owner);
                    command.Parameters.AddWithValue("@EndDate", task.EndDate);
                    command.Parameters.AddWithValue("@TaskID", task.TaskID);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }

            public void DeleteTask(int taskId)
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "DELETE FROM Tasks WHERE TaskID = @TaskID";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@TaskID", taskId);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }

            private Task MapTask(SqlDataReader reader)
            {
                return new Task
                {
                    TaskID = Convert.ToInt32(reader["TaskID"]),
                    ProjectID = Convert.ToInt32(reader["ProjectID"]),
                    UserID = Convert.ToInt32(reader["UserID"]),
                    Name = reader["Name"].ToString(),
                    Description = reader["Description"].ToString(),
                    Priority = reader["Priority"].ToString(),
                    Type = reader["Type"].ToString(),
                    StartDate = Convert.ToDateTime(reader["StartDate"]),
                    Owner = reader["Owner"].ToString(),
                    EndDate = Convert.ToDateTime(reader["EndDate"])
                };
            }
        }
    }
}


