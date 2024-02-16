using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrackerAPI.Models
{
    public class Project
    {

        public int ProjectId { get; set; }
        public string ProjectName { get; set; }
        public string Owner { get; set; }
        public DateTime CreatedOn { get; set; }
        public string Description { get; set; }
        public string Teams { get; set; }

    }

}