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
        MyResumeEntities1 _dbContext = new MyResumeEntities1();     //connection

        [Authorize]

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
            
            if(user.Id == 0)
            {
                _dbContext.User.Add(user);
            }
            else
            {
                //update //Classic Method
                var update = _dbContext.User.Find(user.Id);
                if(update == null)
                {
                    return HttpNotFound();
                }
                update.Name = user.Name;
                update.Surname = user.Surname;
                update.Phone = user.Phone;
                update.Adress = user.Adress;
            }

            _dbContext.SaveChanges();
            return RedirectToAction("Index","User");
        }

        public ActionResult Update(int id)
        {
            var model = _dbContext.User.Find(id);  //get id


            return View("AddUser", model);
        }

        public ActionResult Delete(int id)
        {
            var delete = _dbContext.User.Find(id);

            if (delete == null)
            {
                return HttpNotFound();
            }
            _dbContext.User.Remove(delete);
            _dbContext.SaveChanges();

            return RedirectToAction("Index", "User");
        }
    }
}