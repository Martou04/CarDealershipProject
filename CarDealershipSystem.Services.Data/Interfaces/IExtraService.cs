
namespace CarDealershipSystem.Services.Data.Interfaces
{
    using CarDealershipSystem.Web.ViewModels.CarExtra;
    public interface IExtraService
    {
        Task<IEnumerable<CarExtrasViewModel>> AllExtrasAndTypesAsync();

        Task<IEnumerable<CarExtrasViewModel>> AllExtraTypesAsync();

        Task<bool> ExtraExistsAsync(int typeId, string name);

        Task AddExtraAsync(ExtraFormModel formModel);

        Task<bool> ExtraExistsByIdAsync(string Id);

        Task<ExtraFormModel> GetExtraForEditByIdAsync(string Id);

        Task EditAsync(string Id, ExtraFormModel model);
    }
}
