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
    public class AdminActivityController : Controller
    {
        private PointAppDBContext db = new PointAppDBContext();

        //
        // GET: /AdminActivity/

        public ActionResult Index()
        {
            return View(db.activities.ToList());
        }

        //
        // GET: /AdminActivity/Details/5

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
        // GET: /AdminActivity/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /AdminActivity/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(activity activity)
        {
            if (ModelState.IsValid)
            {
                db.activities.Add(activity);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(activity);
        }

        //
        // GET: /AdminActivity/Edit/5

        public ActionResult Edit(int id = 0)
        {
            activity activity = db.activities.Find(id);
            if (activity == null)
            {
                return HttpNotFound();
            }
            return View(activity);
        }

        //
        // POST: /AdminActivity/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(activity activity)
        {
            if (ModelState.IsValid)
            {
                db.Entry(activity).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(activity);
        }

        //
        // GET: /AdminActivity/Delete/5

        public ActionResult Delete(int id = 0)
        {
            activity activity = db.activities.Find(id);
            if (activity == null)
            {
                return HttpNotFound();
            }
            return View(activity);
        }

        //
        // POST: /AdminActivity/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            activity activity = db.activities.Find(id);
            db.activities.Remove(activity);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}