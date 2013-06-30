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
    public class AdminSignupController : Controller
    {
        private PointAppDBContext db = new PointAppDBContext();
        private SignupMgr mgr = new SignupMgr();
        //
        // GET: /AdminSignup/

        public ActionResult Index()
        {
            var signups = db.signups.Include(s => s.member).Include(s => s.sessioncal);
            return View(signups.ToList());
        }

        //
        // GET: /AdminSignup/Details/5

        public ActionResult Details(int id = 0)
        {
            signup sign = mgr.Retrieved(id);
            if (sign == null)
            {
                return HttpNotFound();
            }
            return View(sign);
        }

        //
        // GET: /AdminSignup/Create

        public ActionResult Create()
        {
            ViewBag.memberid = new SelectList(db.members, "memberid", "username");
            ViewBag.sessioncalid = new SelectList(db.sessioncals, "sessioncalid", "sessioncalid");
            return View();
        }

        //
        // POST: /AdminSignup/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(signup sign)
        {
            if (ModelState.IsValid)
            {
                mgr.Create(sign);
                return RedirectToAction("Index");
            }

            ViewBag.memberid = new SelectList(db.members, "memberid", "username", sign.memberid);
            ViewBag.sessioncalid = new SelectList(db.sessioncals, "sessioncalid", "sessioncalid", sign.sessioncalid);
            return View(sign);
        }

        //
        // GET: /AdminSignup/Edit/5

        public ActionResult Edit(int id = 0)
        {
            signup sign = mgr.Retrieved(id);
            if (sign == null)
            {
                return HttpNotFound();
            }
            ViewBag.memberid = new SelectList(db.members, "memberid", "username", sign.memberid);
            ViewBag.sessioncalid = new SelectList(db.sessioncals, "sessioncalid", "sessioncalid", sign.sessioncalid);
            return View(sign);
        }

        //
        // POST: /AdminSignup/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(signup sign)
        {
            if (ModelState.IsValid)
            {
                mgr.Update(sign);
                return RedirectToAction("Index");
            }
            ViewBag.memberid = new SelectList(db.members, "memberid", "username", sign.memberid);
            ViewBag.sessioncalid = new SelectList(db.sessioncals, "sessioncalid", "sessioncalid", sign.sessioncalid);
            return View(sign);
        }

        //
        // GET: /AdminSignup/Delete/5

        public ActionResult Delete(int id = 0)
        {
            signup sign = mgr.Retrieved(id);
            if (sign == null)
            {
                return HttpNotFound();
            }
            return View(sign);
        }

        //
        // POST: /AdminSignup/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            signup sign = mgr.Retrieved(id);
            mgr.Delete(sign);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}