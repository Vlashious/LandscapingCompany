using System;
using System.Collections.Generic;

namespace LandscapingCompany.Models
{
    public partial class Firm
    {
        public Firm()
        {
            Services = new HashSet<Services>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }

        public virtual ICollection<Services> Services { get; set; }
    }
}
