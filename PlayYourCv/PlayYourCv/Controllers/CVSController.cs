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

            return View();
        }
        public ActionResult prueba()
        {
            return View();
        }
        public ActionResult Create()
        {
            int idAux = Convert.ToInt32(Session["loggedid"] as String);
            ViewData["usuario"] = getUser(idAux);

            ExperienciaController expc = new ExperienciaController();
            ViewData["lista"] = expc.GetExp(idAux);
            IdiomasController idio = new IdiomasController();
            ViewData["listaIdiomas"] = idio.GetUserLanguages(idAux);
            EducacionController edu = new EducacionController();
            ViewData["listaEducacion2"] = edu.GetUserCourses(idAux);
            PresentacionController pres = new PresentacionController();
            //ViewData["listapre"] = pres.GetPre(idAux);


            // Usuario u = getUser(idAux);
            return View();
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
        public Usuario getUser(int id)
        {
            Usuario obj = default(Usuario);
            try
            {
                openConn();
                string sql = string.Format("SELECT * FROM {0} WHERE {1}={2}", "usuarios", "idUsuario", id);
                MySqlCommand cmd = new MySqlCommand(sql, _conn);
                MySqlDataReader rdr = cmd.ExecuteReader();

                obj = ToModelU(rdr);
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
            return obj;
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
                c.Descripcion = rdr["Descripcion"].ToString();
                Lista.Add(c);

            }
            return Lista;
        }


        private Contenido singleContenidoReader(MySqlDataReader rdr)
        {
            Contenido c = new Contenido();
            c.Id = Convert.ToInt32(rdr[_idCol].ToString());
            c.IdUsuario = Convert.ToInt32(Session["loggedid"] as String);
            c.IdCategoria = Convert.ToInt32(rdr["Categorias_idCategorias"] as String);
            c.EmpresaEscuela = rdr["EmpresaEscuela"].ToString();
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