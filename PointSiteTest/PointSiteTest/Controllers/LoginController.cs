using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataLayer;
using System.Web.Security;
using DataLayerBusiness;

namespace PointSiteTest.Controllers
{
    public class LoginController : Controller
    {
        //
        // GET: /Login/

        PointAppDBContext db = new PointAppDBContext();
        MemberMgr mgr = new MemberMgr();

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Login(member mem)
        {
            /*
            var authenticatedMember = mgr.GetAccount(mem);
            if(authenticatedMember != null)
            {

            }
             * */

            return View(mem);
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

    }
}
