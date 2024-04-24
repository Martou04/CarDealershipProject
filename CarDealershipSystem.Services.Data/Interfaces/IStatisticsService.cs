namespace CarDealershipSystem.Services.Data.Interfaces
{
    using Models.Statistics;

    public interface IStatisticsService
    {
        public Task<StatisticsServiceModel> GetStatisticsAsync();
    }
}
