using System;
using System.Collections.Generic;

namespace AutoLib.Models.Domain
{
    public partial class Station
    {
        public Station()
        {
            Borne = new HashSet<Borne>();
        }

        public int IdStation { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public string Adresse { get; set; }
        public int? Numero { get; set; }
        public string Ville { get; set; }
        public int? CodePostal { get; set; }

        public virtual ICollection<Borne> Borne { get; set; }
    }
}
