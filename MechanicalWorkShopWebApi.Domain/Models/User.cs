using System.ComponentModel.DataAnnotations;

namespace Mechanical_workshop.Models
{
    public class User
    {
        public int ID { get; set; }
        public string Email { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Profile { get; set; } = string.Empty;
        public string ResetCode { get; set; } = string.Empty;
        public DateTime? ResetCodeExpiry { get; set; }
    }
}