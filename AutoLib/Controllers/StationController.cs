using Microsoft.AspNetCore.Mvc;
using AutoLib.Models.Domain;
using System.Collections.Generic;
using System.Linq;

namespace AutoLib.Controllers
{
    public class StationController : Controller
    {
        private readonly autolibContext _dbContext;

        public StationController(autolibContext db)
        {
            _dbContext = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Station> stationsList = _dbContext.Station;
            return View(stationsList);
        }

        public IActionResult Details(int id)
        {
            ViewData["bornes"] = _dbContext.Borne.Where(b => b.Station == id);
            ViewData["station"] = _dbContext.Station.Find(id);
            return View();
        }

        [HttpGet]
        public IActionResult Map() { 
            var stations = _dbContext.Station;
            return Json(stations);
        }

        [HttpGet]
        public IActionResult Bornes(int id)
        {
            var bornes = _dbContext.Borne.Where(b => b.Station == id);
            return Json(bornes);
        }

        [HttpGet]
        public IActionResult Detail(int id)
        {
            var station = _dbContext.Station.Find(id);
            return Json(station);
        }
    }
}
