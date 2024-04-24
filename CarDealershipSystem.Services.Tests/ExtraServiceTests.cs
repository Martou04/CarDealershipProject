namespace CarDealershipSystem.Services.Tests
{
    using CarDealershipSystem.Data.Models;
    using CarDealershipSystem.Web.ViewModels.CarExtra;
    using Microsoft.EntityFrameworkCore;

    using Services.Data;
    using Services.Data.Interfaces;
    using System.Collections.Generic;
    using Web.Data;
    using static DatabaseSeeder;

    public class ExtraServiceTests
    {
        private DbContextOptions<CarDealershipDbContext> dbOptions;
        private CarDealershipDbContext dbContext;

        private IExtraService extraService;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            this.dbOptions = new DbContextOptionsBuilder<CarDealershipDbContext>()
                .UseInMemoryDatabase("CarDealershipInMemory" + Guid.NewGuid().ToString())
                .Options;
            this.dbContext = new CarDealershipDbContext(this.dbOptions);

            this.dbContext.Database.EnsureCreated();
            SeedDatabase(this.dbContext);

            this.extraService = new ExtraService(this.dbContext);
        }

        [Test]
        public async Task AllExtrasAndTypesAsync()
        {
            IEnumerable<Extra> extras = this.dbContext.Extra;

             IEnumerable<CarExtrasViewModel> result = await this.extraService.AllExtrasAndTypesAsync();

            Assert.IsNotNull(result);
            Assert.AreEqual(extras.Count(), result.Count());

            foreach (var extra in extras)
            {
                Assert.IsTrue(result.Any(r => r.Id == extra.Id && r.Name == extra.Name));
            }
        }

        [Test]
        public async Task AllExtraTypesAsyncReturnsAllExtraTypes()
        {
            IEnumerable<ExtraType> extraTypes = this.dbContext
                .ExtraTypes
                .Select(ex => new ExtraType 
                { 
                    Id = ex.Id, 
                    Name = ex.Name 
                });

            var result = await this.extraService.AllExtraTypesAsync();

            Assert.IsNotNull(result);
            Assert.AreEqual(extraTypes.Count(), result.Count());
        }

        [Test]
        public async Task ExtraExistsByNameAndTypeAsyncShouldRetutnTrue()
        {
            Extra extra = this.dbContext.Extra.First();

            bool result = await this.extraService.ExtraExistsByNameAndTypeAsync(extra.TypeId, extra.Name);

            Assert.IsTrue(result);
        }

        [Test]
        public async Task ExtraExistsByNameAndTypeAsyncShouldRetutnFalse()
        {
            bool result = await this.extraService.ExtraExistsByNameAndTypeAsync(555, "Tree");

            Assert.IsFalse(result);
        }
    }
}
