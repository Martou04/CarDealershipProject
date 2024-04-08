using CarDealershipSystem.Web.ViewModels.FuelType;

namespace CarDealershipSystem.Services.Data.Interfaces
{
    public interface IFuelTypeService
    {
        Task<IEnumerable<CarSelectFuelTypeFormModel>> AllFuelTypesAsync();

        Task<bool> ExistsByIdAsync(int Id);
    }
}
