using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VlogSite.Repository;

namespace VlogSite.Models.ViewModel
{
    public class userDetailviewModel
    {
        public IEnumerable<BlogTbl> userBlogs { get; set; }
        public UserTbl userDtail { get; set; }

        public ContactTbl userContact { get; set; }
    }
}
