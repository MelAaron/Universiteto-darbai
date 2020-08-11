using AutoNuoma.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using AutoNuoma.ViewModels;
using System.Linq;
using System.Web;

namespace AutoNuoma.Repos
{
    public class MiestasRepository
    {
        public List<MiestasEditViewModel> getMiestai()
        {
            List<MiestasEditViewModel> miestai = new List<MiestasEditViewModel>();
            string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mySqlConnection = new MySqlConnection(conn);
            string sqlquery = "select m.id_MIESTAS, m.pavadinimas, m.salis from miestas m";
            MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);
            mySqlConnection.Open();
            MySqlDataAdapter mda = new MySqlDataAdapter(mySqlCommand);
            DataTable dt = new DataTable();
            mda.Fill(dt);
            mySqlConnection.Close();

            foreach (DataRow item in dt.Rows)
            {
                miestai.Add(new MiestasEditViewModel
                {
                    id = Convert.ToInt32(item["id_MIESTAS"]),
                    pavadinimas = Convert.ToString(item["pavadinimas"]),
                    salis = Convert.ToString(item["salis"])
                });
            }
            return miestai;
        }
        public MiestasEditViewModel getMiestas(int id)
        {
            MiestasEditViewModel miestas = new MiestasEditViewModel();

            string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mySqlConnection = new MySqlConnection(conn);
            string sqlquery = @"SELECT m.id_MIESTAS, m.pavadinimas, m.salis from miestas m WHERE m.id_MIESTAS=" + id;
            MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);
            mySqlConnection.Open();
            MySqlDataAdapter mda = new MySqlDataAdapter(mySqlCommand);
            DataTable dt = new DataTable();
            mda.Fill(dt);
            mySqlConnection.Close();

            foreach (DataRow item in dt.Rows)
            {
                miestas.id = Convert.ToInt32(item["id_MIESTAS"]);
                miestas.pavadinimas = Convert.ToString(item["pavadinimas"]);
                miestas.salis = Convert.ToString(item["salis"]);
            }

            return miestas;
        }
        public int getMiestasCount(int id)
        {
            int naudota = 0;
            string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mySqlConnection = new MySqlConnection(conn);
            string sqlquery = @"SELECT count(id_KOMPANIJA) as kiekis from kompanija where fk_MIESTASid_MIESTAS=" + id;
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

        public bool updateMiestas(MiestasEditViewModel miestas)
        {
            try
            {
                string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
                MySqlConnection mySqlConnection = new MySqlConnection(conn);
                string sqlquery = @"UPDATE miestas a SET a.pavadinimas=?pavadinimas, a.salis=?salis WHERE a.id_MIESTAS=?id";
                MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);
                mySqlCommand.Parameters.Add("?id", MySqlDbType.Int32).Value = miestas.id;
                mySqlCommand.Parameters.Add("?pavadinimas", MySqlDbType.VarChar).Value = miestas.pavadinimas;
                mySqlCommand.Parameters.Add("?salis", MySqlDbType.VarChar).Value = miestas.salis;
                mySqlConnection.Open();
                mySqlCommand.ExecuteNonQuery();
                mySqlConnection.Close();
                return true;

            }
            catch (Exception)
            {
                return false;
            }

        }

        public bool addMiestas(MiestasEditViewModel miestas)
        {
            string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mySqlConnection = new MySqlConnection(conn);
            string sqlquery = @"INSERT INTO miestas(pavadinimas,salis,id_MIESTAS)VALUES(?pavadinimas,?salis,?id)"; 
            MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);
            mySqlCommand.Parameters.Add("?pavadinimas", MySqlDbType.VarChar).Value = miestas.pavadinimas;
            mySqlCommand.Parameters.Add("?salis", MySqlDbType.VarChar).Value = miestas.salis;
            mySqlCommand.Parameters.Add("?id", MySqlDbType.Int32).Value = miestas.id;
            mySqlConnection.Open();
            mySqlCommand.ExecuteNonQuery();
            mySqlConnection.Close();
            return true;
        }

        //public int getMiestasCount(int id)
        //{
        //    int naudota = 0;
        //    string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
        //    MySqlConnection mySqlConnection = new MySqlConnection(conn);
        //    string sqlquery = @"SELECT count(id) as kiekis from " + Globals.dbPrefix + "automobiliai where fk_modelis=" + id;
        //    MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);
        //    mySqlConnection.Open();
        //    MySqlDataAdapter mda = new MySqlDataAdapter(mySqlCommand);
        //    DataTable dt = new DataTable();
        //    mda.Fill(dt);
        //    mySqlConnection.Close();

        //    foreach (DataRow item in dt.Rows)
        //    {
        //        naudota = Convert.ToInt32(item["kiekis"] == DBNull.Value ? 0 : item["kiekis"]);
        //    }
        //    return naudota;
        //}

        public void deleteMiestas(int id)
        {
            string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mySqlConnection = new MySqlConnection(conn);
            string sqlquery = @"DELETE FROM miestas where id_MIESTAS=" + id;
            MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);
            //mySqlCommand.Parameters.Add("?id", MySqlDbType.Int32).Value = id;
            mySqlConnection.Open();
            mySqlCommand.ExecuteNonQuery();
            mySqlConnection.Close();
        }
        //public bool add(Miestas miestas)
        //{
        //    string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
        //    MySqlConnection mySqlConnection = new MySqlConnection(conn);
        //    string sqlquery = "select * from miestai";
        //    MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);
        //    mySqlConnection.Open();
        //    MySqlDataAdapter mda = new MySqlDataAdapter(mySqlCommand);
        //    DataTable dt = new DataTable();
        //    mda.Fill(dt);
        //    mySqlConnection.Close();

        //    return true;
        //}
    }
}