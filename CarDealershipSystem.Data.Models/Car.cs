namespace CarDealershipSystem.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using static Common.EntityValidationConstants.Car;
    using static System.Net.Mime.MediaTypeNames;

    public class Car
    {
        public Car()
        {
            this.Id = Guid.NewGuid();
            this.CarExtras = new HashSet<CarExtra>();
        }

        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(MakeMaxLength)]
        public string Make { get; set; } = null!;

        [Required]
        [MaxLength(ModelMaxLength)]
        public string Model { get; set; } = null!;

        [Required]
        [MaxLength(DescriptionMaxLength)]
        public string Description { get; set; } = null!;

        public int Year { get; set; } 

        public int Kilometers {  get; set; }

        public int Horsepower { get; set; }

        public decimal Price { get; set; }

        public DateTime CreatedOn { get; set; }

        [Required]
        [MaxLength(ImageUrlMaxLength)]
        public string ImageUrl { get; set; } = null!;

        public bool IsActive { get; set; }

        public bool Approved { get; set; }

        public int CategoryId { get; set; }

        public virtual Category Category { get; set; } = null!;

        public int FuelTypeId { get; set; }

        public virtual FuelType FuelType { get; set; } = null!;

        public int TransmissionTypeId { get; set; }

        public virtual TransmissionType TransmissionType { get; set; } = null!;

        public Guid SellerId { get; set; }

        public virtual Seller Seller { get; set;} = null!;

        public virtual ICollection<CarExtra> CarExtras { get; set; }
    }
}
