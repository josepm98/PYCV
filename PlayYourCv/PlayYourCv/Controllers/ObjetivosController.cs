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
            int userid = -1;

            if (String.IsNullOrEmpty(Session["loggedId"] as String)) {
                return View();
            }

            userid = Convert.ToInt32(Session["loggedid"] as String);

            ViewData["listaObjetivos"] = GetObj(userid);
            return View();
        }

        public ActionResult Editar(FormCollection collection) {
            int userid = -1;
            string descripcion = string.Format("{0}", Request.Form["elform"]);

            if (String.IsNullOrEmpty(Session["loggedId"] as String)) {
                return View();
            }

            userid = Convert.ToInt32(Session["loggedid"] as String);

            ViewData["listaObjetivos"] = SetObj(userid, collection);
            return RedirectToAction("Index");
        }

        public Objetivo GetObj(int idUser) {
            Objetivo obj = new Objetivo();
            try {
                openConn();
                string sql = string.Format("SELECT * FROM objetivos WHERE Usuario_idUsuario=@uid");
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = sql;
                cmd.Connection = _conn;
                cmd.Parameters.AddWithValue("@uid", idUser);
                cmd.Prepare();
                MySqlDataReader rdr = cmd.ExecuteReader();
                obj = ToModel(rdr);
            }
            catch (Exception e) {
                Console.WriteLine(e.GetBaseException().ToString());
            }
            finally {
                closeConn();
            }
            return obj;
        }

        [HttpPost, ValidateInput(false)]
        public Objetivo SetObj(int idUser, FormCollection collection) {
            Objetivo obj = new Objetivo();
            try {
                openConn();
                string sql = string.Format("UPDATE objetivos SET Descripcion = @descripcion WHERE Usuario_idUsuario=@uid");
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = sql;
                cmd.Connection = _conn;
                cmd.Parameters.AddWithValue("@uid", idUser);
                cmd.Parameters.AddWithValue("@descripcion", collection["__llista"].ToString());
                cmd.Prepare();
                MySqlDataReader rdr = cmd.ExecuteReader();
                obj = ToModel(rdr);
            }
            catch (Exception e) {
                Console.WriteLine(e.GetBaseException().ToString());
            }
            finally {
                closeConn();
            }
            return obj;

        }


        public override Objetivo ToModel(MySqlDataReader rdr) {
            Objetivo objetivo = new Objetivo();
            if (rdr.Read()) {
                objetivo.Id = Int32.Parse(rdr["idObjetivos"].ToString());
                objetivo.Descripcion = rdr["Descripcion"].ToString();
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
                list.Add(objetivo);
            }
            return list;
        }

        


    }
}