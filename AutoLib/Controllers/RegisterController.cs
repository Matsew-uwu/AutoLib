﻿using AutoLib.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using AutoLib.Models;
using System.Threading.Tasks;
using WebMangaEntity.Models.Utilitaires;
using System;
using Microsoft.AspNetCore.DataProtection;
using System.Net.Sockets;
using Microsoft.AspNetCore.Http;

namespace AutoLib.Controllers
{
    public class RegisterController : Controller
    {
        private readonly autolibContext _dbContext;

        public RegisterController(autolibContext db)
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
        public async Task<IActionResult> Index(RegisterModel model)
        {
            ViewData["_Session"] = HttpContext.Session;

            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("Firstname")))
            {
                return RedirectToAction("Index", "Home");
            }

            if (ModelState.IsValid)
            {
                // Enregistrer les données en utilisant une base de données

                // Hash le mot de passe
                Byte[] selmdp = PasswordHash.GenerateSalt();
                Byte[] mdpByte = PasswordHash.PasswordHashe(model.Password, selmdp);
                
                // On récupère le mot de passe et le sel
                String mdpS = PasswordHash.BytesToString(mdpByte);
                String saltS = PasswordHash.BytesToString(selmdp);


                // Créer une utilisateur
                Client client = new Client
                {
                    Nom = model.Lastname,
                    Prenom = model.Firstname,
                    DateNaissance = model.DateNaissance,
                    Password = mdpS,
                    Salt = saltS
                };

                // Insérer l'utilisateur dans la base de données
                _dbContext.Client.Add(client);
                await _dbContext.SaveChangesAsync();

                return RedirectToAction("Index", "Home");
            }
            
            return View(model);
        }
    }
}
