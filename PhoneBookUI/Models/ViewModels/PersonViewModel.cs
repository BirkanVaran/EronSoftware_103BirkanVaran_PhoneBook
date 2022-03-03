using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhoneBookUI.Models.ViewModels
{
    public class PersonViewModel
    {
        public int e_id { get; set; }
        public string e_adi_soyadi { get; set; }
        public string e_telefon { get; set; }

        public int e_kategori_id { get; set; }

        public CategoryViewModel CategoryVM { get; set; }

    }
}