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
    public class ActivityController : Controller
    {
        private PointAppDBContext db = new PointAppDBContext();
        private ActivityMgr mgr = new ActivityMgr();

        //
        // GET: /Activity/

        public ActionResult Index()
        {
            return View(mgr.GetList());
            ///return View(db.activities.ToList());
        }

        //
        // GET: /Activity/Details/5

        public ActionResult Details(int id = 0)
        {
            activity activity = db.activities.Find(id);
            if (activity == null)
            {
                return HttpNotFound();
            }
            return View(activity);
        }

        //
        // GET: /Activity/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Activity/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(activity act)
        {
            if (ModelState.IsValid)
            {
                mgr.Create(act);
                //db.activities.Add(activity);
                //db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(act);
        }

        //
        // GET: /Activity/Edit/5

        public ActionResult Edit(int id = 0)
        {
            //activity act = db.activities.Find(id);
            activity act = mgr.Retrieved(id);
            if (act == null)
            {
                return HttpNotFound();
            }
            return View(act);
        }

        //
        // POST: /Activity/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(activity act)
        {
            if (ModelState.IsValid)
            {
                mgr.Update(act);
                //db.Entry(act).State = EntityState.Modified;
                //db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(act);
        }

        //
        // GET: /Activity/Delete/5

        public ActionResult Delete(int id = 0)
        {
            //activity activity = db.activities.Find(id);
            activity act = mgr.Retrieved(id);
            if (act == null)
            {
                return HttpNotFound();
            }
            return View(act);
        }

        //
        // POST: /Activity/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //activity act = db.activities.Find(id);
            activity act = mgr.Retrieved(id);
            mgr.Delete(act);
            //db.activities.Remove(act);
            //db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}