namespace CarDealershipSystem.Services.Tests
{
    using CarDealershipSystem.Services.Data;
    using CarDealershipSystem.Services.Data.Interfaces;
    using CarDealershipSystem.Web.ViewModels.Seller;
    using Microsoft.EntityFrameworkCore;

    using Web.Data;

    using static DatabaseSeeder;

    public class SellerServiceTests
    {
        private DbContextOptions<CarDealershipDbContext> dbOptions;
        private CarDealershipDbContext dbContext;

        private ISellerService sellerService;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            this.dbOptions = new DbContextOptionsBuilder<CarDealershipDbContext>()
                .UseInMemoryDatabase("CarDealershipInMemory" + Guid.NewGuid().ToString())
                .Options;
            this.dbContext = new CarDealershipDbContext(this.dbOptions);
            
            this.dbContext.Database.EnsureCreated();
            SeedDatabase(this.dbContext);

            this.sellerService = new SellerService(this.dbContext);
        }

        [Test]
        public async Task SellerExistsByUserIdAsyncShouldReturnTrueWhenExists()
        {
            string existingAgentUserId = SellerUser.Id.ToString();

            bool result = await this.sellerService.SellerExistsByUserIdAsync(existingAgentUserId);

            Assert.True(result);
        }

        [Test]
        public async Task SellerExistsByUserIdAsyncShouldReturnFalseWhenNotExists()
        {
            string existingAgentUserId = User.Id.ToString();

            bool result = await this.sellerService.SellerExistsByUserIdAsync(existingAgentUserId);

            Assert.IsFalse(result);
        }

        [Test]
        public async Task SellerExistsByPhoneNumberAsyncShouldReturnTrueWhenExists()
        {
            string phoneNumber = Seller.PhoneNumber;

            bool result = await this.sellerService.SellerExistsByPhoneNumberAsync(phoneNumber);

            Assert.True(result);
        }

        [Test]
        public async Task SellerExistsByPhoneNumberAsyncShouldReturnFalseWhenNotExists()
        {
            string phoneNumber = User.PhoneNumber;

            bool result = await this.sellerService.SellerExistsByPhoneNumberAsync(phoneNumber);

            Assert.IsFalse(result);
        }

        [Test]
        public async Task CreateSuccessfully()
        {
            var userId = SellerUser.Id.ToString();
            var formModel = new BecomeSellerFormModel
            {
                PhoneNumber = "+359897730222",
                LocationCountry = "Bulgaria",
                LocationCity = "Sofia"
            };

            await sellerService.Create(userId, formModel);

            var createdSeller = await this.dbContext
                .Seller
                .FirstOrDefaultAsync(x => x.UserId == SellerUser.Id);

            Assert.IsNotNull(createdSeller);
            Assert.AreEqual(formModel.LocationCountry, createdSeller.LocationCountry);
            Assert.AreEqual(formModel.LocationCity, createdSeller.LocationCity);
            Assert.AreEqual(formModel.PhoneNumber, createdSeller.PhoneNumber);
        }

        [Test]
        public async Task GetSellerIdByUserIdAsyncReturnsSellerIdIfExists()
        {
            var userId = SellerUser.Id.ToString();

            var sellerId = await this.sellerService.GetSellerIdByUserIdAsync(userId);

            Assert.IsNotNull(sellerId);
            Assert.AreEqual(Seller.Id.ToString(), sellerId);
        }

        [Test]
        public async Task GetSellerIdByUserIdAsyncReturnsNullIfNotExists()
        {
            var userId = User.Id.ToString();

            var sellerId = await this.sellerService.GetSellerIdByUserIdAsync(userId);

            Assert.IsNull(sellerId);
        }

        [Test]
        public async Task HasCarWithIdAsyncReturnsTrueIfSellerExistsAndHasCarWithGivenId()
        {
            var userId = SellerUser.Id.ToString();
            var carId = Seller.CarsForSale.First().Id.ToString();

            var result = await this.sellerService.HasCarWithIdAsync(userId, carId);

            Assert.IsTrue(result);
        }

        [Test]
        public async Task HasCarWithIdAsyncReturnsFalseIfSellerDoesNotExist()
        {
            var userId = Guid.NewGuid().ToString();
            var carId = Seller.CarsForSale.First().Id.ToString();

            var result = await this.sellerService.HasCarWithIdAsync(userId, carId);

            Assert.IsFalse(result);
        }

        [Test]
        public async Task HasCarWithIdAsyncReturnsFalseIfSellerExistsButDoesNotHaveCarWithGivenId()
        {
            var userId = SellerUser.Id.ToString();
            var carId = Guid.NewGuid().ToString();

            var result = await this.sellerService.HasCarWithIdAsync(userId, carId);

            Assert.IsFalse(result);
        }
    }
}