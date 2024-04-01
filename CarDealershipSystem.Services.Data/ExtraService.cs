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

        public async Task<IEnumerable<CarSelectExtrasFormModel>> AllExtrasAsync()
        {
            IEnumerable<CarSelectExtrasFormModel> allExtras = await this.dbContext
                .Extra
                .AsNoTracking()
                .Select(e => new CarSelectExtrasFormModel
                {
                    ExtraName = e.Name,
                    ExtraType = e.Type.Name
                })
                .ToArrayAsync();

            return allExtras;
        }
    }
}
