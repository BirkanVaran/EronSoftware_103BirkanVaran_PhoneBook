using PhoneBookUI.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PhoneBookUI.WebServices;
using PhoneBookUI.Models;

namespace PhoneBookUI.Controllers
{
    public class AccountController : Controller
    {
        WebService webService = new WebService();
        // GET: Account

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
        public ActionResult Login(LoginViewModel loginModel)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            try
            {
                ResponseViewModel responseData = webService.Login(loginModel);
                if (!string.IsNullOrEmpty(responseData.UTOKEN))
                {
                    CurrentUserToken.Token = responseData.UTOKEN;
                    TempData["PersonelAdiSoyadi"] = responseData.e_personel_adi_soyadi;
                    return RedirectToAction("Birkan", "Account");
                }
                return RedirectToAction("Index", "Home");
            }
            catch (Exception)
            {
                return View();
            }


        }
        public ActionResult Birkan()
        {
            return View();
        }


    }
}