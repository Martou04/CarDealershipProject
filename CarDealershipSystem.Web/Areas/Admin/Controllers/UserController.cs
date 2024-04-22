namespace CarDealershipSystem.Web.Areas.Admin.Controllers
{
    using CarDealershipSystem.Web.ViewModels.User;
    using Microsoft.AspNetCore.Mvc;

    using Services.Data.Interfaces;

    public class UserController : BaseAdminController
    {
        private readonly IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        [Route("User/All")]
        public async Task<IActionResult> All()
        {
            IEnumerable<UserViewModel> viewModels = await this.userService.AllAsync();

            return this.View(viewModels);
        }
    }
}
