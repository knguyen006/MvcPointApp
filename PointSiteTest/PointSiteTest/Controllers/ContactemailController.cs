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
    public class ContactemailController : Controller
    {
        private PointAppDBContext db = new PointAppDBContext();
        private ContactemailMgr mgr = new ContactemailMgr();
        //
        // GET: /Contactemail/

        public ActionResult Index()
        {
            var contactemails = db.contactemails.Include(c => c.contact);
            //return View(mgr.GetList());
            return View(contactemails.ToList());
        }

        //
        // GET: /Contactemail/Details/5

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
        // GET: /Contactemail/Create

        public ActionResult Create()
        {
            ViewBag.contactid = new SelectList(db.contacts, "contactid", "firstname");
            return View();
        }

        //
        // POST: /Contactemail/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(contactemail email)
        {
            if (ModelState.IsValid)
            {
                mgr.Create(email);
                //db.contactemails.Add(contactemail);
                //db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.contactid = new SelectList(db.contacts, "contactid", "firstname", email.contactid);
            return View(email);
        }

        //
        // GET: /Contactemail/Edit/5

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
        // POST: /Contactemail/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(contactemail email)
        {
            if (ModelState.IsValid)
            {
                mgr.Update(email);
                //db.Entry(contactemail).State = EntityState.Modified;
                //db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.contactid = new SelectList(db.contacts, "contactid", "firstname", email.contactid);
            return View(email);
        }

        //
        // GET: /Contactemail/Delete/5

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
        // POST: /Contactemail/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            contactemail email = mgr.Retrieved(id);
            mgr.Delete(email);
            //db.contactemails.Remove(contactemail);
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