using VlogSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace VlogSite.Repository
{
    public class blogRepo : Repository<BlogTbl>, IblogRepo
    {
        BlogContext context = new BlogContext();

        public IEnumerable<BlogTbl> userBlogs(int userID)
        {
            return context.BlogTbl.Where(x => x.UserId == userID).ToList();
        }


    }
}