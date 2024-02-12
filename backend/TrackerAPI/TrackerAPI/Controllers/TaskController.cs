using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using TrackerAPI.Models;

namespace TrackerAPI.Controllers
{
    public class TaskController : ApiController
    {

        private static List<Task> tasks = new List<Task>
        {

            new Task { TaskID = 1, ProjectID = 1, UserID = 1, Name = "Task 1", Description = "Description of Task 1", Priority = "High", Type = "Type A", StartDate = DateTime.Now, Owner = "John Doe", EndDate = DateTime.Now.AddDays(7) },
            new Task { TaskID = 2, ProjectID = 1, UserID = 2, Name = "Task 2", Description = "Description of Task 2", Priority = "Medium", Type = "Type B", StartDate = DateTime.Now, Owner = "Jane Smith", EndDate = DateTime.Now.AddDays(5) },
            new Task { TaskID = 3, ProjectID = 2, UserID = 3, Name = "Task 3", Description = "Description of Task 3", Priority = "Low", Type = "Type C", StartDate = DateTime.Now, Owner = "Bob Johnson", EndDate = DateTime.Now.AddDays(10) }
        };

        // GET api/task
        public IEnumerable<Task> Get()
        {
            return tasks;
        }

        // GET api/task/5
        public IHttpActionResult Get(int id)
        {
            var task = tasks.FirstOrDefault(t => t.TaskID == id);
            if (task == null)
            {
                return NotFound();
            }
            return Ok(task);
        }

        // POST api/task
        public IHttpActionResult Post([FromBody] Task task)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            tasks.Add(task);
            return CreatedAtRoute("DefaultApi", new { id = task.TaskID }, task);
        }

        // PUT api/task/5
        public IHttpActionResult Put(int id, [FromBody] Task task)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var existingTask = tasks.FirstOrDefault(t => t.TaskID == id);
            if (existingTask == null)
            {
                return NotFound();
            }

            existingTask.ProjectID = task.ProjectID;
            existingTask.UserID = task.UserID;
            existingTask.Name = task.Name;
            existingTask.Description = task.Description;
            existingTask.Priority = task.Priority;
            existingTask.Type = task.Type;
            existingTask.StartDate = task.StartDate;
            existingTask.Owner = task.Owner;
            existingTask.EndDate = task.EndDate;

            return StatusCode(HttpStatusCode.NoContent);
        }

        // DELETE api/task/5
        public IHttpActionResult Delete(int id)
        {
            var task = tasks.FirstOrDefault(t => t.TaskID == id);
            if (task == null)
            {
                return NotFound();
            }

            tasks.Remove(task);
            return Ok(task);
        }
    }
}




