// Models/Invoice.cs
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mechanical_workshop.Models
{
    public class Invoice
    {
        public int ID { get; set; }
        public int VehicleID { get; set; }
        public int UserID { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; } = DateTime.UtcNow;
        public string Status { get; set; } = string.Empty;
    }
}
