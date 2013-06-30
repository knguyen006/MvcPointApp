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
    public class AdminActivityController : Controller
    {
        private PointAppDBContext db = new PointAppDBContext();
        private ActivityMgr mgr = new ActivityMgr();
        //
        // GET: /AdminActivity/

        public ActionResult Index()
        {
            return View(mgr.GetList());
        }

        //
        // GET: /AdminActivity/Details/5

        public ActionResult Details(int id = 0)
        {
            activity act = mgr.Retrieved(id);
            if (act == null)
            {
                return HttpNotFound();
            }
            return View(act);
        }

        //
        // GET: /AdminActivity/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /AdminActivity/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(activity act)
        {
            if (ModelState.IsValid)
            {
                mgr.Create(act);
                return RedirectToAction("Index");
            }

            return View(act);
        }

        //
        // GET: /AdminActivity/Edit/5

        public ActionResult Edit(int id = 0)
        {
            activity act = mgr.Retrieved(id);
            if (act == null)
            {
                return HttpNotFound();
            }
            return View(act);
        }

        //
        // POST: /AdminActivity/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(activity act)
        {
            if (ModelState.IsValid)
            {
                mgr.Update(act);
                return RedirectToAction("Index");
            }
            return View(act);
        }

        //
        // GET: /AdminActivity/Delete/5

        public ActionResult Delete(int id = 0)
        {
            activity act = mgr.Retrieved(id);
            if (act == null)
            {
                return HttpNotFound();
            }
            return View(act);
        }

        //
        // POST: /AdminActivity/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            activity act = mgr.Retrieved(id);
            mgr.Delete(act);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}