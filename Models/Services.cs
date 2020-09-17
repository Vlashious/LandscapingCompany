using System;
using System.Collections.Generic;

namespace LandscapingCompany.Models
{
    public partial class Services
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? FirmId { get; set; }

        public virtual Firm Firm { get; set; }
    }
}
