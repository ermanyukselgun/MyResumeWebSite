using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyResumeWebSite.Models.EntityFramework;

namespace MyResumeWebSite.Models
{
    public class ProgramKnowledgeModelView
    {
        public IEnumerable<ProgramingLanguage> P_Language { get; set; }
        public IEnumerable<DatabaseManagement> D_Management { get; set; }
        public IEnumerable<WebTechnology> W_Technology { get; set; }
        public IEnumerable<GameTechnology> G_Technology { get; set; }

        public ProgramingLanguage Prog_Language { get; set; }
        public DatabaseManagement Dat_Management { get; set; }
        public WebTechnology Web_Tech { get; set; }
        public GameTechnology Game_Tech { get; set; }



    }
}