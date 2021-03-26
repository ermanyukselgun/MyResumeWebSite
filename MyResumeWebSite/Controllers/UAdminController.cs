using MyResumeWebSite.Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyResumeWebSite.Controllers
{
    [Authorize] //kullanıcı adı ve sifre girisi olmadan girisi yasaklar webconfig te ayarlama yapıldı



    public class UAdminController : Controller
    {
        MyResumeEntities1 _dbContext = new MyResumeEntities1();     //connection

        // GET: UAdmin
        public ActionResult Index()
        {
            var model = _dbContext.AdminUsers.ToList();
            return View(model);
        }

        [HttpGet]
        public ActionResult AddAdmin()
        {
            return View();
        }

        [HttpPost]

        public ActionResult AddAdmin(AdminUser user)
        {

            if (user.Id == 0)
            {
                _dbContext.AdminUsers.Add(user);
            }
            else
            {
                //update 
                _dbContext.Entry(user).State = System.Data.Entity.EntityState.Modified;


            }

            _dbContext.SaveChanges();
            return RedirectToAction("Index", "UAdmin");
        }

        //update
        public ActionResult UpdateAdmin(int id)
        {
            var update = _dbContext.AdminUsers.Find(id);
            if (update == null)
            {
                return HttpNotFound();
            }

            return View("AddAdmin", update);
        }

        public ActionResult DeleteAdmin(int id)
        {
            var del = _dbContext.AdminUsers.Find(id);

            if (del == null)
            {
                return HttpNotFound();
            }

            _dbContext.AdminUsers.Remove(del);
            _dbContext.SaveChanges();
            return RedirectToAction("Index", "UAdmin");
        }
    }
}