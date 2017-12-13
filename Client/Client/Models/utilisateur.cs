using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Client.Models
{
    public partial class utilisateur
    {
        public utilisateur()
        {
            this.reserve = new HashSet<reserve>();
        }


        public int IdUser { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Mail { get; set; }
        public string MotPasse { get; set; }

        public virtual ICollection<reserve> reserve { get; set; }


    }
}
