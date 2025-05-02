using Microsoft.AspNetCore.Mvc;
using RaidPlanner.Bll.Services.IServices;
using RaidPlanner.Api.Dto;
using System.Threading.Tasks;

namespace RaidPlanner.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;

        public AuthController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] AuthDto login)
        {
            var user = await _userService.ValidateUser(login.Username, login.Password);
            if (user == null)
            {
                return Unauthorized(new { message = "Invalid credentials" });
            }

            return Ok(user);
        }
    }
}
