using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BreakProjectWebApp.Models
{
    public class ProjectManager
    {
        ApplicationDbContext db { get; set; }
        public UserManager<ApplicationUser> userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>());
        public RoleManager<IdentityRole> roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new ApplicationDbContext()));

        public ProjectManager(ApplicationDbContext applicationDbContext)
        {
            this.db = applicationDbContext;
        }

        public void ChangeManager(string userId, int projectId)
        {
            var managerRole = db.Roles.Where(x => x.Name == "Manager").FirstOrDefault();
            var desiredProject = db.Projects.Where(x => x.Id == projectId).FirstOrDefault();
            var desiredManager = db.Users.Where(x => x.Id == userId).FirstOrDefault();

            if (desiredManager.Roles.Where(x=>x.RoleId == managerRole.Id).Count() > 0)
            {
                desiredProject.ProjectManagerId = desiredManager.Id;
            }
        }

        //public void 
    }

    
}