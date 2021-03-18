using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyResumeWebSite.Models.EntityFramework;

namespace MyResumeWebSite.Models
{
    public class MediaViewModel
    {

        public IEnumerable<User>Users { get; set; }
        public SocialMediaTable socialMediaTable { get; set; }

    }
}