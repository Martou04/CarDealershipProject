
namespace CarDealershipSystem.Services.Data.Interfaces
{
    using CarDealershipSystem.Web.ViewModels.CarExtra;
    public interface IExtraService
    {
        Task<IEnumerable<CarExtrasViewModel>> AllExtrasAndTypesAsync();
    }
}
