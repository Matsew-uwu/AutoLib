using System;
using System.Collections.Generic;

namespace AutoLib.Models.Domain
{
    public partial class Vehicule
    {
        public Vehicule()
        {
            Borne = new HashSet<Borne>();
            Reservation = new HashSet<Reservation>();
            Utilise = new HashSet<Utilise>();
        }

        public int IdVehicule { get; set; }
        public int Rfid { get; set; }
        public int? EtatBatterie { get; set; }
        public string Disponibilite { get; set; }
        public decimal? Latitude { get; set; }
        public decimal? Longitude { get; set; }
        public int TypeVehicule { get; set; }

        public virtual TypeVehicule TypeVehiculeNavigation { get; set; }
        public virtual ICollection<Borne> Borne { get; set; }
        public virtual ICollection<Reservation> Reservation { get; set; }
        public virtual ICollection<Utilise> Utilise { get; set; }
    }
}
