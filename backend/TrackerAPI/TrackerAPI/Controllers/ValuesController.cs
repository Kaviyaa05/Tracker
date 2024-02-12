using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using TrackerAPI.Dao;

namespace TrackerAPI.Controllers
{

    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ValuesController : ApiController
    {
        // GET api/values



        // GET api/values
        private readonly Dao1 dao = new Dao1();

        [EnableCors("*", "*", "*")]


        public IHttpActionResult Get()
        {
            try
            {
                var records = dao.Show();


                return Ok(records);

            }
            catch (Exception ex)
            {
                // Handle exceptions and return appropriate response
                Console.WriteLine(ex.Message);
                return InternalServerError();
            }
        }


        // GET api/values/5
        public IHttpActionResult Get(int id)
        {
            var currentuser = dao.getId(id);
            return Ok(currentuser);

        }

        // POST api/values
        public string Post([FromBody] Data data)
        {
            dao.Insert(data);
            return "data added";
        }

        // PUT api/values/5
        public string Put(int id, [FromBody] Data data)
        {
            dao.update(data);
            return "marked as read";
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
