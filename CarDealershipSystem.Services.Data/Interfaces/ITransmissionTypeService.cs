namespace CarDealershipSystem.Services.Data.Interfaces
{
    using Web.ViewModels.TransmissionType;
    public interface ITransmissionTypeService
    {
        Task<IEnumerable<CarSelectTransmissionTypeFormModel>> AllTransmissionTypesAsync();

        Task<bool> ExistsByIdAsync(int Id);

        Task<IEnumerable<TransmissionTypeAllViewModel>> AllTransmissionTypes();
    }
}
