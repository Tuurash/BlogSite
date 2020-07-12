using System;
using System.Collections.Generic;

namespace VlogSite.Models
{
    public partial class ContactTbl
    {
        public int ContactId { get; set; }
        public string LinkedinUrl { get; set; }
        public string Email { get; set; }
        public string WebsiteUrl { get; set; }
        public int UserId { get; set; }

        public virtual UserTbl User { get; set; }
    }
}
