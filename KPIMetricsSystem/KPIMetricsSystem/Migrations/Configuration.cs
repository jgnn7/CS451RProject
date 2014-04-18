namespace AspnetIdentitySample.Migrations
{
    using KpiMetricsSystem.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<KpiMetricsSystem.Models.MyDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(KpiMetricsSystem.Models.MyDbContext context)
        {
            //  This method will be called after migrating to the latest version.


            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            var RoleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var myinfo = new MyUserInfo() { FirstName = "Andrew", LastName = "Le" };
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

            //Create admin user
            var user = new ApplicationUser();
            user.UserName = myinfo.FirstName;
            user.Email = "Admin@email.com";
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
