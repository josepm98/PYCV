using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using PlayYourCV.Models;

namespace PlayYourCV.Controllers
{
    public class IdiomasController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Edit()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public ActionResult Create()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }
    }
}
