using TrackerAPI.DataAccessLayer;
using System.Web.Http;
using TrackerAPI.Utils;
using System.Web.Http.Cors;

namespace TrackerAPI.Controllers
{
    
    public class DataController : ApiController
    {

        // GET api/values
        [Authorize]
        public IHttpActionResult Get()
        {
            AuthDAO authDAO = new AuthDAO();

            var username = User.GetUsername();
            var role = User.GetRole();

            return Ok($"UserName: {username}, Role: {role}");
        }
    }
}
