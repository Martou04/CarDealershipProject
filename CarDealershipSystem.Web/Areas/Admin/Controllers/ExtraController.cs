using CarDealershipSystem.Services.Data.Interfaces;
using CarDealershipSystem.Web.ViewModels.CarExtra;
using Microsoft.AspNetCore.Mvc;

namespace CarDealershipSystem.Web.Areas.Admin.Controllers
{
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
    }
}
