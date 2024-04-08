

namespace CarDealershipSystem.Services.Data
{
    using Microsoft.EntityFrameworkCore;

    using Interfaces;
    using Web.Data;
    using Web.ViewModels.TransmissionType;

    public class TransmissionTypeService : ITransmissionTypeService
    {
        private readonly CarDealershipDbContext dbContext;

        public TransmissionTypeService(CarDealershipDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<CarSelectTransmissionTypeFormModel>> AllTransmissionTypesAsync()
        {
            IEnumerable<CarSelectTransmissionTypeFormModel> allTransmissionTypes = await this.dbContext
                .TransmissionTypes
                .Select(tt => new CarSelectTransmissionTypeFormModel
                {
                    Id = tt.Id,
                    Name = tt.Name
                })
                .ToArrayAsync();

            return allTransmissionTypes;
        }

        public async Task<bool> ExistsByIdAsync(int Id)
        {
            bool result = await this.dbContext
                .TransmissionTypes
                .AnyAsync(tt => tt.Id == Id);

            return result;
        }
    }
}
