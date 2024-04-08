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
                .AsNoTracking()
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
    }
}
