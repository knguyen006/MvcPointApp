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
    public class MemProfileController : Controller
    {
        private PointAppDBContext db = new PointAppDBContext();
        private ProfileMgr mgr = new ProfileMgr();
        private MemberMgr memmgr = new MemberMgr();
        //
        // GET: /MemProfile/

        public ActionResult Index(member mem)
        {
            member memdb = memmgr.Retrieved(mem.memberid);
            if (memdb == null)
            {
                return HttpNotFound();
            }
            return View(mgr.GetList(memdb));
        }

        //
        // GET: /MemProfile/Details/5

        public ActionResult Details(int id = 0)
        {
            profile profile = db.profiles.Find(id);
            if (profile == null)
            {
                return HttpNotFound();
            }
            return View(profile);
        }

        //
        // GET: /MemProfile/Create

        public ActionResult Create()
        {
            ViewBag.familyid = new SelectList(db.families, "familyid", "familyname");
            ViewBag.memberid = new SelectList(db.members, "memberid", "username");
            ViewBag.dependentid = new SelectList(db.students, "studentid", "firstname");
            ViewBag.studentid = new SelectList(db.students, "studentid", "firstname");
            return View();
        }

        //
        // POST: /MemProfile/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(profile profile)
        {
            if (ModelState.IsValid)
            {
                db.profiles.Add(profile);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.familyid = new SelectList(db.families, "familyid", "familyname", profile.familyname);
            ViewBag.memberid = new SelectList(db.members, "memberid", "username", profile.memberid);
            ViewBag.dependentid = new SelectList(db.students, "studentid", "firstname", profile.dependentid);
            ViewBag.studentid = new SelectList(db.students, "studentid", "firstname", profile.studentid);
            return View(profile);
        }

        //
        // GET: /MemProfile/Edit/5

        public ActionResult Edit(int id = 0)
        {
            profile profile = db.profiles.Find(id);
            if (profile == null)
            {
                return HttpNotFound();
            }
            ViewBag.familyid = new SelectList(db.families, "familyid", "familyname", profile.familyname);
            ViewBag.memberid = new SelectList(db.members, "memberid", "username", profile.memberid);
            ViewBag.dependentid = new SelectList(db.students, "studentid", "firstname", profile.dependentid);
            ViewBag.studentid = new SelectList(db.students, "studentid", "firstname", profile.studentid);
            return View(profile);
        }

        //
        // POST: /MemProfile/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(profile profile)
        {
            if (ModelState.IsValid)
            {
                db.Entry(profile).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.memberid = new SelectList(db.members, "memberid", "username", profile.memberid);
            ViewBag.dependentid = new SelectList(db.students, "studentid", "firstname", profile.dependentid);
            ViewBag.studentid = new SelectList(db.students, "studentid", "firstname", profile.studentid);
            return View(profile);
        }

        //
        // GET: /MemProfile/Delete/5

        public ActionResult Delete(int id = 0)
        {
            profile profile = db.profiles.Find(id);
            if (profile == null)
            {
                return HttpNotFound();
            }
            return View(profile);
        }

        //
        // POST: /MemProfile/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            profile profile = db.profiles.Find(id);
            db.profiles.Remove(profile);
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