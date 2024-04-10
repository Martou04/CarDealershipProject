﻿using System.ComponentModel.DataAnnotations;

namespace CarDealershipSystem.Web.ViewModels.Seller
{
    public class SellerInfoOnCarDetailsViewModel
    {
        public string Email { get; set; } = null!;

        [Display(Name = "Phone")]
        public string PhoneNumber { get; set; } = null!;
    }
}
