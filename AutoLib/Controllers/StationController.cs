using Microsoft.AspNetCore.Mvc;
using AutoLib.Models.Domain;
using System.Collections.Generic;

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

        [HttpGet]
        public IActionResult Map() { 
            var stations = _dbContext.Station;
            return Json(stations);
        }
    }
}
