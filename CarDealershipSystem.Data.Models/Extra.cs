namespace CarDealershipSystem.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using static Common.EntityValidationConstants.Extra;

    public class Extra
    {
        public Extra()
        {
            this.Id = Guid.NewGuid();
            this.CarExtras = new HashSet<CarExtra>();
        }

        public Guid Id { get; set; }

        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; } = null!;

        public int TypeId { get; set; }

        public virtual ExtraType Type { get; set; }

        public virtual ICollection<CarExtra> CarExtras { get; set; }
    }
}
