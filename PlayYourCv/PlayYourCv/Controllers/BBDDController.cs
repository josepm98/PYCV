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
        public string _table;
        //edit for each of us user or password
        public static string _server="127.0.0.1", _database="playyourcvdatabase", _user="root", _bbddPassword="root";

        static BBDDController()
        {
            string connStr = string.Format("Server={0};Port=3306;Database={1};Uid={2};Pwd={3};",_server,_database,_user,_bbddPassword);
            _conn = new MySqlConnection(connStr);
        }

        public abstract T ToModel(MySqlDataReader rdr);

        public abstract List<T> ToListModel(MySqlDataReader rdr);

        public T getId(int id)
        {
            T obj = default(T);
            openConn();
            try
            {
                string sql = string.Format("SELECT * FROM {0} WHERE id={1}", _table, id);
                MySqlCommand cmd = new MySqlCommand(sql, _conn);
                MySqlDataReader rdr = cmd.ExecuteReader();

                obj = ToModel(rdr);
                rdr.Close();
                closeConn();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                closeConn();
            }
            return obj;
        }

        public MySqlDataReader getAll()
        {
            _conn.Open();
            MySqlDataReader rdr = null;
            try
            {
                string sql = string.Format("SELECT * FROM {0}", _table);
                MySqlCommand cmd = new MySqlCommand(sql, _conn);
                rdr = cmd.ExecuteReader();
                _conn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                _conn.Close();
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

        
    }
}