namespace CarDealershipSystem.Web.Areas.Admin.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    using Services.Data.Interfaces;
    using Web.ViewModels.FuelType;
    using static Common.NotificationMessagesConstants;

    public class FuelTypeController : BaseAdminController
    {
        private readonly IFuelTypeService fuelTypeService;

        public FuelTypeController(IFuelTypeService fuelTypeService)
        {
            this.fuelTypeService = fuelTypeService;
        }

        [HttpGet]
        [Route("FuelType/All")]
        public async Task<IActionResult> All()
        {
            IEnumerable<FuelTypeAllViewModel> fuelTypes = 
                await this.fuelTypeService.AllFuelTypesNamesAsync();

            return this.View(fuelTypes);
        }

        [HttpGet]
        [Route("FuelType/Add")]
        public  IActionResult Add()
        {
            FuelTypeFormModel formModel = new FuelTypeFormModel();

            return this.View(formModel);
        }

        [HttpPost]
        [Route("FuelType/Add")]
        public async Task<IActionResult> Add(FuelTypeFormModel formModel)
        {
            if (!ModelState.IsValid)
            {
                return this.View(formModel);
            }

            bool isFuelTypeExists = await this.fuelTypeService.ExistsByNameAsync(formModel.Name);
            if (isFuelTypeExists)
            {
                this.TempData[ErrorMessage] = "The fuel type you are trying to add already exists!";

                return this.View(formModel);
            }

            try
            {
                await this.fuelTypeService.AddFuelTypeAsync(formModel);

                this.TempData[SuccessMessage] = "Fuel Type was added successfully!";
                return RedirectToAction("All", "FuelType");
            }
            catch (Exception)
            {
                this.ModelState.AddModelError(string.Empty, "Unexpected error occurred while trying to add new fuel type!");

                return this.View(formModel);
            }
        }

        [HttpGet]
        [Route("FuelType/Edit")]
        public async Task<IActionResult> Edit(int id)
        {
            bool fuelTypeExists = await this.fuelTypeService.ExistsByIdAsync(id);
            if(!fuelTypeExists)
            {
                this.TempData[ErrorMessage] = "Тhe Fuel Type you selected does not exist!";

                return this.RedirectToAction("All", "FuelType");
            }

            FuelTypeFormModel formModel = await this.fuelTypeService.GetFuelTypeForEditAsync(id);

            return this.View(formModel);
        }

        [HttpPost]
        [Route("FuelType/Edit")]
        public async Task<IActionResult> Edit(int id, FuelTypeFormModel formModel)
        {
            if(!ModelState.IsValid)
            {
                return this.View(formModel);
            }

            bool fuelTypeExists = await this.fuelTypeService.ExistsByIdAsync(id);
            if (!fuelTypeExists)
            {
                this.TempData[ErrorMessage] = "Тhe Fuel Type you selected does not exist!";

                return this.RedirectToAction("All", "FuelType");
            }

            try
            {
                await this.fuelTypeService.EditAsync(id, formModel);

                this.TempData[SuccessMessage] = "Fuel Type was edited successfully!";
                return this.RedirectToAction("All", "FuelType");
            }
            catch (Exception)
            {
                this.TempData[ErrorMessage] = "Unexpected error occurred while trying to edit the car category.";
                return this.View(formModel);
            }
        }
    }
}
