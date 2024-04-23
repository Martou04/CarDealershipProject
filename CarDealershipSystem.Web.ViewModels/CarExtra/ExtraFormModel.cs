namespace CarDealershipSystem.Web.ViewModels.CarExtra
{
    using System.ComponentModel.DataAnnotations;

    using static Common.EntityValidationConstants.Extra;
    public class ExtraFormModel
    {
        public ExtraFormModel()
        {
            this.ExtraTypes = new HashSet<CarExtrasViewModel>();
        }

        [Required]
        [StringLength(NameMaxLength, MinimumLength = NameMinLength)]
        public string Name { get; set; } = null!;

        [Display(Name = "Extra Type")]
        public int ExtraTypeId { get; set; }

        public IEnumerable<CarExtrasViewModel> ExtraTypes { get; set; }
    }
}
