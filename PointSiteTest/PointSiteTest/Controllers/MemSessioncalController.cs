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
    public class MemSessioncalController : Controller
    {
        private PointAppDBContext db = new PointAppDBContext();

        //
        // GET: /MemSessioncal/

        public ActionResult Index()
        {
            var sessioncals = db.sessioncals.Include(s => s.sessiontype);
            return View(sessioncals.ToList());
        }

        //
        // GET: /MemSessioncal/Details/5

        public ActionResult Details(int id = 0)
        {
            sessioncal sessioncal = db.sessioncals.Find(id);
            if (sessioncal == null)
            {
                return HttpNotFound();
            }
            return View(sessioncal);
        }

        //
        // GET: /MemSessioncal/Create

        public ActionResult Create()
        {
            ViewBag.sessiontypeid = new SelectList(db.sessiontypes, "sessiontypeid", "typename");
            return View();
        }

        //
        // POST: /MemSessioncal/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(sessioncal sessioncal)
        {
            if (ModelState.IsValid)
            {
                db.sessioncals.Add(sessioncal);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.sessiontypeid = new SelectList(db.sessiontypes, "sessiontypeid", "typename", sessioncal.sessiontypeid);
            return View(sessioncal);
        }

        //
        // GET: /MemSessioncal/Edit/5

        public ActionResult Edit(int id = 0)
        {
            sessioncal sessioncal = db.sessioncals.Find(id);
            if (sessioncal == null)
            {
                return HttpNotFound();
            }
            ViewBag.sessiontypeid = new SelectList(db.sessiontypes, "sessiontypeid", "typename", sessioncal.sessiontypeid);
            return View(sessioncal);
        }

        //
        // POST: /MemSessioncal/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(sessioncal sessioncal)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sessioncal).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.sessiontypeid = new SelectList(db.sessiontypes, "sessiontypeid", "typename", sessioncal.sessiontypeid);
            return View(sessioncal);
        }

        //
        // GET: /MemSessioncal/Delete/5

        public ActionResult Delete(int id = 0)
        {
            sessioncal sessioncal = db.sessioncals.Find(id);
            if (sessioncal == null)
            {
                return HttpNotFound();
            }
            return View(sessioncal);
        }

        //
        // POST: /MemSessioncal/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            sessioncal sessioncal = db.sessioncals.Find(id);
            db.sessioncals.Remove(sessioncal);
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