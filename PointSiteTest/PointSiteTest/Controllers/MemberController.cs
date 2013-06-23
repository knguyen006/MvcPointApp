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
    public class MemberController : Controller
    {
        private PointAppDBContext db = new PointAppDBContext();
        private MemberMgr mgr = new MemberMgr();

        //
        // GET: /Member/

        public ActionResult Index()
        {
            var mem = db.members.Include(m => m.approle).Include(m => m.contact).Include(m => m.student);
            
            return View(mem.ToList());
        }

        //
        // GET: /Member/Details/5

        public ActionResult Details(int id = 0)
        {
            member mem = mgr.Retrieved(id);
            if (mem == null)
            {
                return HttpNotFound();
            }
            return View(mem);
        }

        //
        // GET: /Member/Create

        public ActionResult Create()
        {
            ViewBag.approleid = new SelectList(db.approles, "approleid", "rolename");
            ViewBag.contactid = new SelectList(db.contacts, "contactid", "firstname");
            ViewBag.studentid = new SelectList(db.students, "studentid", "firstname");
            return View();
        }

        //
        // POST: /Member/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(member mem)
        {
            if (ModelState.IsValid)
            {
                mgr.Create(mem);
                //db.members.Add(member);
                //db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.approleid = new SelectList(db.approles, "approleid", "rolename", mem.approleid);
            ViewBag.contactid = new SelectList(db.contacts, "contactid", "firstname", mem.contactid);
            ViewBag.studentid = new SelectList(db.students, "studentid", "firstname", mem.studentid);
            return View(mem);
        }

        //
        // GET: /Member/Edit/5

        public ActionResult Edit(int id = 0)
        {
            member mem = mgr.Retrieved(id);
            if (mem == null)
            {
                return HttpNotFound();
            }
            ViewBag.approleid = new SelectList(db.approles, "approleid", "rolename", mem.approleid);
            ViewBag.contactid = new SelectList(db.contacts, "contactid", "firstname", mem.contactid);
            ViewBag.studentid = new SelectList(db.students, "studentid", "firstname", mem.studentid);
            return View(mem);
        }

        //
        // POST: /Member/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(member mem)
        {
            if (ModelState.IsValid)
            {
                mgr.Update(mem);
                //db.Entry(member).State = EntityState.Modified;
                //db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.approleid = new SelectList(db.approles, "approleid", "rolename", mem.approleid);
            ViewBag.contactid = new SelectList(db.contacts, "contactid", "firstname", mem.contactid);
            ViewBag.studentid = new SelectList(db.students, "studentid", "firstname", mem.studentid);
            return View(mem);
        }

        //
        // GET: /Member/Delete/5

        public ActionResult Delete(int id = 0)
        {
            member mem = mgr.Retrieved(id);
            if (mem == null)
            {
                return HttpNotFound();
            }
            return View(mem);
        }

        //
        // POST: /Member/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            member mem = mgr.Retrieved(id);
            mgr.Delete(mem);
            //db.members.Remove(member);
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