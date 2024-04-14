namespace CarDealershipSystem.Web.ViewModels.Car
{
    public class CarPreDeleteDetailsViewModel
    {
        public string Make { get; set; } = null!;

        public string Model { get; set; } = null!;

        public string ImageUrl { get; set; } = null!;

        public int Year { get; set; }

        public decimal Price { get; set; }
    }
}
