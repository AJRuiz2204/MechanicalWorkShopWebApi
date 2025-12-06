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

        public async Task<UserResponseDto> GetUserById(int id)
        {
            var user = await _userRepository.GetById(id);
            if (user == null)
            {
                return null;
            }
            return _mapper.Map<UserResponseDto>(user);
        }

        public async Task<IEnumerable<UserResponseDto>> GetAllUsers()
        {
            var users = await _userRepository.GetAll();
            return _mapper.Map<IEnumerable<UserResponseDto>>(users);
        }

        public async Task<UserResponseDto> UpdateUser(int id, UserUpdateDto updateDto)
        {
            var user = await _userRepository.GetById(id);
            if (user == null)
            {
                return null;
            }

            // Actualizar solo los campos proporcionados
            user.Email = updateDto.Email;
            user.Username = updateDto.Username;
            user.Profile = updateDto.Profile;

            await _userRepository.Update(user);
            await _userRepository.SaveChanges();

            return _mapper.Map<UserResponseDto>(user);
        }

        public async Task<bool> DeleteUser(int id)
        {
            var user = await _userRepository.GetById(id);
            if (user == null)
            {
                return false;
            }

            await _userRepository.Delete(user);
            await _userRepository.SaveChanges();

            return true;
        }

        public async Task<bool> ChangePassword(int id, ChangePasswordDto changePasswordDto)
        {
            var user = await _userRepository.GetById(id);
            if (user == null)
            {
                return false;
            }

            // Validar contraseña actual
            // OJO: En prod, aquí usarías VerifyHash
            if (user.Password != changePasswordDto.CurrentPassword)
            {
                return false;
            }

            // Actualizar contraseña
            // OJO: En prod, aquí usarías HashPassword
            user.Password = changePasswordDto.NewPassword;

            await _userRepository.Update(user);
            await _userRepository.SaveChanges();

            return true;
        }

        public async Task<bool> RequestPasswordReset(PasswordResetRequestDto requestDto)
        {
            var user = await _userRepository.GetByEmail(requestDto.Email);
            if (user == null)
            {
                return false;
            }

            // Generar código de reset (en prod, sería más seguro)
            user.ResetCode = Guid.NewGuid().ToString().Substring(0, 6).ToUpper();
            user.ResetCodeExpiry = DateTime.UtcNow.AddHours(1);

            await _userRepository.Update(user);
            await _userRepository.SaveChanges();

            // Aquí se enviaría un email con el código (no implementado)

            return true;
        }

        public async Task<bool> ResetPassword(PasswordResetDto resetDto)
        {
            var user = await _userRepository.GetByEmail(resetDto.Email);
            if (user == null)
            {
                return false;
            }

            // Validar código y expiración
            if (user.ResetCode != resetDto.ResetCode || 
                user.ResetCodeExpiry == null || 
                user.ResetCodeExpiry < DateTime.UtcNow)
            {
                return false;
            }

            // Actualizar contraseña
            // OJO: En prod, aquí usarías HashPassword
            user.Password = resetDto.NewPassword;
            user.ResetCode = string.Empty;
            user.ResetCodeExpiry = null;

            await _userRepository.Update(user);
            await _userRepository.SaveChanges();

            return true;
        }
    }
}
