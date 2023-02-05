using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoLib.Models.Domain;
using System.Data;
using Microsoft.AspNetCore.Mvc;

namespace AutoLib.Controllers
{
    public class AutoLibController : Controller
    {
        public IActionResult Index()
        {
            ViewData["_Session"] = HttpContext.Session;

            return View();
        }
    }
}
