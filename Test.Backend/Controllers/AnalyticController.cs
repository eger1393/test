using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;
using Test.Backend.Models;
using Test.Data.Repository;

namespace Test.Backend.Controllers
{
    [Route("api/analytic")]
    [ApiController]
    public class AnalyticController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public AnalyticController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet("rollingRetention")]
        public async Task<IActionResult> GetRollingRetention([FromQuery] ushort days)
        {
            if (days == 0)
                return BadRequest("Кол-во дней должно быть больше 1");

            var activeUsersCount = _userRepository.GetCountActiveUsersAfter(days);
            var registeredUsersCount = _userRepository.GetCountUsersWhoRegisteredEarlierThan(DateTime.Today.AddDays(-days));
            await Task.WhenAll(activeUsersCount, registeredUsersCount);
            var rollingRetention = (double)activeUsersCount.Result / registeredUsersCount.Result * 100;
            return Ok(rollingRetention);
        }

        [HttpGet("lifeSpanUsers")]
        public async Task<IActionResult> GetLifeSpanUsers()
        {
            var users = await _userRepository.GetAllAsync();
            var lifeSpanDays = users.Select(x => x.LifeSpanDays).ToList();
            var result = lifeSpanDays.Distinct()
                .OrderBy(x => x)
                .Select(x => new ApiLifeSpanUserResponse()
                {
                    LifeSpanDays = x,
                    Count = lifeSpanDays.Count(lifeSpan => lifeSpan == x)
                });
            return Ok(result);
        }
    }
}
