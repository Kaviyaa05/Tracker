using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TrackerAPI.Models;

namespace WebApplication3.Controllers
{
    public class TaskController : ApiController
    {
        public HttpResponseMessage Get()
        {
            string query = @"
                SELECT TaskId, UserId, Taskname, TaskType, Priority, CreatedBy, StartDate, EndDate, Status, Description 
                FROM Tasks";

            DataTable table = new DataTable();
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["Kaviya"].ConnectionString))
            using (var cmd = new SqlCommand(query, con))
            using (var da = new SqlDataAdapter(cmd))
            {
                cmd.CommandType = CommandType.Text;
                da.Fill(table);
            }

            return Request.CreateResponse(HttpStatusCode.OK, table);
        }
        public HttpResponseMessage Post(TaskForm tsk)
        {
            try
            {
                string query = @"
            INSERT INTO Tasks (TaskId, UserId, Taskname, TaskType, Priority, CreatedBy, StartDate, EndDate, Status, Description)
            VALUES (@TaskId, @UserId, @Taskname, @TaskType, @Priority, @CreatedBy, @StartDate, @EndDate, @Status, @Description)";

                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["Kaviya"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@TaskId", tsk.TaskId);
                    cmd.Parameters.AddWithValue("@UserId", tsk.UserId);
                    cmd.Parameters.AddWithValue("@Taskname", tsk.Taskname);
                    cmd.Parameters.AddWithValue("@TaskType", tsk.TaskType);
                    cmd.Parameters.AddWithValue("@Priority", tsk.Priority);
                    cmd.Parameters.AddWithValue("@CreatedBy", tsk.CreatedBy);
                    cmd.Parameters.AddWithValue("@StartDate", tsk.StartDate);
                    cmd.Parameters.AddWithValue("@EndDate", tsk.EndDate);
                    cmd.Parameters.AddWithValue("@Status", tsk.Status);
                    cmd.Parameters.AddWithValue("@Description", tsk.Description);

                    con.Open();
                    cmd.ExecuteNonQuery();
                }

                return Request.CreateResponse(HttpStatusCode.OK, "Inserted Successfully!!");
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.WriteLine(ex.ToString());

                // Return detailed exception information in the response
                return Request.CreateResponse(HttpStatusCode.InternalServerError, $"Failed to Insert!! Error: {ex.Message}");
            }
        }



        public string Put(TaskForm tsk)
        {
            try
            {
                string query = @"
                    UPDATE Tasks 
                    SET UserId = @UserId, Taskname = @Taskname, TaskType = @TaskType, Priority = @Priority, 
                        CreatedBy = @CreatedBy, StartDate = @StartDate, EndDate = @EndDate, Status = @Status, 
                        Description = @Description
                    WHERE TaskId = @TaskId";

                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["Kaviya"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@UserId", tsk.UserId);
                    cmd.Parameters.AddWithValue("@Taskname", tsk.Taskname);
                    cmd.Parameters.AddWithValue("@TaskType", tsk.TaskType);
                    cmd.Parameters.AddWithValue("@Priority", tsk.Priority);
                    cmd.Parameters.AddWithValue("@CreatedBy", tsk.CreatedBy);
                    cmd.Parameters.AddWithValue("@StartDate", tsk.StartDate);
                    cmd.Parameters.AddWithValue("@EndDate", tsk.EndDate);
                    cmd.Parameters.AddWithValue("@Status", tsk.Status);
                    cmd.Parameters.AddWithValue("@Description", tsk.Description);
                    cmd.Parameters.AddWithValue("@TaskId", tsk.TaskId);

                    con.Open();
                    cmd.ExecuteNonQuery();
                }

                return "Updated Successfully!!";
            }
            catch (Exception)
            {
                return "Failed to Update!!";
            }
        }

        public string Delete(int id)
        {
            try
            {
                string query = @"
                    DELETE FROM Tasks
                    WHERE TaskId = @TaskId";

                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["Kaviya"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@TaskId", id);

                    con.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                        return "Deleted Successfully!!";
                    else
                        return "No record found to delete!!";
                }
            }
            catch (Exception)
            {
                return "Failed to Delete!!";
            }
        }
    }
}
