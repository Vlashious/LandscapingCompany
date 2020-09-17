using System;
using System.Collections.Generic;

namespace LandscapingCompany.Models
{
    public partial class Plants
    {
        public int Id { get; set; }
        public int ParkZone { get; set; }
        public DateTime? PlantingDate { get; set; }
        public int? Age { get; set; }
        public string PlantType { get; set; }
    }
}
