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
    public class AdminFamilyController : Controller
    {
        private PointAppDBContext db = new PointAppDBContext();
        private FamilyMgr mgr = new FamilyMgr();
        //
        // GET: /AdminFamily/

        public ActionResult Index()
        {
            return View(mgr.GetList());
        }

        //
        // GET: /AdminFamily/Details/5

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
        // GET: /AdminFamily/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /AdminFamily/Create

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

        //
        // GET: /AdminFamily/Edit/5

        public ActionResult Edit(int id = 0)
        {
            family fam = mgr.Retrieved(id);
            if (fam == null)
            {
                return HttpNotFound();
            }
            return View(fam);
        }

        //
        // POST: /AdminFamily/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(family fam)
        {
            if (ModelState.IsValid)
            {
                mgr.Update(fam);
                return RedirectToAction("Index");
            }
            return View(fam);
        }

        //
        // GET: /AdminFamily/Delete/5

        public ActionResult Delete(int id = 0)
        {
            family fam = mgr.Retrieved(id);
            if (fam == null)
            {
                return HttpNotFound();
            }
            return View(fam);
        }

        //
        // POST: /AdminFamily/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            family fam = mgr.Retrieved(id);
            mgr.Delete(fam);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}