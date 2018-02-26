using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;


namespace PlayYourCV.Controllers
{
    public class SkillsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Create()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }
        public IActionResult Edit()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }
    }

}