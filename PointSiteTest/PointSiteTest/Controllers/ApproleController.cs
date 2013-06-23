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
    public class ApproleController : Controller
    {
        private PointAppDBContext db = new PointAppDBContext();
        private ApproleMgr mgr = new ApproleMgr();
        //
        // GET: /Approle/

        public ActionResult Index()
        {
            return View(db.approles.ToList());
        }

        //
        // GET: /Approle/Details/5

        public ActionResult Details(int id = 0)
        {
            approle role = mgr.Retrieved(id);
            //approle approle = db.approles.Find(id);
            if (role == null)
            {
                return HttpNotFound();
            }
            return View(role);
        }

        //
        // GET: /Approle/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Approle/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(approle role)
        {
            if (ModelState.IsValid)
            {

                mgr.Create(role);
                //db.approles.Add(role);
                //db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(role);
        }

        //
        // GET: /Approle/Edit/5

        public ActionResult Edit(int id = 0)
        {
            approle role = mgr.Retrieved(id);
            //approle approle = db.approles.Find(id);
            if (role == null)
            {
                return HttpNotFound();
            }
            return View(role);
        }

        //
        // POST: /Approle/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(approle role)
        {
            if (ModelState.IsValid)
            {
                mgr.Update(role);
                //db.Entry(approle).State = EntityState.Modified;
                //db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(role);
        }

        //
        // GET: /Approle/Delete/5

        public ActionResult Delete(int id = 0)
        {
            approle role = mgr.Retrieved(id);
            if (role == null)
            {
                return HttpNotFound();
            }
            return View(role);
        }

        //
        // POST: /Approle/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //approle approle = db.approles.Find(id);
            approle role = mgr.Retrieved(id);
            mgr.Delete(role);
            //db.approles.Remove(approle);
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