using CarDealershipSystem.Services.Data.Models.Statistics;

namespace CarDealershipSystem.Services.Data.Interfaces
{
    public interface IStatisticsService
    {
        public Task<StatisticsServiceModel> GetStatisticsAsync();
    }
}
