using System.ComponentModel.DataAnnotations;

namespace CarDealershipSystem.Web.ViewModels.Car
{
    public class CarAllViewModel
    {
        public string Id { get; set; } = null!;

        public string Make { get; set; } = null!;

        public string Model { get; set; } = null!;

        public string Description { get; set; } = null!;

        public int Year { get; set; }

        public int Horsepower { get; set; }

        public string Category { get; set; } = null!;

        [Display(Name = "Fuel Type")]
        public string FuelType { get; set; } = null!;

        [Display(Name = "Transmission Type")]
        public string TransmissionType { get; set; } = null!;

        public int Kilometers { get; set; }

        public decimal Price { get; set; }

        [Display(Name = "Image Link")]
        public string ImageUrl { get; set; } = null!;

        public DateTime CreatedOn { get; set; }

        public string LocationCountry { get; set; } = null!;

        public string LocationCity { get; set; } = null!;
    }
}
