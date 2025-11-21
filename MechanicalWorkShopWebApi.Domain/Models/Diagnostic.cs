using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mechanical_workshop.Models
{
    public class Diagnostic
    {
        public int Id { get; set; }
        public int VehicleId { get; set; }
        public Vehicle? Vehicle { get; set; }
        public string AssignedTechnician { get; set; } = string.Empty;
        public string ReasonForVisit { get; set; } = string.Empty;
    }
}
