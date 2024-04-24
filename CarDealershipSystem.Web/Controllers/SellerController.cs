namespace CarDealershipSystem.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using ViewModels.Seller;
    using Infrastructure.Extensions;
    using Services.Data.Interfaces;

    using static Common.NotificationMessagesConstants;

    [Authorize]
    public class SellerController : Controller
    {
        private readonly ISellerService sellerService;

        public SellerController(ISellerService sellerService)
        {
            this.sellerService = sellerService;
        }

        [HttpGet]
        public async Task<IActionResult> Become()
        {
            string? userId = this.User.GetId();
            bool isSeller = await sellerService.SellerExistsByUserIdAsync(userId!);
            if(isSeller)
            {
                this.TempData[ErrorMessage] = "You are already a seller!";

                return RedirectToAction("Index", "Home");
            }

            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Become(BecomeSellerFormModel formModel)
        {
            string? userId = User.GetId();
            bool isSeller = await sellerService.SellerExistsByUserIdAsync(userId!);
            if(isSeller)
            {
                this.TempData[ErrorMessage] = "You are already a seller!";

                return RedirectToAction("Index", "Home");
            }

            bool isPhoneNumberTaken =
                await this.sellerService.SellerExistsByPhoneNumberAsync(formModel.PhoneNumber);
            if(isPhoneNumberTaken)
            {
                this.ModelState.AddModelError(nameof(formModel.PhoneNumber), "Seller with the provided phone number already exists!");
            }

            if (!ModelState.IsValid)
            {
                return this.View(formModel);
            }

            try
            {
                await this.sellerService.Create(userId!, formModel);
            }
            catch
            {
                this.TempData[ErrorMessage] =
                    "Unexpected error occurred while registering you as a seller! Please try again later or contact administrator.";

                return RedirectToAction("Index", "Home");
            }

            return RedirectToAction("All", "Car");
        }
    }
}
