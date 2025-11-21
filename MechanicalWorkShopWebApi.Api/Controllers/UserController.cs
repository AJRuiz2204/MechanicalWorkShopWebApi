using MechanicalWorkShopWebApi.Domain.Interfaces.IService;
using Microsoft.AspNetCore.Mvc;
using static MechanicalWorkShopWebApi.Domain.DTOs.UserDto;

namespace MechanicalWorkShopWebApi.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserLoginDto loginDto)
        {
            var result = await _userService.Login(loginDto);
            if (result == null)
            {
                return StatusCode(401, "Usuario o contraseña incorrectos");
            }
            return Ok(result);
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserRegisterDto registerDto)
        {
            var result = await _userService.Register(registerDto);
            return Ok(result);
        }
    }
}
