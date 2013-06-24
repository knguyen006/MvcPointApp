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
using System.Data.Entity.Validation;

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
        public ActionResult Registration(member mem)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (var db = new PointAppDBContext())
                    {

                        mgr.Create(mem);

                        return RedirectToAction("Index", "Home");

                    }
                }
                else
                {
                    ModelState.AddModelError("", "Create record is incorrect!");
                }
            }
            catch (DbEntityValidationException ex)
            {
                var errors = ex.EntityValidationErrors.First(); //.ValidationErrors.First();
                foreach (var propertyError in errors.ValidationErrors)
                {
                    this.ModelState.AddModelError
                     (propertyError.PropertyName, propertyError.ErrorMessage);
                }
                return View();
            }
            return View();
        }

        public ActionResult Logout()
        {
            return View();
        }

    }
}
