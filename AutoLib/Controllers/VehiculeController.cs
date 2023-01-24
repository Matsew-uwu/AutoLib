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
            return View();
        }

        [HttpGet]
        public IActionResult get(int id)
        {
            var vehicule = _dbContext.Vehicule.Find(id);
            return Json(vehicule);
        }
    }
}
