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
                CategoryViewModel responseData = new CategoryViewModel();
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

        public ResponseViewModel InsertCategory(CategoryViewModel model, string uToken)
        {
            try
            {
                ResponseViewModel responseData = new ResponseViewModel();
                using (WebClient webClient=new WebClient())
                {
                    try
                    {
                        webClient.Headers.Add("islem", "KATEGORI_LISTESI_EKLE");
                        webClient.Headers.Add("utoken", uToken);
                        webClient.Encoding = Encoding.UTF8;

                        string data = JsonConvert.SerializeObject(model);

                        string response = webClient.UploadString(categoryUrl, "POST", data);

                        var result = JsonConvert.DeserializeObject<List<ResponseViewModel>>(response);

                        return result.FirstOrDefault();

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