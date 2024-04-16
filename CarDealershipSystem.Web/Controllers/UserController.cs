
namespace CarDealershipSystem.Web.Controllers
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    using CarDealershipSystem.Data.Models;
    using ViewModels.User;
    public class UserController : Controller
    {
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IUserStore<ApplicationUser> userStore;

        public UserController(SignInManager<ApplicationUser> signInManager,
                              UserManager<ApplicationUser> userManager,
                              IUserStore<ApplicationUser> userStore)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
            this.userStore = userStore;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterFormModel formModel)
        {
            if (!ModelState.IsValid)
            {
                return this.View(formModel);
            }

            ApplicationUser user = new ApplicationUser()
            {
                FirstName = formModel.FirstName,
                LastName = formModel.LastName,
            };

            await this.userManager.SetEmailAsync(user, formModel.Email);
            await this.userManager.SetUserNameAsync(user, formModel.Email);

            IdentityResult result = await this.userManager.CreateAsync(user, formModel.Password);

            if (!result.Succeeded)
            {
                foreach(IdentityError error in result.Errors) 
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }

                return View(formModel);
            }

            await this.signInManager.SignInAsync(user, false);

            return this.RedirectToAction("Index", "Home");
        }
    }
}
