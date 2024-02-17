using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrackerAPI.Dao
{
    public class Data
    {
        public int NId { get; set; }
        public string Username { get; set; }
        public DateTime Time { get; set; }
        public string Message { get; set; }
        public string Priority { get; set; }
        public Boolean isRead { get; set; }
    }
}