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
        // GET: api/Report

        [HttpGet]
        [Route("api/Report/Project")]
        public IHttpActionResult GetProjects()
        {
            var projects = dao.fetchProjects();
            return Ok(projects);
        }



        [HttpGet]
        [Route("api/Report/Task")]
        public IHttpActionResult GetTasks()
        {
            var tasks = dao.fetchTask();
            return Ok(tasks);
        }


        [HttpGet]
        [Route("api/Report/TaskByType")]
        public IHttpActionResult GetTaskByType(string taskType)
        {
            var tasks = dao.fetchTaskByType(taskType);
            return Ok(tasks);
        }


        [HttpGet]
        [Route("api/Report/taskPriority")]
        public IHttpActionResult GetTaskPriority(string taskPriority)
        {
            var taskpriority = dao.fetchTaskByPriority(taskPriority);
            return Ok(taskpriority);
        }


        [HttpGet]
        [Route("api/Report/projectPriority")]
        public IHttpActionResult GetProjectPriority(string priority)
        {
            var projectPriority = dao.fetchProjectByPriority(priority);
            return Ok(projectPriority);
        }


        [HttpGet]
        [Route("api/Report/OverDue")]
        public IHttpActionResult GetOverDue()
        {
            var overdue = dao.fetchOverdue(DateTime.Now);
            return Ok(overdue);
        }

        [HttpGet]
        [Route("api/report/ProjectOverdue")]
        public IHttpActionResult GetProjectOverDue()
        {
            var overdue = dao.fetchOverdue(DateTime.Now);
            return Ok(overdue);
        }


       /* [HttpPost]
        [Route("api/Report/GeneratePdf")]
        public IHttpActionResult GeneratePdf()
        {
            List<Task> tasks = dao.fetchTask();
            Pdf pdfGenerator = new Pdf();
            var outpath = "downloads/report.pdf";
            pdfGenerator.GeneratePdf(tasks, outpath);
            return Ok(outpath);

        }*/

        [HttpGet]
        [Route("api/report/details")]
        public IHttpActionResult GetDetails(int id)
        {
            var detail = dao.fetchTaskDetails(id);
            return Ok(detail);
        }

    }
}
