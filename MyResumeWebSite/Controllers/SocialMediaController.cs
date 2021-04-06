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
        [Authorize]

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


        public ActionResult Update(SocialMediaTable xx)
        {
            var model = _dbContext.SocialMediaTable.Find(xx.Id);
            model.SocialMedia = xx.SocialMedia;
            model.MediaAdress = xx.MediaAdress;
            _dbContext.SaveChanges();
            return RedirectToAction("Index", "SocialMedia");
        }

        //public ActionResult Delete(int id)
        //{
        //    var del = _dbContext.SocialMediaTable.Find(id);
        //    if (del == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    _dbContext.SocialMediaTable.Remove(del);
        //    _dbContext.SaveChanges();
        //    return RedirectToAction("Index", "SocialMedia");
        //}

    }
}