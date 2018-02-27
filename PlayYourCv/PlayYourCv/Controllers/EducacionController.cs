using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using PlayYourCV.Models;

namespace PlayYourCV.Controllers
{
    public class EducacionController : Controller
    {
        public ActionResult Index()
        {
            ViewData["Titulo"] = "Educacion";
            //TODO realizar con bbdd
            return View();
        }

        public ActionResult Create()
        {
            ViewData["Titulo"] = "Educacion";
            return View();
        }

        public ActionResult Edit()
        {
            ViewData["Titulo"] = "Educacion";
            return View();
        }
    }
}
