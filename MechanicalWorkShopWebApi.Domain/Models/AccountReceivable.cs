// Models/AccountReceivable.cs
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mechanical_workshop.Models
{
    public class AccountReceivable
    {
        public int Id { get; set; }
        public int EstimateId { get; set; }
        public int CustomerId { get; set; }
        public decimal OriginalAmount { get; set; }
        public decimal Balance { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public DateTime? CompletedDate { get; set; }
        public string Status { get; set; } = "Pending";
    }
}