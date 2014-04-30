using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Web.Mvc;


namespace KpiMetricsSystem.Models
{
    public class ApplicationUser : IdentityUser
    {
        public virtual ICollection<KPI> KPIs { get; set; }
        // FirstName & LastName will be stored in a different table called MyUserInfo
        public virtual MyUserInfo MyUserInfo { get; set; }
    }

    public class MyUserInfo
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

    
  
    public class MyDbContext : IdentityDbContext<ApplicationUser>
    {
        public MyDbContext()
            : base("DefaultConnection")
        {
        }
        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Change the name of the table to be Users instead of AspNetUsers
            modelBuilder.Entity<IdentityUser>()
                .ToTable("Users");
            modelBuilder.Entity<ApplicationUser>()
                .ToTable("Users");
           
            
        }

        public DbSet<MyUserInfo> MyUserInfo { get; set; }

        public System.Data.Entity.DbSet<KpiMetricsSystem.Models.KPI> KPIs { get; set; }
       
    }
    

}