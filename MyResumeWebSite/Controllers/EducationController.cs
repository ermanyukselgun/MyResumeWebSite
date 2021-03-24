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
            else
            {
                var update = _dbContext.Education.Find(education.Id);
                if (update == null)
                {
                    return HttpNotFound();
                }
                update.University = education.University;
                update.Faculty = education.Faculty;
                update.Department = education.Department;
                update.Degree = education.Degree;
                update.Date = education.Date;
            }
            _dbContext.SaveChanges();
            return RedirectToAction("Index", "Education");
        }

        public ActionResult Update(int id)
        {
            var model = _dbContext.Education.Find(id);

            if (model == null)
            {
                return HttpNotFound();
            }

            return View("AddEducation", model);
        }

        public ActionResult Delete (int id)
        {
            var model = _dbContext.Education.Find(id);

            if (model == null)
            {
                return HttpNotFound();
            }
            _dbContext.Education.Remove(model);
            _dbContext.SaveChanges();

            return RedirectToAction("Index", "Education");
        }
    }
}