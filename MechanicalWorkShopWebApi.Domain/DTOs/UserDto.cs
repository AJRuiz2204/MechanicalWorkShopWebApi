namespace MechanicalWorkShopWebApi.Domain.DTOs
{
    public class UserDto
    {
        // Para devolver datos al frontend (sin password)
        public class UserResponseDto
        {
            public int ID { get; set; }
            public string Email { get; set; }
            public string Username { get; set; }
            public string Profile { get; set; }
        }

        // Recibe datos del login
        public class UserLoginDto
        {
            public string Username { get; set; }
            public string Password { get; set; }
        }

        // Para registrar un nuevo usuario
        public class UserRegisterDto
        {
            public string Email { get; set; }
            public string Username { get; set; }
            public string Password { get; set; }
        }

        // Para actualizar información del usuario
        public class UserUpdateDto
        {
            public string Email { get; set; }
            public string Username { get; set; }
            public string Profile { get; set; }
        }

        // Para cambiar contraseña
        public class ChangePasswordDto
        {
            public string CurrentPassword { get; set; }
            public string NewPassword { get; set; }
        }

        // Para solicitar reset de contraseña
        public class PasswordResetRequestDto
        {
            public string Email { get; set; }
        }

        // Para resetear contraseña con código
        public class PasswordResetDto
        {
            public string Email { get; set; }
            public string ResetCode { get; set; }
            public string NewPassword { get; set; }
        }
    }
}
