namespace CarDealershipSystem.Services.Data.Interfaces
{
    using Web.ViewModels.FuelType;

    public interface IFuelTypeService
    {
        Task<IEnumerable<CarSelectFuelTypeFormModel>> AllFuelTypesAsync();

        Task<bool> ExistsByIdAsync(int Id);

        Task<IEnumerable<FuelTypeAllViewModel>> AllFuelTypesNamesAsync();

        Task<bool> ExistsByNameAsync(string Name);

        Task AddFuelTypeAsync(FuelTypeFormModel formModel);
    }
}
