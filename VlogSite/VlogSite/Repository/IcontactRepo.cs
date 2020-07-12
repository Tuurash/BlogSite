using VlogSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace VlogSite.Repository
{
    interface IcontactRepo : IRepository<ContactTbl>
    {
        ContactTbl userContact(int userID);
    }
}
