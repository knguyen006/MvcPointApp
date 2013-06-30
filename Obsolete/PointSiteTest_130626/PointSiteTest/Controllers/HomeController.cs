using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PointSiteTest.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            ViewBag.Message = "Welcome to LPAC Point Tracking MVC Application";

            return View();
        }
        
        public ActionResult About()
        {
            ViewBag.Message = "";

            return View();
        }

        public ActionResult ContactUs()
        {
            ViewBag.Message = "";

            return View();
        }

    }
}
