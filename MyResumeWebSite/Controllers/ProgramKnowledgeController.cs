using MyResumeWebSite.Models;
using MyResumeWebSite.Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyResumeWebSite.Controllers
{
    public class ProgramKnowledgeController : Controller
    {
        MyResumeEntities1 _dbContext = new MyResumeEntities1();  //Connection
        // GET: ProgramKnowledge
        public ActionResult Index()
        {
            ProgramKnowledgeModelView Knowledge = new ProgramKnowledgeModelView();
            Knowledge.P_Language = _dbContext.ProgramingLanguage.ToList();
            Knowledge.D_Management = _dbContext.DatabaseManagement.ToList();

            return View(Knowledge);
        }

        //================================================== Program Language ===================================================================
        [HttpGet]
        public ActionResult AddLanguage()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddLanguage(ProgramKnowledgeModelView language)
        {

            if (language.Prog_Language.Id == 0)
            {
                _dbContext.ProgramingLanguage.Add(language.Prog_Language);
            }
            else
            {
                //Update
                _dbContext.Entry(language.Prog_Language).State = System.Data.Entity.EntityState.Modified;
            }
            _dbContext.SaveChanges();

            return RedirectToAction("Index", "ProgramKnowledge");
        }

        public ActionResult UpdateLanguage(int id)
        {
            var model = new ProgramKnowledgeModelView()
            {
                Prog_Language = _dbContext.ProgramingLanguage.Find(id)
            };

            if (model == null)
            {
                return HttpNotFound();
            }

            return View("AddLanguage", model);
        }

        public ActionResult DeleteLanguage(int id)
        {
            var del = _dbContext.ProgramingLanguage.Find(id);
            if (del == null)
            {
                return HttpNotFound();
            }

            _dbContext.ProgramingLanguage.Remove(del);
            _dbContext.SaveChanges();
            return RedirectToAction("Index", "ProgramKnowledge");
        }

        //================================================== Data Management ===================================================================

        [HttpGet]
        public ActionResult AddDataManagement()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddDataManagement(ProgramKnowledgeModelView dataManagement)
        {

            if (dataManagement.Dat_Management.Id == 0)
            {
                _dbContext.DatabaseManagement.Add(dataManagement.Dat_Management);
            }
            else
            {
                //Update
                _dbContext.Entry(dataManagement.Dat_Management).State = System.Data.Entity.EntityState.Modified;
            }
            _dbContext.SaveChanges();

            return RedirectToAction("Index", "ProgramKnowledge");
        }

        public ActionResult UpdateDataManagement(int id)
        {
            var model = new ProgramKnowledgeModelView()
            {
                Dat_Management = _dbContext.DatabaseManagement.Find(id)
            };

            if (model == null)
            {
                return HttpNotFound();
            }

            return View("AddDataManagement", model);
        }
        public ActionResult DeleteDataManagement(int id)
        {
            var del = _dbContext.DatabaseManagement.Find(id);
            if (del == null)
            {
                return HttpNotFound();
            }

            _dbContext.DatabaseManagement.Remove(del);
            _dbContext.SaveChanges();
            return RedirectToAction("Index", "ProgramKnowledge");
        }
    }
}