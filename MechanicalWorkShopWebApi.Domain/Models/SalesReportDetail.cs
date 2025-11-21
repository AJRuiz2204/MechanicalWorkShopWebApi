using Mechanical_workshop.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MechanicalWorkShopWebApi.Models
{
    public class SalesReportDetail
    {
        public int SalesReportDetailId { get; set; }
        public DateTime EstimateDate { get; set; }
        public decimal Subtotal { get; set; }
        public decimal Tax { get; set; }
        public decimal Total { get; set; }
        public decimal OriginalAmount { get; set; }
        public decimal RemainingBalance { get; set; }
        public decimal TotalPayments { get; set; }
    }
}
