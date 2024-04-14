namespace CarDealershipSystem.Services.Data.Interfaces
{
    using Models.Car;

    using Web.ViewModels.Car;
    using Web.ViewModels.Home;

    public interface ICarService
    {
        Task<IEnumerable<IndexViewModel>> LastFiveCarsAsync();

        Task<string> CreateAndReturnIdAsync(CarFormModel formModel, string sellerId, List<Guid> selectedExtrasIds);

        Task<AllCarsFilteredAndPagedServiceModel> AllAsync(AllCarsQueryModel queryModel);

        Task<IEnumerable<AllSellerCars>> AllBySellerIdAsync(string sellerId);

        Task<bool> ExistsByIdAsync(string carId);

        Task<CarDetailsViewModel> GetDetailsByIdAsync(string carId);

        Task<CarFormModel> GetCarForEditByIdAsync(string carId);

        Task<bool> IsSellerWithIdOwnerOfCarWithIdAsync(string carId, string sellerId);

        Task EditAsync(string carId,CarFormModel model, List<Guid> selectedExtrasIds);

        Task<CarPreDeleteDetailsViewModel> GetCarForDeleteByIdAsync(string carId);

        Task DeleteCarByIdAsync(string carId);
    }
}
