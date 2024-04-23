namespace CarDealershipSystem.Web.Areas.Admin.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    using Services.Data.Interfaces;
    using Web.ViewModels.TransmissionType;
    using static Common.NotificationMessagesConstants;

    public class TransmissionTypeController : BaseAdminController
    {
        private readonly ITransmissionTypeService transmissionTypeService;

        public TransmissionTypeController(ITransmissionTypeService transmissionTypeService)
        {
            this.transmissionTypeService = transmissionTypeService;
        }

        [HttpGet]
        [Route("TransmissionType/All")]
        public async Task<IActionResult> All()
        {
            IEnumerable<TransmissionTypeAllViewModel> allTransmissionTypes =
                await this.transmissionTypeService.AllTransmissionTypes();

            return this.View(allTransmissionTypes);
        }

        [HttpGet]
        [Route("TransmissionType/Add")]
        public IActionResult Add()
        {
            TransmissionTypeFormModel formModel = new TransmissionTypeFormModel();

            return this.View(formModel);
        }

        [HttpPost]
        [Route("TransmissionType/Add")]
        public async Task<IActionResult> Add(TransmissionTypeFormModel formModel)
        {
            if(!ModelState.IsValid)
            {
                return this.View(formModel);
            }

            bool isTransissionTypeExists = 
                await this.transmissionTypeService.ExistsByNameAsync(formModel.Name);
            if (isTransissionTypeExists)
            {
                this.TempData[ErrorMessage] = "The transmission type you are trying to add already exists!";

                return this.View(formModel);
            }

            try
            {
                await this.transmissionTypeService.AddTransmissionTypeAsync(formModel);

                this.TempData[SuccessMessage] = "Transmission Type was added successfully!";
                return this.RedirectToAction("All", "TransmissionType");
            }
            catch (Exception)
            {
                this.ModelState.AddModelError(string.Empty, "Unexpected error occurred while trying to add new transmission type!");

                return this.View(formModel);
            }
        }

        [HttpGet]
        [Route("TransmissionType/Edit")]
        public async Task<IActionResult> Edit(int Id)
        {
            bool isTransissionTypeExists =
                await this.transmissionTypeService.ExistsByIdAsync(Id);
            if (!isTransissionTypeExists)
            {
                this.TempData[ErrorMessage] = "Тhe Transmission Type you selected does not exist!";

                return this.RedirectToAction("All", "TransmissionType");
            }

            TransmissionTypeFormModel transmissionTypeFormModel = 
                await this.transmissionTypeService.GetTransmissionTypeForEditByIdAsync(Id);

            return this.View(transmissionTypeFormModel);
        }

        [HttpPost]
        [Route("TransmissionType/Edit")]
        public async Task<IActionResult> Edit(int Id,  TransmissionTypeFormModel formModel)
        {
            if(!ModelState.IsValid)
            {
                return this.View(formModel);
            }

            bool isTransissionTypeExists =
                await this.transmissionTypeService.ExistsByIdAsync(Id);
            if (!isTransissionTypeExists)
            {
                this.TempData[ErrorMessage] = "Тhe Transmission Type you selected does not exist!";

                return this.RedirectToAction("All", "TransmissionType");
            }

            try
            {
                await this.transmissionTypeService.EditAsync(Id, formModel);

                this.TempData[SuccessMessage] = "Transmission type was edited successfully!";
                return this.RedirectToAction("All", "TransmissionType");
            }
            catch (Exception)
            {
                this.TempData[ErrorMessage] = "Unexpected error occurred while trying to edit the transmission type.";
                return this.View(formModel);
            }
        }
    }
}
