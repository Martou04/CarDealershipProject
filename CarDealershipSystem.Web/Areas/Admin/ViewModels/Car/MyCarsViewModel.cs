namespace CarDealershipSystem.Web.Areas.Admin.ViewModels.Car
{
    using CarDealershipSystem.Web.ViewModels.Car;

    public class MyCarsViewModel
    {
        public IEnumerable<AllSellerCars> AddedCars { get; set; } = null!;
    }
}
