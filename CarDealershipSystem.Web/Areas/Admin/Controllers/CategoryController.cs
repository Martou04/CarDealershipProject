namespace CarDealershipSystem.Web.Areas.Admin.Controllers
{
    using CarDealershipSystem.Services.Data.Interfaces;
    using Microsoft.AspNetCore.Mvc;

    using Web.Data;
    using Web.ViewModels.Category;
    using static Common.GeneralApplicationConstants;
    using static Common.NotificationMessagesConstants;

    public class CategoryController : BaseAdminController
    {
        private readonly CarDealershipDbContext dbContext;
        private readonly ICategoryService categoryService;

        public CategoryController(CarDealershipDbContext dbContext, ICategoryService categoryService)
        {
            this.dbContext = dbContext;
            this.categoryService = categoryService;
        }

        [HttpGet]
        [Route("Category/Add")]
        public IActionResult Add()
        {
            CategoryFormModel formModel = new CategoryFormModel();

            return this.View(formModel);
        }

        [HttpPost]
        [Route("Category/Add")]
        public async Task<IActionResult> Add(CategoryFormModel formModel)
        {
            bool isCategoryExists = await this.categoryService.ExistsByNameAsync(formModel.Name);
            if(isCategoryExists)
            {
                this.TempData[ErrorMessage] = "The category you are trying to add already exists!";

                return this.View(formModel);
            }


            try
            {
                await this.categoryService.AddCategoryAsync(formModel);

                this.TempData[SuccessMessage] = "Car category was added successfully!";
                return RedirectToAction("Index", "Home");
            }
            catch (Exception)
            {
                this.ModelState.AddModelError(string.Empty, "Unexpected error occurred while trying to add new car category!");

                return this.View(formModel);
            }
        }


    }
}
