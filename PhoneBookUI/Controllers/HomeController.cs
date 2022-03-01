using PhoneBookUI.Models;
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
            if (string.IsNullOrEmpty(CurrentUserToken.Token))
            {
                return RedirectToAction("Login", "Account");
            }
            return View();
        }

        
    }
}