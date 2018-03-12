using MySql.Data.MySqlClient;
using PlayYourCV.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace PlayYourCV.Controllers
{
    public class CVSController : BBDDController<Contenido>
    {
        public string _idCat;
        public CVSController()
        {
            _table = "contenidos";
            _idCol = "idContenido";
        }
        public ActionResult Index()
        {
            ViewData["listaCv"] =GetCvsUser();
            return View();
        }

        [HttpPost]
        public ActionResult Index(FormCollection collection)
        {
            //create cv
            try
            {
                // TODO: Add update logic here
                openConn();
                MySqlCommand cmd = new MySqlCommand();
                string sql = string.Format("INSERT INTO cv (Titulo, Usuario_idUsuario) VALUES (@nombre, @uid)");
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@uid", Convert.ToInt32(Session["loggedid"] as String));
                cmd.Parameters.AddWithValue("@nombre", collection["Nombre"].ToString());
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
            //pass cv created
            Cv cvs = new Cv();
            try
            {
                openConn();
                string sql = string.Format("SELECT * FROM cv WHERE {0}=@uid order by idCV desc limit 1", "Usuario_idUsuario");
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = sql;
                cmd.Connection = _conn;
                cmd.Parameters.AddWithValue("@uid", Convert.ToInt32(Session["loggedid"] as String));
                cmd.Prepare();
                MySqlDataReader rdr = cmd.ExecuteReader();
                cvs = ToModelCv(rdr);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.GetBaseException().ToString());
            }
            finally
            {
                closeConn();
            }
            return Create(cvs);
        }
        public ActionResult prueba()
        {
            return View();
        }
        public ActionResult Create(Cv cvs)
        {
            int idAux = Convert.ToInt32(Session["loggedid"] as String);
            ViewData["usuario"] = getUser(idAux);
            ViewData["Contenido"] = GetContenidoUser();
            ViewData["Cv"]= cvs;
            return View("Create");
        }

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            List<Contenido> contenidos = GetContenidoUser();
            List<int> formChecks = new List<int>();
            foreach (Contenido c in contenidos)
            {
                if(collection["name"+c.Id]==null)
                {
                    formChecks.Add(Convert.ToInt32(collection["input" + c.Id].ToString()));
                }
            }
            string idCvs = collection["idCv"].ToString();
            string vals = "";
            for (int i=0;i<formChecks.Count;i++)
            {
                int catCont = -1;
                foreach (Contenido c in contenidos)
                {
                    if (c.Id== formChecks[i])
                    {
                        catCont = c.IdCategoria;
                    }
                }
                if (i==formChecks.Count-1)
                {
                    vals = string.Format("{0} ({1},{2},{3})", vals, idCvs, formChecks[i], catCont);
                }
                else
                {
                    switch (i)
                    {
                        case 0:
                            vals = string.Format("({0},{1},{2}),",idCvs, formChecks[i] ,catCont);
                            break;
                        default:
                            vals = string.Format("{0} ({1},{2},{3}),", vals, idCvs, formChecks[i],catCont);
                            break;
                    }
                }
                
            }
            try
            {
                openConn();
                string sql = string.Format("INSERT INTO cv_has_not_contenido VALUES {0}", vals);
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = sql;
                cmd.Connection = _conn;
                cmd.Prepare();
                int filas = cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            finally
            {
                closeConn();
            }
            return View("Index");
        }

        public ActionResult Edit()
        {
            ViewData["Message"] = "Edicion form.";

            return View();
        }
        public ActionResult Moduloscv()
        {
            ViewData["Message"] = "Edicion form.";

            return View();
        }

        //BBDD methods
        public Usuario getUser(int id)
        {
            Usuario u = default(Usuario);
            try
            {
                openConn();
                string sql = string.Format("SELECT * FROM {0} WHERE {1}={2}", "usuarios", "idUsuario", id);
                MySqlCommand cmd = new MySqlCommand(sql, _conn);
                MySqlDataReader rdr = cmd.ExecuteReader();
                u = ToModelU(rdr);
                rdr.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            finally
            {
                closeConn();
            }
            return u;
        }

        public Usuario ToModelU(MySqlDataReader rdr)
        {
            Usuario u = new Usuario();
            if (rdr.Read())
            {
                u.Id = Convert.ToInt32(rdr["idUsuario"]);
                u.Nombre = rdr["Nombre"].ToString();
                u.Apellido1 = rdr["Apellido1"].ToString();
                u.Apellido2 = rdr["Apellido2"].ToString();
                u.Email = rdr["Email"].ToString();
                u.FechaNacimiento = (!rdr["FechaNacimiento"].ToString().Equals("")) ? DateTime.Parse(rdr["FechaNacimiento"].ToString()) : default(DateTime);
                u.Telefono = rdr["Telefono"].ToString();
            }
            return u;
        }

        public List<Cv> GetCvsUser()
        {
            List<Cv> list = new List<Cv>();
            try
            {
                openConn();
                string sql = string.Format("SELECT * FROM {0} WHERE {1} = @uid", "cv", "Usuario_idUsuario");
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@uid", Convert.ToInt32(Session["loggedid"] as String));
                cmd.Connection = _conn;
                cmd.Prepare();
                MySqlDataReader rdr = cmd.ExecuteReader();
                list = ToListModelCv(rdr);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                closeConn();
            }
            return list;
        }

        public Cv ToModelCv(MySqlDataReader rdr)
        {
            Cv cv = new Cv();
            if (rdr.Read())
            {
                cv.Id = Convert.ToInt32(rdr["idCV"].ToString());
                cv.IdUsuario = Convert.ToInt32(rdr["Usuario_idUsuario"].ToString());
                cv.URL = rdr["URL"].ToString();
                cv.Nombre = rdr["Titulo"].ToString();
            } 
            return cv;
        }

        public List<Cv> ToListModelCv(MySqlDataReader rdr)
        {
            List<Cv> list = new List<Cv>();
            while (rdr.Read())
            {
                Cv aux = new Cv();
                aux.Id = Convert.ToInt32(rdr["idCV"].ToString());
                aux.IdUsuario = Convert.ToInt32(rdr["Usuario_idUsuario"].ToString());
                aux.URL = rdr["URL"].ToString();
                aux.Nombre = rdr["Titulo"].ToString();
                list.Add(aux);
            }
            return list;
        }

        public List<Contenido> GetContenidoUser()
        {
            List<Contenido> list = new List<Contenido>();
            try
            {
                openConn();
                string sql = string.Format("SELECT * FROM {0} WHERE {1} = @uid", _table, "idUsuario");
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@uid", Convert.ToInt32(Session["loggedid"] as String));
                cmd.Connection = _conn;
                cmd.Prepare();
                MySqlDataReader rdr = cmd.ExecuteReader();
                list = ToListModel(rdr);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
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
            List<Contenido> Lista = new List<Contenido>();
            while (rdr.Read())
            {
                Lista.Add(singleContenidoReader(rdr));
            }
            return Lista;
        }


        private Contenido singleContenidoReader(MySqlDataReader rdr)
        {
            Contenido c = new Contenido();
            c.Id = Convert.ToInt32(rdr[_idCol].ToString());
            c.IdUsuario = Convert.ToInt32(rdr["idUsuario"].ToString());
            c.IdCategoria = Convert.ToInt32(rdr["Categorias_idCategorias"].ToString());
            c.EmpresaEscuela = rdr["Empresa_Escuela"].ToString();
            c.Nombre = rdr["Nombre"].ToString();
            c.Descripcion = rdr["Descripcion"].ToString();
            c.Lugar = rdr["Lugar"].ToString();
            c.Posicion = rdr["Posicion"].ToString();
            c.FechaInicio = (!rdr["FechaInicio"].ToString().Equals("")) ? DateTime.Parse(rdr["FechaInicio"].ToString()) : default(DateTime);
            c.FechaFin = (!rdr["FechaFin"].ToString().Equals("")) ? DateTime.Parse(rdr["FechaFin"].ToString()) : default(DateTime);
            c.Hablado = rdr["Hablado"].ToString();
            c.Leido = rdr["Leido"].ToString();
            c.Escrito = rdr["Escrito"].ToString();
            c.NivelGeneral = rdr["NivelGeneral"].ToString();
            return c;
        }

    }
}