using System;
using System.Collections.Generic;

namespace Client.Models
{
    public class trajet
    {
        public trajet()
        {
            this.arrets = new HashSet<arrets>();
        }
        public int? IdTrajet { get; set; }
        public int VilleDepart { get; set; }
        public int VilleArrivee { get; set; }
        public System.DateTime HeureDepart { get; set; }
        public System.DateTime HeureArrivee { get; set; }

        public virtual ICollection<arrets> arrets { get; set; }
    }

}
