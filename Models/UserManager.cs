using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BreakProjectWebApp.Models
{
    public class UserManager
    {
        ApplicationDbContext db;
        public UserManager<ApplicationUser> userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>());
        public UserManager(ApplicationDbContext applicationDbContext)
        {
            this.db = applicationDbContext;
        }

        public ApplicationUser GetUser(string id)
        {
            return db.Users.Find(id);
        }

        public void AddRole(string id, string role)
        {
            var desiredUser = db.Users.FirstOrDefault(x => x.Id == id);
            if (!userManager.IsInRole(desiredUser.Id, role))
            {
                userManager.AddToRole(desiredUser.Id, role);
            }
        }

        public void RemoveFromRole(string id, string role)
        {
            var desiredUser = db.Users.FirstOrDefault(x => x.Id == id);
            if (userManager.IsInRole(desiredUser.Id, role))
            {
                userManager.RemoveFromRole(desiredUser.Id, role);
            }
        }
    }
}