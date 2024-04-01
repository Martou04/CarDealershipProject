
namespace CarDealershipSystem.Web.ViewModels.Seller
{
    using System.ComponentModel.DataAnnotations;

    using static Common.EntityValidationConstants.Seller;
    public class BecomeSellerFormModel
    {
        [Required]
        [StringLength(LocationCountryMaxLength, MinimumLength = LocationCountryMinLength)]
        [Display(Name = "Location Country")]
        public string LocationCountry { get; set; } = null!;

        [Required]
        [StringLength(LocationCityMaxLength, MinimumLength = LocationCityMinLength)]
        [Display(Name = "Location City")]
        public string LocationCity { get; set; } = null!;

        [Required]
        [StringLength(PhoneNumberMaxLength, MinimumLength = PhoneNumberMinLength)]
        [Phone]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; } = null!;
    }
}
