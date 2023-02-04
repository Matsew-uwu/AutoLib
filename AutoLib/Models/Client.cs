using Microsoft.AspNetCore.Identity;

namespace Autolib.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
        public string Prenom { get; set; }
        public string DateNaissance { get; set; }
        public string PassWord { get; set; }
    }
}