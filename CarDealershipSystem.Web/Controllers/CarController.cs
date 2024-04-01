namespace CarDealershipSystem.Web.Controllers
{
    using CarDealershipSystem.Services.Data.Interfaces;
    using CarDealershipSystem.Web.Infrastructure.Extensions;
    using CarDealershipSystem.Web.ViewModels.Car;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using static Common.NotificationMessagesConstants;

    [Authorize]    
    public class CarController : Controller
    {
        private readonly ISellerService sellerService;
        private readonly ICategoryService categoryService;
        private readonly IFuelTypeService fuelTypeService;
        private readonly ITransmissionTypeService transmissionTypeService;
        private readonly IExtraService extraService;

        public CarController(ISellerService sellerService, ICategoryService categoryService, 
                             IFuelTypeService fuelTypeService, ITransmissionTypeService transmissionTypeService, 
                             IExtraService extraService)
        {
            this.sellerService = sellerService;
            this.categoryService = categoryService;
            this.fuelTypeService = fuelTypeService;
            this.transmissionTypeService = transmissionTypeService;
            this.extraService = extraService;
        }

        [AllowAnonymous]
        public async Task<IActionResult> All()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            bool isSeller = 
                await this.sellerService.SellerExistsByUserIdAsync(this.User.GetId()!);

            if (!isSeller)
            {
                this.TempData[ErrorMessage] = "You must become a seller in order to add new cars for sale!";

                return RedirectToAction("Become", "Seller");
            }

            CarFormModel formModel = new CarFormModel()
            {
                Categories = await this.categoryService.AllCategoriesAsync(),
                FuelTypes = await this.fuelTypeService.AllFuelTypesAsync(),
                TransmissionTypes = await this.transmissionTypeService.AllTransmissionTypesAsync(),
                CarExtras = await this.extraService.AllExtrasAsync(),
            };

            return View(formModel);
        }
    }
}
