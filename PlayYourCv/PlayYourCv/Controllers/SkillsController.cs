using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;


namespace PlayYourCV.Controllers
{
    public class SkillsController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Create()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }
        public ActionResult Edit()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }
    }

}