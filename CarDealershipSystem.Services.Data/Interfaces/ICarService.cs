namespace CarDealershipSystem.Services.Data.Interfaces
{
    using CarDealershipSystem.Data.Models;
    using Web.ViewModels.Car;
    using Web.ViewModels.Home;

    public interface ICarService
    {
        Task<IEnumerable<IndexViewModel>> LastFiveCarsAsync();

        Task CreateAsync(CarFormModel formModel, string sellerId, List<Guid> selectedExtrasIds);

    }
}
