using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace InviduelltProjektDB.Models
{
    public partial class Elev
    {
        public int ElevId { get; set; }
        public decimal? Personnummer { get; set; }
        public string FörNamn { get; set; }
        public string EfterNamn { get; set; }
        public int? Klass { get; set; }

        public virtual Klass KlassNavigation { get; set; }
    }
}
