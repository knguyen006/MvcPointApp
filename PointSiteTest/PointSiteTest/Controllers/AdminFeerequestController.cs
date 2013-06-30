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
    public class AdminFeerequestController : Controller
    {
        private PointAppDBContext db = new PointAppDBContext();
        private FeerequestMgr mgr = new FeerequestMgr();
        //
        // GET: /AdminFeerequest/

        public ActionResult Index()
        {
            var feerequests = db.feerequests.Include(f => f.member);
            return View(feerequests.ToList());
        }

        //
        // GET: /AdminFeerequest/Details/5

        public ActionResult Details(int id = 0)
        {
            feerequest req = mgr.Retrieved(id);
            if (req == null)
            {
                return HttpNotFound();
            }
            return View(req);
        }

        //
        // GET: /AdminFeerequest/Create

        public ActionResult Create()
        {
            ViewBag.memberid = new SelectList(db.members, "memberid", "username");
            return View();
        }

        //
        // POST: /AdminFeerequest/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(feerequest req)
        {
            if (ModelState.IsValid)
            {
                mgr.Create(req);
                return RedirectToAction("Index");
            }

            ViewBag.memberid = new SelectList(db.members, "memberid", "username", req.memberid);
            return View(req);
        }

        //
        // GET: /AdminFeerequest/Edit/5

        public ActionResult Edit(int id = 0)
        {
            feerequest req = mgr.Retrieved(id);
            if (req == null)
            {
                return HttpNotFound();
            }
            ViewBag.memberid = new SelectList(db.members, "memberid", "username", req.memberid);
            return View(req);
        }

        //
        // POST: /AdminFeerequest/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(feerequest req)
        {
            if (ModelState.IsValid)
            {
                mgr.Update(req);
                return RedirectToAction("Index");
            }
            ViewBag.memberid = new SelectList(db.members, "memberid", "username", req.memberid);
            return View(req);
        }

        //
        // GET: /AdminFeerequest/Delete/5

        public ActionResult Delete(int id = 0)
        {
            feerequest req = mgr.Retrieved(id);
            if (req == null)
            {
                return HttpNotFound();
            }
            return View(req);
        }

        //
        // POST: /AdminFeerequest/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            feerequest req = mgr.Retrieved(id);
            mgr.Delete(req);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}