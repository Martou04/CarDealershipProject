namespace CarDealershipSystem.Services.Data
{
    using Microsoft.EntityFrameworkCore;
    
    using Interfaces;
    using Web.Data;
    using Web.ViewModels.FuelType;
    using CarDealershipSystem.Data.Models;

    public class FuelTypeService : IFuelTypeService
    {
        private readonly CarDealershipDbContext dbContext;

        public FuelTypeService(CarDealershipDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<CarSelectFuelTypeFormModel>> AllFuelTypesAsync()
        {
            IEnumerable<CarSelectFuelTypeFormModel> allFuelTypes = await this.dbContext
                .FuelTypes
                .Select(ft => new CarSelectFuelTypeFormModel 
                { 
                    Id = ft.Id,
                    Name = ft.Name,
                })
                .ToArrayAsync();

            return allFuelTypes;
        }


        public async Task<bool> ExistsByIdAsync(int Id)
        {
            bool result = await this.dbContext
                .FuelTypes
                .AnyAsync(ft => ft.Id == Id);

            return result;
        }

        public async Task<IEnumerable<FuelTypeAllViewModel>> AllFuelTypesNamesAsync()
        {
            IEnumerable<FuelTypeAllViewModel> fuelTypes = await this.dbContext
                .FuelTypes
                .Select(ft => new FuelTypeAllViewModel
                {
                    Id = ft.Id,
                    Name = ft.Name,
                })
                .ToArrayAsync();

            return fuelTypes;
        }

        public async Task<bool> ExistsByNameAsync(string Name)
        {
            bool result = await this.dbContext
                .FuelTypes
                .AnyAsync(ft => ft.Name == Name);

            return result;
        }

        public async Task AddFuelTypeAsync(FuelTypeFormModel formModel)
        {
            FuelType fuelType = new FuelType()
            {
                Name = formModel.Name
            };

            await this.dbContext.FuelTypes.AddAsync(fuelType);
            await this.dbContext.SaveChangesAsync();
        }

        public async Task<FuelTypeFormModel> GetFuelTypeForEditAsync(int Id)
        {
            FuelType fuelType = await this.dbContext
                .FuelTypes
                .FirstAsync(ft => ft.Id == Id);

            FuelTypeFormModel formModel = new FuelTypeFormModel()
            {
                Name = fuelType.Name,
            };

            return formModel;
        }

        public async Task EditAsync(int Id, FuelTypeFormModel formModel)
        {
            FuelType fuelType = await this.dbContext
                .FuelTypes
                .FirstAsync(ft => ft.Id == Id);

            fuelType.Name = formModel.Name;

            await this.dbContext.SaveChangesAsync();
        }
    }
}
