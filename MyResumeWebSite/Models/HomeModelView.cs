using MyResumeWebSite.Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyResumeWebSite.Models
{
    public class HomeModelView
    {
        public IEnumerable<User> users { get; set; }
        public IEnumerable<Courses> courses { get; set; }
        public IEnumerable<CoursesContent> coursesContents { get; set; }
        public IEnumerable<Education> educations { get; set; }
        public IEnumerable<SocialMediaTable> socialMediaTables { get; set; }
        public IEnumerable<Reference> references { get; set; }
        public IEnumerable<ProgramingLanguage> P_Language { get; set; }
        public IEnumerable<DatabaseManagement> D_Management { get; set; }
        public IEnumerable<WebTechnology> W_Technology { get; set; }
        public IEnumerable<GameTechnology> G_Technology { get; set; }
        public IEnumerable<WorkExperiance> workExperiances { get; set; }
        public IEnumerable<MyProject> myProjects { get; set; }

    }
}