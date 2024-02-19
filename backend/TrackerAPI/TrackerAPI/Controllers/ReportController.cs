using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using TrackerAPI.Models;

namespace TrackerAPI.Controllers
{
    [EnableCors(origins:"*" , headers:"*" , methods: "*")]
    public class ReportController : ApiController
    {
        ReportDao dao = new ReportDao();

        
        [HttpGet]
        //all projects
        public IHttpActionResult GetProject()
        {            
            var project = dao.fetchProject();
            return Ok(project);
        }

        [HttpGet]
        [Route("api/report/createproject/{owner}")]
        //created projects
        public IHttpActionResult GetCreatedProject(string owner)
        {
            Console.WriteLine("HI");
            var createdProj = dao.createdProject(owner);
            return Ok(createdProj);
        }


        [HttpGet]
        [Route("api/report/taskbytype/{type}")]
        //task by type
        public IHttpActionResult GetTasksByType(string type)
        {
            var tasktype = dao.GetTasksByType(type);
            return Ok(tasktype);
        }


        [HttpGet]
        [Route("api/report/taskbypriority/{priority}")]
        //task by priority
        public IHttpActionResult GetTaskByPriority(string priority)
        {
            var taskpriority = dao.GetTasksByPriority(priority);
            return Ok(taskpriority);
        }


        [HttpGet]
        //over due 
        public IHttpActionResult GetOverDue (DateTime currentdate)
        {
            var burndown = dao.GetOverdueTasks(DateTime.Now);
            return Ok(burndown);
        }


        [HttpGet]
        [Route("api/report/taskassigned/{assign}")]
        //task assigned
        public IHttpActionResult GetTaskAssigned (string assign)
        {
            var taskassign = dao.taskAssigned(assign);
            return Ok(taskassign);
        }



        [HttpGet]
        [Route("api/report/taskcreated/{create}")]
        //task created
        public IHttpActionResult GetTaskCreated(string create)
        {
            var taskcreate = dao.taskCreated(create);
            return Ok(taskcreate);
        }



        [HttpGet]
        [Route("api/report/details/{id}")]
        public IHttpActionResult GetDetails (int id)
        {
            var taskdetail = dao.GetTaskDetails(id);
            return Ok(taskdetail);
        }
    }
}
