using MyResumeWebSite.Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MyResumeWebSite.Controllers
{
    public class SecurityController : Controller
    {
        private MyResumeEntities1 _dbContext = new MyResumeEntities1();     //connection

       


        // GET: Security
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(AdminUser adminUser)
        {
            var userLogin = _dbContext.AdminUsers.FirstOrDefault(i => i.UserName == adminUser.UserName && i.Password == adminUser.Password);

            if (adminUser != null)
            {
                FormsAuthentication.SetAuthCookie(adminUser.UserName, false);
                return RedirectToAction("Index", "UAdmin");
            }
            else
            {
                ViewBag.Message = "Please check your UserName or Password...";
                return View();
            }
        }


        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index","Home");
        }
    }
}