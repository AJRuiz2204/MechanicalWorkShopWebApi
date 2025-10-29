// Models/EstimateFlatFee.cs

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mechanical_workshop.Models
{
    public class EstimateFlatFee
    {
        public int ID { get; set; }
        public string Type { get; set; } = "[FLATFEE]";
        public string Description { get; set; } = string.Empty;
        public decimal FlatFeePrice { get; set; }
        public decimal ExtendedPrice { get; set; }
        public bool Taxable { get; set; } = false;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
