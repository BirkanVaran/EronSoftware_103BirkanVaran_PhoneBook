using PhoneBookUI.Models;
using PhoneBookUI.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PhoneBookUI.WebServices;

namespace PhoneBookUI.Controllers
{
    public class CategoryController : Controller
    {
        WebService webService = new WebService();
        string uToken = CurrentUserToken.Token;


        // GET: Category

        
        public ActionResult CategoryList()
        {
            var categoryList = webService.GetAllCategories(uToken);
            return View(categoryList);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(string categoryName)
        {
            try
            {
                bool result = webService.InsertCategory(categoryName, uToken);
                if (result)
                {
                    return RedirectToAction("CategoryList", "Category");
                }
                return View();
            }
            catch (Exception)
            {

                return View();
            }
        }



        public ActionResult Update(int id)
        {
            ViewBag.categoryid = id;
            return View();
        }

        [HttpPost]
        public ActionResult Update(int eskiId, string newCategoryName)
        {
            try
            {
                bool result = webService.UpdateCategory(newCategoryName,eskiId, uToken);
                if (result)
                {
                    return RedirectToAction("CategoryList", "Category");
                }
                return RedirectToAction("CategoryList", "Category");
            }
            catch (Exception)
            {

                return View();
            }
        }

        public ActionResult Delete(int eskiId)
        {
            try
            {
                bool result = webService.DeleteCategory(eskiId, uToken);
                if (result)
                {
                    return RedirectToAction("CategoryList", "Category");
                }
                return RedirectToAction("CategoryList", "Category");
            }
            catch (Exception)
            {

                return View();
            }
        }
    }
}