﻿namespace CarDealershipSystem.Services.Data.Interfaces
{
    using Models.Car;

    using Web.ViewModels.Car;
    using Web.ViewModels.Home;

    public interface ICarService
    {
        Task<IEnumerable<IndexViewModel>> LastFiveCarsAsync();

        Task CreateAsync(CarFormModel formModel, string sellerId, List<Guid> selectedExtrasIds);

        Task<AllCarsFilteredAndPagedServiceModel> AllAsync(AllCarsQueryModel queryModel);

        Task<IEnumerable<AllSellerCars>> AllBySellerIdAsync(string sellerId);

        Task<CarDetailsViewModel?> GetDetailsByIdAsync(string carId);
    }
}
