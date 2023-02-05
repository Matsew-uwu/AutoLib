using AutoLib.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using System;
using AutoLib.Models.Domain;
using System.Threading.Tasks;
using System.Linq;

namespace AutoLib.Controllers
{
    public class ReservationController : Controller
    {

        private readonly autolibContext _dbContext;

        public ReservationController(autolibContext db)
        {
            _dbContext = db;
        }
        
        [HttpPost]
        public IActionResult Index()
        {
            ViewData["_Session"] = HttpContext.Session;
            return View();
        }

        
        public async Task<IActionResult> Confirm(IFormCollection collection)
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("Firstname")))
            {
                return RedirectToAction("Index", "Login");
            }

           
            try
            {
                int vehiculeId = int.Parse(collection["VehiculeId"]);

                DateTime currentDateTime = DateTime.Now;
                string dateReservation = currentDateTime.ToString("dd/MM/yyyy HH:mm");

                Reservation reservation = new Reservation
                {
                    Vehicule = vehiculeId,
                    Client = (int)HttpContext.Session.GetInt32("IdClient"),
                    DateReservation = currentDateTime,
                    DateEcheance = currentDateTime.AddMinutes(30),
                };

                _dbContext.Reservation.Add(reservation);
                await _dbContext.SaveChangesAsync();

                //mise à jour de la disponibilité du véhicule
                var vehicule = _dbContext.Vehicule.Find(vehiculeId);
                if (vehicule != null)
                {
                    vehicule.Disponibilite = "NON DISPONIBLE";
                    _dbContext.Vehicule.Update(vehicule);
                    _dbContext.SaveChanges();
                }
/*
                //mise à jour de la borne
                var borne = _dbContext.Borne.Where(s => s.IdVehicule == vehiculeId).FirstOrDefault();
                if (borne != null)
                {
                    borne.IdVehicule = null;
                    _dbContext.Borne.Update(borne);
                    _dbContext.SaveChanges();
                }*/
                
                return RedirectToAction("Reservations", "Client");
            }
            catch
            {
                return RedirectToAction("Detail", "Station");
            }

            
        }
    }
}
