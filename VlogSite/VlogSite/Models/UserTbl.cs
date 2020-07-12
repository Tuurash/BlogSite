using System;
using System.Collections.Generic;

namespace VlogSite.Models
{
    public partial class UserTbl
    {
        public UserTbl()
        {
            BlogTbl = new HashSet<BlogTbl>();
            ContactTbl = new HashSet<ContactTbl>();
        }

        public int UserId { get; set; }
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public string UserPassword { get; set; }
        public string UserAbout { get; set; }
        public string UserPhoto { get; set; }

        public virtual ICollection<BlogTbl> BlogTbl { get; set; }
        public virtual ICollection<ContactTbl> ContactTbl { get; set; }
    }
}
