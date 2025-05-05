using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RaidPlanner.Api.Dto;
using RaidPlanner.Api.Services;
using RaidPlanner.Bll.ObjectModels;
using RaidPlanner.Bll.Services.IServices;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RaidPlanner.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly JwtOptions jwtOptions;

        public UsersController(IUserService userService, JwtOptions jwtOptions)
        {
            _userService = userService;
            this.jwtOptions = jwtOptions;
        }

        [HttpPost]
        public async Task<ActionResult<UserDto>> CreateUserAsync(UserDto userDto)
        {
            try
            {
                var userModel = userDto.Adapt<UserModel>();
                var createdUser = await _userService.CreateUserAsync(userModel);
                var createdUserDto = createdUser.Adapt<UserDto>();
                return CreatedAtAction(nameof(GetUserById), new { id = createdUserDto.Id }, createdUserDto);

            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserDto>> GetUserById(int id)
        {
            var user = await _userService.GetUserByIdAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            var userDto = user.Adapt<UserDto>();
            return Ok(userDto);
        }

        [HttpGet]
        [Authorize]

        public async Task<ActionResult<IEnumerable<UserDto>>> GetAllUsers()
        {
            var users = await _userService.GetAllUsersAsync();

            if (users == null || !users.Any())
            {
                return NotFound();
            }

            var usersDto = users.Adapt<IEnumerable<UserDto>>();
            return Ok(usersDto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<UserDto>> UpdateUser(int id, UserDto userDto)
        {
            var userModel = userDto.Adapt<UserModel>();
            userModel.Id = id;

            var updatedUser = await _userService.UpdateUserAsync(userModel);

            if (updatedUser == null)
            {
                return NotFound();
            }

            var updatedUserDto = updatedUser.Adapt<UserDto>();
            return Ok(updatedUserDto);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var result = await _userService.DeleteUserAsync(id);

            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            //Appel sur service user pour verifier login et mot de passe
            UserModel MonUser = new UserModel
            {
                Id = 1,
                Mail = "dylan@zebest.java",
                RoleId = 1,
                Username = "Dylan"
            };
            //Si le mot de passe est correct 
            if(MonUser == null) {
                return NotFound();
            }

            //génération du jwt pour le user
            loginDto.Access_Token = JwtManager.GenerateToken(jwtOptions, loginDto);

            return Ok(loginDto);

        }

    }
    
}
