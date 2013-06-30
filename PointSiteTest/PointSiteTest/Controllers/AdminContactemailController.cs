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
    public class AdminContactemailController : Controller
    {
        private PointAppDBContext db = new PointAppDBContext();
        private ContactemailMgr mgr = new ContactemailMgr();
        //
        // GET: /AdminContactemail/

        public ActionResult Index()
        {
            var contactemails = db.contactemails.Include(c => c.contact);
            return View(contactemails.ToList());
        }

        //
        // GET: /AdminContactemail/Details/5

        public ActionResult Details(int id = 0)
        {
            contactemail email = mgr.Retrieved(id);
            if (email == null)
            {
                return HttpNotFound();
            }
            return View(email);
        }

        //
        // GET: /AdminContactemail/Create

        public ActionResult Create()
        {
            ViewBag.contactid = new SelectList(db.contacts, "contactid", "firstname");
            return View();
        }

        //
        // POST: /AdminContactemail/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(contactemail email)
        {
            if (ModelState.IsValid)
            {
                mgr.Create(email);
                return RedirectToAction("Index");
            }

            ViewBag.contactid = new SelectList(db.contacts, "contactid", "firstname", email.contactid);
            return View(email);
        }

        //
        // GET: /AdminContactemail/Edit/5

        public ActionResult Edit(int id = 0)
        {
            contactemail email = mgr.Retrieved(id);
            if (email == null)
            {
                return HttpNotFound();
            }
            ViewBag.contactid = new SelectList(db.contacts, "contactid", "firstname", email.contactid);
            return View(email);
        }

        //
        // POST: /AdminContactemail/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(contactemail email)
        {
            if (ModelState.IsValid)
            {
                mgr.Update(email);
                return RedirectToAction("Index");
            }
            ViewBag.contactid = new SelectList(db.contacts, "contactid", "firstname", email.contactid);
            return View(email);
        }

        //
        // GET: /AdminContactemail/Delete/5

        public ActionResult Delete(int id = 0)
        {
            contactemail email = mgr.Retrieved(id);
            if (email == null)
            {
                return HttpNotFound();
            }
            return View(email);
        }

        //
        // POST: /AdminContactemail/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            contactemail email = mgr.Retrieved(id);
            mgr.Delete(email);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}