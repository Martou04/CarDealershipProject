using CarDealershipSystem.Services.Data.Interfaces;
using CarDealershipSystem.Web.Data;
using CarDealershipSystem.Web.ViewModels.TransmissionType;
using Microsoft.AspNetCore.Mvc;

namespace CarDealershipSystem.Web.Areas.Admin.Controllers
{
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


    }
}
