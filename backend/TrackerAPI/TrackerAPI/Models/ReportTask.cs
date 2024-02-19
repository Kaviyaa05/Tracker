using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrackerAPI.Models
{
    public class ReportTask
    {
        public int ProjectId { get; set; }
        public string ProjectName { get; set; }
        public int TaskId { get; set; }
        public string taskName { get; set; }
        public string taskType { get; set; }
        public string taskPriority { get; set; }
        public string taskDescription { get; set; }
        public string owner { get; set; }
        public string assigned { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
    }
}