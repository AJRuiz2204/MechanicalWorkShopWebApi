// Models/Estimate.cs

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mechanical_workshop.Models
{
    public class Estimate
    {
        public int ID { get; set; }
        public DateTime Date { get; set; } = DateTime.UtcNow;
        public string CustomerNote { get; set; } = string.Empty;
        public decimal Subtotal { get; set; }
        public decimal Tax { get; set; }
        public decimal Total { get; set; }
        public string AuthorizationStatus { get; set; } = "InReview";
    }
}
