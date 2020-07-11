using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VlogSite.Models.ViewModel
{
    public class userViewModel
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public string UserPassword { get; set; }
        public string UserAbout { get; set; }
        
       
        public IFormFile UserPhoto { get; set; }
    }
}
