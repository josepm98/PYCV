using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace PlayYourCV.Controllers
{
    public class CVSController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Create()
        {
            ViewData["Message"] = "Creacion form.";

            return View();
        }
        public ActionResult Edit()
        {
            ViewData["Message"] = "Edicion form.";

            return View();
        }
        public ActionResult Moduloscv()
        {
            ViewData["Message"] = "Edicion form.";

            return View();
        }
    }
}