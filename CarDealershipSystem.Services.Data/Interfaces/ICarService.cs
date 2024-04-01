namespace CarDealershipSystem.Services.Data.Interfaces
{
    using CarDealershipSystem.Web.ViewModels.Home;

    public interface ICarService
    {
        Task<IEnumerable<IndexViewModel>> LastFiveCarsAsync();
    }
}
