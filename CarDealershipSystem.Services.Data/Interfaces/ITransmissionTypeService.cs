﻿namespace CarDealershipSystem.Services.Data.Interfaces
{
    using Web.ViewModels.TransmissionType;

    public interface ITransmissionTypeService
    {
        Task<IEnumerable<CarSelectTransmissionTypeFormModel>> AllTransmissionTypesAsync();

        Task<bool> ExistsByIdAsync(int Id);

        Task<IEnumerable<TransmissionTypeAllViewModel>> AllTransmissionTypes();

        Task<bool> ExistsByNameAsync(string Name);

        Task AddTransmissionTypeAsync(TransmissionTypeFormModel formModel);

        Task<TransmissionTypeFormModel> GetTransmissionTypeForEditByIdAsync(int Id);

        Task EditAsync(int Id, TransmissionTypeFormModel model);
    }
}
