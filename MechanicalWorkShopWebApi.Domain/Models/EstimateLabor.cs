// Models/EstimateLabor.cs

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mechanical_workshop.Models
{
    public class EstimateLabor
    {
        public int ID { get; set; }
        public string Type { get; set; } = "[LABOR]";
        public string Description { get; set; } = string.Empty;
        public decimal Duration { get; set; }
        public decimal LaborRate { get; set; }
        public decimal ExtendedPrice { get; set; }
        public bool Taxable { get; set; } = false;
    }
}
