using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PhoneBookUI.Models.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        public string e_kullanici_adi { get; set; }

        [DataType(DataType.Password)]
        public string e_sifre { get; set; }
    }
}