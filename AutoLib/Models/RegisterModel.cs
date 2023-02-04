using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace AutoLib.Models
{
    public class RegisterModel
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

        [DataType(DataType.Password)]
        [Display(Name = "Confirmer le mot de passe")]
        [Compare("Password", ErrorMessage = "Les mots de passe ne correspond pas.")]
        public string ConfirmPassword { get; set; }
    }

}
