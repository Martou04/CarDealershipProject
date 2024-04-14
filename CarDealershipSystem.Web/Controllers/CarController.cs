namespace CarDealershipSystem.Web.Controllers
{
    using CarDealershipSystem.Data.Models;
    using CarDealershipSystem.Services.Data.Interfaces;
    using CarDealershipSystem.Services.Data.Models.Car;
    using CarDealershipSystem.Web.Infrastructure.Extensions;
    using CarDealershipSystem.Web.ViewModels.Car;
    using CarDealershipSystem.Web.ViewModels.CarExtra;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using static Common.NotificationMessagesConstants;

    [Authorize]    
    public class CarController : Controller
    {
        private readonly ICarService carService;
        private readonly ISellerService sellerService;
        private readonly ICategoryService categoryService;
        private readonly IFuelTypeService fuelTypeService;
        private readonly ITransmissionTypeService transmissionTypeService;
        private readonly IExtraService extraService;

        public CarController(ICarService carService,ISellerService sellerService, 
                             ICategoryService categoryService, IFuelTypeService fuelTypeService, 
                             ITransmissionTypeService transmissionTypeService, IExtraService extraService)
        {
            this.carService = carService;
            this.sellerService = sellerService;
            this.categoryService = categoryService;
            this.fuelTypeService = fuelTypeService;
            this.transmissionTypeService = transmissionTypeService;
            this.extraService = extraService;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> All([FromQuery]AllCarsQueryModel queryModel)
        {
            AllCarsFilteredAndPagedServiceModel serviceModel = 
                await this.carService.AllAsync(queryModel);

            queryModel.Cars = serviceModel.Cars;
            queryModel.TotalCars = serviceModel.TotalCarsCount;
            queryModel.Categories = await this.categoryService.AllCategoryNamesAsync();

            return this.View(queryModel);
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

            try
            {
                CarFormModel formModel = new CarFormModel()
                {
                    Categories = await this.categoryService.AllCategoriesAsync(),
                    FuelTypes = await this.fuelTypeService.AllFuelTypesAsync(),
                    TransmissionTypes = await this.transmissionTypeService.AllTransmissionTypesAsync(),
                    CarExtras = await this.extraService.AllExtrasAndTypesAsync(),
                };

                return View(formModel);
            }
            catch (Exception)
            {
                return this.GeneralError();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Add(CarFormModel formModel)
        {
            bool isSeller =
                await this.sellerService.SellerExistsByUserIdAsync(this.User.GetId()!);

            if (!isSeller)
            {
                this.TempData[ErrorMessage] = "You must become a seller in order to add new cars for sale!";

                return RedirectToAction("Become", "Seller");
            }

            bool categoryExists = 
                await this.categoryService.ExistsByIdAsync(formModel.CategoryId);
            if(!categoryExists)
            {
                this.ModelState.AddModelError(nameof(formModel.CategoryId), "Selected category does not exist!");
            }

            bool fuelTypeExists =
                await this.fuelTypeService.ExistsByIdAsync(formModel.FuelTypeId);
            if(!fuelTypeExists)
            {
                this.ModelState.AddModelError(nameof(formModel.FuelTypeId), "Selected fuel type does not exist!");
            }

            bool transmissionTypeExists =
                await this.transmissionTypeService.ExistsByIdAsync(formModel.TransmissionTypeId);
            if (!transmissionTypeExists)
            {
                this.ModelState.AddModelError(nameof(formModel.TransmissionTypeId), "Selected transmission type does not exist!");
            }

            if (!ModelState.IsValid)
            {
                formModel.Categories = await this.categoryService.AllCategoriesAsync();
                formModel.FuelTypes = await this.fuelTypeService.AllFuelTypesAsync();
                formModel.TransmissionTypes = await this.transmissionTypeService.AllTransmissionTypesAsync();
                formModel.CarExtras = await this.extraService.AllExtrasAndTypesAsync();

                return this.View(formModel);
            }

            try
            {
                string? sellerId = 
                    await this.sellerService.GetSellerIdByUserIdAsync(this.User.GetId()!);

                List<Guid> selectedExtrasIds = formModel.SelectedExtrasIds.ToList();

                string carId = 
                    await this.carService.CreateAndReturnIdAsync(formModel, sellerId!,selectedExtrasIds);

                this.TempData[SuccessMessage] = "Car was added successfully!";
                return this.RedirectToAction("Details", "Car", new {id = carId});
            }
            catch (Exception)
            {
                this.ModelState.AddModelError(string.Empty, "Unexpected error occurred while trying to add your car for sale!");
                formModel.Categories = await this.categoryService.AllCategoriesAsync();
                formModel.FuelTypes = await this.fuelTypeService.AllFuelTypesAsync();
                formModel.TransmissionTypes = await this.transmissionTypeService.AllTransmissionTypesAsync();
                formModel.CarExtras = await this.extraService.AllExtrasAndTypesAsync();

                return this.View(formModel);
            }
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Details(string id)
        {
            bool carExists = await this.carService
                .ExistsByIdAsync(id);
            if (!carExists)
            {
                this.TempData[ErrorMessage] = "Car with the provided id does not exist!";

                return this.RedirectToAction("All", "Car");
            }

            try
            {
                CarDetailsViewModel viewModel = await this.carService
                .GetDetailsByIdAsync(id);

                return this.View(viewModel);
            }
            catch (Exception)
            {
                return this.GeneralError();
            }
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            bool carExists = await this.carService
                .ExistsByIdAsync(id);
            if(!carExists)
            {
                this.TempData[ErrorMessage] = "Car with the provided id does not exist!";

                return this.RedirectToAction("All", "Car");
            }

            bool isUserSeller = await this.sellerService
                .SellerExistsByUserIdAsync(this.User.GetId()!);
            if(!isUserSeller)
            {
                this.TempData[ErrorMessage] = "You must become a seller in order to edit car info!";

                return this.RedirectToAction("Become", "Seller");
            }

            string? sellerId = 
                await this.sellerService.GetSellerIdByUserIdAsync(this.User.GetId()!);
            bool isSellerOwner = await this.carService
                .IsSellerWithIdOwnerOfCarWithIdAsync(id, sellerId!);
            if(!isSellerOwner)
            {
                this.TempData[ErrorMessage] = "You must be the seller owner of the car you want to edit!";

                return this.RedirectToAction("Mine", "Car");
            }

            try
            {
                CarFormModel formModel = await this.carService
                .GetCarForEditByIdAsync(id);
                formModel.Categories = await this.categoryService.AllCategoriesAsync();
                formModel.FuelTypes = await this.fuelTypeService.AllFuelTypesAsync();
                formModel.TransmissionTypes = await this.transmissionTypeService.AllTransmissionTypesAsync();
                formModel.CarExtras = await this.extraService.AllExtrasAndTypesAsync();

                return this.View(formModel);
            }
            catch (Exception)
            {
                return this.GeneralError();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(string id, CarFormModel formModel)
        {
            if(!this.ModelState.IsValid)
            {
                formModel.Categories = await this.categoryService.AllCategoriesAsync();
                formModel.FuelTypes = await this.fuelTypeService.AllFuelTypesAsync();
                formModel.TransmissionTypes = await this.transmissionTypeService.AllTransmissionTypesAsync();
                formModel.CarExtras = await this.extraService.AllExtrasAndTypesAsync();
                return this.View(formModel);
            }

            bool carExists = await this.carService
                .ExistsByIdAsync(id);
            if (!carExists)
            {
                this.TempData[ErrorMessage] = "Car with the provided id does not exist!";

                return this.RedirectToAction("All", "Car");
            }

            bool isUserSeller = await this.sellerService
                .SellerExistsByUserIdAsync(this.User.GetId()!);
            if (!isUserSeller)
            {
                this.TempData[ErrorMessage] = "You must become a seller in order to edit car info!";

                return this.RedirectToAction("Become", "Seller");
            }

            string? sellerId =
                await this.sellerService.GetSellerIdByUserIdAsync(this.User.GetId()!);
            bool isSellerOwner = await this.carService
                .IsSellerWithIdOwnerOfCarWithIdAsync(id, sellerId!);
            if (!isSellerOwner)
            {
                this.TempData[ErrorMessage] = "You must be the seller owner of the car you want to edit!";

                return this.RedirectToAction("Mine", "Car");
            }

            try
            {
                List<Guid> selectedExtrasIds = formModel.SelectedExtrasIds.ToList();
                await this.carService.EditAsync(id, formModel, selectedExtrasIds);

                this.TempData[SuccessMessage] = "Car was edited successfully!";
                return this.RedirectToAction("Details", "Car", new { id });
            }
            catch (Exception)
            {
                this.TempData[ErrorMessage] = "Unexpected error occurred while trying to update the car. Please try again later or contact admin.";
                formModel.Categories = await this.categoryService.AllCategoriesAsync();
                formModel.FuelTypes = await this.fuelTypeService.AllFuelTypesAsync();
                formModel.TransmissionTypes = await this.transmissionTypeService.AllTransmissionTypesAsync();
                formModel.CarExtras = await this.extraService.AllExtrasAndTypesAsync();

                return this.View(formModel);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Mine()
        {
            List<AllSellerCars> myCars = new List<AllSellerCars>();

            string userId = this.User.GetId()!;
            bool isUserSeller = 
                await this.sellerService.SellerExistsByUserIdAsync(userId);

            try
            {
                if (isUserSeller)
                {
                    string? sellerId =
                        await this.sellerService.GetSellerIdByUserIdAsync(userId);

                    myCars.AddRange(await this.carService.AllBySellerIdAsync(sellerId!));
                }
                else
                {
                    this.TempData[ErrorMessage] = "You must be a seller to see your cars for sale!";

                    return this.RedirectToAction("Become", "Seller");
                }

                return this.View(myCars);
            }
            catch (Exception)
            {
                return this.GeneralError();
            }
        }

        private IActionResult GeneralError()
        {
            this.TempData[ErrorMessage] =
                "Unexpected error occurred! Please try again later or contact admin!";

            return this.RedirectToAction("Index", "Home");
        }
    }
}
