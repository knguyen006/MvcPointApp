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
    public class AdminSessioncalController : Controller
    {
        private PointAppDBContext db = new PointAppDBContext();
        private SessioncalMgr mgr = new SessioncalMgr();
        //
        // GET: /AdminSessioncal/

        public ActionResult Index()
        {
            var sessioncals = db.sessioncals.Include(s => s.sessiontype);
            return View(sessioncals.ToList());
        }

        //
        // GET: /AdminSessioncal/Details/5

        public ActionResult Details(int id = 0)
        {
            sessioncal cal = mgr.Retrieved(id);
            if (cal == null)
            {
                return HttpNotFound();
            }
            return View(cal);
        }

        //
        // GET: /AdminSessioncal/Create

        public ActionResult Create()
        {
            ViewBag.sessiontypeid = new SelectList(db.sessiontypes, "sessiontypeid", "typename");
            return View();
        }

        //
        // POST: /AdminSessioncal/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(sessioncal cal)
        {
            if (ModelState.IsValid)
            {
                mgr.Create(cal);
                return RedirectToAction("Index");
            }

            ViewBag.sessiontypeid = new SelectList(db.sessiontypes, "sessiontypeid", "typename", cal.sessiontypeid);
            return View(cal);
        }

        //
        // GET: /AdminSessioncal/Edit/5

        public ActionResult Edit(int id = 0)
        {
            sessioncal cal = mgr.Retrieved(id);
            if (cal == null)
            {
                return HttpNotFound();
            }
            ViewBag.sessiontypeid = new SelectList(db.sessiontypes, "sessiontypeid", "typename", cal.sessiontypeid);
            return View(cal);
        }

        //
        // POST: /AdminSessioncal/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(sessioncal cal)
        {
            if (ModelState.IsValid)
            {
                mgr.Update(cal);
                return RedirectToAction("Index");
            }
            ViewBag.sessiontypeid = new SelectList(db.sessiontypes, "sessiontypeid", "typename", cal.sessiontypeid);
            return View(cal);
        }

        //
        // GET: /AdminSessioncal/Delete/5

        public ActionResult Delete(int id = 0)
        {
            sessioncal cal = mgr.Retrieved(id);
            if (cal == null)
            {
                return HttpNotFound();
            }
            return View(cal);
        }

        //
        // POST: /AdminSessioncal/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            sessioncal cal = mgr.Retrieved(id);
            mgr.Delete(cal);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}