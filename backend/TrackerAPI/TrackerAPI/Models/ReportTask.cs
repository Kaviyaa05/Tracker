using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrackerAPI.Models
{
    public class ReportTask
    {

        public int ProjectID { get; set; }
        public int TaskID { get; set; }
        public int UserID { get; set; }
        public string Name { get; set; }
        public string Priority { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public string Owner { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

    }
}