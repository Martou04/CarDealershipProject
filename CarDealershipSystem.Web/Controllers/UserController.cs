﻿namespace CarDealershipSystem.Web.Controllers
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Authentication;
    using Microsoft.Extensions.Caching.Memory;

    using Griesoft.AspNetCore.ReCaptcha;

    using CarDealershipSystem.Data.Models;
    using ViewModels.User;

    using static Common.GeneralApplicationConstants;
    using static Common.NotificationMessagesConstants;

    public class UserController : Controller
    {
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IMemoryCache memoryCache;

        public UserController(SignInManager<ApplicationUser> signInManager,
                              UserManager<ApplicationUser> userManager,
                              IMemoryCache memoryCache)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;

            this.memoryCache = memoryCache;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return this.View();
        }

        [HttpPost]
        [ValidateRecaptcha(Action = "submit", 
            ValidationFailedAction = ValidationFailedAction.ContinueRequest)]
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

                return this.View(formModel);
            }

            await this.signInManager.SignInAsync(user, false);
            this.memoryCache.Remove(UsersCacheKey);

            return this.RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public async Task<IActionResult> Login(string? returnUrl = null)
        {
            await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);

            LoginFormModel model = new LoginFormModel()
            {
                ReturnUrl = returnUrl
            };

            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginFormModel model)
        {
            if(!ModelState.IsValid)
            {
                return this.View(model);
            }

            var result = 
                await this.signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);

            if(!result.Succeeded)
            {
                this.TempData[ErrorMessage] = 
                    "There was an error while logging you in! Please try again later or contact an admin.";

                return this.View(model);
            }

            return this.Redirect(model.ReturnUrl ?? "/Home/Index");
        }
    }
}
