using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Shopping.Models
{
    public class ShippingDetails
    {
        public string UserName { get; set; }
        [Required(ErrorMessage = "Lütfen Adres Tanımı Giriniz")]
        public string AdressTitle { get; set; }
        [Required(ErrorMessage = "Lütfen Adres Giriniz")]
        public string Adress { get; set; }
        [Required(ErrorMessage = "Lütfen Şehir Giriniz")]
        public string City { get; set; }
        [Required(ErrorMessage = "Lütfen Semt Giriniz")]
        public string District { get; set; }
        [Required(ErrorMessage = "Lütfen Mahalle Giriniz")]
        public string Neighborhood { get; set; }
        [Required(ErrorMessage = "Lütfen Posta Kodu Giriniz")]
        public string PostCode { get; set; }



    }
}