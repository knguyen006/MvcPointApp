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
    public class AdminContactController : Controller
    {
        private PointAppDBContext db = new PointAppDBContext();
        private ContactMgr mgr = new ContactMgr();

        //
        // GET: /AdminContact/

        public ActionResult Index()
        {
            var contacts = db.contacts.Include(c => c.member);
            return View(contacts.ToList());
        }

        //
        // GET: /AdminContact/Details/5

        public ActionResult Details(int id = 0)
        {
            contact con = mgr.Retrieved(id);
            if (con == null)
            {
                return HttpNotFound();
            }
            return View(con);
        }

        //
        // GET: /AdminContact/Create

        public ActionResult Create()
        {
            ViewBag.memberid = new SelectList(db.members, "memberid", "username");
            return View();
        }

        //
        // POST: /AdminContact/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(contact con)
        {
            if (ModelState.IsValid)
            {
                mgr.Create(con);
                return RedirectToAction("Index");
            }

            ViewBag.memberid = new SelectList(db.members, "memberid", "username", con.memberid);
            return View(con);
        }

        //
        // GET: /AdminContact/Edit/5

        public ActionResult Edit(int id = 0)
        {
            contact con = mgr.Retrieved(id);
            if (con == null)
            {
                return HttpNotFound();
            }
            ViewBag.memberid = new SelectList(db.members, "memberid", "username", con.memberid);
            return View(con);
        }

        //
        // POST: /AdminContact/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(contact con)
        {
            if (ModelState.IsValid)
            {
                mgr.Update(con);
                return RedirectToAction("Index");
            }
            ViewBag.memberid = new SelectList(db.members, "memberid", "username", con.memberid);
            return View(con);
        }

        //
        // GET: /AdminContact/Delete/5

        public ActionResult Delete(int id = 0)
        {
            contact con = mgr.Retrieved(id);
            if (con == null)
            {
                return HttpNotFound();
            }
            return View(con);
        }

        //
        // POST: /AdminContact/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            contact con = mgr.Retrieved(id);
            mgr.Delete(con);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}