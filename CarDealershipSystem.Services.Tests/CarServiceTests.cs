namespace CarDealershipSystem.Services.Tests
{
    using CarDealershipSystem.Web.ViewModels.Car;
    using Microsoft.EntityFrameworkCore;

    using Services.Data;
    using Services.Data.Interfaces;
    using Web.Data;

    using static DatabaseSeeder;

    public class CarServiceTests
    {
        private DbContextOptions<CarDealershipDbContext> dbOptions;
        private CarDealershipDbContext dbContext;

        private ICarService carService;
        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            this.dbOptions = new DbContextOptionsBuilder<CarDealershipDbContext>()
                .UseInMemoryDatabase("CarDealershipInMemory" + Guid.NewGuid().ToString())
                .Options;
            this.dbContext = new CarDealershipDbContext(this.dbOptions);

            this.dbContext.Database.EnsureCreated();
            SeedDatabase(this.dbContext);

            this.carService = new CarService(this.dbContext);
        }

        [Test]
        public async Task LastFiveCarsAsyncReturnsLastFiveActiveAndApprovedCars()
        {
            var expectedCount = 5;

            var result = await this.carService.LastFiveCarsAsync();

            Assert.IsNotNull(result);
            Assert.AreEqual(expectedCount, result.Count());
        }

        [Test]
        public async Task AllAsyncReturnsCars()
        {
            var queryModel = new AllCarsQueryModel
            {
                Category = "Sedan",
                SearchString = "BMW",
            };

            var result = await carService.AllAsync(queryModel);

            Assert.IsNotNull(result);
        }

        [Test]
        public async Task AllBySellerIdAsyncReturnsAllCarsBelongingToSeller()
        {
            var sellerId = Seller.Id; 
            var expectedCarsCount = dbContext.Cars.Count(c => c.SellerId == sellerId && c.IsActive);

            var result = await carService.AllBySellerIdAsync(sellerId.ToString());

            Assert.IsNotNull(result);
            Assert.AreEqual(expectedCarsCount, result.Count());
        }

        [Test]
        public async Task GetDetailsByIdAsyncReturnsCarDetailsById()
        {
            var carId = Car.Id;
            var expectedCar = dbContext.Cars.FirstOrDefault(c => c.Id == carId);

            var result = await carService.GetDetailsByIdAsync(carId.ToString());

            Assert.IsNotNull(result);
            Assert.AreEqual(expectedCar.Make, result.Make);
            Assert.AreEqual(expectedCar.Model, result.Model);
        }

        [Test]
        public async Task ExistsByIdAsyncReturnsTrueIfCarExists()
        {
            var existingCarId = dbContext.Cars.First(c => c.IsActive).Id.ToString();

            var result = await carService.ExistsByIdAsync(existingCarId);

            Assert.IsTrue(result);
        }

        [Test]
        public async Task ExistsByIdAsyncReturnsFalseIfCarDoesNotExist()
        {
            var nonExistingCarId = Guid.NewGuid().ToString();

            var result = await carService.ExistsByIdAsync(nonExistingCarId);

            Assert.IsFalse(result);
        }

        [Test]
        public async Task GetCarForEditByIdAsyncReturnsCarFormModelById()
        {
            var existingCarId = dbContext.Cars.First(c => c.IsActive).Id.ToString();
            var expectedCar = dbContext.Cars.FirstOrDefault(c => c.Id == Guid.Parse(existingCarId));

            var result = await carService.GetCarForEditByIdAsync(existingCarId);

            Assert.IsNotNull(result);
            Assert.AreEqual(expectedCar.Make, result.Make);
            Assert.AreEqual(expectedCar.Model, result.Model);
            Assert.AreEqual(expectedCar.Description, result.Description);
            Assert.AreEqual(expectedCar.Year, result.Year);
            Assert.AreEqual(expectedCar.Kilometers, result.Kilometers);
            Assert.AreEqual(expectedCar.Horsepower, result.Horsepower);
            Assert.AreEqual(expectedCar.Price, result.Price);
            Assert.AreEqual(expectedCar.ImageUrl, result.ImageUrl);
            Assert.AreEqual(expectedCar.CategoryId, result.CategoryId);
            Assert.AreEqual(expectedCar.FuelTypeId, result.FuelTypeId);
            Assert.AreEqual(expectedCar.TransmissionTypeId, result.TransmissionTypeId);
        }

        [Test]
        public async Task IsSellerWithIdOwnerOfCarWithIdAsyncReturnsTrueIfSellerIsOwner()
        {
            var sellerId = dbContext.Seller.First().Id.ToString();
            string carId = dbContext.Cars.First(c => c.SellerId.ToString() == sellerId).Id.ToString();

            var result = await carService.IsSellerWithIdOwnerOfCarWithIdAsync(carId, sellerId);

            Assert.IsTrue(result);
        }

        [Test]
        public async Task GetCarForDeleteByIdAsyncReturnsCarPreDeleteDetailsViewModel()
        {
            var existingCarId = dbContext.Cars.First(c => c.IsActive).Id.ToString();
            var expectedCar = dbContext.Cars.FirstOrDefault(c => c.Id == Guid.Parse(existingCarId));

            var result = await carService.GetCarForDeleteByIdAsync(existingCarId);

            Assert.AreEqual(expectedCar.Make, result.Make);
            Assert.AreEqual(expectedCar.Model, result.Model);
            Assert.AreEqual(expectedCar.ImageUrl, result.ImageUrl);
            Assert.AreEqual(expectedCar.Year, result.Year);
            Assert.AreEqual(expectedCar.Price, result.Price);
        }

        [Test]
        public async Task DeleteCarByIdAsyncShouldChangeIsActive()
        {
            var existingCarId = dbContext.Cars.First(c => c.IsActive).Id.ToString();
            var expectedCar = dbContext.Cars.FirstOrDefault(c => c.Id == Guid.Parse(existingCarId));

            await this.carService.DeleteCarByIdAsync(existingCarId);

            Assert.AreEqual(expectedCar.IsActive, false);
        }

        [Test]
        public async Task ChangeVisibilityAsync()
        {
            var existingCarId = dbContext.Cars.First(c => c.IsActive).Id.ToString();
            var expectedCar = dbContext.Cars.FirstOrDefault(c => c.Id == Guid.Parse(existingCarId));
            
            bool visibility = expectedCar.Approved;
            await this.carService.ChangeVisibilityAsync(existingCarId);

            Assert.AreNotEqual(expectedCar.Approved, visibility);
        }
    }
}
