using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mechanical_workshop.Models
{
    public class Vehicle
    {
        public int Id { get; set; }
        public string Vin { get; set; } = string.Empty;
        public string Make { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;
        public string Year { get; set; } = string.Empty;
        public string Engine { get; set; } = string.Empty;
        public string Plate { get; set; } = string.Empty;
        public string State { get; set; } = string.Empty;
        public string Status { get; set; } = "Visto";
    }
}
