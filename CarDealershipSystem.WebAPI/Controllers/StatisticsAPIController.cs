namespace CarDealershipSystem.WebAPI.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    using Services.Data.Interfaces;
    using Services.Data.Models.Statistics;

    [Route("api/statistics")]
    [ApiController]
    public class StatisticsAPIController : ControllerBase
    {
        private readonly IStatisticsService statisticsService;

        public StatisticsAPIController(IStatisticsService statisticsService)
        {
            this.statisticsService = statisticsService;
        }

        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(200, Type = typeof(StatisticsServiceModel))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetStatistics()
        {
            try
            {
                StatisticsServiceModel serviceModel = 
                    await this.statisticsService.GetStatisticsAsync();

                return this.Ok(serviceModel);   
            }
            catch (Exception)
            {
                return this.BadRequest();
            }
        }
    }
}
