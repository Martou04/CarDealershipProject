﻿namespace CarDealershipSystem.Services.Data
{
    using Microsoft.EntityFrameworkCore;

    using Interfaces;
    using Web.Data;
    using Web.ViewModels.Category;

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
                .AsNoTracking()
                .Select(c => new CarSelectCategoryFormModel
                {
                    Id = c.Id,
                    Name = c.Name,
                })
                .ToArrayAsync();

            return allCategories;
        }
    }
}