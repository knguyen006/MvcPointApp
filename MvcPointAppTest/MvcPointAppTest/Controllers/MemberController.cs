using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using System.Web;
using System.Web.Mvc;
using MvcPointAppTest.Filters;
using MvcPointAppTest.Models;

namespace MvcPointAppTest.Controllers
{
    public class MemberController : Controller
    {
        //
        // GET: /Member/

        public ActionResult Student()
        {
            return View();
        }


    }
}
