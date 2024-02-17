using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrackerAPI.Models
{
    public class DocumentsTable
    {

        public int DocumentId { get; set; } 

        public string Title { get; set; } 
        public string Content { get; set; } 
        public DateTime CreatedAt{ get; set; }
        public DateTime ModifiedAt { get; set; }



        
        public Document()
        {
            CreateTime = DateTime.Now;

        }
    }
}
      

        
    }
}