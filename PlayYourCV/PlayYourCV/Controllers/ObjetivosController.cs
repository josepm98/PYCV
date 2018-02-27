using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PlayYourCV.Models;

namespace PlayYourCV.Controllers
{
    public class ObjetivosController : Controller
    {
        public IActionResult Index()
        {
            ViewData["Mensage"] = "Index";
            return View();
        }

        public IActionResult Create() {
            ViewData["Mensage"] = "Create";
            return View();
        }

        public IActionResult Editar() {
            ViewData["Mensage"] = "Editar";
            return View();
        }

        public IActionResult Error() {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}