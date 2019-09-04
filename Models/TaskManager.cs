using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BreakProjectWebApp.Models
{
    public class TaskManager
    {
        ApplicationDbContext db { get; set; }
        public UserManager<ApplicationUser> userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>());
        public RoleManager<IdentityRole> roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new ApplicationDbContext()));

        public TaskManager(ApplicationDbContext applicationDbContext)
        {
            this.db = applicationDbContext;
        }

        public void AddToTask(string userId, int TaskId)
        {
            var desiredTask = db.ProjectTasks.FirstOrDefault(x => x.Id == TaskId);
            desiredTask.DeveloperId = db.Users.FirstOrDefault(x => x.Id == userId).Id;
        }

        public void AddTask(int ProjectId, string Name, Priority priority, DateTime Deadline)
        {
            ProjectTask newTask = new ProjectTask() {ProjectId = ProjectId, Name = Name, Complete = false, Priority = priority, DeadLine = Deadline };
            db.ProjectTasks.Add(newTask);
        }

        public void RemoveTask(int taskId)
        {
            ProjectTask targetTask = db.ProjectTasks.FirstOrDefault(x => x.Id == taskId);
            db.ProjectTasks.Remove(targetTask);
        }


    }
}