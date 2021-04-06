using MyResumeWebSite.Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyResumeWebSite.Controllers
{
    public class CoursesController : Controller
    {

        MyResumeEntities1 _dbContext = new MyResumeEntities1(); //Connection

        [Authorize]
        // GET: Courses
        public ActionResult Index()
        {
            var model = _dbContext.CoursesContent.ToList();
            return View(model);
        }

        [HttpGet]
        public ActionResult AddCourses()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddCourses(CoursesContent content)
        {            
            if (content.Id == 0)
            {
                _dbContext.CoursesContent.Add(content);
            }
            else
            {
                var update = _dbContext.CoursesContent.Find(content.Id);
                if (update == null)
                {
                    return HttpNotFound();
                }
                update.Courses.CourseName = content.Courses.CourseName;
                update.Courses.Company = content.Courses.Company;
                update.CourseContent = content.CourseContent;
                update.Courses.Date = content.Courses.Date;
            }

            _dbContext.SaveChanges();

            return RedirectToAction("Index", "Courses");

        }
        public ActionResult Update(int id)
        {
            var model = _dbContext.CoursesContent.Find(id);
            if (model == null)
            {
                return HttpNotFound();
            }

            return View("AddCourses", model);
        }

        public ActionResult Delete(int id)
        {
            var model = _dbContext.CoursesContent.Find(id);
            if (model == null)
            {
                return HttpNotFound();
            }
            _dbContext.CoursesContent.Remove(model);

            var data = _dbContext.Courses.Find(id);
            if (data == null)
            {
                return HttpNotFound();
            }
            _dbContext.Courses.Remove(data);

            _dbContext.SaveChanges();
            return RedirectToAction("Index", "Courses");
        }
    }
}