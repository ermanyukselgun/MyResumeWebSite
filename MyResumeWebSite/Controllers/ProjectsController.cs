using MyResumeWebSite.Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
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

        public ActionResult Update(int id)
        {
            var update = _dbContext.MyProjects.Find(id);
            if (update == null)
            {
                return HttpNotFound();
            }

            return View(update);
        }
        [HttpPost]
        public ActionResult Update(MyProject myProject, HttpPostedFileBase picture)
        {
            if (ModelState.IsValid)
            {
                var model = _dbContext.MyProjects.Find(myProject.Id);
                if (model != null && picture != null && picture.ContentLength > 0)
                {
                    FileInfo fileInfo = new FileInfo(picture.FileName);
                    string yeni = Guid.NewGuid().ToString() + fileInfo.Extension;//12345.jpeg
                    picture.SaveAs(Server.MapPath("~/Assets/img/" + yeni));
                    myProject.Picture = yeni;

                    model.projectName = myProject.projectName;
                    model.projectContent = myProject.projectContent;
                    model.projectLanguage = myProject.projectLanguage;
                    model.Picture = myProject.Picture;
                    _dbContext.SaveChanges();
                    return RedirectToAction("Index");

                }
            }
            return View(myProject);

        }

        public ActionResult Delete(int id)
        {
            var del = _dbContext.MyProjects.Find(id);

            if (del == null)
            {
                return HttpNotFound();
            }

            _dbContext.MyProjects.Remove(del);
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}