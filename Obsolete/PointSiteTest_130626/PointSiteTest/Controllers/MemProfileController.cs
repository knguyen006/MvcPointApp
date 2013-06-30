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

        //
        // GET: /MemProfile/

        public ActionResult Index()
        {
            var profiles = db.profiles.Include(p => p.family).Include(p => p.member).Include(p => p.student).Include(p => p.student1);
            return View(profiles.ToList());
        }

        //
        // GET: /MemProfile/Details/5

        public ActionResult Details(int id = 0)
        {
            profile pro = mgr.Retrieved(id);
            if (pro == null)
            {
                return HttpNotFound();
            }
            return View(pro);
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
        public ActionResult Create(profile pro)
        {
            if (ModelState.IsValid)
            {
                mgr.Create(pro);
                return RedirectToAction("Index");
            }

            ViewBag.familyid = new SelectList(db.families, "familyid", "familyname", pro.familyid);
            ViewBag.memberid = new SelectList(db.members, "memberid", "username", pro.memberid);
            ViewBag.dependentid = new SelectList(db.students, "studentid", "firstname", pro.dependentid);
            ViewBag.studentid = new SelectList(db.students, "studentid", "firstname", pro.studentid);
            return View(pro);
        }

        //
        // GET: /MemProfile/Edit/5

        public ActionResult Edit(int id = 0)
        {
            profile pro = mgr.Retrieved(id);
            if (pro == null)
            {
                return HttpNotFound();
            }
            ViewBag.familyid = new SelectList(db.families, "familyid", "familyname", pro.familyid);
            ViewBag.memberid = new SelectList(db.members, "memberid", "username", pro.memberid);
            ViewBag.dependentid = new SelectList(db.students, "studentid", "firstname", pro.dependentid);
            ViewBag.studentid = new SelectList(db.students, "studentid", "firstname", pro.studentid);
            return View(pro);
        }

        //
        // POST: /MemProfile/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(profile pro)
        {
            if (ModelState.IsValid)
            {
                mgr.Update(pro);
                return RedirectToAction("Index");
            }
            ViewBag.familyid = new SelectList(db.families, "familyid", "familyname", pro.familyid);
            ViewBag.memberid = new SelectList(db.members, "memberid", "username", pro.memberid);
            ViewBag.dependentid = new SelectList(db.students, "studentid", "firstname", pro.dependentid);
            ViewBag.studentid = new SelectList(db.students, "studentid", "firstname", pro.studentid);
            return View(pro);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}