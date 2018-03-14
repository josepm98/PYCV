using MySql.Data.MySqlClient;
using PlayYourCV.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace PlayYourCV.Controllers
{
    public class LogrosController : BBDDController<Logro>
    {
        public ActionResult Index()
        {
            //update progress bar
            getUserExp(Convert.ToInt32(Session["loggedid"] as String));
            return View();
        }

        public override List<Logro> ToListModel(MySqlDataReader rdr)
        {
            throw new NotImplementedException();
        }

        public override Logro ToModel(MySqlDataReader rdr)
        {
            throw new NotImplementedException();
        }
    }
}