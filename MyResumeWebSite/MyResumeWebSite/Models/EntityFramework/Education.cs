//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MyResumeWebSite.Models.EntityFramework
{
    using System;
    using System.Collections.Generic;
    
    public partial class Education
    {
        public int Id { get; set; }
        public string University { get; set; }
        public string Faculty { get; set; }
        public string Department { get; set; }
        public string Degree { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
    }
}
