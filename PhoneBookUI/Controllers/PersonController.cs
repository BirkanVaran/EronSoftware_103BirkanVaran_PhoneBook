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

        [HttpPost]
        public ActionResult Create(string fullName, string phoneNumber, int categoryId)
        {
            
            try
            {
                bool result = webService.InsertPerson(fullName, phoneNumber, categoryId, uToken);
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

        [HttpPost]
        public ActionResult Update(string newFullName, string newPhoneNumber, int newCategoryId, int eskiId)
        {
            try
            {
                bool result = webService.UpdatePerson(newFullName, newPhoneNumber, newCategoryId, eskiId, uToken);
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
        [HttpPost]
        public ActionResult Delete(int eskiId)
        {
            try
            {
                bool result = webService.DeletePerson(eskiId, uToken);
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