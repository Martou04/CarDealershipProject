namespace CarDealershipSystem.Web.ViewModels.Car
{
    using CarDealershipSystem.Data.Models;
    using CarDealershipSystem.Services.Mapping;

    public class CarAdminAllViewModel : IMapFrom<Car>
    {
        public string Id { get; set; } = null!;

        public string Make { get; set; } = null!;

        public string Model { get; set; } = null!;

        public int Year { get; set; }

        public decimal Price { get; set; }

        public bool Approved { get; set; }
    }
}
