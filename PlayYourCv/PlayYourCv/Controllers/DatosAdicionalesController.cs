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
    public class DatosAdicionalesController : BBDDController<Contenido>
    {
        public string _idCat;

        public DatosAdicionalesController()
        {
            _table = "contenidos";
            _idCol = "idContenido";
            _idCat = "8";
        }


        public ActionResult Index()
        {
            //TODO select all
            ViewData["lista"] = GetAdi(Convert.ToInt32(Session["loggedid"] as String));
            return View();
        }

        public ActionResult Details(int id)
        {
            return View();
        }

      

        // POST
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            if (String.IsNullOrEmpty(Session["loggedId"] as String))
            {
                return View();
            }

            int userid = Convert.ToInt32(Session["loggedid"] as String);
            int categoriaid = 8;

            openConn();
            string nombre = collection["Nombre"].ToString();

            try
            {

                string sql =
                "INSERT INTO contenidos (idUsuario, Categorias_idCategorias, Nombre) Values " +
                " (@userid,@categoriaid,@nombre)";

                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = sql;
                cmd.Connection = _conn;
                cmd.Parameters.AddWithValue("@userid", userid);
                cmd.Parameters.AddWithValue("@categoriaid", categoriaid);
                cmd.Parameters.AddWithValue("@nombre", nombre);
                cmd.Prepare();
                int filas = cmd.ExecuteNonQuery();

                closeConn(); //método propio que cierra conexión si está abierta
                return RedirectToAction("Index");

            }
            catch (Exception ex)
            {
                string s = ex.Message;
                closeConn(); //método propio que cierra conexión si está abierta
            }

            return View("Index");
        }

        // GET: Presentacion/Edit/5
        /*
        public ActionResult Edit(int id)
        {
            Contenido model = this.getId(id);
            return View(model);
        }
        */

        // POST: Presentacion/Edit/5
        [HttpPost]
        public ActionResult Edit(FormCollection collection)
        {
            if (String.IsNullOrEmpty(Session["loggedid"] as String))
            {
                return View();
            }

            int userid = Convert.ToInt32(Session["loggedid"] as String);

            try
            {
                _conn.Open();
                int contenidoid = Convert.ToInt32(collection["Id"].ToString());
                string nombre = collection["Nombre"].ToString();

                string sql = "UPDATE contenidos SET " +
                    "Nombre=@nombre WHERE idContenido=@contenidoid";

                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = sql;
                cmd.Connection = _conn;
                cmd.Parameters.AddWithValue("@contenidoid", contenidoid);
                cmd.Parameters.AddWithValue("@nombre", nombre);
                cmd.Prepare();
                int filas = cmd.ExecuteNonQuery();

                closeConn(); //método propio que cierra conexión si está abierta
                return RedirectToAction("Index");

            }

            catch (Exception ex)
            {
                string s = ex.Message;
                closeConn(); //método propio que cierra conexión si está abierta
            }

            return View();
        }

        // GET: Presentacion/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                int userid = Convert.ToInt32(Session["loggedid"] as String);

                openConn();

                string sql = "DELETE FROM contenidos WHERE idContenido = @id";
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = sql;
                cmd.Connection = _conn;
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Prepare();
                int filas = cmd.ExecuteNonQuery();

                closeConn(); //método propio que cierra conexión si está abierta
            }
            catch (Exception ex)
            {
                string s = ex.Message;
                closeConn(); //método propio que cierra conexión si está abierta
            }
            return View("Index");
        }


        public override Contenido ToModel(MySqlDataReader rdr)
        {
            Contenido c = new Contenido();
            if (rdr.Read())
            {
                c.Id = Convert.ToInt32(rdr["idContenido"]);
                c.Nombre = rdr["Nombre"].ToString();
            }

            return c;
        }

        public override List<Contenido> ToListModel(MySqlDataReader rdr)
        {
            List<Contenido> Lista = new List<Contenido>();
            while (rdr.Read())
            {
                Contenido c = new Contenido();
                c.Id = Convert.ToInt32(rdr["idContenido"]);
                c.Nombre = rdr["Nombre"].ToString();
                Lista.Add(c);
            }

            return Lista;
        }

        public List<Contenido> GetAdi(int idUser)
        {
            List<Contenido> list = new List<Contenido>();
            try
            {
                openConn();
                string sql = string.Format("SELECT * FROM contenidos WHERE idUsuario=@uid AND Categorias_idCategorias=8");
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = sql;
                cmd.Connection = _conn;
                cmd.Parameters.AddWithValue("@uid", idUser);
                cmd.Prepare();
                MySqlDataReader rdr = cmd.ExecuteReader();
                list = ToListModel(rdr);
            }
            catch (Exception ex)
            {
                string s = ex.Message;
                closeConn();
            }
            finally
            {
                closeConn();
            }
            return list;
        }
    }

}