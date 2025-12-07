using MechanicalWorkShopWebApi.Domain.Interfaces.IRepository;

namespace MechanicalWorkShopWebApi.Domain.Exceptions
{
    public class UserValidator
    {
        private readonly IUserRepository _userRepository;

        public UserValidator(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task ValidateUsernameIsUniqueAsync(string username)
        {
            var existingUser = await _userRepository.GetByUsername(username);

            if (existingUser != null)
            {
                throw new DuplicateUsernameException($"El nombre de usuario '{username}' ya está en uso.");
            }
        }

        public async Task ValidateEmailIsUniqueAsync( string email)
        {
            var existingEmail = await _userRepository.GetByEmail(email);

            if (existingEmail != null)
            {
                throw new DuplicateUsernameException($"El correo '{email}' ya está en uso.");
            }
        }
    }
}
