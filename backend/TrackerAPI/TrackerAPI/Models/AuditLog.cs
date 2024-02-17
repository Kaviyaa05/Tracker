using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrackerAPI.Models
{
    public class AuditLog
    {
        public DateTime Date_And_Time { get; set; }
        public string UserName { get; set; }
        public string Module { get; set; }
        public string Action { get; set; }
    }
}
