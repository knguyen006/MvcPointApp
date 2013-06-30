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
    public class AdminStudentController : Controller
    {
        private PointAppDBContext db = new PointAppDBContext();
        private StudentMgr mgr = new StudentMgr();

        //
        // GET: /AdminStudent/

        public ActionResult Index()
        {
            return View(mgr.GetList());
        }

        //
        // GET: /AdminStudent/Details/5

        public ActionResult Details(int id = 0)
        {
            student stu = mgr.Retrieved(id);
            if (stu == null)
            {
                return HttpNotFound();
            }
            return View(stu);
        }

        //
        // GET: /AdminStudent/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /AdminStudent/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(student stu)
        {
            if (ModelState.IsValid)
            {
                mgr.Create(stu);
                return RedirectToAction("Index");
            }

            return View(stu);
        }

        //
        // GET: /AdminStudent/Edit/5

        public ActionResult Edit(int id = 0)
        {
            student stu = mgr.Retrieved(id);
            if (stu == null)
            {
                return HttpNotFound();
            }
            return View(stu);
        }

        //
        // POST: /AdminStudent/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(student stu)
        {
            if (ModelState.IsValid)
            {
                mgr.Update(stu);
                return RedirectToAction("Index");
            }
            return View(stu);
        }

        //
        // GET: /AdminStudent/Delete/5

        public ActionResult Delete(int id = 0)
        {
            student stu = mgr.Retrieved(id);
            if (stu == null)
            {
                return HttpNotFound();
            }
            return View(stu);
        }

        //
        // POST: /AdminStudent/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            student stu = mgr.Retrieved(id);
            mgr.Delete(stu);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}