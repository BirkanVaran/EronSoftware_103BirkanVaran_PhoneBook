﻿using PhoneBookUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PhoneBookUI.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            return RedirectToAction("Login", "Account");
        }
        public ActionResult Deneme()
        {
            return View();

        }

    }
}