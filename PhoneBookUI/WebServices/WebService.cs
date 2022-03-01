using Newtonsoft.Json;
using PhoneBookUI.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;

namespace PhoneBookUI.WebServices
{
    public class WebService
    {
        public const string pToken = "OPp60lBs9vqqNiAvzM2QPsgVuzHvld4ZShVGqlYqEcEgi2BGFt";
        public const string autUrl = "http://eronsoftware.com:55301/KULLANICI/authentication/";
        public const string categoryUrl = "http://eronsoftware.com:55301/KULLANICI/kategori/";
        public const string personUrl = "http://eronsoftware.com:55301/KULLANICI/kisi/";


        public ResponseViewModel Login(LoginViewModel model)
        {

            try
            {
  
                using (WebClient webClient = new WebClient())
                {
                    try
                    {
                        webClient.Headers.Add("ptoken", pToken);
                        webClient.Headers.Add("islem", "LOGIN");
                        webClient.Encoding = Encoding.UTF8;

                        string data = JsonConvert.SerializeObject(model);
                        string response = webClient.UploadString(autUrl, "POST", data);

                        var result = JsonConvert.DeserializeObject<List<ResponseViewModel>>(response);

                        return result.FirstOrDefault();


                    }
                    catch (Exception ex)
                    {

                        throw ex;
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Logout(string uToken)
        {
            try
            {
                using (WebClient webClient = new WebClient())
                {
                    try
                    {
                        webClient.Headers.Add("islem", "LOGOUT");
                        webClient.Headers.Add("utoken", uToken);
                        webClient.Encoding = Encoding.UTF8;

                        string response = webClient.UploadString(autUrl, "POST", string.Empty);

                        var result = JsonConvert.DeserializeObject<List<ResponseViewModel>>(response);

                        return result.FirstOrDefault().MESAJ == "Çıkış Yapıldı" ? true : false;
                    }
                    catch (Exception ex)
                    {

                        throw ex;
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<CategoryViewModel> GetAllCategories(string uToken)
        {
            try
            {
                using (WebClient webClient = new WebClient())
                {
                    try
                    {
                        webClient.Headers.Add("islem", "KATEGORI_LISTESI");
                        webClient.Headers.Add("utoken", uToken);
                        webClient.Encoding = Encoding.UTF8;

                        string response = webClient.UploadString(categoryUrl, "POST", string.Empty);


                        var result = JsonConvert.DeserializeObject<List<CategoryViewModel>>(response);

                        return result;

                    }
                    catch (Exception ex)
                    {

                        throw ex;
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool InsertCategory(string categoryName, string uToken)
        {
            try
            {
                CategoryInsertViewModel insertModel = new CategoryInsertViewModel()
                {
                    e_kategori_adi = categoryName
                };
                using (WebClient webClient=new WebClient())
                {
                    try
                    {
                        webClient.Headers.Add("islem", "KATEGORI_LISTESI_EKLE");
                        webClient.Headers.Add("utoken", uToken);
                        webClient.Encoding = Encoding.UTF8;

                        string data = JsonConvert.SerializeObject(insertModel);

                        string response = webClient.UploadString(categoryUrl, "POST", data);

                        var result = JsonConvert.DeserializeObject<List<ResponseViewModel>>(response);

                        return result.FirstOrDefault().MESAJ == "Kategori kayıt edildi" ? true : false;


                    }
                    catch (Exception)
                    {

                        throw;
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }

        }

        public bool UpdateCategory(string newCategoryName, int eskiId, string uToken)
        {
            try
            {
                CategoryUpdateViewModel updateModel = new CategoryUpdateViewModel()
                {
                    e_kategori_adi = newCategoryName,
                    ESKI_ID = eskiId
                };
                using (WebClient webClient = new WebClient())
                {
                    try
                    {
                        webClient.Headers.Add("islem", "KATEGORI_LISTESI_DUZENLE");
                        webClient.Headers.Add("utoken", uToken);
                        webClient.Encoding = Encoding.UTF8;

                        string data = JsonConvert.SerializeObject(updateModel);

                        string response = webClient.UploadString(categoryUrl, "POST", data);

                        var result = JsonConvert.DeserializeObject<List<ResponseViewModel>>(response);

                        return result.FirstOrDefault().MESAJ == "Kategori güncellendi" ? true : false;


                    }
                    catch (Exception)
                    {

                        throw;
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }

        }

        public bool DeleteCategory(int eskiId, string uToken)
        {
            try
            {
                CategoryDeleteViewModel deleteModel = new CategoryDeleteViewModel()
                {
                    ESKI_ID = eskiId
                };
                using (WebClient webClient = new WebClient())
                {
                    try
                    {
                        webClient.Headers.Add("islem", "KATEGORI_LISTESI_SIL");
                        webClient.Headers.Add("utoken", uToken);
                        webClient.Encoding = Encoding.UTF8;

                        string data = JsonConvert.SerializeObject(deleteModel);

                        string response = webClient.UploadString(categoryUrl, "POST", data);

                        var result = JsonConvert.DeserializeObject<List<ResponseViewModel>>(response);

                        return result.FirstOrDefault().MESAJ == "Kategori silindi" ? true : false;


                    }
                    catch (Exception)
                    {

                        throw;
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }

        }

        public List<PersonViewModel> GetAllPeople(string uToken)
        {
            try
            {
                using (WebClient webClient = new WebClient())
                {
                    try
                    {
                        webClient.Headers.Add("islem", "KISI_LISTESI");
                        webClient.Headers.Add("utoken", uToken);
                        webClient.Encoding = Encoding.UTF8;

                        string response = webClient.UploadString(personUrl, "POST", string.Empty);


                        var result = JsonConvert.DeserializeObject<List<PersonViewModel>>(response);

                        return result;

                    }
                    catch (Exception ex)
                    {

                        throw ex;
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool InsertPerson(string fullName, string phoneNumber, int categoryId, string uToken)
        {
            try
            {
                PersonInsertViewModel insertModel = new PersonInsertViewModel()
                {
                    e_kategori_id=categoryId,
                    e_adi_soyadi=fullName,
                    e_telefon=phoneNumber

                };
                using (WebClient webClient = new WebClient())
                {
                    try
                    {
                        webClient.Headers.Add("islem", "KISI_LISTESI_EKLE");
                        webClient.Headers.Add("utoken", uToken);
                        webClient.Encoding = Encoding.UTF8;

                        string data = JsonConvert.SerializeObject(insertModel);

                        string response = webClient.UploadString(personUrl, "POST", data);

                        var result = JsonConvert.DeserializeObject<List<ResponseViewModel>>(response);

                        return result.FirstOrDefault().MESAJ == "Kişi rehbere eklendi" ? true : false;


                    }
                    catch (Exception)
                    {

                        throw;
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }

        }

        public bool UpdatePerson(string newFullName, string newPhoneNumber,int newCategoryId, int eskiId, string uToken)
        {
            try
            {
                PersonUpdateViewModel updateModel = new PersonUpdateViewModel()
                {
                    e_kategori_id=newCategoryId,
                    e_adi_soyadi=newFullName,
                    e_telefon=newPhoneNumber,
                    ESKI_ID=eskiId

                };
                using (WebClient webClient = new WebClient())
                {
                    try
                    {
                        webClient.Headers.Add("islem", "KISI_LISTESI_DUZENLE");
                        webClient.Headers.Add("utoken", uToken);
                        webClient.Encoding = Encoding.UTF8;

                        string data = JsonConvert.SerializeObject(updateModel);

                        string response = webClient.UploadString(categoryUrl, "POST", data);

                        var result = JsonConvert.DeserializeObject<List<ResponseViewModel>>(response);

                        return result.FirstOrDefault().MESAJ == "Kişi bilgisi güncellendi" ? true : false;


                    }
                    catch (Exception)
                    {

                        throw;
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }

        }

        public bool DeletePerson(int eskiId, string uToken)
        {
            try
            {
                PersonDeleteViewModel deleteModel = new PersonDeleteViewModel()
                {
                    ESKI_ID = eskiId
                };
                using (WebClient webClient = new WebClient())
                {
                    try
                    {
                        webClient.Headers.Add("islem", "KISI_LISTESI_SIL");
                        webClient.Headers.Add("utoken", uToken);
                        webClient.Encoding = Encoding.UTF8;

                        string data = JsonConvert.SerializeObject(deleteModel);

                        string response = webClient.UploadString(personUrl, "POST", data);

                        var result = JsonConvert.DeserializeObject<List<ResponseViewModel>>(response);

                        return result.FirstOrDefault().MESAJ == "Kişi silindi" ? true : false;


                    }
                    catch (Exception)
                    {

                        throw;
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }

        }







    }
}