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
    public class AdminMemberController : Controller
    {
        private PointAppDBContext db = new PointAppDBContext();
        private MemberMgr mgr = new MemberMgr();
        //
        // GET: /AdminMember/

        public ActionResult Index()
        {
            return View(mgr.GetList());
        }

        //
        // GET: /AdminMember/Details/5

        public ActionResult Details(int id = 0)
        {
            member mem = mgr.Retrieved(id);
            if (mem == null)
            {
                return HttpNotFound();
            }
            return View(mem);
        }

        //
        // GET: /AdminMember/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /AdminMember/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(member mem)
        {
            if (ModelState.IsValid)
            {
                mgr.Create(mem);
                return RedirectToAction("Index");
            }

            return View(mem);
        }

        //
        // GET: /AdminMember/Edit/5

        public ActionResult Edit(int id = 0)
        {
            member mem = mgr.Retrieved(id);
            if (mem == null)
            {
                return HttpNotFound();
            }
            return View(mem);
        }

        //
        // POST: /AdminMember/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(member mem)
        {
            if (ModelState.IsValid)
            {
                mgr.Update(mem);
                return RedirectToAction("Index");
            }
            return View(mem);
        }

        //
        // GET: /AdminMember/Delete/5

        public ActionResult Delete(int id = 0)
        {
            member mem = mgr.Retrieved(id);
            if (mem == null)
            {
                return HttpNotFound();
            }
            return View(mem);
        }

        //
        // POST: /AdminMember/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            member mem = mgr.Retrieved(id);
            mgr.Delete(mem);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}