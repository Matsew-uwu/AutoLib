using Microsoft.AspNetCore.Mvc;
using AutoLib.Models.Domain;
using System.Linq;
using Microsoft.AspNetCore.Http;

namespace AutoLib.Controllers
{
    public class ClientController : Controller
    {
        private readonly autolibContext _dbContext;

        public ClientController(autolibContext db)
        {
            _dbContext = db;
        }
            
        public IActionResult Reservations()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("IdClient")))
            {
                return RedirectToAction("Index", "Login");
            }
            
            ViewData["_Session"] = HttpContext.Session;
            ViewData["Reservations"] = _dbContext.Reservation.Where(s => s.Client == (int) HttpContext.Session.GetInt32("IdClient"));
            return View();
        }
    }
}
