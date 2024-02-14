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
using TrackerAPI.Models;

namespace TrackerAPI.Controllers
{
    public class profileController : ApiController
    {
        // GET: login
        public HttpResponseMessage Get()
        {
            try
            {
                string query = @"SELECT Name, Email, Phone, Role, About, Password, Address,UserId FROM dbo.[Users]";
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

        // POST: login
        public HttpResponseMessage Post([FromBody] profile log)
        {
            try
            {
                if (log == null)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Profile data is null");
                }

                string query = @"INSERT INTO dbo.Users (Name, Email, Phone, Role, About, Password, Address,UserId) 
                                VALUES (@Name, @Email, @Phone, @Role, @About, @Password, @Address,@UserId)";
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["arunkumar"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Name", log.Name ?? "");

                    cmd.Parameters.AddWithValue("@Email", log.Email ?? "");
                    cmd.Parameters.AddWithValue("@Phone", log.Phone ?? "");
                    cmd.Parameters.AddWithValue("@Role", log.Role ?? "");
                    cmd.Parameters.AddWithValue("@About", log.About ?? "");
                    cmd.Parameters.AddWithValue("@Password", log.Password ?? "");
                    cmd.Parameters.AddWithValue("@Address", log.Address ?? "");
                    cmd.Parameters.AddWithValue("@UserId", log.UserId ?? "");


                    con.Open();
                    cmd.ExecuteNonQuery();
                }
                return Request.CreateResponse(HttpStatusCode.Created, "added successfully");
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Failed to insert data: " + ex.Message);
            }
        }

        // PUT: login
        public HttpResponseMessage put([FromBody] profile log)
        {
            try
            {
                if (log == null || string.IsNullOrEmpty(log.Name))
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Profile data is null or Name is empty");
                }

                string query = @"UPDATE dbo.Users 
                                SET Email = @Email, Phone = @Phone, Role = @Role, 
                                    About = @About, Password = @Password, Address = @Address,UserId = @UserId
                                WHERE Name = @Name";
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["arunkumar"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Name", log.Name);

                    cmd.Parameters.AddWithValue("@Email", log.Email ?? "");
                    cmd.Parameters.AddWithValue("@Phone", log.Phone ?? "");
                    cmd.Parameters.AddWithValue("@Role", log.Role ?? "");
                    cmd.Parameters.AddWithValue("@About", log.About ?? "");
                    cmd.Parameters.AddWithValue("@Password", log.Password ?? "");
                    cmd.Parameters.AddWithValue("@Address", log.Address ?? "");
                    cmd.Parameters.AddWithValue("@UserId", log.UserId);

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

        // DELETE: login/{name}
        public HttpResponseMessage Delete(String id)
        {
            try
            {
                string query = @"DELETE FROM dbo.[Users] WHERE Name = @Name";

                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["arunkumar"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Name", id);

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
