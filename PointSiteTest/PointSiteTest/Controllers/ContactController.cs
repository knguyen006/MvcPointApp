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
    public class ContactController : Controller
    {
        private PointAppDBContext db = new PointAppDBContext();
        private ContactMgr mgr = new ContactMgr();
        //
        // GET: /Contact/

        public ActionResult Index()
        {
            return View(mgr.GetList());
            //return View(db.contacts.ToList());
        }

        //
        // GET: /Contact/Details/5

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
        // GET: /Contact/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Contact/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(contact con)
        {
            if (ModelState.IsValid)
            {
                mgr.Create(con);
                //db.contacts.Add(contact);
                //db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(con);
        }

        //
        // GET: /Contact/Edit/5

        public ActionResult Edit(int id = 0)
        {
            contact con = mgr.Retrieved(id);
            //contact contact = db.contacts.Find(id);
            if (con == null)
            {
                return HttpNotFound();
            }
            return View(con);
        }

        //
        // POST: /Contact/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(contact con)
        {
            if (ModelState.IsValid)
            {
                mgr.Update(con);
                //db.Entry(contact).State = EntityState.Modified;
                //db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(con);
        }

        //
        // GET: /Contact/Delete/5

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
        // POST: /Contact/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            contact con = mgr.Retrieved(id);
            mgr.Delete(con);
            //db.contacts.Remove(contact);
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