using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TrackerAPI
{
    public class team
    {

        [Key]

        public int TeamID { get; set; }

        [Required]
        public int ProjectID { get; set; }

        [Required]
        [StringLength(100)]
        public string TeamName { get; set; }

        [StringLength(255)]
        public string TeamMemberList { get; set; }
    }
}