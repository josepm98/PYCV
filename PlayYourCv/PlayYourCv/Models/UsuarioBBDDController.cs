using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using PlayYourCV.Models;

namespace PlayYourCv.Models
{
    public class UsuarioBBDDController : BBDDController<Usuario>
    {
        public UsuarioBBDDController()
        {
            _table = "Usuarios";
        }

        public override List<Usuario> ToListModel(MySqlDataReader rdr)
        {
            List<Usuario> list = new List<Usuario>();
            while (rdr.Read())
            {

            }
            return list;
        }

        public override Usuario ToModel(MySqlDataReader rdr)
        {
            Usuario usuario = new Usuario();
            while (rdr.Read())
            {

            }
            return usuario;
        }
    }
}