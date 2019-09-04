using BreakProjectWebApp.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BreakProjectWebApp.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private RoleManager<IdentityRole> rolesManager;
        private UserManager<IdentityUser> usersManager;
        public HomeController()
        {
            rolesManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>());
            usersManager = new UserManager<IdentityUser>(new UserStore<IdentityUser>());
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult TaskView()
        {
            string UserId = User.Identity.GetUserId();
            var TaskCollection = db.ProjectTasks.Where(x => x.DeveloperId == UserId).ToList();
            return View(TaskCollection);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}