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

        public ActionResult Perfil()
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
                u.FechaNacimiento = (! rdr["FechaNacimiento"].ToString().Equals(""))? DateTime.Parse(rdr["FechaNacimiento"].ToString()) : default(DateTime);
                u.Telefono = rdr["Telefono"].ToString();
            }
            return u;
        }
        [HttpPost]
        public ActionResult Edit(String Nombre, String Email)
        {
            openConn();
            try
            {
                // TODO: Add update logic here
                MySqlCommand cmd = new MySqlCommand();
                string sql = "UPDATE "+_table+" " +
                    "SET Nombre = @Nombre, " +
                    /*"Apellido1 = @Apellido1, " +
                    "Apellido2 = @Apellido2, " +
                    "Telefono = @telefono, " +
                    /*"FechaNacimiento = @FechaNacimiento," +*/
                    " Email = @Email" +
                    " WHERE "+_idCol+" = @uid";
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@Nombre", Nombre);
               // cmd.Parameters.AddWithValue("@Apellido1", collection["Apellido1"].ToString());
               // cmd.Parameters.AddWithValue("@Apellido2", collection["Apellido2"].ToString());
                //cmd.Parameters.AddWithValue("@telefono", collection["telefono"].ToString());
               // cmd.Parameters.AddWithValue("@FechaNacimiento", FechaNacimiento);
                cmd.Parameters.AddWithValue("@email", Email);
                cmd.Parameters.AddWithValue ("@uid",Convert.ToInt32(Session["loggedid"] as String));
                cmd.Connection = _conn;
                cmd.Prepare();
                int rowsAfected=cmd.ExecuteNonQuery();
                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Index");
            }
            finally
            {
                closeConn();
            }
        }
        public override List<Usuario> ToListModel(MySqlDataReader rdr)
        {
            throw new NotImplementedException();
        }
    }
}