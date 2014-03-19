using KpiMetricsSystem.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace KpiMetricsSystem
{
    // This is useful if you do not want to tear down the database each time you run the application.
    // You want to create a new database if the Model changes
    // public class MyDbInitializer : DropCreateDatabaseIfModelChanges<MyDbContext>
    public class MyDbInitializer : DropCreateDatabaseAlways<MyDbContext>
    {
        protected override void Seed(MyDbContext context)
        {
            InitializeIdentityForEF(context);
            base.Seed(context);
        }

        private void InitializeIdentityForEF(MyDbContext context)
        {
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            var RoleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var myinfo = new MyUserInfo() { FirstName = "Andrew", LastName = "Le", Email = "Admin@mail.com" };
            string AdminRole = "Admin";
            string password = "password";
            string UserRole = "Staff";

            //Create staff role
            RoleManager.Create(new IdentityRole(UserRole));
            

            //Create Role Admin if it does not exist
            if (!RoleManager.RoleExists(AdminRole))
            {
                var roleresult = RoleManager.Create(new IdentityRole(AdminRole));
            }

            //Create User=Admin with password=123456
            var user = new ApplicationUser();
            user.UserName = myinfo.FirstName;
            user.MyUserInfo = myinfo;
            var adminresult = UserManager.Create(user, password);

            //Add User Admin to Role Admin
            if (adminresult.Succeeded)
            {
                var result = UserManager.AddToRole(user.Id, AdminRole);
            }
        }
    }
}