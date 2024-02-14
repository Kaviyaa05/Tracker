
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TrackerAPI.Models;

namespace TrackerAPI.Controllers
{
    public class DocumentsController : ApiController
    {

        // Add document
        //[EnableCors(origins: "*", headers: "*", methods: "*")]
        public IHttpActionResult Post(DocumentsTable review)
        {


            using (SqlConnection connection = DocumentsDao.GetConnection())
            {
                review.CreatedAt = DateTime.Now;
                string query = "INSERT INTO notes (Title, Content, CreatedAt) VALUES (@Title, @Content, @CreatedAt)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Title", review.Title);
                command.Parameters.AddWithValue("@Content", review.Content);
                command.Parameters.AddWithValue("@CreatedAt", review.CreatedAt);
                

                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();

                if (rowsAffected > 0)
                    return Ok();
                else
                    return NotFound();
            }
        }

        // Get all records
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [HttpPost]
        public IHttpActionResult Get(DocumentsTable review)
        {
            try
            {
                using (SqlConnection connection = DocumentsDao.GetConnection())
                {
                    connection.Open();
                    string query = "INSERT INTO notes (Title, Content, CreatedAt) VALUES (@Title, @Content, @CreatedAt)";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Title", review.Title);
                    command.Parameters.AddWithValue("@Content", review.Content);
                    command.Parameters.AddWithValue("@CreatedAt", DateTime.Now);
                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                        return Ok("Note added successfully");
                    else
                        return BadRequest("Failed to add note");
                }
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // Get all records
        [HttpGet]
        public IHttpActionResult Get()
        {
            try
            {
                List<DocumentsTable> notes = new List<DocumentsTable>();
                using (SqlConnection connection = DocumentsDao.GetConnection())
                {
                    connection.Open();
                    string query = "SELECT Id, Title, Content FROM notes";
                    SqlCommand command = new SqlCommand(query, connection);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        DocumentsTable note = new DocumentsTable
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            Title = reader["Title"].ToString(),
                            Content = reader["Content"].ToString()
                        };
                        notes.Add(note);
                    }
                }
                return Ok(notes);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // Get single note by id
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            try
            {
                using (SqlConnection connection = DocumentsDao.GetConnection())
                {
                    connection.Open();
                    string query = "SELECT Title, Content FROM notes WHERE Id = @Id";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Id", id);
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        DocumentsTable note = new DocumentsTable
                        {
                            Title = reader["Title"].ToString(),
                            Content = reader["Content"].ToString()
                        };
                        return Ok(note);
                    }
                    else
                    {
                        return NotFound();
                    }
                }
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // Update a note
        [HttpPut]
        public IHttpActionResult Put(int id, DocumentsTable review)
        {
            try
            {
                using (SqlConnection connection = DocumentsDao.GetConnection())
                {
                    connection.Open();
                    string query = "UPDATE notes SET Title = @Title, Content = @Content WHERE Id = @Id";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Title", review.Title);
                    command.Parameters.AddWithValue("@Content", review.Content);
                    command.Parameters.AddWithValue("@Id", id);
                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                        return Ok("Note updated successfully");
                    else
                        return NotFound();
                }
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // Delete a note
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            try
            {
                using (SqlConnection connection = DocumentsDao.GetConnection())
                {
                    connection.Open();
                    string query = "DELETE FROM notes WHERE Id = @Id";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Id", id);
                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                        return Ok("Note deleted successfully");
                    else
                        return NotFound();
                }
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}


