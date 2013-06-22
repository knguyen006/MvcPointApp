using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataLayerBusiness;
using DataLayer;

namespace PointSiteTest.Controllers
{
    public class AccountController : Controller
    {
        //
        // GET: /Account/
        MemberMgr mgr = new MemberMgr();

        public ActionResult Login()
        {
            return View();
        }

    }
}
