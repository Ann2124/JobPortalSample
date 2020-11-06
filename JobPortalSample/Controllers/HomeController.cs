using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JobPortalSample.Models;
using System.IO;
using System.Data.Entity;
using System.Web.Security;


namespace JobPortalSample.Controllers
{
    public class HomeController : Controller
    {
        JobPortalContext db = new JobPortalContext();
        public ActionResult Index()
        {
            return View(db.Openings.ToList());
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