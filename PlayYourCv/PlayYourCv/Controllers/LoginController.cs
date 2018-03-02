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
    public class LoginController : BBDDController<Usuario>
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        // GET: Login/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

     

        // GET: Login/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Login/Edit/5
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

        // GET: Login/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Login/Delete/5
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



        // GET: Login/Create
        public ActionResult Login()
        {
            return View();
        }




        // POST: Login/Create
        [HttpPost]
        public ActionResult Index(FormCollection collection)
        {
            openConn();
            string email = collection["Email"].ToString();
            string pass = collection["Contrasenya"].ToString();
            pass = Codifica.ConverteixPassword(pass);
            try
            {
                string sql =
"SELECT * FROM usuarios WHERE Email=@email and contrasenya=@password";
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = sql;
                cmd.Connection = _conn;
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@password", pass);
                cmd.Prepare();
                MySqlDataReader rdr = cmd.ExecuteReader();
                Usuario Model = null;
                if (rdr.Read())
                {
                    int _id = 0;
                    Int32.TryParse(rdr["idUsuario"].ToString(), out _id);
                    Model = new Usuario();
                    Model.Id = Convert.ToInt32(rdr["idUsuario"]);
                    Model.Nombre = rdr["Nombre"].ToString();
                    Model.Contrasenya = rdr["contrasenya"].ToString(); ;
                    Model.Email = rdr["Email"].ToString();
                }

                rdr.Close();
                closeConn(); //método propio que cierra conexión si está abierta

                if (Model != null)
                {
                    this.HttpContext.Session.Add("logged", Model.Nombre);
                    this.HttpContext.Session.Add("loggedid", Model.Id.ToString());
                    return RedirectToAction("Index", "Home");
                }

            }
            catch (Exception ex)
            {
                closeConn(); //método propio que cierra conexión si está abierta
            }

            return View();
        }

        public override Usuario ToModel(MySqlDataReader rdr)
        {
            throw new NotImplementedException();
        }

        public override List<Usuario> ToListModel(MySqlDataReader rdr)
        {
            throw new NotImplementedException();
        }



        public ActionResult Registro()
        {
            return View();
        }

        //reb les dades del formulari via POST i crea el nou registre a users
        [HttpPost]
        public ActionResult Registro(FormCollection collection)
        {

            // primer verifiquem que email NO existeixi
            // si existeix, retornem a vista registre amb msg d'error
            // cal crear mètode: bool emailExisteix(string email)
            if (emailExisteix(collection["Email"].ToString())){
                ViewBag.ErrorMsg = "Este email ya ha sido registrado";
                return View();
            }

            try
            {
                _conn.Open();
                MySqlCommand cmd = new MySqlCommand();
                string sql =
                "INSERT INTO usuarios (Nombre, contrasenya, Email) VALUES (@nom,@password,@email)";

                string passwordVisible = collection["contrasenya"];
                string passwordCodificada =
                Codifica.ConverteixPassword(passwordVisible);

                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@nom", collection["Nombre"].ToString());
                cmd.Parameters.AddWithValue("@password", passwordCodificada);
                cmd.Parameters.AddWithValue("@email", collection["Email"].ToString());
                cmd.Connection = _conn;
                cmd.Prepare();
                cmd.ExecuteNonQuery();

                _conn.Close();
                return RedirectToAction("Index","Home");

            }
            catch (Exception e)
            {
                if (_conn.State == System.Data.ConnectionState.Open)
                {
                    _conn.Close();
                }
                return View();
            }

        }

        private bool emailExisteix(string email)
        {
            bool existeix = false;
            openConn();
          
            try
            {
                string sql = "SELECT * FROM usuarios WHERE Email=@email";
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = sql;
                cmd.Connection = _conn;
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Prepare();
                MySqlDataReader rdr = cmd.ExecuteReader();

                if (rdr.Read())
                {
                    existeix = true;
                }

                rdr.Close();
                closeConn(); //método propio que cierra conexión si está abierta

            }
            catch (Exception ex)
            {
                closeConn(); //método propio que cierra conexión si está abierta
            }

            return existeix;
        }
    }


}

