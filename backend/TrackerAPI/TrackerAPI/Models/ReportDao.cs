
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace TrackerAPI.Models
{
    public class ReportDao
    {

        public List<ReportProject> fetchProjects()
        {
            List<ReportProject> projects = new List<ReportProject>();

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Kaviya"].ConnectionString))
            using (SqlCommand command = new SqlCommand("SELECT * FROM dummyproject", connection))
            {

                try
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int projectId = reader.GetInt32(0);
                            int userId = reader.GetInt32(1);
                            string name = reader.GetString(2);
                            string description = reader.GetString(3);
                            string priority = reader.GetString(4);
                            string team_members = reader.GetString(5);
                            string owner = reader.GetString(6);
                            DateTime startDate = reader.GetDateTime(7);
                            DateTime endDate = reader.GetDateTime(8);

                            projects.Add(new ReportProject
                            {
                                ProjectID = projectId,
                                UserID = userId,
                                Name = name,
                                Description = description,
                                Priority = priority,
                                Team = team_members,
                                Owner = owner,
                                StartDate = startDate,
                                EndDate = endDate
                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            return projects;
        }



        public List<ReportTask> fetchTask()
        {
            string connectionStirng = ConfigurationManager.ConnectionStrings["Kaviya"].ConnectionString;
            List<ReportTask> tasks = new List<ReportTask>();


            using (SqlConnection connection = new SqlConnection(connectionStirng))
            {

                using (SqlCommand command = new SqlCommand("select * from dummytask", connection))
                {
                    try
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int projectId = reader.GetInt32(0);
                                int taskId = reader.GetInt32(1);
                                int userId = reader.GetInt32(2);
                                string name = reader.GetString(3);
                                string priority = reader.GetString(4);
                                string type = reader.GetString(5);
                                string description = reader.GetString(6);
                                string owner = reader.GetString(7);
                                DateTime startDate = reader.GetDateTime(8);
                                DateTime endDate = reader.GetDateTime(9);


                                tasks.Add(new ReportTask


                                {
                                    ProjectID = projectId,
                                    TaskID = taskId,
                                    UserID = userId,
                                    Name = name,
                                    Priority = priority,
                                    Type = type,
                                    Description = description,

                                    Owner = owner,
                                    StartDate = startDate,
                                    EndDate = endDate
                                });
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
            }
            return tasks;
        }



        public List<ReportTask> fetchTaskByType(string taskType)
        {
            string query = "SELECT * FROM dummytask WHERE task_type = @TaskType";
            List<ReportTask> tasks = new List<ReportTask>();

       

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Kaviya"].ConnectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@TaskType", taskType);

                try
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int projectId = reader.GetInt32(0);
                            int taskId = reader.GetInt32(1);
                            int userId = reader.GetInt32(2);
                            string name = reader.GetString(3);
                            string priority = reader.GetString(4);
                            string type = reader.GetString(5);
                            string description = reader.GetString(6);
                            string owner = reader.GetString(7);
                            DateTime startDate = reader.GetDateTime(8);
                            DateTime endDate = reader.GetDateTime(9);


                            tasks.Add(new ReportTask

                            {
                                ProjectID = projectId,
                                TaskID = taskId,
                                UserID = userId,
                                Name = name,
                                Priority = priority,
                                Type = type,
                                Description = description,

                                Owner = owner,
                                StartDate = startDate,
                                EndDate = endDate
                            });

                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);

                }
            }

            return tasks;
        }



        public List<ReportTask> fetchOverdue(DateTime currentDate)
        {
            string query = "SELECT * FROM dummytask WHERE end_date <= @CurrentDate";
            List<ReportTask> tasks = new List<ReportTask>();


            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["kaviya"].ConnectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@CurrentDate", currentDate);

                try
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int projectId = reader.GetInt32(0);
                            int taskId = reader.GetInt32(1);
                            int userId = reader.GetInt32(2);
                            string name = reader.GetString(3);
                            string priority = reader.GetString(4);
                            string type = reader.GetString(5);
                            string description = reader.GetString(6);
                            string owner = reader.GetString(7);
                            DateTime startDate = reader.GetDateTime(8);
                            DateTime endDate = reader.GetDateTime(9);


                            tasks.Add(new ReportTask
             {
                                ProjectID = projectId,
                                TaskID = taskId,
                                UserID = userId,
                                Name = name,
                                Priority = priority,
                                Type = type,
                                Description = description,
                                Owner = owner,
                                StartDate = startDate,
                                EndDate = endDate
                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            return tasks;
        }



        public List<ReportProject> fetchProjectOverdue(DateTime currentDate)
        {
            string query = "SELECT * FROM dummyproject WHERE end_date <= @CurrentDate";
            List<ReportProject> projects = new List<ReportProject>();

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Kaviya"].ConnectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@CurrentDate", currentDate);

                try
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int projectId = reader.GetInt32(0);
                            int userId = reader.GetInt32(1);
                            string name = reader.GetString(2);
                            string description = reader.GetString(3);
                            string priority = reader.GetString(4);
                            string team_members = reader.GetString(5);
                            string owner = reader.GetString(6);
                            DateTime startDate = reader.GetDateTime(7);
                            DateTime endDate = reader.GetDateTime(8);

                            projects.Add(new ReportProject
                            {
                                ProjectID = projectId,
                                UserID = userId,
                                Name = name,
                                Description = description,
                                Priority = priority,
                                Team = team_members,
                                Owner = owner,
                                StartDate = startDate,
                                EndDate = endDate
                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            return projects;
        }



        public List<ReportTask> fetchTaskByPriority(string taskPriority)
        {
            string query = "SELECT * FROM dummytask WHERE task_priority = @TaskPriority";
            List<ReportTask> tasks = new List<ReportTask>();

  

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Kaviya"].ConnectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@TaskPriority", taskPriority);

                try
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int projectId = reader.GetInt32(0);
                            int taskId = reader.GetInt32(1);
                            int userId = reader.GetInt32(2);
                            string name = reader.GetString(3);
                            string priority = reader.GetString(4);
                            string type = reader.GetString(5);
                            string description = reader.GetString(6);
                            string owner = reader.GetString(7);
                            DateTime startDate = reader.GetDateTime(8);
                            DateTime endDate = reader.GetDateTime(9);


                            tasks.Add(new ReportTask
              {
                                ProjectID = projectId,
                                TaskID = taskId,
                                UserID = userId,
                                Name = name,
                                Priority = priority,
                                Type = type,
                                Description = description,
                                Owner = owner,
                                StartDate = startDate,
                                EndDate = endDate
                            });

                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);

                }
            }

            return tasks;
        }


        public List<ReportProject> fetchProjectByPriority(string projectPriority)
        {
            string query = "SELECT * FROM dummyproject WHERE project_priority = @ProjectPriority";
            List<ReportProject> projects = new List<ReportProject>();

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Kaviya"].ConnectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@ProjectPriority", projectPriority);

                try
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int projectId = reader.GetInt32(0);
                            int userId = reader.GetInt32(1);
                            string name = reader.GetString(2);
                            string description = reader.GetString(3);
                            string priority = reader.GetString(4);
                            string team_members = reader.GetString(5);
                            string owner = reader.GetString(6);
                            DateTime startDate = reader.GetDateTime(7);
                            DateTime endDate = reader.GetDateTime(8);


                            projects.Add(new ReportProject
                            {
                                ProjectID = projectId,
                                UserID = userId,
                                Name = name,
                                Description = description,
                                Priority = priority,
                                Team = team_members,
                                Owner = owner,
                                StartDate = startDate,
                                EndDate = endDate
                            });

                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);

                }
            }

            return projects;
        }



        public List<TaskDetails> fetchTaskDetails(int taskid)
        {
            string query = "select dummytask.project_id, dummyproject.project_name,dummytask.task_id, dummytask.USER_ID,dummyproject.project_priority, dummytask.task_name,dummytask.task_priority, dummytask.task_type, dummytask.description,dummytask.owner,dummyproject.team_members, dummytask.start_date,dummytask.end_date from dummytask join dummyproject on dummytask.project_id = dummyproject.project_id where task_id=@TaskID";
            List<TaskDetails> details = new List<TaskDetails>();
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Kaviya"].ConnectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@TaskID", taskid);
                try
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int projectId = reader.GetInt32(0);
                            string projectName = reader.GetString(1);
                            int taskId = reader.GetInt32(2);
                            int userId = reader.GetInt32(3);
                            string projectPriority = reader.GetString(4);
                            string taskname = reader.GetString(5);
                            string taskpriority = reader.GetString(6);
                            string tasktype = reader.GetString(7);
                            string description = reader.GetString(8);
                            string owner = reader.GetString(9);
                            string teams = reader.GetString(10);
                            DateTime startDate = reader.GetDateTime(11);
                            DateTime endDate = reader.GetDateTime(12);

                            details.Add(new TaskDetails
                            {
                                ProjectID = projectId,
                                ProjectName = projectName,
                                TaskID = taskId,
                                UserID = userId,
                                ProjectPriority = projectPriority,
                                TaskName = taskname,
                                TaskPriority = taskpriority,
                                TaskType = tasktype,
                                Description = description,
                                Assigned_By = owner,
                                Teams = teams,
                                StartDate = startDate,
                                EndDate = endDate
                            });
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("error", e);
                }

            }
            return details;

        }
    }
}