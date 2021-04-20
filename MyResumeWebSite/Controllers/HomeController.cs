using MyResumeWebSite.Models;
using MyResumeWebSite.Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyResumeWebSite.Controllers
{
    public class HomeController : Controller
    {
        MyResumeEntities1 _dbContext = new MyResumeEntities1();  //Connection

        
        public ActionResult Index()
        {
            HomeModelView homeModelView = new HomeModelView();
            homeModelView.users = _dbContext.User.ToList();
            homeModelView.courses = _dbContext.Courses.ToList();
            homeModelView.D_Management = _dbContext.DatabaseManagement.ToList();
            homeModelView.educations = _dbContext.Education.ToList();
            homeModelView.G_Technology = _dbContext.GameTechnology.ToList();
            homeModelView.P_Language = _dbContext.ProgramingLanguage.ToList();
            homeModelView.references = _dbContext.Reference.ToList();
            homeModelView.socialMediaTables = _dbContext.SocialMediaTable.ToList();
            homeModelView.W_Technology = _dbContext.WebTechnology.ToList();
            homeModelView.workExperiances = _dbContext.WorkExperiance.ToList();
            homeModelView.coursesContents = _dbContext.CoursesContent.ToList();
            homeModelView.myProjects = _dbContext.MyProjects.ToList();

            return View(homeModelView);
        }
    }
}