﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataLayer;
using DataLayerBusiness;
using System.Data;
using System.Web.Security;

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
                //if(IsValid(mem.username, mem.userpass))
                if(mgr.UserIsValid(mem.username, mem.userpass))
                {
                    FormsAuthentication.SetAuthCookie(mem.username, false);
                    if (mgr.GetAdminUser() != null)
                    {
                        return RedirectToAction("AdminWelcome", "Account");
                    }
                    else
                    {
                        return RedirectToAction("Welcome", "Account");
                    }
                }
            }
            else
            {
                ModelState.AddModelError("", "The user name or password is incorrect!");
            }
            return View();
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
                ModelState.AddModelError("", "Create record is incorrect!");
            }

            return View();
        }


        public ActionResult Logout()
        {
            return View();
        }
        public ActionResult Welcome()
        {
            return View();
        }

        public ActionResult AdminWelcome()
        {
            return View();
        }

    }
}
