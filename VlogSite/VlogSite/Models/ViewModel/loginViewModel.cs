using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace VlogSite.Models.ViewModel
{
    public class loginViewModel
    {
        [Required(ErrorMessage = "Must type User Email correctly!")]
        public string userMail { get; set; }

        [Required(ErrorMessage = "Must Type Password correctly!")]
        [DataType(DataType.Password)]
        public string Password { get; set; }


    }
}
