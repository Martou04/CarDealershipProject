using CarDealershipSystem.Services.Data.Interfaces;

namespace CarDealershipSystem.Services.Data
{
    using CarDealershipSystem.Data.Models;
    using CarDealershipSystem.Web.ViewModels.Seller;
    using Microsoft.EntityFrameworkCore;
    using Web.Data;

    public class SellerService : ISellerService
    {
        private readonly CarDealershipDbContext dbContext;

        public SellerService(CarDealershipDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<bool> SellerExistsByUserIdAsync(string userId)
        {
            bool result = await dbContext
                .Seller
                .AnyAsync(s => s.UserId.ToString() == userId);

            return result;
        }

        public async Task<bool> SellerExistsByPhoneNumberAsync(string phoneNumber)
        {
            bool result = await dbContext
                .Seller
                .AnyAsync(s => s.PhoneNumber == phoneNumber);

            return result;
        }

        public async Task Create(string userId, BecomeSellerFormModel formModel)
        {
            Seller newSeller = new Seller()
            {
                UserId = Guid.Parse(userId),
                LocationCountry = formModel.LocationCountry,
                LocationCity = formModel.LocationCity,
                PhoneNumber = formModel.PhoneNumber,
            };

            await dbContext.Seller.AddAsync(newSeller);
            await dbContext.SaveChangesAsync();
        }

    }
}
