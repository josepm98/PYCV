using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using MySql.Data.MySqlClient;
using PlayYourCV.Models;

namespace PlayYourCV.Controllers
{
    public class IdiomasController : BBDDController<Contenido>
    {
        public IdiomasController()
        {
            _table = "contenidos";
            _idCol = "idContenido";
        }
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

        public override Contenido ToModel(MySqlDataReader rdr)
        {
            Contenido c = new Contenido();
            if (rdr.Read())
            {

            }
            return null;
        }

        public override List<Contenido> ToListModel(MySqlDataReader rdr)
        {
            while (rdr.Read())
            {

            }
            return null;
        }
    }
}
