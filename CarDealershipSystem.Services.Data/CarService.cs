
namespace CarDealershipSystem.Services.Data
{
    using Web.ViewModels.Home;
    using Web.Data;
    using Interfaces;
    using Microsoft.EntityFrameworkCore;

    public class CarService : ICarService
    {
        private readonly CarDealershipDbContext dbContext;

        public CarService(CarDealershipDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<IndexViewModel>> LastFiveCarsAsync()
        {
            IEnumerable<IndexViewModel> lastFiveCars = await this.dbContext
                .Cars
                .OrderByDescending(c => c.CreatedOn)
                .Take(5)
                .Select(c => new IndexViewModel()
                {
                    Id = c.Id.ToString(),
                    Make = c.Make,
                    Model = c.Model,
                    Year = c.Year,
                    Horsepower = c.Horsepower,
                    FuelType = c.FuelType.Name,
                    TransmissionType = c.TransmissionType.Name,
                    Price = c.Price,
                    ImageUrl = c.ImageUrl,
                    CreatedOn = c.CreatedOn
                })
                .ToArrayAsync();

            return lastFiveCars;
        }
    }
}
