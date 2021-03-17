using MyResumeWebSite.Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyResumeWebSite.Controllers
{
    public class UserController : Controller
    {
        MyResumeEntities _dbContext = new MyResumeEntities();     //connection
        // GET: User
        public ActionResult Index()
        {
            var model = _dbContext.User.ToList();
            return View(model);
        }


        [HttpGet]
        public ActionResult AddUser()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddUser(User user)
        {
            var model = _dbContext.User.Add(user);
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}