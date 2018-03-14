using MySql.Data.MySqlClient;
using PlayYourCV.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PlayYourCV.Controllers
{
	
    public abstract class BBDDController<T> : Controller
    {
        public static MySqlConnection _conn;
        public Object _model;
        public string _table,_idCol;

        //edit for each of us user or password
        public static string _server="127.0.0.1", _database="playyourcvdatabase", _user="root", _bbddPassword="root";

        static BBDDController()
        {
            string connStr = string.Format("Server={0};Port=3306;Database={1};Uid={2};Pwd={3};",_server,_database,_user,_bbddPassword);
            _conn = new MySqlConnection(connStr);
        }

        public abstract T ToModel(MySqlDataReader rdr);

        public abstract List<T> ToListModel(MySqlDataReader rdr);

        public ActionResult checkLogged()
        {
            if (String.IsNullOrEmpty(Session["logged"] as String))
            {
                ViewBag.UserIsLogged = false;
                ViewData["Title"] = "Home Page";
                return View("Index", "Login");//return to home
            }
            else
            {
                ViewBag.UserIsLogged = true;
                ViewBag.Logged = Session["logged"] as String;
                ViewBag.LoggedId = Session["loggedid"] as String;
                return null;
            }
        }

        public T getId(int id)
        {
            T obj = default(T);
            try
            {
                openConn();
                string sql = string.Format("SELECT * FROM {0} WHERE {1}={2}", _table, _idCol, id);
                MySqlCommand cmd = new MySqlCommand(sql, _conn);
                MySqlDataReader rdr = cmd.ExecuteReader();

                obj = ToModel(rdr);
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

        public MySqlDataReader getAll()
        {
            MySqlDataReader rdr = null;
            try
            {
                openConn();
                string sql = string.Format("SELECT * FROM {0}", _table);
                MySqlCommand cmd = new MySqlCommand(sql, _conn);
                rdr = cmd.ExecuteReader();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            finally
            {
                closeConn();
            }
            return rdr;
        }

        public void openConn()
        {
            if (_conn.State == System.Data.ConnectionState.Closed)
            {
                _conn.Open();
            }
        }

        public void closeConn()
        {
            if (_conn.State == System.Data.ConnectionState.Open)
            {
                _conn.Close();
            }
        }

        public void getUserExp(int idUser)
        {
            int exp = 0;
            List<int> list = new List<int>();
            //getExp
            try
            {
                openConn();
                string sql = string.Format("SELECT Experiencia FROM {0} WHERE {1} in SELECT Categorias_idCategorias FROM contenidos WHERE idUsuario=@uid", "categorias", "idCategorias");
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = sql;
                cmd.Connection = _conn;
                cmd.Parameters.AddWithValue("@uid", Convert.ToInt32(Session["loggedid"] as String));
                cmd.Prepare();
                MySqlDataReader rdr = cmd.ExecuteReader();
                list = ToIntList(rdr);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.GetBaseException().ToString());
            }
            finally
            {
                closeConn();
            }
            foreach (int i in list)
            {
                exp += i;
            }
            //getLvlExp and Image
            double lvlExp = 0;

            if (exp >= 15000)
            {
                lvlExp=100;
            }
            else if (exp >= 7000)
            {
                lvlExp = ((exp-7000)/8000)*100;
            }
            else if (exp >= 3000)
            {
                lvlExp = ((exp - 3000)/4000)*100;
            }
            else if (exp >= 1000)
            {
                 lvlExp=((exp-1000)/2000)*100;
            }
            else
            {
                lvlExp=(exp/1000)*100;
            }
            ViewData["lvlProgress"]= lvlExp;
        }

        public List<int> ToIntList(MySqlDataReader rdr)
        {
            List<int> list =new List<int>();
            while (rdr.Read())
            {
                list.Add(Convert.ToInt32(rdr["Experiencia"].ToString()));
            }
            return list;
        }
    }
}