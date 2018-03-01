using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using MySql.Data.MySqlClient;
using PlayYourCv.Models;
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
            ViewData["Mensage"] = "Create";
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