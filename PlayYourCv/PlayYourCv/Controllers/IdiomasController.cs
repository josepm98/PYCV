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
        public string _idCat;

        public IdiomasController()
        {
            _table = "contenidos";
            _idCol = "idContenido";
            _idCat = "3";
        }

        public ActionResult Index()
        {
            if (checkLogged()==null)
            {
                ViewBag.UserIsLogged = true;
                ViewBag.Logged = Session["logged"] as String;
                ViewBag.LoggedId = Session["loggedid"] as String;

                ViewData["listaIdiomas"] = GetUserLanguages(Convert.ToInt32(Session["loggedid"] as String));
                ViewData["Titulo"] = "Idiomas";
                return View();
            }
            else
            {
                return checkLogged();//return to home
            }
        }

        public ActionResult Create()
        {
            ViewData["Titulo"] = "Agregar Idioma";
            return View();
        }

        // POST: Login/Edit/5
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                openConn();
                MySqlCommand cmd = new MySqlCommand();
                string sql = string.Format("INSERT INTO {0} (idUsuario, Categorias_idCategorias, Nombre, Hablado, Escrito, Leido, NivelGeneral) VALUES (@uid, {1}, @nombre, @hablado, @escrito, @leido, @nivelGeneral)", _table,_idCat);
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@uid", Convert.ToInt32(Session["loggedid"] as String));
                cmd.Parameters.AddWithValue("@nombre", collection["Nombre"].ToString());
                cmd.Parameters.AddWithValue("@hablado", collection["Hablado"].ToString());
                cmd.Parameters.AddWithValue("@escrito", collection["Escrito"].ToString());
                cmd.Parameters.AddWithValue("@leido", collection["Leido"].ToString());
                cmd.Parameters.AddWithValue("@nivelGeneral", collection["NivelGeneral"].ToString());
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
            ViewData["Titulo"] = "Editar Idioma";
            ViewData["Idioma"]= getId(id);
            return View();
        }

        // POST: Login/Edit/5
        [HttpPost]
        public ActionResult Edit(FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                openConn();
                MySqlCommand cmd = new MySqlCommand();
                string sql = string.Format("UPDATE {0} SET Nombre=@nombre, Hablado=@hablado, Escrito=@escrito, Leido=@leido, NivelGeneral=@nivelGeneral WHERE {1}=@cId", _table, _idCol);
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@nombre", collection["Nombre"].ToString());
                cmd.Parameters.AddWithValue("@hablado", collection["Hablado"].ToString());
                cmd.Parameters.AddWithValue("@escrito", collection["Escrito"].ToString());
                cmd.Parameters.AddWithValue("@leido", collection["Leido"].ToString());
                cmd.Parameters.AddWithValue("@nivelGeneral", collection["NivelGeneral"].ToString());
                cmd.Parameters.AddWithValue("@cId", collection["Id"].ToString());
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

        // GET: Login/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                // TODO: Add update logic here
                openConn();
                MySqlCommand cmd = new MySqlCommand();
                string sql = string.Format("DELETE FROM {0} WHERE {1}=@cId", _table, _idCol);
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@cId", id);
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

        //BBDD methods
        public List<Contenido> GetUserLanguages(int idUser)
        {
            List<Contenido> list = new List<Contenido>();
            try
            {
                openConn();
                string sql =string.Format("SELECT * FROM {0} WHERE {1}=@uid AND {2}={3}", _table, "idUsuario", "Categorias_idCategorias", _idCat);
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
            return list;
        }
		
		private Contenido singleContenidoReader(MySqlDataReader rdr)
        {
            Contenido c = new Contenido();
            c.Id = Convert.ToInt32(rdr[_idCol].ToString());
            c.IdUsuario = Convert.ToInt32(Session["loggedid"] as String);
            c.Nombre = rdr["Nombre"].ToString();
            c.IdCategoria = Convert.ToInt32(_idCat);
            c.Hablado = rdr["Hablado"].ToString();
            c.Leido = rdr["Leido"].ToString();
            c.Escrito = rdr["Escrito"].ToString();
            c.NivelGeneral = rdr["NivelGeneral"].ToString();
            return c;
        }
    }
}
