using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test.Backend.Models;
using Test.Data.Models;
using Test.Data.Repository;

namespace Test.Backend.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _userRepository.GetAllAsync();
            return Ok(users);
        }

        [HttpPost]
        public async Task<IActionResult> AddUsers([FromBody] List<ApiUserRequest> users)
        {

            await _userRepository.AddRangeAsync(
                users.Select(x =>
                    new User()
                    {
                        Id = default,
                        LifeSpanDays = default,
                        LastActivityDate = x.LastActivityDate,
                        RegistrationDate = x.RegistrationDate,
                    })
                );
            return Ok();
        }
    }
}
