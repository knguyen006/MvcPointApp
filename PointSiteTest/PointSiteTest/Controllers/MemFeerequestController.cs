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
    public class MemFeerequestController : Controller
    {
        private PointAppDBContext db = new PointAppDBContext();

        //
        // GET: /MemFeerequest/

        public ActionResult Index()
        {
            var feerequests = db.feerequests.Include(f => f.member);
            return View(feerequests.ToList());
        }

        //
        // GET: /MemFeerequest/Details/5

        public ActionResult Details(int id = 0)
        {
            feerequest feerequest = db.feerequests.Find(id);
            if (feerequest == null)
            {
                return HttpNotFound();
            }
            return View(feerequest);
        }

        //
        // GET: /MemFeerequest/Create

        public ActionResult Create()
        {
            ViewBag.memberid = new SelectList(db.members, "memberid", "username");
            return View();
        }

        //
        // POST: /MemFeerequest/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(feerequest feerequest)
        {
            if (ModelState.IsValid)
            {
                db.feerequests.Add(feerequest);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.memberid = new SelectList(db.members, "memberid", "username", feerequest.memberid);
            return View(feerequest);
        }

        //
        // GET: /MemFeerequest/Edit/5

        public ActionResult Edit(int id = 0)
        {
            feerequest feerequest = db.feerequests.Find(id);
            if (feerequest == null)
            {
                return HttpNotFound();
            }
            ViewBag.memberid = new SelectList(db.members, "memberid", "username", feerequest.memberid);
            return View(feerequest);
        }

        //
        // POST: /MemFeerequest/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(feerequest feerequest)
        {
            if (ModelState.IsValid)
            {
                db.Entry(feerequest).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.memberid = new SelectList(db.members, "memberid", "username", feerequest.memberid);
            return View(feerequest);
        }

        //
        // GET: /MemFeerequest/Delete/5

        public ActionResult Delete(int id = 0)
        {
            feerequest feerequest = db.feerequests.Find(id);
            if (feerequest == null)
            {
                return HttpNotFound();
            }
            return View(feerequest);
        }

        //
        // POST: /MemFeerequest/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            feerequest feerequest = db.feerequests.Find(id);
            db.feerequests.Remove(feerequest);
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