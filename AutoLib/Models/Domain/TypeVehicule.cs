using System;
using System.Collections.Generic;

namespace AutoLib.Models.Domain
{
    public partial class TypeVehicule
    {
        public TypeVehicule()
        {
            Vehicule = new HashSet<Vehicule>();
        }

        public int IdTypeVehicule { get; set; }
        public string Categorie { get; set; }
        public string TypeVehicule1 { get; set; }

        public virtual ICollection<Vehicule> Vehicule { get; set; }
    }
}
