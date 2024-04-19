namespace CarDealershipSystem.Web.ViewModels.Home
{
    using Services.Mapping;
    using CarDealershipSystem.Data.Models;
    public class IndexViewModel : IMapFrom<Car>
    {
        public string Id { get; set; } = null!;

        public string Make { get; set; } = null!;

        public string Model { get; set; } = null!;

        public int Year { get; set; }

        public int Horsepower { get; set; }

        public string FuelType { get; set; } = null!;

        public string TransmissionType { get; set; } = null!;

        public decimal Price { get; set; }

        public string ImageUrl { get; set; } = null!;

        public DateTime CreatedOn { get; set; }
    }
}
