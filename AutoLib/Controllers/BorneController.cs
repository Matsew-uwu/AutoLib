using AutoLib.Models.Domain;
using Microsoft.AspNetCore.Mvc;

namespace AutoLib.Controllers
{
    public class BorneController : Controller
    {
        private readonly autolibContext _dbContext;

        public BorneController(autolibContext db)
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
            var borne = _dbContext.Borne.Find(id);
            return Json(borne);
        }

    }
}
