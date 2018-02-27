using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PlayYourCV.Models;

namespace PlayYourCV.Controllers
{
    public class EducacionController : Controller
    {
        public IActionResult Index()
        {
            ViewData["Titulo"] = "Educacion";
            //TODO realizar con bbdd
            return View();
        }

        public IActionResult Create()
        {
            ViewData["Titulo"] = "Educacion";
            return View();
        }

        public IActionResult Edit()
        {
            ViewData["Titulo"] = "Educacion";
            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
