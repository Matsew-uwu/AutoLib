using AutoLib.Models.Domain;
using Microsoft.AspNetCore.Mvc;

namespace AutoLib.Controllers
{
    public class TypeVehiculeController : Controller
    {
        private readonly autolibContext _dbContext;

        public TypeVehiculeController(autolibContext db)
        {
            _dbContext = db;
        }
        public IActionResult Index()
        {
            ViewData["_Session"] = HttpContext.Session;
            
            return View();
        }

        [HttpGet]
        public IActionResult get(int id)
        {
            var typeVehicule = _dbContext.TypeVehicule.Find(id);
            return Json(typeVehicule);
        }

        public TypeVehicule getTypeVehicule(int id)
        {
            var typeVehicule = _dbContext.TypeVehicule.Find(id);
            return typeVehicule;
        }
    }
}
