using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrackerAPI.Models
{
    public class Comment
    {
        public int CommentId { get; set; }
        public int TaskId { get; set; }
        public int ProjectId { get; set; }
        public string CommentedData { get; set; }
        public DateTime DateTimePosted { get; set; }
    }
}