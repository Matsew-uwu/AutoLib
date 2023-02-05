using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace AutoLib.Models
{
    public class ReservationModel
    {
        [Required]
        [Display(Name = "Client")]
        public int ClientId { get; set; }

        [Required]
        [Display(Name = "Borne")]
        public int BorneId { get; set; }

        [Required]
        [Display(Name = "Vehicule")]
        public int VehiculeId { get; set; }

        // Date input
        [Required]
        [Display(Name = "Date de réservation")]
        public DateTime DateReservation { get; set; }

        [Required]
        [Display(Name = "Date d'échéance")]
        public DateTime DateEcheance { get; set; }


    }

}
