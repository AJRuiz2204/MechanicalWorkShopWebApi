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

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _userService.GetAllUsers();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var user = await _userService.GetUserById(id);
            if (user == null)
            {
                return NotFound($"Usuario con ID {id} no encontrado");
            }
            return Ok(user);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, [FromBody] UserUpdateDto updateDto)
        {
            var result = await _userService.UpdateUser(id, updateDto);
            if (result == null)
            {
                return NotFound($"Usuario con ID {id} no encontrado");
            }
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var result = await _userService.DeleteUser(id);
            if (!result)
            {
                return NotFound($"Usuario con ID {id} no encontrado");
            }
            return Ok(new { message = "Usuario eliminado exitosamente" });
        }

        [HttpPost("{id}/change-password")]
        public async Task<IActionResult> ChangePassword(int id, [FromBody] ChangePasswordDto changePasswordDto)
        {
            var result = await _userService.ChangePassword(id, changePasswordDto);
            if (!result)
            {
                return BadRequest("No se pudo cambiar la contraseña. Verifica la contraseña actual.");
            }
            return Ok(new { message = "Contraseña cambiada exitosamente" });
        }

        [HttpPost("request-reset")]
        public async Task<IActionResult> RequestPasswordReset([FromBody] PasswordResetRequestDto requestDto)
        {
            var result = await _userService.RequestPasswordReset(requestDto);
            if (!result)
            {
                return NotFound("Usuario no encontrado");
            }
            return Ok(new { message = "Código de reset enviado al correo electrónico" });
        }

        [HttpPost("reset-password")]
        public async Task<IActionResult> ResetPassword([FromBody] PasswordResetDto resetDto)
        {
            var result = await _userService.ResetPassword(resetDto);
            if (!result)
            {
                return BadRequest("Código de reset inválido o expirado");
            }
            return Ok(new { message = "Contraseña restablecida exitosamente" });
        }
    }
}
