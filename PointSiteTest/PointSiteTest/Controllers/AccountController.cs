using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataLayer;
using DataLayerBusiness;
using System.Web.Security;
using System.Data;
using System.Data.Entity;

namespace PointSiteTest.Controllers
{
    public class AccountController : Controller
    {
        //
        // GET: /Account/
        private MemberMgr mgr = new MemberMgr();

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(member mem)
        {
            if (ModelState.IsValid)
            {
                MemberMgr mgr = new MemberMgr();

                if (mgr.UserIsValid(mem.username, mem.userpass))
                {
                    FormsAuthentication.SetAuthCookie(mem.username, false);
                    return RedirectToAction("Index", "Welcome", "Welcome");
                }
                else
                {
                    ModelState.AddModelError("", "Login is incorrect!");
                }
            }
            return View();
        }

        [HttpGet]
        public ActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Registration(member mem)
        {
            if (ModelState.IsValid)
            {
                mgr.Create(mem);

                return RedirectToAction("Index", "Home");
            }
            return View(mem);
        }

        public ActionResult Logout()
        {
            return View();
        }

    }
}
