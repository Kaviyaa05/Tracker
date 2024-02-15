using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;

namespace TrackerAPI.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]

    public class ImageController : ApiController
    {
        // GET: Images
        public HttpResponseMessage Get()
        {
            try
            {
                //Query to get data
                string query = @"SELECT Id, PhotoData FROM dbo.upload";
                DataTable table = new DataTable();
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["ImageDB"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    da.Fill(table);
                }

                // converting the bytes[] values of images to string values
                List<object> images = new List<object>();
                foreach (DataRow row in table.Rows)
                {
                    string base64String = Convert.ToBase64String((byte[])row["PhotoData"]);
                    images.Add(new { Id = row["Id"], PhotoData = base64String });
                }

                return Request.CreateResponse(HttpStatusCode.OK, images);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Failed to retrieve data: " + ex.Message);
            }
        }


        // POST: Images
        public string Post()
        {
            try
            {
                var httpRequest = HttpContext.Current.Request;

                // check the presence of files
                if (httpRequest.Files.Count < 1)
                {
                    return "No files uploaded";
                }

                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["ImageDB"].ConnectionString))
                {
                    con.Open();

                    // Loop through each file
                    foreach (string file in httpRequest.Files)
                    {
                        var postedFile = httpRequest.Files[file];

                        if (postedFile != null && postedFile.ContentLength > 0)
                        {
                            byte[] fileData;
                            using (var binaryReader = new System.IO.BinaryReader(postedFile.InputStream))
                            {
                                fileData = binaryReader.ReadBytes((int)postedFile.InputStream.Length);
                            }
                            //Query to post data
                            string query = @"INSERT INTO dbo.upload(PhotoData) VALUES (@PhotoData)";
                            using (var cmd = new SqlCommand(query, con))
                            {
                                cmd.Parameters.Add("@PhotoData", SqlDbType.VarBinary).Value = fileData;
                                cmd.ExecuteNonQuery();
                            }
                        }
                    }

                    con.Close();
                }

                return "Images added successfully";
            }
            catch (Exception ex)
            {
                return "Failed to add images: " + ex.Message;
            }
        }
    }
}
