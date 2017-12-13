using System;
namespace Client.Models
{
    public class arrets
    {
        public int NumeroTrain { get; set; }
        public int IdGare { get; set; }
        public System.DateTime HeureDepart { get; set; }
        public System.DateTime HeureArrivee { get; set; }
        public int IdArret { get; set; }
        public bool IsTerminus { get; set; }
        public int IdTrajet { get; set; }
        public int IdVille { get; set; }

        public virtual ville ville { get; set; }
    }

}
