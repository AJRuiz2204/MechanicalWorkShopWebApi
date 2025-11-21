using static MechanicalWorkShopWebApi.Domain.DTOs.UserDto;

namespace MechanicalWorkShopWebApi.Domain.Interfaces.IService
{
    public interface IUserService
    {
        Task<UserResponseDto> Login(UserLoginDto loginDto);
        Task<UserResponseDto> Register(UserRegisterDto registerDto);
    }
}
