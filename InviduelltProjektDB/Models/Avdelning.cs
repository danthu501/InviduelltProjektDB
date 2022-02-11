using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace InviduelltProjektDB.Models
{
    public partial class Avdelning
    {
        public Avdelning()
        {
            Anställda = new HashSet<Anställda>();
        }

        public int AvdelningsId { get; set; }
        public string AvdelningsNamn { get; set; }

        public virtual ICollection<Anställda> Anställda { get; set; }
    }
}
