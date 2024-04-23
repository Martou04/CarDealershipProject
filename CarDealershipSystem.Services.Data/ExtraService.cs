using CarDealershipSystem.Data.Models;
using CarDealershipSystem.Services.Data.Interfaces;
using CarDealershipSystem.Web.Data;
using CarDealershipSystem.Web.ViewModels.CarExtra;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealershipSystem.Services.Data
{
    public class ExtraService : IExtraService
    {
        private readonly CarDealershipDbContext dbContext;

        public ExtraService(CarDealershipDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<CarExtrasViewModel>> AllExtrasAndTypesAsync()
        {
            IEnumerable<CarExtrasViewModel> allExtras = await this.dbContext
                .Extra
                .Select(e => new CarExtrasViewModel
                {
                    Id = e.Id,
                    Name = e.Name,
                    TypeId = e.TypeId,
                    TypeName = e.Type.Name
                })
                .ToArrayAsync();

            return allExtras;
        }

        public async Task<IEnumerable<CarExtrasViewModel>> AllExtraTypesAsync()
        {
            IEnumerable<CarExtrasViewModel> allExtraTypes = await this.dbContext
                .ExtraTypes
                .Select(et => new  CarExtrasViewModel
                {
                    TypeId = et.Id,
                    TypeName = et.Name
                })
                .ToArrayAsync();

            return allExtraTypes;
        }

        public async Task<bool> ExtraExistsAsync(int typeId, string name)
        {
            bool result = await this.dbContext
                .Extra
                .Where(e => e.TypeId == typeId)
                .AnyAsync(e => e.Name == name);

            return result;
        }

        public async Task AddExtraAsync(ExtraFormModel formModel)
        {
            Extra extra = new Extra()
            {
                Name = formModel.Name,
                TypeId = formModel.ExtraTypeId
            };

            await this.dbContext.Extra.AddAsync(extra);
            await this.dbContext.SaveChangesAsync();
        }

        public async Task<bool> ExtraExistsByIdAsync(string Id)
        {
            bool result = await this.dbContext
                .Extra
                .AnyAsync(e => e.Id.ToString() == Id);

            return result;
        }

        public async Task<ExtraFormModel> GetExtraForEditByIdAsync(string Id)
        {
            Extra extra = await this.dbContext
                .Extra
                .FirstAsync(e => e.Id.ToString() == Id);

            ExtraFormModel model = new ExtraFormModel()
            {
                Name = extra.Name,
                ExtraTypeId = extra.TypeId
            };

            return model;
        }

        public async Task EditAsync(string Id, ExtraFormModel model)
        {
            Extra extra = await this.dbContext
                .Extra
                .FirstAsync(e => e.Id.ToString() == Id);

            extra.Name = model.Name;
            extra.TypeId = model.ExtraTypeId;

            await this.dbContext.SaveChangesAsync();
        }
    }
}
