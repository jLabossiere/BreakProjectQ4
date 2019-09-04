using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BreakProjectWebApp.Models
{
    public class ProjectTask
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ProjectId { get; set; }
        public virtual Project Project { get; set; }
        public bool Complete { get; set; }
        public string DeveloperId { get; set; }
        public virtual ApplicationUser Developer { get; set; }
        public Priority Priority { get; set; }
        public DateTime DeadLine { get; set; }
    }
}