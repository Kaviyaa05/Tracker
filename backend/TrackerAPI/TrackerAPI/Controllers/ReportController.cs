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
    public class ReportController : ApiController
    {
        ReportDao dao = new ReportDao();

        
        [HttpGet]
        [Route("api/report/Project")]
        //all projects
        public IHttpActionResult GetProject()
        {            
            var project = dao.fetchProject();
            return Ok(project);
        }

        [HttpGet]
        [Route("api/report/CreatedProject")]
        //created projects
        public IHttpActionResult GetCreatedProject(string owner)
        {
            Console.WriteLine("HI");
            var createdProj = dao.createdProject(owner);
            return Ok(createdProj);
        }

        [HttpGet]
        [Route("api/report/Task")]
        //task by type
        public IHttpActionResult GetTask()
        {
            var task = dao.fetchtask();
            return Ok(task);
        }


        [HttpGet]
        [Route("api/report/TaskByType")]
        //task by type
        public IHttpActionResult GetTasksByType(string type)
        {
            var tasktype = dao.GetTasksByType(type);
            return Ok(tasktype);
        }


        [HttpGet]
        [Route("api/report/TaskByPriority")]
        //task by priority
        public IHttpActionResult GetTaskByPriority(string priority)
        {
            var taskpriority = dao.GetTasksByPriority(priority);
            return Ok(taskpriority);
        }


        [HttpGet]
        [Route("api/report/overdue")]
        //over due 
        public IHttpActionResult GetOverDue()
        {
            
            var burndown = dao.GetOverdueTasks(DateTime.Now);
            return Ok(burndown);
        }


        [HttpGet]
        [Route("api/report/TaskAssigned")]
        //task assigned
        public IHttpActionResult GetTaskAssigned (string assign)
        {
            var taskassign = dao.taskAssigned(assign);
            return Ok(taskassign);
        }



        [HttpGet]
        [Route("api/report/TaskCreated")]
        //task created
        public IHttpActionResult GetTaskCreated(string create)
        {
            var taskcreate = dao.taskCreated(create);
            return Ok(taskcreate);
        }



        [HttpGet]
        [Route("api/report/Details")]
        public IHttpActionResult GetDetails (int id)
        {
            var taskdetail = dao.GetTaskDetails(id);
            return Ok(taskdetail);
        }
    }
}
