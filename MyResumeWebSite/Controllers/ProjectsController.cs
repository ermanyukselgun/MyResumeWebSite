using MyResumeWebSite.Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyResumeWebSite.Controllers
{
    public class ProjectsController : Controller
    {
        MyResumeEntities1 _dbContext = new MyResumeEntities1();
        // GET: Projects
        public ActionResult Index()
        {
            var model = _dbContext.MyProjects.ToList();
            return View(model);
        }


        [HttpGet]
        public ActionResult AddProject()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddProject(MyProject projects , HttpPostedFileBase picture)
        {
            if (ModelState.IsValid)
            {
                if (picture != null && picture.ContentLength > 0)
                {
                    FileInfo fileInfo = new FileInfo(picture.FileName);

                    string yeni = Guid.NewGuid().ToString() + fileInfo.Extension;//12345.jpeg
                    picture.SaveAs(Server.MapPath("~/Assets/img/" + yeni));

                    projects.Picture = yeni;
                    _dbContext.MyProjects.Add(projects);
                    _dbContext.SaveChanges();
                    return RedirectToAction("Index");
                }
                _dbContext.MyProjects.Add(projects);
                _dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            
            return View(projects);
        }
    }
}