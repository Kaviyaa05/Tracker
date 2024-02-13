using TrackerAPI.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace TrackerAPI.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class CommentController : ApiController
    {
        // GET: api/Comment/GetComments
        [HttpGet]
        [Route("api/Comment/GetComments")]
        public HttpResponseMessage GetComments()
        {
            List<Comment> comments = new List<Comment>();
            try
            {
                string query = "SELECT * FROM Comment";

                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["BackendConnectionString"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))
                {
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Comment comment = new Comment
                        {
                            CommentId = Convert.ToInt32(reader["CommentId"]),
                            TaskId = Convert.ToInt32(reader["TaskId"]),
                            ProjectId = Convert.ToInt32(reader["ProjectId"]),
                            CommentedData = reader["CommentedData"].ToString(),
                            DateTimePosted = Convert.ToDateTime(reader["DateTimePosted"])
                        };
                        comments.Add(comment);
                    }

                    return Request.CreateResponse(HttpStatusCode.OK, comments);
                }
            }
            catch (Exception)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Failed to fetch comments! ");
            }
        }

        // POST: api/Comment/AddComment
        [HttpPost]
        [Route("api/Comment/AddComment")]
        public HttpResponseMessage AddComment(Comment comment)
        {
            try
            {
                string query = @"INSERT INTO Comment (TaskId, ProjectId, CommentedData, DateTimePosted) 
                                 VALUES (@TaskId, @ProjectId, @CommentedData, @DateTimePosted)";

                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["BackendConnectionString"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@TaskId", comment.TaskId);
                    cmd.Parameters.AddWithValue("@ProjectId", comment.ProjectId);
                    cmd.Parameters.AddWithValue("@CommentedData", comment.CommentedData);
                    cmd.Parameters.AddWithValue("@DateTimePosted", comment.DateTimePosted);

                    con.Open();
                    cmd.ExecuteNonQuery();
                }

                return Request.CreateResponse(HttpStatusCode.OK, "Comment Added Successfully!");
            }
            catch (Exception)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Failed to Add Comment! ");
            }
        }

        // PUT: api/Comment/UpdateComment
        [HttpPut]
        [Route("api/Comment/UpdateComment")]
        public HttpResponseMessage UpdateComment(Comment comment)
        {
            try
            {
                string query = @"UPDATE Comment
                                 SET TaskId = @TaskId, ProjectId = @ProjectId, CommentedData = @CommentedData,
                                     DateTimePosted = @DateTimePosted
                                 WHERE CommentId = @CommentId";

                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["BackendConnectionString"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@TaskId", comment.TaskId);
                    cmd.Parameters.AddWithValue("@ProjectId", comment.ProjectId);
                    cmd.Parameters.AddWithValue("@CommentedData", comment.CommentedData);
                    cmd.Parameters.AddWithValue("@DateTimePosted", comment.DateTimePosted);
                    cmd.Parameters.AddWithValue("@CommentId", comment.CommentId);

                    con.Open();
                    cmd.ExecuteNonQuery();
                }

                return Request.CreateResponse(HttpStatusCode.OK, "Comment Updated Successfully!");
            }
            catch (Exception)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Failed to Update Comment! ");
            }
        }

        // DELETE: api/Comment/DeleteComment/{id}
        [HttpDelete]
        [Route("api/Comment/DeleteComment/{id}")]
        public HttpResponseMessage DeleteComment(int id)
        {
            try
            {
                string query = "DELETE FROM Comment WHERE CommentId = @CommentId";

                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["BackendConnectionString"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@CommentId", id);

                    con.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        return Request.CreateResponse(HttpStatusCode.OK, "Comment Deleted Successfully!");
                    }
                    else
                    {
                        return Request.CreateResponse(HttpStatusCode.NotFound, "No comment found with the provided CommentId.");
                    }
                }
            }
            catch (Exception)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Failed to Delete Comment! ");
            }
        }
    }
}
