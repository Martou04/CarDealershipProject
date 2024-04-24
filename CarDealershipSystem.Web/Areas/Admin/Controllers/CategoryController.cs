namespace CarDealershipSystem.Web.Areas.Admin.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    using Web.ViewModels.Category;
    using Services.Data.Interfaces;

    using static Common.NotificationMessagesConstants;

    public class CategoryController : BaseAdminController
    {
        private readonly ICategoryService categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        [HttpGet]
        [Route("Category/All")]
        public async Task<IActionResult> All()
        {
            IEnumerable<CategoryAllViewModel> allCategories = 
                await this.categoryService.AllCategoriesNamesAsync();

            return this.View(allCategories);
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
            if(!ModelState.IsValid)
            {
                return this.View(formModel);
            }

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
                return RedirectToAction("All", "Category");
            }
            catch (Exception)
            {
                this.ModelState.AddModelError(string.Empty, "Unexpected error occurred while trying to add new car category!");

                return this.View(formModel);
            }
        }

        [HttpGet]
        [Route("Category/Edit")]
        public async Task<IActionResult> Edit(int Id)
        {
            bool categoryExists = await this.categoryService.ExistsByIdAsync(Id);
            if(!categoryExists)
            {
                this.TempData[ErrorMessage] = "Тhe category you selected does not exist!";

                return this.RedirectToAction("All", "Category");
            }
            CategoryFormModel formModel = 
                await this.categoryService.GetCategoryForEditByIdAsync(Id);

            return this.View(formModel);
        }

        [HttpPost]
        [Route("Category/Edit")]
        public async Task<IActionResult> Edit(int Id, CategoryFormModel formModel)
        {
            if(!ModelState.IsValid)
            {
                return this.View(formModel);
            }

            bool categoryExists = await this.categoryService.ExistsByIdAsync(Id);
            if (!categoryExists)
            {
                this.TempData[ErrorMessage] = "Тhe category you selected does not exist!";

                return this.RedirectToAction("All", "Category");
            }

            try
            {
                await this.categoryService.EditAsync(Id, formModel);

                this.TempData[SuccessMessage] = "Car category was edited successfully!";
                return this.RedirectToAction("All", "Category");
            }
            catch (Exception)
            {
                this.TempData[ErrorMessage] = "Unexpected error occurred while trying to edit the car category.";
                return this.View(formModel);
            }
        }

    }
}
