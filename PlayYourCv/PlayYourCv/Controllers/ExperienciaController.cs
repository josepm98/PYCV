﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using PlayYourCV.Models;

namespace PlayYourCV.Controllers {
    public class ExperienciaController : Controller {
        public ActionResult Index() {
            ViewData["Mensage"] = "Index";
            return View();
        }

        public ActionResult Create() {
            ViewData["Mensage"] = "Create";
            return View();
        }

        public ActionResult Edit() {
            ViewData["Mensage"] = "Editar";
            return View();
        }
    }
}