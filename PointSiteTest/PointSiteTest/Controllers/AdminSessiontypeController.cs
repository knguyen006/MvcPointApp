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
    public class AdminSessiontypeController : Controller
    {
        private PointAppDBContext db = new PointAppDBContext();
        private SessiontypeMgr mgr = new SessiontypeMgr();

        //
        // GET: /AdminSessiontype/

        public ActionResult Index()
        {
            return View(mgr.GetList());
        }

        //
        // GET: /AdminSessiontype/Details/5

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
        // GET: /AdminSessiontype/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /AdminSessiontype/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(sessiontype type)
        {
            if (ModelState.IsValid)
            {
                mgr.Create(type);
                return RedirectToAction("Index");
            }

            return View(type);
        }

        //
        // GET: /AdminSessiontype/Edit/5

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
        // POST: /AdminSessiontype/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(sessiontype type)
        {
            if (ModelState.IsValid)
            {
                mgr.Update(type);
                return RedirectToAction("Index");
            }
            return View(type);
        }

        //
        // GET: /AdminSessiontype/Delete/5

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
        // POST: /AdminSessiontype/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            sessiontype type = mgr.Retrieved(id);
            mgr.Delete(type);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}