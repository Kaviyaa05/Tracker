
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
        string connectionString = ConfigurationManager.ConnectionStrings["Connection"].ConnectionString;

        //fetching all projects
        public List<ReportProject> fetchProject()
        {
            List<ReportProject> project = new List<ReportProject>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand("select * from Project", connection))
            {
                try
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int projectid = reader.GetInt32(0);
                            string projectname = reader.GetString(1);
                            string description = reader.GetString(2);
                            string owner = reader.GetString(3);
                            string team = reader.GetString(4);
                            DateTime startdate = reader.GetDateTime(5);

                            project.Add(new ReportProject
                            {
                                ProjectID = projectid,
                                ProjectName = projectname,
                                ProjectDescription = description,
                                Owner = owner,
                                TeamName = team,
                                StartDate = startdate
                            });
                        }

                    }
                } catch (Exception e)
                {
                    Console.WriteLine("Error", e);
                }
            } return project;

        }



        //project created by me 
        public List<ReportProject> createdProject(string owner)
        {
            List<ReportProject> assignedProejct = new List<ReportProject>();
            string query = "select ProjectId, ProjectName, ProjectDescription,TeamName, StartDate from project where Owner  = @Owner";
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Owner", owner);
                try
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int projectid = reader.GetInt32(0);
                            string projectname = reader.GetString(1);
                            string description = reader.GetString(2);
                            string team = reader.GetString(3);
                            DateTime startdate = reader.GetDateTime(4);

                            assignedProejct.Add(new ReportProject
                            {
                                ProjectID = projectid,
                                ProjectName = projectname,
                                ProjectDescription = description,
                                TeamName = team,
                                StartDate = startdate
                            }) ;
                        }

                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error", e);
                }
            } return assignedProejct;
        }



        //fetching all tasks
        public List<ReportTask> fetchtask()
        {
            List<ReportTask> task = new List<ReportTask>();
            using (SqlConnection connection = new SqlConnection(connectionString))
                using(SqlCommand command = new SqlCommand("select TaskId, TaskName, TaskType, TaskPriority,TaskDescription,Owner,Assigned,StartDate,Enddate from task ", connection))
                {
                try
                {
                    connection.Open();
                    using(SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int taskid = reader.GetInt32(0);
                            string taskname = reader.GetString(1);
                            string tasktype = reader.GetString(2);
                            string taskpriority = reader.GetString(3);
                            string taskdescription = reader.GetString(4);
                            string owner = reader.GetString(5);
                            string assign = reader.GetString(6);
                            DateTime start = reader.GetDateTime(7);
                            DateTime end = reader.GetDateTime(8);


                            task.Add(new ReportTask
                            {
                                TaskId = taskid,
                                taskName = taskname,
                                taskType = tasktype,
                                taskPriority = taskpriority,
                                taskDescription = taskdescription,
                                owner = owner,
                                assigned = assign,
                                startDate = start,
                                endDate = end,
                            });
                        }
                    }
                }catch(Exception ex)
                {
                    Console.WriteLine("Error", ex);
                }
            } return task;
        }


 
        //task assigned to me
        public List <ReportTask> taskAssigned (string assign)
        {
            List<ReportTask> assigntask = new List<ReportTask>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand("select TaskId, TaskName, TaskType, TaskPriority,TaskDescription,Owner,StartDate,Enddate from task where Assigned = @Assign ", connection))
            {
                try
                {
                    connection.Open();
                    using(SqlDataReader reader= command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int taskid = reader.GetInt32(0);
                            string taskname = reader.GetString(1);
                            string tasktype = reader.GetString(2);
                            string taskpriority = reader.GetString(3);
                            string taskdescription = reader.GetString(4);
                            string owner = reader.GetString(5);
                            DateTime start = reader.GetDateTime(6);
                            DateTime end = reader.GetDateTime(7);

                            assigntask.Add(new ReportTask
                            {
                                TaskId = taskid,
                                taskName = taskname,
                                taskType = tasktype,
                                taskPriority = taskpriority,
                                taskDescription = taskdescription,
                                owner = owner,
                                startDate = start,
                                endDate = end,
                            });
                        }
                    }
                }catch(Exception e)
                {
                    Console.WriteLine("Error", e);
                }

            }
            return assigntask;

        }


        //task created by me
        public List<ReportTask> taskCreated(string owner)
        {
            List<ReportTask> assigntask = new List<ReportTask>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand("select TaskId, TaskName, TaskType, TaskPriority,TaskDescription,Assigned,StartDate,Enddate from task where Owner = @own ", connection))
            {
                command.Parameters.AddWithValue("@Own", owner);
                try
                {

                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int taskid = reader.GetInt32(0);
                            string taskname = reader.GetString(1);
                            string tasktype = reader.GetString(2);
                            string taskpriority = reader.GetString(3);
                            string taskdescription = reader.GetString(4);
                            string assign = reader.GetString(5);
                            DateTime start = reader.GetDateTime(6);
                            DateTime end = reader.GetDateTime(7);

                            assigntask.Add(new ReportTask
                            {
                                TaskId = taskid,
                                taskName = taskname,
                                taskType = tasktype,
                                taskPriority = taskpriority,
                                taskDescription = taskdescription,
                                assigned = assign,
                                startDate = start,
                                endDate = end,
                            });
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error", e);
                }

            }
            return assigntask;

        }


        public List<ReportTask> GetTasks(string query, string parameterName, object parameterValue)
        {
            List<ReportTask> tasks = new List<ReportTask>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue(parameterName, parameterValue);

                try
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int taskId = reader.GetInt32(0);
                            string taskName = reader.GetString(1);
                            string taskType = reader.GetString(2);
                            string taskPriority = reader.GetString(3);
                            string taskDescription = reader.GetString(4);
                            string owner = reader.GetString(5);
                            string assign = reader.GetString(6);
                            DateTime start = reader.GetDateTime(7);
                            DateTime end = reader.GetDateTime(8);

                            tasks.Add(new ReportTask
                            {
                                TaskId = taskId,
                                taskName = taskName,
                                taskType = taskType,
                                taskPriority = taskPriority,
                                taskDescription = taskDescription,
                                owner = owner,
                                assigned = assign,
                                startDate = start,
                                endDate = end,
                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error", ex);
                }
            }

            return tasks;
        }

        public List<ReportTask> GetTasksByType(string type)
        {
            string query = "SELECT TaskId, TaskName, TaskType, TaskPriority, TaskDescription, Owner, Assigned, StartDate, EndDate FROM task WHERE TaskType = @TaskType";
            return GetTasks(query, "@TaskType", type);
        }

        public List<ReportTask> GetTasksByPriority(string priority)
        {
            string query = "SELECT TaskId, TaskName, TaskType, TaskPriority, TaskDescription, Owner, Assigned, StartDate, EndDate FROM task WHERE TaskPriority = @TaskPriority";
            return GetTasks(query, "@TaskPriority", priority);
        }

        public List<ReportTask> GetOverdueTasks(DateTime currentTime)
        {
            string query = "SELECT TaskId, TaskName, TaskType, TaskPriority, TaskDescription, Owner, Assigned, StartDate, EndDate FROM task WHERE EndDate <= @Date";
            return GetTasks(query, "@Date", currentTime);
        }


        public List<ReportTask> GetTaskDetails(int taskid)
        {
            string query = "select * from task where taskid = @TaskId";
            List < ReportTask > taskdetails = new List<ReportTask>();
            using(SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@TaskId", taskid);

                try
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int projectid = reader.GetInt32(0);
                            string projectname = reader.GetString(1);
                            int taskId = reader.GetInt32(2);
                            string taskName = reader.GetString(3);
                            string taskType = reader.GetString(4);
                            string taskPriority = reader.GetString(5);
                            string taskDescription = reader.GetString(6);
                            string owner = reader.GetString(7);
                            string assign = reader.GetString(8);
                            DateTime start = reader.GetDateTime(9);
                            DateTime end = reader.GetDateTime(10);

                            taskdetails.Add(new ReportTask
                            {
                                ProjectId = projectid,
                                ProjectName = projectname,
                                TaskId = taskId,
                                taskName = taskName,
                                taskType = taskType,
                                taskPriority = taskPriority,
                                taskDescription = taskDescription,
                                owner = owner,
                                assigned = assign,
                                startDate = start,
                                endDate = end,
                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error", ex);
                }
            }

            return taskdetails;
        }
    }
}