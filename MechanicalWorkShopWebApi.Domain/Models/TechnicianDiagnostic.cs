using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mechanical_workshop.Models
{
    public class TechnicianDiagnostic
    {
        public int Id { get; set; }
        public int Mileage { get; set; }
        public string ExtendedDiagnostic { get; set; } = string.Empty;
    }
}
