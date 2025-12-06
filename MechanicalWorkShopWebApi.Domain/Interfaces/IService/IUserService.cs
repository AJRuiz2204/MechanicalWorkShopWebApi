using static MechanicalWorkShopWebApi.Domain.DTOs.UserDto;

namespace MechanicalWorkShopWebApi.Domain.Interfaces.IService
{
    public interface IUserService
    {
        Task<UserResponseDto> Login(UserLoginDto loginDto);
        Task<UserResponseDto> Register(UserRegisterDto registerDto);
        Task<UserResponseDto> GetUserById(int id);
        Task<IEnumerable<UserResponseDto>> GetAllUsers();
        Task<UserResponseDto> UpdateUser(int id, UserUpdateDto updateDto);
        Task<bool> DeleteUser(int id);
        Task<bool> ChangePassword(int id, ChangePasswordDto changePasswordDto);
        Task<bool> RequestPasswordReset(PasswordResetRequestDto requestDto);
        Task<bool> ResetPassword(PasswordResetDto resetDto);
    }
}
