using MyResumeWebSite.Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyResumeWebSite.Controllers
{
    public class WorkExpController : Controller
    {
        MyResumeEntities1 _dbContext = new MyResumeEntities1();     //connection

        [Authorize]


        // GET: WorkExp
        public ActionResult Index()
        {
            var Experiens = _dbContext.WorkExperiance.ToList();
            return View(Experiens);
        }

        [HttpGet]
        public ActionResult AddExperiens()
        {
            return View();
        }


        [HttpPost]
        public ActionResult AddExperiens(WorkExperiance workExperiance)
        {
            if (workExperiance.Id == 0)
            {
                _dbContext.WorkExperiance.Add(workExperiance);
            }
            else
            {
                //Update
                _dbContext.Entry(workExperiance).State = System.Data.Entity.EntityState.Modified;
            }

            _dbContext.SaveChanges();
            return RedirectToAction("Index", "WorkExp");
        }

        //Update

        public ActionResult UpdateExperiens(int id)
        {
            var update = _dbContext.WorkExperiance.Find(id);
            if (update == null)
            {
                return HttpNotFound();
            }

            return View("AddExperiens", update);
        }

        public ActionResult DeleteExperiens(int id)
        {
            var del = _dbContext.WorkExperiance.Find(id);

            if (del == null)
            {
                return HttpNotFound();
            }

            _dbContext.WorkExperiance.Remove(del);
            _dbContext.SaveChanges();
            return RedirectToAction("Index", "WorkExp");
        }
    }
}