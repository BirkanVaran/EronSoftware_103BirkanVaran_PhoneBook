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

        public ActionResult Search(int? categoryId, string name)
        {
            if (name!=null)
            {
                PersonSearchModel searchModel = new PersonSearchModel()
                {
                    e_adi_soyadi = name,
                    e_kategori_id = categoryId
                };
                List<PersonViewModel> personList = webService.Search(uToken, searchModel);
                return View(personList);
            }
            return View();
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
        public ActionResult Update(int id)
        {
            List<SelectListItem> categoryList = new List<SelectListItem>();
            webService.GetAllCategories(CurrentUserToken.Token).ForEach(x => categoryList.Add(new SelectListItem()
            {
                Text = x.e_kategori_adi,
                Value = x.e_id.ToString()
            }));
            ViewBag.Category = categoryList;
            ViewBag.PersonId = id;
            return View();
        }

        [HttpPost]
        public ActionResult Update(PersonUpdateViewModel updateModel)
        {
            try
            {
                bool result = webService.UpdatePerson(updateModel.e_adi_soyadi, updateModel.e_kategori_id, updateModel.e_telefon, updateModel.ESKI_ID, uToken);
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