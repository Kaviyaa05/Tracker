﻿
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
    [RoutePrefix("api/documents")]
    public class DocumentsController : ApiController
    {
       


        // POST action method
        [HttpPost]
            [Route("")] //Route for post
            public IHttpActionResult Post(DocumentsTable note)
            {
                try
                {
                    using (SqlConnection connection = DocumentsDao.GetConnection())
                    {
                        connection.Open();
                        string query = "INSERT INTO notes (Title, Content, CreatedAt) VALUES (@Title, @Content, @CreatedAt)";
                        SqlCommand command = new SqlCommand(query, connection);
                        command.Parameters.AddWithValue("@Title", note.Title);
                        command.Parameters.AddWithValue("@Content", note.Content);
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


            // PUT: For Update content 
            [HttpPut]
            [Route("{documentId}")] //Route for put
            public IHttpActionResult Put(int documentId, DocumentsTable review)
            {
                try
                {
                    if (review == null)
                    {
                        return BadRequest("Review object is null.");
                    }

                    using (SqlConnection connection = DocumentsDao.GetConnection())
                    {
                        connection.Open();
                        string query = "UPDATE notes SET Title = @Title, Content = @Content, ModifiedAt = @ModifiedAt WHERE DocumentId = @DocumentId";
                        SqlCommand command = new SqlCommand(query, connection);
                        command.Parameters.AddWithValue("@Title", review.Title);
                        command.Parameters.AddWithValue("@Content", review.Content);
                        command.Parameters.AddWithValue("@ModifiedAt", DateTime.Now); 
                        command.Parameters.AddWithValue("@DocumentId", documentId);

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
        //GET:Getting data using id
            [HttpGet]
            [Route("{id}")] //Route for getbyid
            public IHttpActionResult GetContentById(int id)
            {
                try
                {
                    using (SqlConnection connection = DocumentsDao.GetConnection())
                    {
                        connection.Open();
                        string query = "SELECT Content FROM notes WHERE DocumentId = @DocumentId";
                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@DocumentId", id);
                            object result = command.ExecuteScalar();
                            if (result != null && result != DBNull.Value)
                            {
                                string content = (string)result;
                                return Ok(content);
                            }
                            else
                            {
                                return NotFound(); 
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    return InternalServerError(ex);
                }
            }
        // GET: Get all notes
            [HttpGet]
            [Route("")] //route for get
            public IHttpActionResult GetAll()
            {
                try
                {
                    List<DocumentsTable> notes = new List<DocumentsTable>();
                    using (SqlConnection connection = DocumentsDao.GetConnection())
                    {
                        connection.Open();
                        string query = "SELECT DocumentId, Title, Content, CreatedAt, ModifiedAt FROM notes";
                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            using (SqlDataReader reader = command.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    DocumentsTable note = new DocumentsTable
                                    {
                                        DocumentId = reader.GetInt32(reader.GetOrdinal("DocumentId")),
                                        Title = reader.GetString(reader.GetOrdinal("Title")),
                                        Content = reader.GetString(reader.GetOrdinal("Content")),
                                        CreatedAt = reader.GetDateTime(reader.GetOrdinal("CreatedAt")),
                                        ModifiedAt = (DateTime)(reader.IsDBNull(reader.GetOrdinal("ModifiedAt")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("ModifiedAt")))
                                    };

                                   

                                    notes.Add(note);
                                }
                            }
                        }
                    }
                    return Ok(notes); 
                }
                catch (Exception ex)
                {
                    return InternalServerError(ex);
                }
            }
        }
    }





