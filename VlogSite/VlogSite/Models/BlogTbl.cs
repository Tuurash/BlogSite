using System;
using System.Collections.Generic;

namespace VlogSite.Models
{
    public partial class BlogTbl
    {
        public int BlogId { get; set; }
        public string BlogName { get; set; }
        public string BlogBody { get; set; }
        public string BlogPhoto { get; set; }
        public int UserId { get; set; }
    }
}
