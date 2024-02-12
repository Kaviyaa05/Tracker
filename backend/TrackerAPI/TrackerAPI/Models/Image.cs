using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrackerAPI.Models
{
    public class Image
    {
        //Implementing getter setter
        public int Id { get; set; }

        public byte[] PhotoData { get; set; }
    }
}