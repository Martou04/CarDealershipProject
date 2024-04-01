namespace CarDealershipSystem.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using static Common.EntityValidationConstants.Extra;
    public class ExtraType
    {
        public ExtraType()
        {
            this.Extras = new HashSet<Extra>();
        }

        public int Id { get; set; }

        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; } = null!;

        public virtual ICollection<Extra> Extras { get; set; }
    }
}
