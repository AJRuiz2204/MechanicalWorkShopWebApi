// Models/Report.cs
using System.ComponentModel.DataAnnotations;

namespace Mechanical_workshop.Models
{
    public class Report
    {
        public int ID { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public DateTime Date { get; set; } = DateTime.UtcNow;
        public string Author { get; set; } = string.Empty;
    }
}
