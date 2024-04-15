
namespace CarDealershipSystem.Services.Data.Interfaces
{
    using Web.ViewModels.Seller;

    public interface ISellerService
    {
        Task<bool> SellerExistsByUserIdAsync(string userId);

        Task<bool> SellerExistsByPhoneNumberAsync(string phoneNumber);

        Task Create(string userId, BecomeSellerFormModel formModel);

        Task<string?> GetSellerIdByUserIdAsync(string userId);

        Task<bool> HasCarWithIdAsync(string userId, string carId);
    }
}
