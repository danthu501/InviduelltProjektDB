using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace InviduelltProjektDB.Models
{
    public partial class Anställda
    {
        public Anställda()
        {
            Betyg = new HashSet<Betyg>();
        }

        public int AnställningsNummer { get; set; }
        public string FörNamn { get; set; }
        public string EfterNamn { get; set; }
        public string Befattning { get; set; }
        public decimal? Lön { get; set; }
        public DateTime? AnställningsDatum { get; set; }
        public int? FavdelningsId { get; set; }

        public virtual Avdelning Favdelnings { get; set; }
        public virtual ICollection<Betyg> Betyg { get; set; }
    }
}
