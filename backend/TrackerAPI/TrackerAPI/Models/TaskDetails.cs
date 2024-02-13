using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrackerAPI.Models
{
    public class TaskDetails
    {
        public int ProjectID { get; set; }
        public string ProjectName { get; set; }
        public int TaskID { get; set; }
        public int UserID { get; set; }
        public string ProjectPriority { get; set; }
        public string TaskName { get; set; }
        public string TaskPriority { get; set; }
        
        public string TaskType { get; set; }
        public string Description { get; set; }
        public string Assigned_By { get; set; }       
        public string Teams { get; set;}        
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}