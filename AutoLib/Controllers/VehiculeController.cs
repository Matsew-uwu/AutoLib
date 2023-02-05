using AutoLib.Models.Domain;
using Microsoft.AspNetCore.Mvc;

namespace AutoLib.Controllers
{
    public class VehiculeController : Controller
    {
        private readonly autolibContext _dbContext;

        public VehiculeController(autolibContext db)
        {
            _dbContext = db;
        }
        public IActionResult Index()
        {
            ViewData["_Session"] = HttpContext.Session;

            return View();
        }

        [HttpGet]
        public IActionResult Get(int id)
        {
            var vehicule = _dbContext.Vehicule.Find(id);
            return Json(vehicule);
        }

        public Vehicule GetVehicule(int id)
        {
            Vehicule vehicule = _dbContext.Vehicule.Find(id);
            return vehicule;
        }
    }
}
