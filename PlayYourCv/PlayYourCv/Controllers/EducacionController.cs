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
    public class EducacionController : BBDDController<Contenido>
    {

        public EducacionController()
        {
            _table = "contenidos";
            _idCol = "idContenido";
        }

        public ActionResult Index()
        {
            /*if (checkLogged()!=null)
            {
                ViewBag.UserIsLogged = true;
                ViewBag.Logged = Session["logged"] as String;
                ViewBag.LoggedId = Session["loggedid"] as String;

                ViewData["listaEducacion"] = GetUserCourses(ViewBag.LoggedId);
                ViewData["Titulo"] = "Idiomas";
                return View("Index","Login");//return to home
            }
            else
            {
                return checkLogged();
            }*/
            //TODO delete after testing
            ViewData["Titulo"] = "Educacion";
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        // GET: Login/Edit/5
        public ActionResult Edit(int id)
        {

            return View();
        }

        // POST: Login/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Login/Delete/5
        public ActionResult Delete(int id)
        {
            // TODO: Add update logic here
            return RedirectToAction("Index");
        }

        //BBDD methods
        public List<Contenido> GetUserCourses(int idUser)
        {
            List<Contenido> list = new List<Contenido>();
            try
            {
                openConn();
                string sql = string.Format("SELECT * FROM {0} WHERE {1}=@uid AND {2}={3}", _table, _idCol,"Categorias_idCategorias",1/*idCat educacion*/);
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = sql;
                cmd.Connection = _conn;
                cmd.Parameters.AddWithValue("@uid", idUser);
                cmd.Prepare();
                MySqlDataReader rdr = cmd.ExecuteReader();
                list = ToListModel(rdr);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.GetBaseException().ToString());
            }
            finally
            {
                closeConn();
            }
            return list;
        }

        public override Contenido ToModel(MySqlDataReader rdr)
        {
            Contenido c = new Contenido();
            if (rdr.Read())
            {
                c = singleContenidoReader(rdr);
            }
            return c;
        }

        public override List<Contenido> ToListModel(MySqlDataReader rdr)
        {
            List<Contenido> list = new List<Contenido>();
            while (rdr.Read())
            {
                list.Add(singleContenidoReader(rdr));
            }
            return null;
        }

        private Contenido singleContenidoReader(MySqlDataReader rdr)
        {
            Contenido c = new Contenido();
            c.Id = Convert.ToInt32(rdr[_idCol].ToString());
            c.IdUsuario = Convert.ToInt32(Session["loggedid"] as String);
            c.Nombre = rdr["Nombre"].ToString();
            c.Descripcion = rdr["Descripcion"].ToString();
            c.EmpresaEscuela = rdr["Empresa_Escuela"].ToString();
            c.Lugar = rdr["Lugar"].ToString();
            c.FechaInicio = DateTime.Parse(rdr["FechaInicio"].ToString());
            c.FechaFin = DateTime.Parse(rdr["FechaFin"].ToString());
            return c;
        }
    }
}
