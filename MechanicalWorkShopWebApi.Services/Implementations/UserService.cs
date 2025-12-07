using AutoMapper;
using Mechanical_workshop.Models;
using MechanicalWorkShopWebApi.Domain.Exceptions;
using MechanicalWorkShopWebApi.Domain.Interfaces.IRepository;
using MechanicalWorkShopWebApi.Domain.Interfaces.IService;
using MechanicalWorkShopWebApi.Infrastructure.Security;
using static MechanicalWorkShopWebApi.Domain.DTOs.UserDto;

namespace MechanicalWorkShopWebApi.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IPasswordHasher _passwordHasher;
        private readonly UserValidator _userValidator;

        public UserService(IUserRepository userRepository, IMapper mapper, IPasswordHasher passwordHasher, UserValidator userValidator) // Constructor
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _passwordHasher = passwordHasher;
            _userValidator = userValidator;
        }

        public async Task<UserResponseDto> Login(UserLoginDto loginDto)
        {
            var user = await _userRepository.GetByUsername(loginDto.Username);

            if (user == null || !_passwordHasher.VerifyPasswordHash(loginDto.Password, user.PasswordHash, user.PasswordSalt))
            {
                return null;
            }

            return _mapper.Map<UserResponseDto>(user);
        }

        public async Task<UserResponseDto> Register(UserRegisterDto registerDto)
        {
            await _userValidator.ValidateUsernameIsUniqueAsync(registerDto.Username);
            await _userValidator.ValidateEmailIsUniqueAsync(registerDto.Email);

            _passwordHasher.CreatePasswordHash(registerDto.Password, out var passwordHash, out var passwordSalt);

            var userEntity = _mapper.Map<User>(registerDto);

            userEntity.PasswordHash = passwordHash;
            userEntity.PasswordSalt = passwordSalt;

            // Asignaciones por defecto (si aplica)
            userEntity.Profile = "User";

            await _userRepository.Add(userEntity);
            await _userRepository.SaveChanges();

            // Devolver respuesta mapeada
            return _mapper.Map<UserResponseDto>(userEntity);
        }
    }
}
