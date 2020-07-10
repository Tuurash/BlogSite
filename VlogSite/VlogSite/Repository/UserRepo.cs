using VlogSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace VlogSite.Repository
{
    public class UserRepo : Repository<UserTbl>, IUserRepo
    {


        public IEnumerable<UserTbl> GetHighestPaidEmployees()
        {
            throw new NotImplementedException();
        }


    }
}