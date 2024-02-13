using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TrackerAPI.Models
{
    public class TimeTracker
    {
        public int UserID { get; set; } 
        public int ProjectID { get; set; }

        [Key]
        public int TaskID { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int TotalWorkingHours { get; set; }

    }
}