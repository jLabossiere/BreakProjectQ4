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

        
    }
}