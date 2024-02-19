using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrackerAPI.Models
{
    public class ReportProject
    {
        internal int projectId;

        public int ProjectID { get; set; }
        public string ProjectName { get; set; }
        public string ProjectDescription { get; set; }
        public string Owner { get; set; }
        public string TeamName { get; set; }
        public DateTime StartDate { get; set; }

    }
}