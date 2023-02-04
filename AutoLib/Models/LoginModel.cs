using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace AutoLib.Models
{
    public class LoginModel
    {
        [Required]
        [Display(Name = "Prénom")]
        public string Firstname { get; set; }

        [Required]
        [Display(Name = "Nom")]
        public string Lastname { get; set; }

        // Date input
        [Required]
        [Display(Name = "Date de naissance")]
        public DateTime? DateNaissance { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Mot de passe")]
        public string Password { get; set; }
    }

}
