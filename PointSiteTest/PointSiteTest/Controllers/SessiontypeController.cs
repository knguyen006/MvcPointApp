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
    public class SessiontypeController : Controller
    {
        private PointAppDBContext db = new PointAppDBContext();
        private SessiontypeMgr mgr = new SessiontypeMgr();
        //
        // GET: /Sessiontype/

        public ActionResult Index()
        {
            return View(mgr.GetList());
            //return View(db.sessiontypes.ToList());
        }

        //
        // GET: /Sessiontype/Details/5

        public ActionResult Details(int id = 0)
        {
            sessiontype type = mgr.Retrieved(id);
            if (type == null)
            {
                return HttpNotFound();
            }
            return View(type);
        }

        //
        // GET: /Sessiontype/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Sessiontype/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(sessiontype type)
        {
            if (ModelState.IsValid)
            {
                mgr.Create(type);
                //db.sessiontypes.Add(sessiontype);
                //db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(type);
        }

        //
        // GET: /Sessiontype/Edit/5

        public ActionResult Edit(int id = 0)
        {
            sessiontype type = mgr.Retrieved(id);
            if (type == null)
            {
                return HttpNotFound();
            }
            return View(type);
        }

        //
        // POST: /Sessiontype/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(sessiontype type)
        {
            if (ModelState.IsValid)
            {
                mgr.Update(type);
                //db.Entry(sessiontype).State = EntityState.Modified;
                //db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(type);
        }

        //
        // GET: /Sessiontype/Delete/5

        public ActionResult Delete(int id = 0)
        {
            sessiontype type = mgr.Retrieved(id);
            if (type == null)
            {
                return HttpNotFound();
            }
            return View(type);
        }

        //
        // POST: /Sessiontype/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            sessiontype type = mgr.Retrieved(id);
            mgr.Delete(type);
            //db.sessiontypes.Remove(sessiontype);
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