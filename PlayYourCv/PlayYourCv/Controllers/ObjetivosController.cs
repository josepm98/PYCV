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
    public class ObjetivosController : BBDDController<Objetivo>
    {

        public ObjetivosController() {
            _table = "objetivos";
            _idCol = "idObjetivos";
        }
        public ActionResult Index()
        {
            if (checkLogged() == null)
            {
                ViewBag.UserIsLogged = true;
                ViewBag.Logged = Session["logged"] as String;
                ViewBag.LoggedId = Session["loggedid"] as String;

                ViewData["listaObjetivos"] = GetUserObjetives(Convert.ToInt32(Session["loggedid"] as String));
                ViewData["listaCategorias"] = GetCategories();
                ViewData["Titulo"] = "Objetivo Principal";
                return View();
            }
            else
            {
                return checkLogged();//return to home
            }
        }

        // POST: Login/Create
        [HttpPost]
        public ActionResult AddSubobjetive(FormCollection collection)
        {
            //delete after test VALUES PASS
            string aux1 = collection["Descripcion"].ToString();
            string aux2 = collection["IdPadre"].ToString();
            string aux3 = collection["IdCategoria"].ToString();
            try {
                openConn();
                string sql =string.Format("INSERT INTO {0} (Primaria, Descripcion, Objetivos_idObjetivos, Usuario_idUsuario, Categorias_idCategorias) VALUES (@primaria, @descripcion, @idPadre, @uid, @idCategoria)",_table);
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = sql;
                cmd.Connection = _conn;
                cmd.Parameters.AddWithValue("@primaria", 0);
                cmd.Parameters.AddWithValue("@descripcion", collection["Descripcion"].ToString());
                cmd.Parameters.AddWithValue("@idPadre", collection["IdPadre"].ToString());
                cmd.Parameters.AddWithValue("@idCategoria", collection["IdCategoria"].ToString());
                cmd.Parameters.AddWithValue("@uid", Convert.ToInt32(Session["loggedid"] as String));
                cmd.Prepare();
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


        public ActionResult Editar() {
            ViewData["Mensage"] = "Editar";
            return View();
        }

        //BBDD methods
        public List<Objetivo> GetUserObjetives(int idUser)
        {
            List<Objetivo> list = new List<Objetivo>();
            try
            {
                openConn();
                string sql = string.Format("SELECT * FROM {0} WHERE {1}=@uid", _table, "Usuario_idUsuario");
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

        public List<Objetivo> GetUserObjetives(int idUser, int idObjetivoPadre)
        {
            List<Objetivo> list = new List<Objetivo>();
            try
            {
                openConn();
                string sql = string.Format("SELECT * FROM {0} WHERE {1}=@uid AND {2}=@idPadre", _table, "Usuario_idUsuario", "Objetivos_idObjetivos");
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = sql;
                cmd.Connection = _conn;
                cmd.Parameters.AddWithValue("@uid", idUser);
                cmd.Parameters.AddWithValue("@idPadre", idObjetivoPadre);
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

        public List<Categoria> GetCategories()
        {
            List<Categoria> list = new List<Categoria>();
            try
            {
                openConn();
                string sql = string.Format("SELECT * FROM {0} WHERE {1} in (2,3,6,7,8)", "categorias", "idCategorias");
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = sql;
                cmd.Connection = _conn;
                cmd.Prepare();
                MySqlDataReader rdr = cmd.ExecuteReader();
                list = ToListModelC(rdr);
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

        public override Objetivo ToModel(MySqlDataReader rdr) {
            Objetivo o = new Objetivo();
            if (rdr.Read())
            {
                o = singleContenidoReader(rdr);
            }
            return o;
        }

        public override List<Objetivo> ToListModel(MySqlDataReader rdr) {
            List<Objetivo> list = new List<Objetivo>();
            while (rdr.Read()) {
                list.Add(singleContenidoReader(rdr));
            }
            return list;
        }

        private Objetivo singleContenidoReader(MySqlDataReader rdr)
        {
            Objetivo o = new Objetivo();
            o.Id = Int32.Parse(rdr["idObjetivos"].ToString());
            o.IdCategoria = Int32.Parse(rdr["Categorias_idCategorias"].ToString());
            o.Primaria = (rdr["Primaria"].ToString().Equals("True")) ? true : false;
            o.IdPadre = (!rdr["Objetivos_idObjetivos"].ToString().Equals("")) ? Int32.Parse(rdr["Objetivos_idObjetivos"].ToString()) : -1;
            o.Descripcion = rdr["Descripcion"].ToString();
            return o;
        }

        public List<Categoria> ToListModelC(MySqlDataReader rdr)
        {
            List<Categoria> list = new List<Categoria>();
            while (rdr.Read())
            {
                Categoria c = new Categoria();
                c.Id = Int32.Parse(rdr["idCategorias"].ToString());
                c.Nombre = rdr["Nombre"].ToString();
                c.Experiencia = Int32.Parse(rdr["Experiencia"].ToString());
                list.Add(c);
            }
            return list;
        }

    }
}