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
                string query = "SELECT * FROM Project";

                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["EmployeeConnection"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))
                {
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Project project = new Project
                        {
                            ProjectId = Convert.ToInt32(reader["ProjectId"]),
                            ProjectName = reader["ProjectName"].ToString(),
                            Owner = reader["Owner"].ToString(),
                            CreatedOn = Convert.ToDateTime(reader["CreatedOn"]),
                            Description = reader["Description"].ToString(),
                            Teams = reader["Teams"].ToString()
                        };
                        projects.Add(project);
                    }

                    return Request.CreateResponse(HttpStatusCode.OK, projects);
                }
            }
            catch (Exception)
            {
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
                string query = @"INSERT INTO Project (ProjectName, Owner, CreatedOn, Description, Teams) 
                                 VALUES (@ProjectName, @Owner, @CreatedOn, @Description, @Teams)";

                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["EmployeeConnection"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@ProjectName", project.ProjectName);
                    cmd.Parameters.AddWithValue("@Owner", project.Owner);
                    cmd.Parameters.AddWithValue("@CreatedOn", project.CreatedOn);
                    cmd.Parameters.AddWithValue("@Description", project.Description);
                    cmd.Parameters.AddWithValue("@Teams", project.Teams);

                    con.Open();
                    cmd.ExecuteNonQuery();
                }

                return Request.CreateResponse(HttpStatusCode.OK, "Project Added Successfully!");
            }
            catch (Exception)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Failed to Add Project! ");
            }
        }

        // PUT: api/Projects/UpdateProject/{id}
        [HttpPut]
        [Route("api/Projects/UpdateProject/{id}")]
        public HttpResponseMessage UpdateProject(int id, Project project)
        {
            try
            {
                string query = @"UPDATE Project 
                         SET ProjectName = @ProjectName, Owner = @Owner, CreatedOn = @CreatedOn, 
                             Description = @Description, Teams = @Teams 
                         WHERE ProjectId = @ProjectId";

                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["EmployeeConnection"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@ProjectName", project.ProjectName);
                    cmd.Parameters.AddWithValue("@Owner", project.Owner);
                    cmd.Parameters.AddWithValue("@CreatedOn", project.CreatedOn);
                    cmd.Parameters.AddWithValue("@Description", project.Description);
                    cmd.Parameters.AddWithValue("@Teams", project.Teams);
                    cmd.Parameters.AddWithValue("@ProjectId", id); // Use id from the route URL

                    con.Open();
                    cmd.ExecuteNonQuery();
                }

                return Request.CreateResponse(HttpStatusCode.OK, "Project Updated Successfully!");
            }
            catch (Exception)
            {
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
                string query = "DELETE FROM Project WHERE ProjectId = @ProjectId";

                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["EmployeeConnection"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@ProjectId", id);

                    con.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();

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
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Failed to Delete Project! ");
            }
        }
    }
}
