using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mechanical_workshop.Models
{
    public class SalesReport
    {
        public int SalesReportId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal TotalEstimates { get; set; }
        public decimal TotalPartsRevenue { get; set; }
        public decimal TotalLaborRevenue { get; set; }
        public decimal TotalFlatFeeRevenue { get; set; }
        public decimal TotalTaxCollected { get; set; }
        public decimal TotalPaymentsCollected { get; set; }
        public decimal TotalOutstanding { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
    }
}
