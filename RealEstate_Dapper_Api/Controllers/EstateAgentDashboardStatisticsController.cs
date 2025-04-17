using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Repositories.EstateAgentRepositories.DashboardRepositories.StatisticRepositories;

namespace RealEstate_Dapper_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstateAgentDashboardStatisticsController : ControllerBase
    {
        private readonly IStatisticsRepository _statisticRepository;

        public EstateAgentDashboardStatisticsController(IStatisticsRepository statisticRepository)
        {
            _statisticRepository = statisticRepository;
        }

        [HttpGet("AllProductCount")]
        public IActionResult AllProductCount()
        {
            var values = _statisticRepository.AllProductCount();
            return Ok(values);
        }

        [HttpGet("ProductCountByEmployeeId")]
        public IActionResult ProductCountByEmployeeId(int id)
        {
            var values = _statisticRepository.ProductCountByEmployeeId(id);
            return Ok(values);
        }

        [HttpGet("ProductCountByStatusFalse")]
        public IActionResult ProductCountByStatusFalse(int id)
        {
            var values = _statisticRepository.ProductCountByStatusFalse(id);
            return Ok(values);
        }

        [HttpGet("ProductCountByStatusTrue")]
        public IActionResult ProductCountByStatusTrue(int id)
        {
            var values = _statisticRepository.ProductCountByStatusTrue(id);
            return Ok(values);
        }
    }
}
