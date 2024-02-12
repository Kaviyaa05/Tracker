
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
            public string Post(Table review)
            {


                using (SqlConnection connection = MainClass.GetConnection())
                {
                    review.CreatedAt = DateTime.Now; 
                    string query = "INSERT INTO notes (Title, Content, CreatedAt, ModifiedAt) VALUES (@Title, @Content, @CreatedAt, @ModifiedAt)";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Title", review.Title);
                    command.Parameters.AddWithValue("@Content", review.Content);
                    command.Parameters.AddWithValue("@CreatedAt", review.CreatedAt);
                    command.Parameters.AddWithValue("@ModifiedAt", review.ModifiedAt);

                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                        return "Document added successfully";
                    else
                        return "Failed to add document";
                }
            }

            // Get all documents
            //[EnableCors(origins: "*", headers: "*", methods: "*")]
            public IEnumerable<Table> Get()
            {
                List<Table> bookReviews = new List<Table>();
                using (SqlConnection connection = MainClass.GetConnection())
                {
                    string query = "SELECT * FROM notes";

                    SqlCommand command = new SqlCommand(query, connection);

                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Table review = new Table();
                        review.Id = Convert.ToInt32(reader["Id"]);
                        review.Title = reader["Title"].ToString();
                        review.Content = reader["Content"].ToString();
                      

                        bookReviews.Add(review);
                    }
                }
                return bookReviews;
            }

            // Get single documents
            //[EnableCors(origins: "*", headers: "*", methods: "*")]
            public Table Get(string title)
            {
                using (SqlConnection connection = MainClass.GetConnection())
                {
                    string query = "SELECT * FROM notes WHERE Title = @Title";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Title", title);

                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        Table review = new Table();
                        review.Id = Convert.ToInt32(reader["Id"]);
                        review.Title = reader["Title"].ToString();
                        review.Content = reader["Content"].ToString();
                        
                        return review;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
                //Modify the document

            //[EnableCors(origins: "*", headers: "*", methods: "*")]
            public string Put(string title, Table review)
            {
                review.ModifiedAt = DateTime.Now; 

                using (SqlConnection connection = MainClass.GetConnection())
                {
                    review.ModifiedAt = DateTime.Now;
                    string query = "UPDATE notes SET  Content = @Content, ModifiedAt = @ModifiedAt WHERE Title=@Title";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Title", review.Title);
                    command.Parameters.AddWithValue("@Content", review.Content);
                    command.Parameters.AddWithValue("@ModifiedAt", review.ModifiedAt);
                    

                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                        return "Updated";
                    else
                        return "Document not found";
                }
            }

            // Delete the documnet
            //[EnableCors(origins: "*", headers: "*", methods: "*")]
            public string Delete(string title)
            {
                using (SqlConnection connection = MainClass.GetConnection())
                {
                    string query = "DELETE FROM notes WHERE Title = @Title";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Title", title);

                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                        return "Note deleted successfully";
                    else
                        return "Note record not found";
                }
            }

        }
    }
