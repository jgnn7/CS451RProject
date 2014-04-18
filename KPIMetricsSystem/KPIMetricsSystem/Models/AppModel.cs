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


namespace KpiMetricsSystem.Models
{
    public class ApplicationUser : IdentityUser
    {
        //public string Email { get; set; }
        // FirstName & LastName will be stored in a different table called MyUserInfo
        public virtual MyUserInfo MyUserInfo { get; set; }
    }

    public class MyUserInfo
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

    //KPI TABLES
    public class SLA_PERFORMANCE
    {
        [Key]
        public int id { get; set; }

        public float Number_of_SLA_Met { get; set; }
        public float Total_Number_of_SLA { get; set; }
        DateTime Date_Due { get; set; }
        DateTime Date_Modified { get; set; }
    }
    public class KPI
    {
        public int id { get; set; }

        public string KPI_Name { get; set; }
    }
    public class Relation
    {
        [Key]
        public int id { get; set; }

        public KPI kpi { get; set; } //foreign key??

        public MyUserInfo User { get; set; }

    }
    public class Number_of_Sev_2
    {
        [Key]
        public int id { get; set; }

        public int Number_of_Incidents { get; set; }
        DateTime Date_Due { get; set; }
        DateTime Date_Modified { get; set; }
    }
    public class Number_of_Sev_1
    {
        [Key]
        public int id { get; set; }

        public int Number_of_Incidents { get; set; }
        DateTime Date_Due { get; set; }
        DateTime Date_Modified { get; set; }
    }
    public class Percent_of_TurnOver
    {
        [Key]
        public int id { get; set; }

        public int Number_of_TurnOver { get; set; }
        public int Non_Controllable_TurnOver { get; set; }
        public int Headcount { get; set; }
        DateTime Date_Due { get; set; }
        DateTime Date_Modified { get; set; }
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
        public DbSet<KPI> KPI { get; set; }
        public DbSet<Relation> Relation { get; set; }
        public DbSet<Number_of_Sev_1> Number_of_Severity_one { get; set; }
        public DbSet<Number_of_Sev_2> Number_of_severity_two { get; set; }
        public DbSet<SLA_PERFORMANCE> SLA_Performace { get; set; }
        public DbSet<Percent_of_TurnOver> Turnover_Percent { get; set; }
       
    }
    

}