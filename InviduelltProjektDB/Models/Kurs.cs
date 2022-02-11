using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace InviduelltProjektDB.Models
{
    public partial class Kurs
    {
        public Kurs()
        {
            Betyg = new HashSet<Betyg>();
        }

        public int KursId { get; set; }
        public string KursNamn { get; set; }
        public DateTime? KursStart { get; set; }
        public DateTime? KursSlutDatum { get; set; }

        public virtual ICollection<Betyg> Betyg { get; set; }
    }
}
