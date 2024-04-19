using Microsoft.AspNetCore.Mvc;

namespace CarDealershipSystem.Web.Areas.Admin.Controllers
{
    public class HomeController : BaseAdminController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
