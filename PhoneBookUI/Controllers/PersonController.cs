using PhoneBookUI.Models;
using PhoneBookUI.Models.ViewModels;
using PhoneBookUI.WebServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PhoneBookUI.Controllers
{
    public class PersonController : Controller
    {
        WebService webService = new WebService();
        public string uToken = CurrentUserToken.Token;
        // GET: Category
        public ActionResult Index()
        {
            List<PersonViewModel> personList = webService.GetAllPeople(uToken);
            return View(personList);
        }

        public ActionResult Create()
        {
            List<SelectListItem> categoryList = new List<SelectListItem>();
            webService.GetAllCategories(CurrentUserToken.Token).ForEach(x => categoryList.Add(new SelectListItem()
            {
                Text = x.e_kategori_adi,
                Value = x.e_id.ToString()
            }));
            ViewBag.category = categoryList;
            
            return View();
        }

        [HttpPost]
        public ActionResult Create(PersonViewModel personModel)
        {
            
            try
            {
                bool result = webService.InsertPerson(personModel, uToken);
                if (result)
                {
                    return RedirectToAction("Index", "Person");
                }
                return RedirectToAction("Index", "Person");
            }
            catch (Exception)
            {

                return View();
            }
        }
        public ActionResult Update()
        {
            List<SelectListItem> categoryList = new List<SelectListItem>();
            webService.GetAllCategories(CurrentUserToken.Token).ForEach(x => categoryList.Add(new SelectListItem()
            {
                Text = x.e_kategori_adi,
                Value = x.e_id.ToString()
            }));
            ViewBag.Category = categoryList;
            return View();
        }

        [HttpPost]
        public ActionResult Update(PersonUpdateViewModel updateModel)
        {
            try
            {
                bool result = webService.UpdatePerson(updateModel, uToken);
                if (result)
                {
                    return RedirectToAction("Index", "Person");
                }
                return RedirectToAction("Index", "Person");
            }
            catch (Exception)
            {

                return View();
            }
        }
        public ActionResult Delete(int id)
        {
            try
            {
                bool result = webService.DeletePerson(id, uToken);
                if (result)
                {
                    return RedirectToAction("Index", "Person");
                }
                return RedirectToAction("Index", "Person");
            }
            catch (Exception)
            {

                return View();
            }
        }
    }
}