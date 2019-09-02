using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BreakProjectWebApp.Models
{
    public class Project
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ProjectManagerId { get; set; }
        public virtual ApplicationUser ProjectManager { get; set; }
        public virtual ICollection<ApplicationUser> Developers { get; set; }
        public virtual ICollection<ProjectTask> Tasks { get; set; }
        public bool Complete { get; set; }
    }
}