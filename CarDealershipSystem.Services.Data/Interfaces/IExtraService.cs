
namespace CarDealershipSystem.Services.Data.Interfaces
{
    using CarDealershipSystem.Web.ViewModels.CarExtra;
    public interface IExtraService
    {
        Task<IEnumerable<CarExtrasViewModel>> AllExtrasAndTypesAsync();

        Task<IEnumerable<CarExtrasViewModel>> AllExtraTypesAsync();

        Task<bool> ExtraExistsAsync(int typeId, string name);

        Task AddExtraAsync(ExtraFormModel formModel);
    }
}
