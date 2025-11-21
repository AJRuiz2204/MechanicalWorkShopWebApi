// Models/WorkshopSettings.cs

using System;
using System.ComponentModel.DataAnnotations;

namespace Mechanical_workshop.Models
{
    public class WorkshopSettings
    {
        public int Id { get; set; }
        public string? WorkshopName { get; set; }
        public string? Address { get; set; }
        public string? PrimaryPhone { get; set; }
        public string? SecondaryPhone { get; set; }
        public string? Fax { get; set; }
        public string? WebsiteUrl { get; set; }
        public DateTime LastUpdated { get; set; } = DateTime.UtcNow;
        public string? Disclaimer { get; set; }
        public string? Email { get; set; }
    }
}
