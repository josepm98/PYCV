using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace PlayYourCV.Controllers
{
    public class CVSController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Create()
        {
            ViewData["Message"] = "Creacion form.";

            return View();
        }
        public IActionResult Edit()
        {
            ViewData["Message"] = "Edicion form.";

            return View();
        }
    }
}