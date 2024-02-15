using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrackerAPI.Models
{
    public class Pdf
    {
        public int ProjectID { get; set; }
        public string ProjectName { get; set; }
        public string ProjectOwner { get; set; }
        public DateTime ProjectCreatedOn { get; set; }
        public string Team { get; set; }
        public int TaskID { get; set; }
        public string TaskName { get; set; }
        public string TaskType { get; set; }
        public string TaskPriority { get; set; }
        public string Owner { get; set; }
        public string AssignedTo { get; set; }
        public string TaskDescription { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}