using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataLayer;
using DataLayerBusiness;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Web.Security;

namespace PointSiteTest.Controllers
{
    public class AccountController : Controller
    {
        //
        // GET: /Account/
        private MemberMgr mgr = new MemberMgr();
        private ApproleMgr rolemgr = new ApproleMgr();
        private PointAppDBContext db = new PointAppDBContext();

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
                if (mgr.UserIsValid(mem.username, mem.userpass))
                {
                    FormsAuthentication.SetAuthCookie(mem.username, false);
                    return RedirectToAction("Welcome", "Welcome");
                    /*
                    var admintxt = mgr.GetAdminUser();
                    if (admintxt != null)
                    {
                        return RedirectToAction("AdminWelcome", "AdminWelcome");
                    }
                    else
                    {
                        return RedirectToAction("Welcome", "Welcome");
                    }
                    */
                }
                else
                {
                    ModelState.AddModelError("", "The user name or password provided is incorrect!");
                }
            }
            return View(mem);
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(member mem)
        {
            if (ModelState.IsValid)
            {
                mgr.Create(mem);

                return RedirectToAction("Login", "Account");
            }
            else
            {
                ModelState.AddModelError("", "Register data is incorrect!  Please check user name and password again.");
            }

            return View();
        }

        [Authorize(Roles="Member")]
        public ActionResult Welcome()
        {
            return View();
        }

        [Authorize(Roles="Admin")]
        public ActionResult AdminWelcome()
        {
            return View();
        }
    }
}
