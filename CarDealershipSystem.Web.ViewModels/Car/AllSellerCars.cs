namespace CarDealershipSystem.Web.ViewModels.Car
{
    public class AllSellerCars
    {
        public string Id { get; set; } = null!;

        public string Make { get; set; } = null!;

        public string Model { get; set; } = null!;

        public string ImageUrl { get; set; } = null!;

        public int Year { get; set; }

        public decimal Price { get; set; }

        public bool Approved { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}
