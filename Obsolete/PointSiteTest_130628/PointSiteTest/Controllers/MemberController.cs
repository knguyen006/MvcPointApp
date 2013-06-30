using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataLayer;
using DataLayerBusiness;
using PointSiteTest.Models;

namespace PointSiteTest.Controllers
{
    public class MemberController : Controller
    {
        //
        // GET: /Member/
        PointAppDBContext db = new PointAppDBContext();
        private MemberMgr mgr = new MemberMgr();

        public ActionResult Index(Int32? id, Int32? profileID)
        {
            return View();
        }

    }
}
