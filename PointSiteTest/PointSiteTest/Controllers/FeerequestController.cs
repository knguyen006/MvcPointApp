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
    public class FeerequestController : Controller
    {
        private PointAppDBContext db = new PointAppDBContext();
        private FeerequestMgr mgr = new FeerequestMgr();
        //
        // GET: /Feerequest/

        public ActionResult Index()
        {
            var request = db.feerequests.Include(f => f.member);
            return View(request.ToList());
        }

        //
        // GET: /Feerequest/Details/5

        public ActionResult Details(int id = 0)
        {
            feerequest request = db.feerequests.Find(id);
            if (request == null)
            {
                return HttpNotFound();
            }
            return View(request);
        }

        //
        // GET: /Feerequest/Create

        public ActionResult Create()
        {
            ViewBag.memberid = new SelectList(db.members, "memberid", "username");
            return View();
        }

        //
        // POST: /Feerequest/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(feerequest request)
        {
            if (ModelState.IsValid)
            {
                mgr.Create(request);
                //db.feerequests.Add(feerequest);
                //db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.memberid = new SelectList(db.members, "memberid", "username", request.memberid);
            return View(request);
        }

        //
        // GET: /Feerequest/Edit/5

        public ActionResult Edit(int id = 0)
        {
            feerequest request = mgr.Retrieved(id);
            if (request == null)
            {
                return HttpNotFound();
            }
            ViewBag.memberid = new SelectList(db.members, "memberid", "username", request.memberid);
            return View(request);
        }

        //
        // POST: /Feerequest/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(feerequest request)
        {
            if (ModelState.IsValid)
            {
                mgr.Update(request);
                //db.Entry(feerequest).State = EntityState.Modified;
                //db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.memberid = new SelectList(db.members, "memberid", "username", request.memberid);
            return View(request);
        }

        //
        // GET: /Feerequest/Delete/5

        public ActionResult Delete(int id = 0)
        {
            feerequest request = mgr.Retrieved(id);
            if (request == null)
            {
                return HttpNotFound();
            }
            return View(request);
        }

        //
        // POST: /Feerequest/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            feerequest request = mgr.Retrieved(id);
            mgr.Delete(request);
            //db.feerequests.Remove(request);
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