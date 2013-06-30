using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataLayer;
using DataLayerBusiness;

namespace PointSiteTest.Controllers
{
    public class MemFamilyController : Controller
    {
        private PointAppDBContext db = new PointAppDBContext();
        private FamilyMgr mgr = new FamilyMgr();
        //
        // GET: /MemFamily/

        public ActionResult Index()
        {
            return View(mgr.GetList());
        }

        //
        // GET: /MemFamily/Details/5

        public ActionResult Details(int id = 0)
        {
            family fam = mgr.Retrieved(id);
            if (fam == null)
            {
                return HttpNotFound();
            }
            return View(fam);
        }

        //
        // GET: /MemFamily/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /MemFamily/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(family fam)
        {
            if (ModelState.IsValid)
            {
                mgr.Create(fam);
                return RedirectToAction("Index");
            }

            return View(fam);
        }
    }
}