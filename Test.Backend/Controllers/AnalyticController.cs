using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Test.Services.Services;

namespace Test.Backend.Controllers
{
    [Route("api/analytic")]
    [ApiController]
    public class AnalyticController : ControllerBase
    {
        private readonly IAnalyticService _analyticService;
        public AnalyticController(IAnalyticService analyticService)
        {
            _analyticService = analyticService;
        }

        [HttpGet("rollingRetention")]
        public async Task<IActionResult> GetRollingRetention([FromQuery] ushort days)
        {
            if (days == 0)
                return BadRequest("Кол-во дней должно быть больше 1");

            var rollingRetention = await _analyticService.CalculateRollingRetentionAsync(days);
            return Ok(rollingRetention);
        }

        [HttpGet("lifeSpanUsers")]
        public async Task<IActionResult> GetLifeSpanUsers()
        {
            var result = await _analyticService.GetLifeSpanDistribution();
            return Ok(result);
        }
    }
}
