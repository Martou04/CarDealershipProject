namespace CarDealershipSystem.Services.Data
{
    using Microsoft.EntityFrameworkCore;

    using Interfaces;
    using Web.Data;
    using Models.Statistics;

    internal class StatisticsService : IStatisticsService
    {
        private readonly CarDealershipDbContext dbContext;

        public StatisticsService(CarDealershipDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<StatisticsServiceModel> GetStatisticsAsync()
        {
            return new StatisticsServiceModel()
            {
                TotalCars = await this.dbContext.Cars
                    .Where(c => c.IsActive)
                    .CountAsync(),
                TotalSellers = await this.dbContext.Seller.CountAsync()
            };
        }
    }
}
