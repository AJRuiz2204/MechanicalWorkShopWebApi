// Models/EstimatePart.cs

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mechanical_workshop.Models
{
    public class EstimatePart
    {
        public int ID { get; set; }
        public string Type { get; set; } = "[PART]";
        public string Description { get; set; } = string.Empty;
        public string? PartNumber { get; set; } = string.Empty;
        public decimal Quantity { get; set; }
        public decimal NetPrice { get; set; }
        public decimal ListPrice { get; set; }
        public decimal ExtendedPrice { get; set; }
        public bool Taxable { get; set; } = false;
        public int EstimateID { get; set; }
    }
}
