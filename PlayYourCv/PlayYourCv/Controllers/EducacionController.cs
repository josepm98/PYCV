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
        public string _idCat;

        public EducacionController()
        {
            _table = "contenidos";
            _idCol = "idContenido";
            _idCat = "2";
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

        // POST
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                MySqlCommand cmd = new MySqlCommand();
                string sql = string.Format("INSERT INTO {0} (idUsuario, Nombre, Descripcion, Empresa_Escuela, Lugar, FechaInicio, FechaFin) VALUES  (@uid, @nombre, @descripcion, @empresaEscuela, @lugar, @fInicio, @fFin", _table);
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@uid", Convert.ToInt32(Session["loggedid"] as String));
                cmd.Parameters.AddWithValue("@nombre", collection["Nombre"].ToString());
                cmd.Parameters.AddWithValue("@descripcion", collection["Descripcion"].ToString());
                cmd.Parameters.AddWithValue("@empresaEscuela", collection["EmpresaEscuela"].ToString());
                cmd.Parameters.AddWithValue("@lugar", collection["Lugar"].ToString());
                cmd.Parameters.AddWithValue("@fInicio", collection["FechaInicio"].ToString());
                cmd.Parameters.AddWithValue("@fFin", collection["FechaFin"].ToString());
                cmd.Connection = _conn;
                cmd.Prepare();
                //TODO delete after succesfull update
                int rowsAfected = cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                closeConn();
            }
            return RedirectToAction("Index");
        }

        // GET: Login/Edit/5
        public ActionResult Edit(int id)
        {
            getId(id);
            return View(getId(id));
        }

        // POST: Login/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            openConn();
            //TODO delete after succesfull update
            string nombre = collection["Nombre"].ToString();
            string descripcion = collection["Descripcion"].ToString();
            string empresaEscuela = collection["EmpresaEscuela"].ToString();
            string lugar = collection["Lugar"].ToString();
            string fInicio = collection["FechaInicio"].ToString();
            string fFin = collection["FechaFin"].ToString();
            try
            {
                // TODO: Add update logic here
                MySqlCommand cmd = new MySqlCommand();
                string sql = string.Format("UPDATE {0} SET Nombre = @nombre, Descripcion = @descripcion, Empresa_Escuela = @empresaEscuela, Lugar = @lugar, FechaInicio = @fInicio, FechaFin = @fFin WHERE {1} = @cid",_table,id);
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@nombre", nombre);
                cmd.Parameters.AddWithValue("@descripcion", collection["Descripcion"].ToString());
                cmd.Parameters.AddWithValue("@empresaEscuela", collection["EmpresaEscuela"].ToString());
                cmd.Parameters.AddWithValue("@lugar", collection["Lugar"].ToString());
                cmd.Parameters.AddWithValue("@fInicio", collection["FechaInicio"].ToString());
                cmd.Parameters.AddWithValue("@fFin", collection["FechaFin"].ToString());
                cmd.Parameters.AddWithValue("@cid", Convert.ToInt32(Session["loggedid"] as String));
                cmd.Connection = _conn;
                cmd.Prepare();
                //TODO delete after succesfull update
                int rowsAfected = cmd.ExecuteNonQuery();
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                closeConn();
            }

            return RedirectToAction("Index");
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
                string sql = string.Format("SELECT * FROM {0} WHERE {1}=@uid AND {2}={3}", _table, _idCol,"Categorias_idCategorias",_idCat);
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
