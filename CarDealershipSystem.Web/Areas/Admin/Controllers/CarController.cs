namespace CarDealershipSystem.Web.Areas.Admin.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    using Web.ViewModels.Car;
    using Web.Infrastructure.Extensions;
    using Web.Areas.Admin.ViewModels.Car;
    using Services.Data.Interfaces;

    public class CarController : BaseAdminController
    {
        private readonly ISellerService sellerService;
        private readonly ICarService carService;

        public CarController(ISellerService sellerService, ICarService carService)
        {
            this.sellerService = sellerService;
            this.carService = carService;
        }

        public async Task<IActionResult> Mine()
        {
            string? sellerId = 
                await this.sellerService.GetSellerIdByUserIdAsync(this.User.GetId()!);
            MyCarsViewModel viewModel = new MyCarsViewModel()
            {
                AddedCars = await this.carService.AllBySellerIdAsync(sellerId!),
            };

            return this.View(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            IEnumerable<CarAdminAllViewModel> allCars = await this.carService.AllCarsForAdminAsync();

            return this.View(allCars);
        }

        public async Task<IActionResult> ChangeVisibility(string carId)
        {
            await this.carService.ChangeVisibilityAsync(carId);
            return this.RedirectToAction("All", "Car");
        }
    }
}
