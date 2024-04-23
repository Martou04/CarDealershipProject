

namespace CarDealershipSystem.Services.Data
{
    using Microsoft.EntityFrameworkCore;

    using Interfaces;
    using Web.Data;
    using Web.ViewModels.TransmissionType;
    using CarDealershipSystem.Data.Models;

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
        public async Task<IEnumerable<TransmissionTypeAllViewModel>> AllTransmissionTypes()
        {
            IEnumerable<TransmissionTypeAllViewModel> allTransmissionTypes = await this.dbContext
                .TransmissionTypes
                .Select(tt => new TransmissionTypeAllViewModel 
                {
                    Id = tt.Id,
                    Name = tt.Name
                })
                .ToArrayAsync();

            return allTransmissionTypes;
        }

        public async Task<bool> ExistsByNameAsync(string Name)
        {
            bool result = await this.dbContext
                .TransmissionTypes
                .AnyAsync(tt => tt.Name == Name);

            return result;
        }

        public async Task AddTransmissionTypeAsync(TransmissionTypeFormModel formModel)
        {
            TransmissionType transmissionType = new TransmissionType()
            {
                Name = formModel.Name,
            };

            await this.dbContext.TransmissionTypes.AddAsync(transmissionType);
            await this.dbContext.SaveChangesAsync();
        }

        public async Task<TransmissionTypeFormModel> GetTransmissionTypeForEditByIdAsync(int Id)
        {
            TransmissionType transmissionType = await this.dbContext
                .TransmissionTypes
                .FirstAsync(tt => tt.Id == Id);

            TransmissionTypeFormModel formModel = new TransmissionTypeFormModel()
            {
                Name = transmissionType.Name,
            };

            return formModel;
        }

        public async Task EditAsync(int Id, TransmissionTypeFormModel model)
        {
            TransmissionType transmissionType = await this.dbContext
                .TransmissionTypes
                .FirstAsync (tt => tt.Id == Id);

            transmissionType.Name = model.Name;

            await this.dbContext.SaveChangesAsync();
        }
    }
}
