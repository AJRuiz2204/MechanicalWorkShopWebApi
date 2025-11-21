using Mechanical_workshop.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MechanicalWorkShopWebApi.Models
{
    public class Payment
    {
        public int Id { get; set; }
        public int AccountReceivableId { get; set; }
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; } = DateTime.UtcNow;
        public required string Method { get; set; }
        public string TransactionReference { get; set; } = string.Empty;
        public string Notes { get; set; } = string.Empty;
    }
}
