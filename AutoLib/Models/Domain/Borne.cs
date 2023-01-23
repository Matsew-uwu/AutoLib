using System;
using System.Collections.Generic;

namespace AutoLib.Models.Domain
{
    public partial class Borne
    {
        public Borne()
        {
            UtiliseBorneArriveeNavigation = new HashSet<Utilise>();
            UtiliseBorneDepartNavigation = new HashSet<Utilise>();
        }

        public int IdBorne { get; set; }
        public bool EtatBorne { get; set; }
        public int Station { get; set; }
        public int? IdVehicule { get; set; }

        public virtual Vehicule IdVehiculeNavigation { get; set; }
        public virtual Station StationNavigation { get; set; }
        public virtual ICollection<Utilise> UtiliseBorneArriveeNavigation { get; set; }
        public virtual ICollection<Utilise> UtiliseBorneDepartNavigation { get; set; }
    }
}
