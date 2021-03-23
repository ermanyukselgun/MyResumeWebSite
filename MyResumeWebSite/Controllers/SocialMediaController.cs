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
        MyResumeEntities1 _dbContext = new MyResumeEntities1();
        // GET: SocialMedia
        public ActionResult Index()
        {
            var socialMediaTables = _dbContext.SocialMediaTable.ToList();
            return View(socialMediaTables);
        }


        [HttpGet]
        public ActionResult AddMedia()
        {
            return View();
        }


        [HttpPost]
        public ActionResult AddMedia(SocialMediaTable socialMediaTable)
        {
            if(socialMediaTable.Id == 0)
            {
                _dbContext.SocialMediaTable.Add(socialMediaTable);
            }
            
            _dbContext.SaveChanges();
            return RedirectToAction("Index","SocialMedia");
        }

        public ActionResult GetData(int Id)
        {
            var data = _dbContext.SocialMediaTable.Find(Id); //Id yı yakalayıp get data sayfasına yonledirdik
            return View("GetData", data);
        }
        public ActionResult Update(SocialMediaTable socialMediaTable)
        {
            var model = _dbContext.SocialMediaTable.Find(socialMediaTable.Id);
            model.SocialMedia = socialMediaTable.SocialMedia;
            model.MediaAdress = socialMediaTable.MediaAdress;
            _dbContext.SaveChanges();
            return RedirectToAction("Index", "SocialMedia");
        }

    }
}