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

        public async Task<string?> GetSellerIdByUserIdAsync(string userId)
        {
            Seller? seller = await this.dbContext
                .Seller
                .FirstOrDefaultAsync(s => s.UserId == Guid.Parse(userId));
            if(seller == null)
            {
                return null;
            }

            return seller.Id.ToString();
        }

        public async Task<bool> HasCarWithIdAsync(string userId, string carId)
        {
            Seller? seller = await this.dbContext
                .Seller
                .Include(s => s.CarsForSale)
                .FirstOrDefaultAsync(s => s.UserId.ToString() == userId);

            if(seller == null)
            {
                return false;
            }

            return seller.CarsForSale.Any(c => c.Id.ToString() == carId);
        }
    }
}
