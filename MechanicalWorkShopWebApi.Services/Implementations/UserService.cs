using AutoMapper;
using Mechanical_workshop.Models;
using MechanicalWorkShopWebApi.Domain.Interfaces.IRepository;
using MechanicalWorkShopWebApi.Domain.Interfaces.IService;
using static MechanicalWorkShopWebApi.Domain.DTOs.UserDto;

namespace MechanicalWorkShopWebApi.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<UserResponseDto> Login(UserLoginDto loginDto)
        {
            // 1. Buscar usuario en DB
            var user = await _userRepository.GetByUsername(loginDto.Username);

            // 2. Validar si existe y si la contraseña coincide
            // OJO: En prod, aquí usarías VerifyHash(loginDto.Password, user.Password)
            if (user == null || user.Password != loginDto.Password)
            {
                return null; // Login fallido
            }

            // 3. Si todo ok, mapear a DTO (sin password) y devolver
            return _mapper.Map<UserResponseDto>(user);
        }

        public async Task<UserResponseDto> Register(UserRegisterDto registerDto)
        {
            // 1. Convertir DTO a Entidad
            var userEntity = _mapper.Map<User>(registerDto);

            // Aquí podrías setear valores por defecto
            userEntity.Profile = "User";

            // 2. Guardar en DB
            await _userRepository.Add(userEntity);
            await _userRepository.SaveChanges();

            // 3. Devolver respuesta mapeada
            return _mapper.Map<UserResponseDto>(userEntity);
        }
    }
}
