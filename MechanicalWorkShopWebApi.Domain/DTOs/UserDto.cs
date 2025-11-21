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
    }
}
