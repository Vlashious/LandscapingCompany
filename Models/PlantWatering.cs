using System;
using System.Collections.Generic;

namespace LandscapingCompany.Models
{
    public partial class PlantWatering
    {
        public int PlantAge { get; set; }
        public string PlantType { get; set; }
        public int? Regularity { get; set; }
        public TimeSpan? WateringTime { get; set; }
        public int? Litres { get; set; }
    }
}
