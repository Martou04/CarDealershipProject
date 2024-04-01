

namespace CarDealershipSystem.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using static Common.EntityValidationConstants.FuelType;

    public class FuelType
    {
        public FuelType()
        {
            this.Cars = new HashSet<Car>();
        }

        public int Id { get; set; }

        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; } = null!;

        public virtual ICollection<Car> Cars { get; set; }
    }
}
