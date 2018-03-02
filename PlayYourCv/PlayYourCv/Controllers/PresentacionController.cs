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
        // GET: Presentacion
        public ActionResult Index()
        {
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

            try
            {

                string sql =
                "INSERT INTO contenidos (idUsuario, Categorias_idCategorias, Descripcion) Values " +
                " (@userid,@categoriaid,@descripcion)";

                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = sql;
                cmd.Connection = _conn;
                cmd.Parameters.AddWithValue("@userid", userid);
                cmd.Parameters.AddWithValue("@categoriaid", categoriaid);
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
            return View();
        }

        // POST: Presentacion/Edit/5
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
            throw new NotImplementedException();
        }

        public override List<Contenido> ToListModel(MySqlDataReader rdr)
        {
            throw new NotImplementedException();
        }
    }
}
