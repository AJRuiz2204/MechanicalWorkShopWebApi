using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mechanical_workshop.Models
{
    public class UserWorkshop
    {
        public int Id { get; set; }
        public string Email { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Profile { get; set; } = string.Empty;
        public string? ResetCode { get; set; }
        public DateTime? ResetCodeExpiration { get; set; }
        public string Address { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string State { get; set; } = string.Empty;
        public string Zip { get; set; } = string.Empty;
        public string PrimaryNumber { get; set; } = string.Empty;
        public string? SecondaryNumber { get; set; }
        public bool NoTax { get; set; } = false;
    }
}