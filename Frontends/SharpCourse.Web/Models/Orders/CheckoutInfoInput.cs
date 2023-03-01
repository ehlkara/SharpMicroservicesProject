using System;
using System.ComponentModel.DataAnnotations;

namespace SharpCourse.Web.Models.Orders
{
	public class CheckoutInfoInput
	{
        [Display(Name = "Province")]
        public string Province { get; set; }
        [Display(Name = "District")]
        public string District { get; set; }
        [Display(Name = "Street")]
        public string Street { get; set; }
        [Display(Name = "Zip Code")]
        public string ZipCode { get; set; }
        [Display(Name = "Address")]
        public string Line { get; set; }

        [Display(Name = "Card Name Surname")]
        public string CardName { get; set; }
        [Display(Name = "Card Number")]
        public string CardNumber { get; set; }
        [Display(Name = "Expiration")]
        public string Expiration { get; set; }
        [Display(Name = "CVV/CVC2 number")]
        public string CVV { get; set; }
        [Display(Name = "Total Price")]
        public decimal TotalPrice { get; set; }
    }
}

