namespace CarDealershipSystem.Services.Data
{
    using Microsoft.EntityFrameworkCore;

    using Interfaces;
    using Web.Data;
    using Web.ViewModels.Category;
    using CarDealershipSystem.Data.Models;

    public class CategoryService : ICategoryService
    {
        private readonly CarDealershipDbContext dbContext;

        public CategoryService(CarDealershipDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<CarSelectCategoryFormModel>> AllCategoriesAsync()
        {
            IEnumerable<CarSelectCategoryFormModel> allCategories = await this.dbContext
                .Categories
                .Select(c => new CarSelectCategoryFormModel
                {
                    Id = c.Id,
                    Name = c.Name,
                })
                .ToArrayAsync();

            return allCategories;
        }

        public async Task<bool> ExistsByIdAsync(int Id)
        {
            bool result = await this.dbContext
                .Categories
                .AnyAsync(c => c.Id == Id);

            return result;
        }

        public async Task<IEnumerable<string>> AllCategoryNamesAsync()
        {
            IEnumerable<string> allNames = await this.dbContext
                .Categories
                .Select (c => c.Name)
                .ToArrayAsync();

            return allNames;
        }

        public async Task AddCategoryAsync(CategoryFormModel formModel)
        {
            Category newCategory = new Category()
            {
                Name = formModel.Name,
            };

            await this.dbContext.Categories.AddAsync(newCategory);
            await this.dbContext.SaveChangesAsync();
        }

        public async Task<bool> ExistsByNameAsync(string name)
        {
            bool result = await this.dbContext
                .Categories
                .AnyAsync (c => c.Name == name);

            return result;
        }

        public async Task<IEnumerable<CategoryAllViewModel>> AllCategorysNamesAsync()
        {
            ICollection<CategoryAllViewModel> categories = await this.dbContext
                .Categories
                .Select(c => new CategoryAllViewModel
                {
                    Id = c.Id,
                    Name= c.Name,
                })
                .ToArrayAsync();

            return categories;
        }

        public async Task<CategoryFormModel> GetCategoryForEditByIdAsync(int Id)
        {
            Category category = await this.dbContext
                .Categories
                .FirstAsync(c => c.Id == Id);

            CategoryFormModel formModel = new CategoryFormModel()
            {
                Name = category.Name,
            };

            return formModel;
        }

        public async Task EditAsync(int Id, CategoryFormModel model)
        {
            Category category = await this.dbContext
                .Categories
                .FirstAsync(c => c.Id == Id);

            category.Name = model.Name;

            await this.dbContext.SaveChangesAsync();
        }
    }
}
