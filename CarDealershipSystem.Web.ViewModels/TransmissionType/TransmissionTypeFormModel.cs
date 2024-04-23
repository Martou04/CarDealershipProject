namespace CarDealershipSystem.Web.ViewModels.TransmissionType
{
    using System.ComponentModel.DataAnnotations;

    using static Common.EntityValidationConstants.TransmissionType;
    public class TransmissionTypeFormModel
    {
        [Required]
        [StringLength(NameMaxLength, MinimumLength = NameMinLength)]
        public string Name { get; set; } = null!;
    }
}
