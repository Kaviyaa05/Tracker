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
    public class ProjectsController : ApiController
    {
        // GET: api/Projects
        [HttpGet]
        [Route("api/Projects")]
        public HttpResponseMessage GetProjects()
        {
            List<Project> projects = new List<Project>();
            try
            {
                // SQL query to select all projects from the database
                string query = "SELECT * FROM Project";

                // Using ADO.NET to execute the SQL query
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["EmployeeConnection"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))
                {
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    // Read data and populate projects list
                    while (reader.Read())
                    {
                        Project project = new Project
                        {
                            ProjectId = Convert.ToInt32(reader["ProjectId"]),
                            ProjectName = reader["ProjectName"].ToString(),
                            Priority = reader["Priority"].ToString(),
                            Description = reader["Description"].ToString(),
                            Owner = reader["Owner"].ToString(),
                            StartDate = reader["StartDate"] != DBNull.Value ? Convert.ToDateTime(reader["StartDate"]) : (DateTime?)null,
                            EndDate = reader["EndDate"] != DBNull.Value ? Convert.ToDateTime(reader["EndDate"]) : (DateTime?)null,
                            Status = reader["Status"].ToString(),
                            TeamMembers = reader["TeamMembers"].ToString()
                        };
                        projects.Add(project);
                    }

                    // Return projects list as JSON response
                    return Request.CreateResponse(HttpStatusCode.OK, projects);
                }
            }
            catch (Exception)
            {
                // Return an error response if an exception occurs
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Failed to fetch projects! ");
            }
        }

        // POST: api/Projects/AddProject
        [HttpPost]
        [Route("api/Projects/AddProject")]
        public HttpResponseMessage AddProject(Project project)
        {
            try
            {
                // SQL query to insert a new project into the database
                string query = @"INSERT INTO Project (ProjectName, Priority, Description, Owner, StartDate, EndDate, Status, TeamMembers) 
                                 VALUES (@ProjectName, @Priority, @Description, @Owner, @StartDate, @EndDate, @Status, @TeamMembers)";

                // Using ADO.NET to execute the SQL query with parameters
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["EmployeeConnection"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@ProjectName", project.ProjectName);
                    cmd.Parameters.AddWithValue("@Priority", project.Priority);
                    cmd.Parameters.AddWithValue("@Description", project.Description);
                    cmd.Parameters.AddWithValue("@Owner", project.Owner);
                    cmd.Parameters.AddWithValue("@StartDate", project.StartDate);
                    cmd.Parameters.AddWithValue("@EndDate", project.EndDate);
                    cmd.Parameters.AddWithValue("@Status", project.Status);
                    cmd.Parameters.AddWithValue("@TeamMembers", project.TeamMembers);

                    con.Open();
                    cmd.ExecuteNonQuery();
                }

                // Return a success response
                return Request.CreateResponse(HttpStatusCode.OK, "Project Added Successfully!");
            }
            catch (Exception)
            {
                // Return an error response if an exception occurs
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Failed to Add Project! ");
            }
        }

        // PUT: api/Projects/UpdateProject
        [HttpPut]
        [Route("api/Projects/UpdateProject")]
        public HttpResponseMessage UpdateProject(Project project)
        {
            try
            {
                // SQL query to update a project in the database
                string query = @"UPDATE Project 
                                 SET ProjectName = @ProjectName, Priority = @Priority, Description = @Description, 
                                     Owner = @Owner, StartDate = @StartDate, EndDate = @EndDate, Status = @Status, TeamMembers = @TeamMembers 
                                 WHERE ProjectId = @ProjectId";

                // Using ADO.NET to execute the SQL query with parameters
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["EmployeeConnection"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@ProjectName", project.ProjectName);
                    cmd.Parameters.AddWithValue("@Priority", project.Priority);
                    cmd.Parameters.AddWithValue("@Description", project.Description);
                    cmd.Parameters.AddWithValue("@Owner", project.Owner);
                    cmd.Parameters.AddWithValue("@StartDate", project.StartDate);
                    cmd.Parameters.AddWithValue("@EndDate", project.EndDate);
                    cmd.Parameters.AddWithValue("@Status", project.Status);
                    cmd.Parameters.AddWithValue("@TeamMembers", project.TeamMembers);
                    cmd.Parameters.AddWithValue("@ProjectId", project.ProjectId); // Include the ProjectId for update

                    con.Open();
                    cmd.ExecuteNonQuery();
                }

                // Return a success response
                return Request.CreateResponse(HttpStatusCode.OK, "Project Updated Successfully!");
            }
            catch (Exception)
            {
                // Return an error response if an exception occurs
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Failed to Update Project! ");
            }
        }

        // DELETE: api/Projects/DeleteProject/{id}
        [HttpDelete]
        [Route("api/Projects/DeleteProject/{id}")]
        public HttpResponseMessage DeleteProject(int id)
        {
            try
            {
                // SQL query to delete a project from the database based on ProjectId
                string query = "DELETE FROM Project WHERE ProjectId = @ProjectId";

                // Using ADO.NET to execute the SQL query with a parameter
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["EmployeeConnection"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@ProjectId", id);

                    con.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();

                    // Check if any rows were affected to determine success
                    if (rowsAffected > 0)
                    {
                        return Request.CreateResponse(HttpStatusCode.OK, "Project Deleted Successfully!");
                    }
                    else
                    {
                        return Request.CreateResponse(HttpStatusCode.NotFound, "No project found with the provided ProjectId.");
                    }
                }
            }
            catch (Exception)
            {
                // Return an error response if an exception occurs
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Failed to Delete Project! ");
            }
        }
    }
}
