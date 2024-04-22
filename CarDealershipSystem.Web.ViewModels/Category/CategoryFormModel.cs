namespace CarDealershipSystem.Web.ViewModels.Category
{
    using System.ComponentModel.DataAnnotations;

    using static Common.EntityValidationConstants.Category;

    public class CategoryFormModel
    {
        [Required]
        [Display(Name = "Category Name:")]
        [StringLength(NameMaxLength, MinimumLength = NameMinLength)]
        public string Name { get; set; } = null!;
    }
}
