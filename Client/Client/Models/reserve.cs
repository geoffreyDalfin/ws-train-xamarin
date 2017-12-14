using System;
namespace Client.Models
{
    public class reserve
    {
        public Nullable<int> IdUser { get; set; }
        public int IdGareDepart { get; set; }
        public int IdGareArrivee { get; set; }
        public int NbBillets { get; set; }
        public Nullable<System.DateTime> DateReservation { get; set; }
        public Nullable<System.DateTime> DateDepart { get; set; }
        public string VilleDepart { get; set;  }
        public string VilleArrivee { get; set; }
    }
}
