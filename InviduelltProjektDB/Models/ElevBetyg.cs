using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace InviduelltProjektDB.Models
{
    public partial class ElevBetyg
    {
        public int? ElevId { get; set; }
        public int? BetygId { get; set; }

        public virtual Betyg Betyg { get; set; }
        public virtual Elev Elev { get; set; }
    }
}
