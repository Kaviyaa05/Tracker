﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrackerAPI.Models
{
    public class Table
    {
      

        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime ModifiedAt { get; set; }
      

        
    }
}