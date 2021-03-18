using MyResumeWebSite.Models;
using MyResumeWebSite.Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyResumeWebSite.Controllers
{
    public class SocialMediaController : Controller
    {
        MyResumeEntities _dbContext = new MyResumeEntities();
        // GET: SocialMedia
        public ActionResult Index()
        {
            var media = _dbContext.SocialMediaTable.ToList();
            return View(media);
        }


        [HttpGet]
        public ActionResult AddMedia()
        {
            var model = new MediaViewModel()
            {
                Users = _dbContext.User.ToList(),
                socialMediaTable = new SocialMediaTable()
            };

            return View(model);
        }


        [HttpPost]
        public ActionResult AddMedia(SocialMediaTable socialMedia)
        {

            if (socialMedia.Id == 0)
            {
                _dbContext.SocialMediaTable.Add(socialMedia);
            }


            _dbContext.SaveChanges();
            return RedirectToAction("Index", "SocialMedia");
            
            
        }

    }
}