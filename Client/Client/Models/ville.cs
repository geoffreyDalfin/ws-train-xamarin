using System;
using System.Collections.Generic;

namespace Client.Models
{
    public class ville
    {
        public ville()
        {
            this.gare = new HashSet<gare>();
        }

        public int? IdVille { get; set; }
        public string NomVille { get; set; }
        public virtual ICollection<gare> gare { get; set; }
    }
}
