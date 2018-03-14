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
    public class ExperienciaController : BBDDController<Contenido>
    {
        public string _idCat;
        public ExperienciaController() : base()
        {
            _table = "contenidos";
            _idCol = "idContenido";

            _idCat = "7";
        }

        // GET: Login
        public ActionResult Index()
        {
            //TODO select all
            ViewData["Lista"] = GetExp(Convert.ToInt32(Session["loggedid"] as String));
            //update progress bar
            getUserExp(Convert.ToInt32(Session["loggedid"] as String));
            return View();
        }

        // GET: Login/Details/5
        public ActionResult Details(int id)
        {
            //update progress bar
            getUserExp(Convert.ToInt32(Session["loggedid"] as String));
            return View();
        }


        // GET: Login/Delete/5
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
            //update progress bar
            getUserExp(Convert.ToInt32(Session["loggedid"] as String));
            return View("Index");
        }

        // GET: Login/Create
        public ActionResult Create()
        {
            //update progress bar
            getUserExp(Convert.ToInt32(Session["loggedid"] as String));
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
            int categoriaid = 7;



            openConn();
            string puesto = collection["Posicion"].ToString();
            string empresa = collection["EmpresaEscuela"].ToString();
            string lugar = collection["Lugar"].ToString();
            //DateTime fechaIni = Convert.ToDateTime(collection["FechaInicio"]);
            //DateTime fechaFin = Convert.ToDateTime(collection["FechaFin"]);
            string fechaIni = collection["FechaInicio"];
            string fechaFin = collection["FechaFin"];
            string descripcion = collection["Descripcion"].ToString();

            try
            {

                string sql =
                "INSERT INTO contenidos (idUsuario, Categorias_idCategorias, Posicion,Empresa_Escuela,Lugar,FechaInicio,FechaFin,Descripcion) Values " +
                " (@userid,@categoriaid,@puesto,@empresa,@lugar,@fechaIni,@fechaFin,@descripcion)";

                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = sql;
                cmd.Connection = _conn;
                cmd.Parameters.AddWithValue("@userid", userid);
                cmd.Parameters.AddWithValue("@categoriaid", categoriaid);
                cmd.Parameters.AddWithValue("@puesto", puesto);
                cmd.Parameters.AddWithValue("@empresa", empresa);
                cmd.Parameters.AddWithValue("@lugar", lugar);
                cmd.Parameters.AddWithValue("@fechaIni", fechaIni);
                cmd.Parameters.AddWithValue("@fechaFin", fechaFin);
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

        public ActionResult Edit(int id)
        {
            Contenido model = this.getId(id);
            //update progress bar
            getUserExp(Convert.ToInt32(Session["loggedid"] as String));
            return View(model);
        }

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
                string puesto = collection["Posicion"].ToString();
                string empresa = collection["EmpresaEscuela"].ToString();
                string lugar = collection["Lugar"].ToString();

                // string fechaIni = collection["FechaInicio"];
                // string fechaFin = collection["FechaFin"];
                DateTime fechaIni = Convert.ToDateTime(collection["FechaInicio"]);
                DateTime fechaFin = Convert.ToDateTime(collection["FechaFin"]);
                string descripcion = collection["Descripcion"].ToString();

                string sql = "UPDATE contenidos SET Posicion=@puesto,Empresa_Escuela=@empresa," +
                    "Lugar=@lugar,FechaInicio=@fechaIni,FechaFin=@fechaFin,Descripcion=@descripcion WHERE idContenido=@contenidoid";

                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = sql;
                cmd.Connection = _conn;
                cmd.Parameters.AddWithValue("@contenidoid", contenidoid);
                cmd.Parameters.AddWithValue("@puesto", puesto);
                cmd.Parameters.AddWithValue("@empresa", empresa);
                cmd.Parameters.AddWithValue("@lugar", lugar);
                cmd.Parameters.AddWithValue("@fechaIni", fechaIni);
                cmd.Parameters.AddWithValue("@fechaFin", fechaFin);
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

        public override Contenido ToModel(MySqlDataReader rdr)
        {
            Contenido c = new Contenido();
            if (rdr.Read())
            {
                c.Id = Convert.ToInt32(rdr["idContenido"]);
                c.EmpresaEscuela = rdr["Empresa_Escuela"].ToString();
                c.Posicion = rdr["Posicion"].ToString();
                c.Lugar = rdr["Lugar"].ToString();
                c.FechaInicio = (!rdr["FechaInicio"].ToString().Equals("")) ? DateTime.Parse(rdr["FechaInicio"].ToString()) : default(DateTime);
                c.FechaFin = (!rdr["FechaFin"].ToString().Equals("")) ? DateTime.Parse(rdr["FechaFin"].ToString()) : default(DateTime);
                /*c.FechaInicio = (!rdr["FechaInicio"].ToString().Equals("")) ? Convert.ToDateTime(rdr["FechaInicio"]) : default(DateTime);
                c.FechaFin = (!rdr["FechaFin"].ToString().Equals("")) ? Convert.ToDateTime(rdr["FechaFin"]) : default(DateTime);*/
                c.Descripcion = rdr["Descripcion"].ToString();

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
                c.EmpresaEscuela = rdr["Empresa_Escuela"].ToString();
                c.Posicion = rdr["Posicion"].ToString();
                c.Lugar = rdr["Lugar"].ToString();
                c.FechaInicio = (!rdr["FechaInicio"].ToString().Equals("")) ? DateTime.Parse(rdr["FechaInicio"].ToString()) : default(DateTime);
                c.FechaFin = (!rdr["FechaFin"].ToString().Equals("")) ? DateTime.Parse(rdr["FechaFin"].ToString()) : default(DateTime);
                /*c.FechaInicio = (!rdr["FechaInicio"].ToString().Equals("")) ? Convert.ToDateTime(rdr["FechaInicio"]) : default(DateTime);
                c.FechaFin = (!rdr["FechaFin"].ToString().Equals("")) ? Convert.ToDateTime(rdr["FechaFin"]) : default(DateTime);*/
                c.Descripcion = rdr["Descripcion"].ToString();
                Lista.Add(c);

            }
            return Lista;
        }

        public List<Contenido> GetExp(int idUser)
        {
            List<Contenido> list = new List<Contenido>();
            try
            {
                openConn();
                string sql = string.Format("SELECT * FROM contenidos WHERE idUsuario=@uid AND Categorias_idCategorias=7");
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