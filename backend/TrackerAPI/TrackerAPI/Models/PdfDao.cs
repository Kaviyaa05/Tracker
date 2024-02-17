using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrackerAPI.Models
{
    public class PdfDao
    {

        private static List<Pdf> tasks = new List<Pdf>
        {
            new Pdf { TaskID = 1, ProjectID = 1, ProjectName = "Task 1", TaskDescription = "Description of Task 1", TaskPriority = "High", TaskType = "Type A", StartDate = DateTime.Now, Owner = "John Doe", EndDate = DateTime.Now.AddDays(7) },
            new Pdf { TaskID = 2, ProjectID = 1, ProjectName = "Task 2", TaskDescription = "Description of Task 2", TaskPriority = "Medium", TaskType = "Type B", StartDate = DateTime.Now, Owner = "Jane Smith", EndDate = DateTime.Now.AddDays(5) },
            new Pdf { TaskID = 3, ProjectID = 2, ProjectName = "Task 3", TaskDescription = "Description of Task 3", TaskPriority = "Low", TaskType = "Type C", StartDate = DateTime.Now, Owner = "Bob Johnson", EndDate = DateTime.Now.AddDays(10) }
        };

        public List<Pdf> GetAllTasks()
        {
            return tasks;
        }

        public Pdf GetTaskById(int taskId)
        {
            return tasks.FirstOrDefault(t => t.TaskID == taskId);
        }

        public void AddTask(Pdf task)
        {
            // Simulate generating TaskID
            task.TaskID = tasks.Count + 1;
            tasks.Add(task);
        }

        public void UpdateTask(int taskId, Pdf updatedTask)
        {
            var existingTask = tasks.FirstOrDefault(t => t.TaskID == taskId);
            if (existingTask != null)
            {
                existingTask.ProjectID = updatedTask.ProjectID;
                existingTask.ProjectName = updatedTask.ProjectName;
                existingTask.TaskDescription = updatedTask.TaskDescription;
                existingTask.TaskPriority = updatedTask.TaskPriority;
                existingTask.TaskType = updatedTask.TaskType;
                existingTask.StartDate = updatedTask.StartDate;
                existingTask.Owner = updatedTask.Owner;
                existingTask.EndDate = updatedTask.EndDate;
            }
        }

        public void DeleteTask(int taskId)
        {
            var taskToRemove = tasks.FirstOrDefault(t => t.TaskID == taskId);
            if (taskToRemove != null)
            {
                tasks.Remove(taskToRemove);
            }
        }

    }
}