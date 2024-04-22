namespace CarDealershipSystem.Web.ViewModels.FuelType
{
    using System.ComponentModel.DataAnnotations;

    using static Common.EntityValidationConstants.FuelType;

    public class FuelTypeFormModel
    {
        [Required]
        [StringLength(NameMaxLength, MinimumLength = NameMinLength)]
        public string Name { get; set; } = null!;
    }
}
