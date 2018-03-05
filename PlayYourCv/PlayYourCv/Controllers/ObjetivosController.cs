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
            ViewData["listaObjetivos"] = select();
            return View();
        }

        public ActionResult Create() {
            
            return View();
        }

        // POST: Login/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection) {

            if (String.IsNullOrEmpty(Session["loggedId"] as String)) {
                return View();
            }

            int userid = Convert.ToInt32(Session["loggedid"] as String);
            int categoriaid = 5;

            openConn();
            string idObjetivos = collection["Id"].ToString();
            string primaria = collection["Primaria"].ToString();
            string descripcion = collection["Descripcion"].ToString();
            string idPadre = collection["IdPadre"].ToString();
            string idCategoria = collection["IdCategoria"].ToString();
            
            try {

                string sql =
                "INSERT INTO objetivos (idObjetivos, Primaria, Descripcion, Objetivos_idObjetivos, Usuario_idUsuario, Categorias_idCategorias) Values " +
                " (@idObjetivos,@primaria,@descripcion,@idPadre,@userid,1)";

                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = sql;
                cmd.Connection = _conn;
                cmd.Parameters.AddWithValue("@idObjetivos", idObjetivos);
                cmd.Parameters.AddWithValue("@primaria", primaria);
                cmd.Parameters.AddWithValue("@descripcion", descripcion);
                cmd.Parameters.AddWithValue("@idPadre", idPadre);
                cmd.Parameters.AddWithValue("@userid", userid);
                cmd.Parameters.AddWithValue("@idCategoria", idCategoria);


                cmd.Prepare();
                int filas = cmd.ExecuteNonQuery();

                closeConn(); //método propio que cierra conexión si está abierta
                return RedirectToAction("Index");

            }
            catch (Exception ex) {
                closeConn(); //método propio que cierra conexión si está abierta
            }

            return View();
        }


        public ActionResult Editar() {
            ViewData["Mensage"] = "Editar";
            return View();
        }

        public override Objetivo ToModel(MySqlDataReader rdr) {
            Objetivo objetivo = new Objetivo();
            if (rdr.Read()) {
                objetivo.Id=Int32.Parse(rdr["idObjetivos"].ToString());
                objetivo.Descripcion = rdr["Descripcion"].ToString();
                objetivo.Primaria = (rdr["Primaria"].ToString().Equals("True")) ?true:false;
                objetivo.IdPadre = (!rdr["Objetivos_idObjetivos"].ToString().Equals("")) ?Int32.Parse(rdr["Objetivos_idObjetivos"].ToString()):-1;
            }
            return objetivo;
        }

        public override List<Objetivo> ToListModel(MySqlDataReader rdr) {
            List<Objetivo> list = new List<Objetivo>();
            while (rdr.Read()) {
                Objetivo objetivo = new Objetivo();
                objetivo.Id = Int32.Parse(rdr["idObjetivos"].ToString());
                objetivo.Descripcion = rdr["Descripcion"].ToString();
                string aux = rdr["Primaria"].ToString();
                objetivo.Primaria = (rdr["Primaria"].ToString().Equals("True")) ? true : false;
                objetivo.IdPadre = (! rdr["Objetivos_idObjetivos"].ToString().Equals("")) ? Int32.Parse(rdr["Objetivos_idObjetivos"].ToString()) : -1;
                list.Add(objetivo);
            }
            return list;
        }

        public List<Objetivo> select() {
            List<Objetivo> infoObjetivos = new List<Objetivo>();
            if (_conn.State == System.Data.ConnectionState.Closed) {
                _conn.Open();
            }

            // You sql command
            MySqlCommand selectData;

            // Create the sql command
            selectData = _conn.CreateCommand();

            // Declare the sript of sql command
            selectData.CommandText = string.Format("SELECT * from {0} where Usuario_idUsuario = 1", _table);

            // Declare a reader, through which we will read the data.
            MySqlDataReader rdr = selectData.ExecuteReader();

            // Read the data
            infoObjetivos = ToListModel(rdr);

            rdr.Close();
            if (_conn.State == System.Data.ConnectionState.Open) {
                _conn.Close();
            }

            return infoObjetivos;
        }

    }
}