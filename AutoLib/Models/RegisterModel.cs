using System.ComponentModel.DataAnnotations;

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

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

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
