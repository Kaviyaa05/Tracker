using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;


namespace TrackerAPI.Models
{
    public class UserController : ApiController
    {
        // GET: profile
        public HttpResponseMessage Get()
        {
            try
            {
                string query = @"SELECT UserId, Name, Role, Email, Password FROM dbo.Users";
                DataTable table = new DataTable();
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["arunkumar"].ConnectionString))
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
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Failed to retrieve data: " + ex.Message);
            }
        }

        // POST: profile
        public HttpResponseMessage Post([FromBody] User log)
        {
            try
            {
                if (log == null)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Profile data is null");
                }

                string query = @"INSERT INTO dbo.Users (UserId, Name, Role, Email, Password) 
                                VALUES (@UserId, @Name, @Role, @Email, @Password)";
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["arunkumar"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@UserId", log.UserId ?? "");
                    cmd.Parameters.AddWithValue("@Name", log.Name ?? "");
                    cmd.Parameters.AddWithValue("@Role", log.Role ?? "");
                    cmd.Parameters.AddWithValue("@Email", log.Email ?? "");
                    cmd.Parameters.AddWithValue("@Password", log.Password ?? "");
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
                return Request.CreateResponse(HttpStatusCode.Created, "Added successfully");
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Failed to insert data: " + ex.Message);
            }
        }

        // PUT: profile/{id}
        public HttpResponseMessage Put(string id, [FromBody] User log)
        {
            try
            {
                if (log == null)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Profile data is null");
                }

                string query = @"UPDATE dbo.Users 
                                 SET UserId = @UserId, 
                                     Name = @Name, 
                                     Role = @Role, 
                                     Email = @Email, 
                                     Password = @Password 
                                 WHERE UserId = @Id";
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["arunkumar"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@UserId", log.UserId ?? "");
                    cmd.Parameters.AddWithValue("@Name", log.Name ?? "");
                    cmd.Parameters.AddWithValue("@Role", log.Role ?? "");
                    cmd.Parameters.AddWithValue("@Email", log.Email ?? "");
                    cmd.Parameters.AddWithValue("@Password", log.Password ?? "");
                    cmd.Parameters.AddWithValue("@Id", id); // Use id for identifying the user to update

                    con.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                        return Request.CreateResponse(HttpStatusCode.OK, "Updated Successfully");
                    else
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "User not found");
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Failed to Update: " + ex.Message);
            }
        }

        // DELETE: profile/{id}
        public HttpResponseMessage Delete(string id)
        {
            try
            {
                string query = @"DELETE FROM dbo.[Users] WHERE UserId = @UserId";

                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["arunkumar"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@UserId", id);

                    con.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                        return Request.CreateResponse(HttpStatusCode.OK, "Deleted Successfully");
                    else
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "User not found");
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Failed to Delete: " + ex.Message);
            }
        }
    }
}
