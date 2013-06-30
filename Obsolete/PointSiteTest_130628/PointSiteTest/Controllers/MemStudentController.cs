using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataLayer;

namespace PointSiteTest.Controllers
{
    public class MemStudentController : Controller
    {
        private PointAppDBContext db = new PointAppDBContext();

        //
        // GET: /MemStudent/

        public ActionResult Index()
        {
            return View(db.students.ToList());
        }

        //
        // GET: /MemStudent/Details/5

        public ActionResult Details(int id = 0)
        {
            student student = db.students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

    }
}