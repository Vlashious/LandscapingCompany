using System;
using System.Collections.Generic;

namespace LandscapingCompany.Models
{
    public partial class ParkZones
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? ParkId { get; set; }

        public virtual Parks Park { get; set; }
    }
}
