namespace CarDealershipSystem.Web.Areas.Admin.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    using Services.Data.Interfaces;
    using Web.ViewModels.CarExtra;

    using static Common.NotificationMessagesConstants;

    public class ExtraController : BaseAdminController
    {
        private readonly IExtraService extraService;

        public ExtraController(IExtraService extraService)
        {
            this.extraService = extraService;
        }

        [HttpGet]
        [Route("Extra/All")]
        public async Task<IActionResult> All()
        {
            IEnumerable<CarExtrasViewModel> allExtras = await this.extraService.AllExtrasAndTypesAsync();

            return this.View(allExtras);
        }

        [HttpGet]
        [Route("Extra/Add")]
        public async Task<IActionResult> Add()
        {
            ExtraFormModel formModel = new ExtraFormModel()
            {
                ExtraTypes = await this.extraService.AllExtraTypesAsync()
            };

            return this.View(formModel);
        }

        [HttpPost]
        [Route("Extra/Add")]
        public async Task<IActionResult> Add(ExtraFormModel formModel)
        {
            if(!ModelState.IsValid)
            {
                formModel.ExtraTypes = await this.extraService.AllExtraTypesAsync();
                return this.View(formModel);
            }

            bool isExtraExists = 
                await this.extraService.ExtraExistsByNameAndTypeAsync(formModel.ExtraTypeId, formModel.Name);
            if(isExtraExists)
            {
                this.TempData[ErrorMessage] = "The extra you are trying to add already exists!";
                formModel.ExtraTypes = await this.extraService.AllExtraTypesAsync();

                return this.View(formModel);
            }

            try
            {
                await this.extraService.AddExtraAsync(formModel);

                this.TempData[SuccessMessage] = "Extra was added successfully!";
                return RedirectToAction("All", "Extra");
            }
            catch (Exception)
            {
                this.ModelState.AddModelError(string.Empty, "Unexpected error occurred while trying to add new extra!");
                formModel.ExtraTypes = await this.extraService.AllExtraTypesAsync();

                return this.View(formModel);
            }
        }

        [HttpGet]
        [Route("Extra/Edit")]
        public async Task<IActionResult> Edit(string Id)
        {
            bool extraExists = await this.extraService.ExtraExistsByIdAsync(Id);
            if(!extraExists)
            {
                this.TempData[ErrorMessage] = "Тhe Extra you selected does not exist!";
                
                return this.RedirectToAction("All", "Extra");
            }

            ExtraFormModel formModel = await this.extraService.GetExtraForEditByIdAsync(Id);
            formModel.ExtraTypes = await this.extraService.AllExtraTypesAsync();

            return this.View(formModel);
        }

        [HttpPost]
        [Route("Extra/Edit")]
        public async Task<IActionResult> Edit(string Id, ExtraFormModel formModel)
        {
            if(!ModelState.IsValid)
            {
                formModel.ExtraTypes = await this.extraService.AllExtraTypesAsync();

                return this.View(formModel);
            }

            bool extraExists = await this.extraService.ExtraExistsByIdAsync(Id);
            if (!extraExists)
            {
                this.TempData[ErrorMessage] = "Тhe Extra you selected does not exist!";

                return this.RedirectToAction("All", "Extra");
            }

            try
            {
                await this.extraService.EditAsync(Id, formModel);

                this.TempData[SuccessMessage] = "Extra was edited successfully!";
                return this.RedirectToAction("All", "Extra");
            }
            catch (Exception)
            {
                this.TempData[ErrorMessage] = "Unexpected error occurred while trying to edit the extra.";
                formModel.ExtraTypes = await this.extraService.AllExtraTypesAsync();

                return this.View(formModel);
            }
        }
    }
}
