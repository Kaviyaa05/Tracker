using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrackerAPI.Models
{
    public class DocumentsTable
    {

        public int DocumentId { get; set; } // Primary Key

        public int UserId { get; set; } // Foreign Key
        public int ProjectId { get; set; } // Foreign Key
        public DateTime CreateTime { get; set; }
        public string DocumentData { get; set; }



        // Constructor to set CreatedAt and ModifiedAt when the object is instantiated
        public Document()
        {
            CreateTime = DateTime.Now;

        }
    }
}
      

        
    }
}