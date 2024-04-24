namespace CarDealershipSystem.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using static Common.EntityValidationConstants.Seller;

    public class Seller
    {
        public Seller()
        {
            this.Id = Guid.NewGuid();
            this.CarsForSale = new HashSet<Car>();
        }

        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(LocationCountryMaxLength)]
        public string LocationCountry { get; set; } = null!;

        [Required]
        [MaxLength(LocationCityMaxLength)]
        public string LocationCity { get; set; } = null!;

        [Required]
        [MaxLength(PhoneNumberMaxLength)]
        public string PhoneNumber { get; set; } = null!;

        public Guid UserId { get; set; }

        public virtual ApplicationUser User { get; set; } = null!;

        public virtual ICollection<Car> CarsForSale { get; set; }
    }
}
