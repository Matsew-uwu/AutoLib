using AutoLib.Models;
using AutoLib.Models.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using WebMangaEntity.Models.Utilitaires;

namespace AutoLib.Controllers
{
    public class LoginController : Controller
    {
        private readonly autolibContext _dbContext;

        public LoginController(autolibContext db)
        {
            _dbContext = db;
        }

        public IActionResult Index()
        {
            ViewData["_Session"] = HttpContext.Session;

            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("Firstname")))
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        [HttpPost]
        public IActionResult Index(LoginModel model)
        {
            ViewData["_Session"] = HttpContext.Session;
            
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("Firstname")))
            {
                return RedirectToAction("Index", "Home");
            }

            if (ModelState.IsValid)
            {

                // Vérifie si l'utilisateur existe 
                Client client = _dbContext.Client.Where(s => s.Nom == model.Lastname && s.Prenom == model.Firstname).FirstOrDefault();

                if (client == null)
                {
                    ModelState.AddModelError("", "L'utilisateur n'existe pas");
                    return View(model);
                }

                // Hash du mot de passe
                String clientSalt = client.Salt;
                String clientPassword = client.Password;

                Byte[] saltByte = PasswordHash.StringToBytes(clientSalt);
                Byte[] passwordByte = PasswordHash.StringToBytes(clientPassword);

                
                // Vérifie si le mot de passe est correct
                if (PasswordHash.VerifyPassword(saltByte, model.Password, passwordByte) == false)
                {
                    ModelState.AddModelError("", "Mot de passe incorrect");
                    return View(model);
                }

                // Créer une session
                HttpContext.Session.SetString("Lastname", client.Nom);
                HttpContext.Session.SetString("Firstname", client.Prenom);
                HttpContext.Session.SetString("DateOfBirth", client.DateNaissance.ToString());
                HttpContext.Session.SetInt32("IdClient", client.IdClient);

                return RedirectToAction("Index", "Home");
            }
            return View(model);
        }
    }
}
