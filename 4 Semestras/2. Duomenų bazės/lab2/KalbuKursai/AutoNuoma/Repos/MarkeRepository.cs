using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using AutoNuoma.Models;
using MySql.Data.MySqlClient;

namespace AutoNuoma.Repos
{
    public class MarkeRepository
    {
        public List<Marke> getMarkes()
        {
            List<Marke> markes = new List<Marke>();

            string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mySqlConnection = new MySqlConnection(conn);
            string sqlquery = @"SELECT m.id, m.pavadinimas
                                FROM "+Globals.dbPrefix+"markes m";
            MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);
            mySqlConnection.Open();
            MySqlDataAdapter mda = new MySqlDataAdapter(mySqlCommand);
            DataTable dt = new DataTable();
            mda.Fill(dt);
            mySqlConnection.Close();

            foreach (DataRow item in dt.Rows)
            {
                markes.Add(new Marke
                {
                    id = Convert.ToInt32(item["id"]),
                    pavadinimas = Convert.ToString(item["pavadinimas"]),
                });
            }

            return markes;
        }

        public Marke getMarke(int id)
        {
            Marke marke = new Marke();

            string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mySqlConnection = new MySqlConnection(conn);
            string sqlquery = @"SELECT m.id, m.pavadinimas 
                                FROM "+Globals.dbPrefix+"markes m WHERE m.id="+id;
            MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);
            mySqlConnection.Open();
            MySqlDataAdapter mda = new MySqlDataAdapter(mySqlCommand);
            DataTable dt = new DataTable();
            mda.Fill(dt);
            mySqlConnection.Close();

            foreach (DataRow item in dt.Rows)
            {

                marke.id = Convert.ToInt32(item["id"]);
                    marke.pavadinimas = Convert.ToString(item["pavadinimas"]);
            }

            return marke;
        }

        public bool updateMarke(Marke marke)
        {
            string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mySqlConnection = new MySqlConnection(conn);
            string sqlquery = @"UPDATE "+Globals.dbPrefix+"markes a SET a.pavadinimas=?pavadinimas WHERE a.id=?id";
            MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);
            mySqlCommand.Parameters.Add("?id", MySqlDbType.VarChar).Value = marke.id;
            mySqlCommand.Parameters.Add("?pavadinimas", MySqlDbType.VarChar).Value = marke.pavadinimas;
            mySqlConnection.Open();
            mySqlCommand.ExecuteNonQuery();
            mySqlConnection.Close();
            return true;
        }

        public bool addMarke(Marke marke)
        {
            string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mySqlConnection = new MySqlConnection(conn);
            string sqlquery = @"INSERT INTO "+Globals.dbPrefix+"markes(pavadinimas)VALUES(?pavadinimas)";
            MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);
            mySqlCommand.Parameters.Add("?pavadinimas", MySqlDbType.VarChar).Value = marke.pavadinimas;
            mySqlConnection.Open();
            mySqlCommand.ExecuteNonQuery();
            mySqlConnection.Close();
            return true;
        }

        public int getMarkeCount(int id)
        {
            int naudota = 0;
            string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mySqlConnection = new MySqlConnection(conn);
            string sqlquery = @"SELECT count(id) as kiekis from "+Globals.dbPrefix+"modeliai where fk_marke=" + id;
            MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);
            mySqlConnection.Open();
            MySqlDataAdapter mda = new MySqlDataAdapter(mySqlCommand);
            DataTable dt = new DataTable();
            mda.Fill(dt);
            mySqlConnection.Close();

            foreach (DataRow item in dt.Rows)
            {
                naudota = Convert.ToInt32(item["kiekis"] == DBNull.Value ? 0 : item["kiekis"]);
            }
            return naudota;
        }

        public void deleteMarke(int id)
        {
            string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mySqlConnection = new MySqlConnection(conn);
            string sqlquery = @"DELETE FROM "+Globals.dbPrefix+"markes where id=?id";
            MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);
            mySqlCommand.Parameters.Add("?id", MySqlDbType.Int32).Value = id;
            mySqlConnection.Open();
            mySqlCommand.ExecuteNonQuery();
            mySqlConnection.Close();
        }

    }
}