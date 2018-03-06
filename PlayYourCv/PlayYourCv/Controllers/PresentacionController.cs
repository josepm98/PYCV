using MySql.Data.MySqlClient;
using PlayYourCV.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Security.Cryptography;
using System.Text;

namespace PlayYourCV.Controllers
{
    public class PresentacionController : BBDDController<Contenido>
    {
        public string _idCat;
        public PresentacionController() : base()
        {
            _table = "contenidos";
            _idCol = "idContenido";
            _idCat = "5";
        }
        // GET: Presentacion
        public ActionResult Index()
        {
            //TODO select all
            ViewData["lista"] = GetPre(Convert.ToInt32(Session["loggedid"] as String));
            return View();
        }

        // GET: Presentacion/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Presentacion/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Login/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {


            if (String.IsNullOrEmpty(Session["loggedId"] as String))
            {
                return View();
            }


            int userid = Convert.ToInt32(Session["loggedid"] as String);
            int categoriaid = 5;



            openConn();
            string descripcion = collection["Descripcion"].ToString();
            string nombre = collection["Nombre"].ToString();

            try
            {

                string sql =
                "INSERT INTO contenidos (idUsuario, Categorias_idCategorias, Nombre, Descripcion) Values " +
                " (@userid,@categoriaid,@nombre,@descripcion)";

                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = sql;
                cmd.Connection = _conn;
                cmd.Parameters.AddWithValue("@userid", userid);
                cmd.Parameters.AddWithValue("@categoriaid", categoriaid);
                cmd.Parameters.AddWithValue("@nombre", nombre);
                cmd.Parameters.AddWithValue("@descripcion", descripcion);
                cmd.Prepare();
                int filas = cmd.ExecuteNonQuery();

                closeConn(); //método propio que cierra conexión si está abierta
                return RedirectToAction("Index");

            }
            catch (Exception ex)
            {
                closeConn(); //método propio que cierra conexión si está abierta
            }

            return View();
        }

        // GET: Presentacion/Edit/5
        public ActionResult Edit(int id)
        {
            Contenido model = this.getId(id);
            return View(model);
        }

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
                string descripcion = collection["Descripcion"].ToString();
                string nombre = collection["Nombre"].ToString();

                string sql = "UPDATE contenidos SET " +
                    "Descripcion=@descripcion, Nombre=@nombre WHERE idContenido=@contenidoid";

                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = sql;
                cmd.Connection = _conn;
                cmd.Parameters.AddWithValue("@contenidoid", contenidoid);
                cmd.Parameters.AddWithValue("@nombre", nombre);
                cmd.Parameters.AddWithValue("@descripcion", descripcion);
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
            return View();
        }

        // POST: Presentacion/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public override Contenido ToModel(MySqlDataReader rdr)
        {
            Contenido c = new Contenido();
            if (rdr.Read())
            {
                c.Id = Convert.ToInt32(rdr["idContenido"]);
                c.Descripcion = rdr["Descripcion"].ToString();
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
                c.Descripcion = rdr["Descripcion"].ToString();
                c.Nombre = rdr["Nombre"].ToString();
                Lista.Add(c);

            }
            return Lista;
        }

        public List<Contenido> GetPre(int idUser)
        {
            List<Contenido> list = new List<Contenido>();
            try
            {
                openConn();
                string sql = string.Format("SELECT * FROM contenidos WHERE idUsuario=@uid AND Categorias_idCategorias=5");
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
    }
}
