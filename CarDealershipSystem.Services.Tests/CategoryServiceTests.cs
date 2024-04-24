namespace CarDealershipSystem.Services.Tests
{
    using CarDealershipSystem.Data.Models;
    using CarDealershipSystem.Web.ViewModels.Category;
    using Microsoft.EntityFrameworkCore;

    using Services.Data;
    using Services.Data.Interfaces;
    using Web.Data;

    using static DatabaseSeeder;

    public class CategoryServiceTests
    {
        private DbContextOptions<CarDealershipDbContext> dbOptions;
        private CarDealershipDbContext dbContext;

        private ICategoryService categoryService;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            this.dbOptions = new DbContextOptionsBuilder<CarDealershipDbContext>()
                .UseInMemoryDatabase("CarDealershipInMemory" + Guid.NewGuid().ToString())
                .Options;
            this.dbContext = new CarDealershipDbContext(this.dbOptions);

            this.dbContext.Database.EnsureCreated();
            SeedDatabase(this.dbContext);

            this.categoryService = new CategoryService(this.dbContext);
        }

        [Test]
        public async Task AllCategoriesAsync()
        {
            int categoryCount = this.dbContext.Categories.Count();

            var result = await this.categoryService.AllCategoriesAsync();

            Assert.AreEqual(categoryCount, result.Count());
        }

        [Test]
        public async Task ExistsByIdAsyncShouldReturnTrue()
        {
            int categoryId = this.dbContext.Categories.First().Id;

            var result = await this.categoryService.ExistsByIdAsync(categoryId);

            Assert.IsTrue(result);
        }

        [Test]
        public async Task ExistsByIdAsyncShouldReturnFalse()
        {
            Random rnd = new Random();
            int categoryId = rnd.Next(150, 1500);

            var result = await this.categoryService.ExistsByIdAsync(categoryId);

            Assert.IsFalse(result);
        }


        [Test]
        public async Task AllCategoryNamesAsync()
        {
            IEnumerable<string> categoryNames = this.dbContext.Categories.Select(c => c.Name);

            var result = await this.categoryService.AllCategoryNamesAsync();

            Assert.AreEqual(categoryNames, result);
        }

        [Test]
        public async Task AddCategoryAsyncAddsNewCategory()
        {
            var categoryName = "SUV";

            await categoryService.AddCategoryAsync(new CategoryFormModel { Name = categoryName });

            var addedCategory = await dbContext.Categories.FirstOrDefaultAsync(c => c.Name == categoryName);
            Assert.IsNotNull(addedCategory);
            Assert.AreEqual(categoryName, addedCategory.Name);
        }

        [Test]
        public async Task ExistsByNameAsyncShouldReturnTrue()
        {
            string name = this.dbContext.Categories.First().Name;

            bool result = await this.categoryService.ExistsByNameAsync(name);

            Assert.IsTrue(result);
        }

        [Test]
        public async Task ExistsByNameAsyncShouldReturnFalse()
        {
            string name = "wwwwwwwwwqdsad";

            bool result = await this.categoryService.ExistsByNameAsync(name);

            Assert.IsFalse(result);
        }

        [Test]
        public async Task AllCategoriesNamesAsyncReturnsAllCategories()
        {
            var categories = this.dbContext.Categories.ToList();

            var result = await categoryService.AllCategoriesNamesAsync();

            Assert.IsNotNull(result);
            Assert.AreEqual(categories.Count, result.Count());

            foreach (var category in categories)
            {
                Assert.IsTrue(result.Any(c => c.Id == category.Id && c.Name == category.Name));
            }
        }

        [Test]
        public async Task GetCategoryForEditByIdAsyncReturnsCategoryFormModel()
        {
            Category category = this.dbContext.Categories.First();

            var categoryForEdit = await this.categoryService.GetCategoryForEditByIdAsync(category.Id);

            Assert.AreEqual(category.Name, categoryForEdit.Name);
        }

        [Test]
        public async Task EditAsyncShouldChangeName()
        {
            Category category = this.dbContext.Categories.First();
            CategoryFormModel model = new CategoryFormModel()
            {
                Name = "Rock"
            };

            await this.categoryService.EditAsync(category.Id, model);

            Assert.AreEqual(category.Name, model.Name);
        }
    }
}
