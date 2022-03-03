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
                    Session["uToken"] = responseData.UTOKEN;
                    ViewBag.LoginMessage = "Giriş başarılı";
                    return RedirectToAction("Index", "Home");
                }
                ViewBag.LoginMessage = "Kullanıcı adı ya da şifre yanlış.";
                return View();
            }
            catch (Exception)
            {
                return View();
            }


        }


        public ActionResult Logout()
        {
            string uToken = CurrentUserToken.Token;
            try
            {
                bool sonuc = webService.Logout(uToken);
                if (sonuc)
                {
                    CurrentUserToken.Token = string.Empty;
                    return RedirectToAction("Login", "Account");
                }
                return View();

            }
            catch (Exception)
            {

                return RedirectToAction("Login", "Account");

            }
        }

        //public ActionResult Logout()
        //{
        //    try
        //    {
        //        bool sonuc = webService.Logout(Session["utoken"] as String);
        //        if (sonuc)
        //        {
        //            Session["utoken"] = string.Empty;
        //        }
        //        return RedirectToAction("Login", "Account");

        //    }
        //    catch (Exception)
        //    {

        //        return RedirectToAction("Login", "Account");

        //    }
        //}
    }
}