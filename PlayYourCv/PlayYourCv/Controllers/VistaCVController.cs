using MySql.Data.MySqlClient;
using PlayYourCV.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PlayYourCV.Controllers
{
    public class VistaCVController : BBDDController<Contenido>
    {
        public VistaCVController()
        {
            _idCol = "idContenido";
            _table = "contenidos";
        }
        // GET: VistaCV
        public ActionResult Index(int id)
        {
            ViewData["listaContenidos"] = GetContentFromCv(id);
            ViewData["UsuarioContenido"] = GetUserData(Convert.ToInt32(Session["loggedid"] as String));
            return View();
        }

        //BBDD methods
        public Usuario GetUserData(int id)
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
                u.FotoURL = rdr["fotoURL"].ToString();
            }
            return u;
        }

        //categorias
        public List<Categoria> GetCategoriasUser()
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
       
        //contenido
        public List<Contenido> GetContentFromCv(int id)
        {
            List<Contenido> list = new List<Contenido>();
            try
            {
                openConn();
                string sql = string.Format("SELECT * FROM contenidos WHERE Categorias_idCategorias in (Select Categorias_idCategorias from cv_has_categorias WHERE CV_idCV={0}) and idContenido not in (Select Contenido_idContenido from cv_has_not_contenido WHERE CV_idCV={0})",id);
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = sql;
                cmd.Connection = _conn;
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

        public override List<Contenido> ToListModel(MySqlDataReader rdr)
        {
            List<Contenido> list = new List<Contenido>();
            while (rdr.Read())
            {
                list.Add(singleContenidoReader(rdr));
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