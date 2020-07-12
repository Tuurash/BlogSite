using VlogSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace VlogSite.Repository
{
    public class contactRepo : Repository<ContactTbl>, IcontactRepo
    {
        BlogContext context = new BlogContext();        

        public ContactTbl userContact(int userID)
        {
            ContactTbl uc= context.ContactTbl.FirstOrDefault(x => x.UserId == userID);
            return uc;
        }


    }
}