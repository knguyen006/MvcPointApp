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
    public class MemSignupController : Controller
    {
        private PointAppDBContext db = new PointAppDBContext();

        //
        // GET: /MemSignup/

        public ActionResult Index()
        {
            var signups = db.signups.Include(s => s.member).Include(s => s.sessioncal);
            return View(signups.ToList());
        }

        //
        // GET: /MemSignup/Details/5

        public ActionResult Details(int id = 0)
        {
            signup signup = db.signups.Find(id);
            if (signup == null)
            {
                return HttpNotFound();
            }
            return View(signup);
        }

        //
        // GET: /MemSignup/Create

        public ActionResult Create()
        {
            ViewBag.memberid = new SelectList(db.members, "memberid", "username");
            ViewBag.sessioncalid = new SelectList(db.sessioncals, "sessioncalid", "sessioncalid");
            return View();
        }

        //
        // POST: /MemSignup/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(signup signup)
        {
            if (ModelState.IsValid)
            {
                db.signups.Add(signup);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.memberid = new SelectList(db.members, "memberid", "username", signup.memberid);
            ViewBag.sessioncalid = new SelectList(db.sessioncals, "sessioncalid", "sessioncalid", signup.sessioncalid);
            return View(signup);
        }

        //
        // GET: /MemSignup/Edit/5

        public ActionResult Edit(int id = 0)
        {
            signup signup = db.signups.Find(id);
            if (signup == null)
            {
                return HttpNotFound();
            }
            ViewBag.memberid = new SelectList(db.members, "memberid", "username", signup.memberid);
            ViewBag.sessioncalid = new SelectList(db.sessioncals, "sessioncalid", "sessioncalid", signup.sessioncalid);
            return View(signup);
        }

        //
        // POST: /MemSignup/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(signup signup)
        {
            if (ModelState.IsValid)
            {
                db.Entry(signup).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.memberid = new SelectList(db.members, "memberid", "username", signup.memberid);
            ViewBag.sessioncalid = new SelectList(db.sessioncals, "sessioncalid", "sessioncalid", signup.sessioncalid);
            return View(signup);
        }

        //
        // GET: /MemSignup/Delete/5

        public ActionResult Delete(int id = 0)
        {
            signup signup = db.signups.Find(id);
            if (signup == null)
            {
                return HttpNotFound();
            }
            return View(signup);
        }

        //
        // POST: /MemSignup/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            signup signup = db.signups.Find(id);
            db.signups.Remove(signup);
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