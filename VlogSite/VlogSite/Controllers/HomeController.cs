using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using VlogSite.Models;
using VlogSite.Models.ViewModel;
using VlogSite.Repository;

namespace VlogSite.Controllers
{
    public class HomeController : Controller
    {
     
        IRepository<UserTbl> userRep = new UserRepo ();

        private readonly ILogger<HomeController> _logger;

        private readonly IWebHostEnvironment WebHostEnvironment;

        public HomeController(ILogger<HomeController> logger,IWebHostEnvironment webHostEnvironment)
        {
            _logger = logger;
            WebHostEnvironment = webHostEnvironment;
        }

        public ActionResult Login()
        {
            return View();
        }


        public IActionResult Index2()
        {
            
            return View(userRep.GetAll());
        }

        public IActionResult Register2()
        {
            return View();
        }
        
        [HttpPost]

        public IActionResult Register2(userViewModel usrVm)
        {
            BlogContext bc = new BlogContext();


            //string FileName = UploadFile(usrVm);
            string FileName = "30e9b737-e94a-4778-a827-e046858b174d-avatar.png";

            var user = new UserTbl
            {
                UserName= usrVm.UserName,
                UserEmail=usrVm.UserEmail,
                UserPassword=usrVm.UserPassword,
                UserPhoto = FileName
            };
            bc.UserTbl.Add(user);
            bc.SaveChanges();

            return RedirectToAction("Index2");
        }

        private string UploadFile(userViewModel usrVm)
        {
            

            string fileName = null;

            if (usrVm.UserPhoto != null)
            {
                string uploadDir = Path.Combine(WebHostEnvironment.WebRootPath,"Image");
                fileName = Guid.NewGuid().ToString() + "-" + usrVm.UserPhoto.FileName;
                string filePath = Path.Combine(uploadDir, fileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    usrVm.UserPhoto.CopyTo(fileStream);
                }
            }
            return fileName;
        }


        // UserDetails

        public IActionResult usrDetails(int ID)
        {

            return View(userRep.Get(ID));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
