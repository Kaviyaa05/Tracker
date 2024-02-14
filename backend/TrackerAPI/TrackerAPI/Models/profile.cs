using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrackerAPI.Models
{
    public class Profile
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Role { get; set; }

        public string About { get; set; }

        public string Password { get; set; }

        public string Address { get; set; }
        public string UserId { get; set; }
    }
}