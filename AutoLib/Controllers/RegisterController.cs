using AutoLib.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using AutoLib.Models;
using System.Threading.Tasks;

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
            return View();
        }

        [HttpPost]
        public IActionResult Index(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                // Enregistrer les données en utilisant une base de données ou un autre mécanisme de stockage
                return RedirectToAction("Index", "Home");
            }
            return View(model);
        }
    }
}
