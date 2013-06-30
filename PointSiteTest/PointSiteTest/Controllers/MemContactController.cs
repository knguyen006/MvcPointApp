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
    public class MemContactController : Controller
    {
        private PointAppDBContext db = new PointAppDBContext();

        //
        // GET: /MemContact/

        public ActionResult Index()
        {
            var contacts = db.contacts.Include(c => c.member);
            return View(contacts.ToList());
        }

        //
        // GET: /MemContact/Details/5

        public ActionResult Details(int id = 0)
        {
            contact contact = db.contacts.Find(id);
            if (contact == null)
            {
                return HttpNotFound();
            }
            return View(contact);
        }

        //
        // GET: /MemContact/Create

        public ActionResult Create()
        {
            ViewBag.memberid = new SelectList(db.members, "memberid", "username");
            return View();
        }

        //
        // POST: /MemContact/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(contact contact)
        {
            if (ModelState.IsValid)
            {
                db.contacts.Add(contact);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.memberid = new SelectList(db.members, "memberid", "username", contact.memberid);
            return View(contact);
        }

        //
        // GET: /MemContact/Edit/5

        public ActionResult Edit(int id = 0)
        {
            contact contact = db.contacts.Find(id);
            if (contact == null)
            {
                return HttpNotFound();
            }
            ViewBag.memberid = new SelectList(db.members, "memberid", "username", contact.memberid);
            return View(contact);
        }

        //
        // POST: /MemContact/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(contact contact)
        {
            if (ModelState.IsValid)
            {
                db.Entry(contact).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.memberid = new SelectList(db.members, "memberid", "username", contact.memberid);
            return View(contact);
        }

        //
        // GET: /MemContact/Delete/5

        public ActionResult Delete(int id = 0)
        {
            contact contact = db.contacts.Find(id);
            if (contact == null)
            {
                return HttpNotFound();
            }
            return View(contact);
        }

        //
        // POST: /MemContact/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            contact contact = db.contacts.Find(id);
            db.contacts.Remove(contact);
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