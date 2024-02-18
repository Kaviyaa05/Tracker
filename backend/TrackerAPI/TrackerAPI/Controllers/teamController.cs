using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;


namespace TrackerAPI.Controllers
{
    public class teamController : ApiController
    {
        //get
        public HttpResponseMessage Get()
        {
            string query = @"
            SELECT *
            FROM dbo.teams
            ";
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
        public HttpResponseMessage Post(team teamData)
        {
            try
            {
                string query = @"
            INSERT INTO dbo.teams (TeamName, TeamMemberList)
            VALUES ( @TeamName, @TeamMemberList)
        ";

                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["Kaviya"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))
                {

                    cmd.Parameters.AddWithValue("@TeamName", teamData.TeamName);
                    cmd.Parameters.AddWithValue("@TeamMemberList", teamData.TeamMemberList);

                    con.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        return Request.CreateResponse(HttpStatusCode.Created, "Data inserted successfully");
                    }
                    else
                    {
                        return Request.CreateResponse(HttpStatusCode.InternalServerError, "Failed to insert data");
                    }
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Failed to insert data: " + ex.Message);
            }
        }
    }
}
