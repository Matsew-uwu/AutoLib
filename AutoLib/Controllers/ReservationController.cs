using AutoLib.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using System;
using AutoLib.Models.Domain;
using System.Threading.Tasks;

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

                return RedirectToAction("Reservations", "Client");
            }
            catch
            {
                return RedirectToAction("Detail", "Station");
            }

            
        }
    }
}
