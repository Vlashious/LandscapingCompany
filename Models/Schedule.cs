using System;
using System.Collections.Generic;

namespace LandscapingCompany.Models
{
    public partial class Schedule
    {
        public int WorkerId { get; set; }
        public int PlantId { get; set; }
        public TimeSpan PlantWateringTime { get; set; }
    }
}
