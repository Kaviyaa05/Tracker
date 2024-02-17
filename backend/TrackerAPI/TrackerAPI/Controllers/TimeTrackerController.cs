using System;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Configuration;
using System.Web.Http.Cors;
using TrackerAPI.Models;


namespace TrackerAPI.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api/TimeTracker")]
    public class TimeTrackerController : ApiController
    {
        [Route("GetAllTimeEntries")]
        [HttpGet]
        public HttpResponseMessage GetAllTimeEntries()
        {
            try
            {
                string query = "SELECT UserID, ProjectID, TaskID, StartTime, EndTime, TotalWorkingHours FROM dbo.TimeTracker";
                DataTable table = new DataTable();

                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["TimeTrackerDB"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    da.Fill(table);
                }

                return Request.CreateResponse(HttpStatusCode.OK, table);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [Route("AddTimeEntry")]
        [HttpPost]
        public HttpResponseMessage AddTimeEntry([FromBody] TimeTracker time)
        {
            try
            {
                string query = "INSERT INTO dbo.TimeTracker (UserID, ProjectID, TaskID, StartTime, EndTime, TotalWorkingHours) VALUES (@UserID, @ProjectID, @TaskID, @StartTime, @EndTime, @TotalWorkingHours)";

                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["TimeTrackerDB"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@UserID", time.UserID);
                    cmd.Parameters.AddWithValue("@ProjectID", time.ProjectID);
                    cmd.Parameters.AddWithValue("@TaskID", time.TaskID);
                    cmd.Parameters.AddWithValue("@StartTime", time.StartTime);
                    cmd.Parameters.AddWithValue("@EndTime", time.EndTime);
                    cmd.Parameters.AddWithValue("@TotalWorkingHours", Convert.ToDouble(time.TotalWorkingHours));
                    con.Open();
                    cmd.ExecuteNonQuery();
                }

                return Request.CreateResponse(HttpStatusCode.OK, "Added Successfully!");
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Failed to Add! " + ex.Message);
            }
        }

        [Route("EditTimeEntry")]
        [HttpPut]
        public HttpResponseMessage EditTimeEntry([FromBody] TimeTracker time)
        {
            try
            {
                string query = "UPDATE dbo.TimeTracker SET UserID = @UserID, ProjectID = @ProjectID, StartTime = @StartTime, EndTime = @EndTime, TotalWorkingHours = @TotalWorkingHours WHERE TaskID = @TaskID";

                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["TimeTrackerDB"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@UserID", time.UserID);
                    cmd.Parameters.AddWithValue("@ProjectID", time.ProjectID);
                    cmd.Parameters.AddWithValue("@TaskID", time.TaskID);
                    cmd.Parameters.AddWithValue("@StartTime", time.StartTime);
                    cmd.Parameters.AddWithValue("@EndTime", time.EndTime);
                    cmd.Parameters.AddWithValue("@TotalWorkingHours", time.TotalWorkingHours);

                    con.Open();
                    cmd.ExecuteNonQuery();
                }

                return Request.CreateResponse(HttpStatusCode.OK, "Updated Successfully!");
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Failed to Update! " + ex.Message);
            }
        }

        [Route("DeleteTimeEntry/{id}")]
        [HttpDelete]
        public HttpResponseMessage DeleteTimeEntry(int id)
        {
            try
            {
                string query = "DELETE FROM [dbo].[TimeTracker] WHERE TaskID = @TaskID";

                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["TimeTrackerDB"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@TaskID", id);

                    con.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        return Request.CreateResponse(HttpStatusCode.OK, "Deleted Successfully!");
                    }
                    else
                    {
                        return Request.CreateResponse(HttpStatusCode.NotFound, "No records found with the provided TaskID.");
                    }
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Failed to Delete! " + ex.Message);
            }
        }

        // Other actions can be defined here if needed

    }
}