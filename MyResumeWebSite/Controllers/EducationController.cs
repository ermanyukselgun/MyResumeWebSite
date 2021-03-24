using MyResumeWebSite.Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyResumeWebSite.Controllers
{
    public class EducationController : Controller
    {
        MyResumeEntities1 _dbContext = new MyResumeEntities1();
        // GET: Education
        public ActionResult Index()
        {
            var education = _dbContext.Education.ToList();
            return View(education);
        }

        [HttpGet]
        public ActionResult AddEducation()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddEducation(Education education)
        {
            if( education.Id == 0)
            {
                _dbContext.Education.Add(education);
            }
            _dbContext.SaveChanges();
            return RedirectToAction("Index", "Education");
        }
    }
}