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
    public class DatosPersonalesController : BBDDController<Usuario>
    {
        public DatosPersonalesController()
        {
            _table = "usuarios";
            _idCol = "idUsuario";
        }
        public ActionResult Index()
        {
            int idAux = -1;
            if (String.IsNullOrEmpty(Session["logged"] as String))
            {
                ViewBag.UserIsLogged = false;
            }
            else
            {
                ViewBag.UserIsLogged = true;
                idAux=Convert.ToInt32(Session["loggedid"] as String);
                
            }
            ViewData["usuario"]=getId(idAux);
            Usuario u = getId(idAux);
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Edit()
        {
            return View();
        }

        public override Usuario ToModel(MySqlDataReader rdr)
        {
            Usuario u = new Usuario();
            if (rdr.Read())
            {
                u.Id = Convert.ToInt32(rdr["idUsuario"]);
                u.Nombre = rdr["Nombre"].ToString();
                u.Apellido1 = rdr["Apellido1"].ToString();
                u.Apellido2 = rdr["Apellido2"].ToString();
                u.Email = rdr["Email"].ToString();
                u.FechaNacimiento = Convert.ToDateTime(rdr["FechaNacimiento"]);
                u.Telefono = rdr["Telefono"].ToString();
            }
            return u;
        }

        public override List<Usuario> ToListModel(MySqlDataReader rdr)
        {
            throw new NotImplementedException();
        }
    }
}