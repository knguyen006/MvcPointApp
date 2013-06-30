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
    public class MemContactemailController : Controller
    {
        private PointAppDBContext db = new PointAppDBContext();

        //
        // GET: /MemContactemail/

        public ActionResult Index()
        {
            var contactemails = db.contactemails.Include(c => c.contact);
            return View(contactemails.ToList());
        }

        //
        // GET: /MemContactemail/Details/5

        public ActionResult Details(int id = 0)
        {
            contactemail contactemail = db.contactemails.Find(id);
            if (contactemail == null)
            {
                return HttpNotFound();
            }
            return View(contactemail);
        }

        //
        // GET: /MemContactemail/Create

        public ActionResult Create()
        {
            ViewBag.contactid = new SelectList(db.contacts, "contactid", "firstname");
            return View();
        }

        //
        // POST: /MemContactemail/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(contactemail contactemail)
        {
            if (ModelState.IsValid)
            {
                db.contactemails.Add(contactemail);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.contactid = new SelectList(db.contacts, "contactid", "firstname", contactemail.contactid);
            return View(contactemail);
        }

        //
        // GET: /MemContactemail/Edit/5

        public ActionResult Edit(int id = 0)
        {
            contactemail contactemail = db.contactemails.Find(id);
            if (contactemail == null)
            {
                return HttpNotFound();
            }
            ViewBag.contactid = new SelectList(db.contacts, "contactid", "firstname", contactemail.contactid);
            return View(contactemail);
        }

        //
        // POST: /MemContactemail/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(contactemail contactemail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(contactemail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.contactid = new SelectList(db.contacts, "contactid", "firstname", contactemail.contactid);
            return View(contactemail);
        }

        //
        // GET: /MemContactemail/Delete/5

        public ActionResult Delete(int id = 0)
        {
            contactemail contactemail = db.contactemails.Find(id);
            if (contactemail == null)
            {
                return HttpNotFound();
            }
            return View(contactemail);
        }

        //
        // POST: /MemContactemail/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            contactemail contactemail = db.contactemails.Find(id);
            db.contactemails.Remove(contactemail);
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