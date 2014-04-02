using KpiMetricsSystem.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace KpiMetricsSystem.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //if admin role, redirect to admin master page
            //else redirect to UsersMasterPage
            if (User.IsInRole("Admin"))
            {
                return View("AdminMasterPage");
            }
            else
                return View("UsersMasterPage");
        }
        public ActionResult Welcome()
        {
            return View();
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