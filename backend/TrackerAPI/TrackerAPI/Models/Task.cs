using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrackerAPI.Models
{
    public class Task
    {
        public int TaskId { get; set; }
        public int UserId { get; set; }
        public string Taskname { get; set; }
        public string TaskType { get; set; }
        public string Priority { get; set; }
        public string CreatedBy { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Status { get; set; }
        public string Description { get; set; }

    }
}