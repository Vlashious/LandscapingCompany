using System;
using System.Collections.Generic;

namespace LandscapingCompany.Models
{
    public partial class Parks
    {
        public Parks()
        {
            ParkZones = new HashSet<ParkZones>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<ParkZones> ParkZones { get; set; }
    }
}
