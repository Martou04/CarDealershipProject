﻿namespace CarDealershipSystem.Services.Data
{
    using Microsoft.EntityFrameworkCore;
    
    using Interfaces;
    using Web.Data;
    using Web.ViewModels.FuelType;

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
    }
}
