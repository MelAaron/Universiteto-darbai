using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using AutoNuoma.ViewModels;
using MySql.Data.MySqlClient;

namespace AutoNuoma.Repos
{
    public class ModeliuRepository
    {
        public List<ModelisViewModel> getModeliai()
        {
            List<ModelisViewModel> modelisViewModels = new List<ModelisViewModel>();

            string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mySqlConnection = new MySqlConnection(conn);
            string sqlquery = @"SELECT m.id, m.pavadinimas, mm.pavadinimas AS marke 
                                FROM "+Globals.dbPrefix+@"modeliai m
                                LEFT JOIN "+Globals.dbPrefix+@"markes mm ON mm.id=m.fk_marke";
            MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);
            mySqlConnection.Open();
            MySqlDataAdapter mda = new MySqlDataAdapter(mySqlCommand);
            DataTable dt = new DataTable();
            mda.Fill(dt);
            mySqlConnection.Close();

            foreach (DataRow item in dt.Rows)
            {
                modelisViewModels.Add(new ModelisViewModel
                {
                    id = Convert.ToInt32(item["id"]),
                    pavadinimas = Convert.ToString(item["pavadinimas"]),
                    marke = Convert.ToString(item["marke"])
                });
            }

            return modelisViewModels;
        }

        public ModelisEditViewModel getModelis(int id)
        {
            ModelisEditViewModel modelis = new ModelisEditViewModel();

            string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mySqlConnection = new MySqlConnection(conn);
            string sqlquery = @"SELECT m.* 
                                FROM "+Globals.dbPrefix+@"modeliai m WHERE m.id=" + id;
            MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);
            mySqlConnection.Open();
            MySqlDataAdapter mda = new MySqlDataAdapter(mySqlCommand);
            DataTable dt = new DataTable();
            mda.Fill(dt);
            mySqlConnection.Close();

            foreach (DataRow item in dt.Rows)
            {
                modelis.id = Convert.ToInt32(item["id"]);
                modelis.pavadinimas = Convert.ToString(item["pavadinimas"]);
                modelis.fk_marke = Convert.ToInt32(item["fk_marke"]);
            }

            return modelis;
        }

        public bool updateModelis(ModelisEditViewModel modelis)
        {
            string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mySqlConnection = new MySqlConnection(conn);
            string sqlquery = @"UPDATE "+Globals.dbPrefix+"modeliai a SET a.pavadinimas=?pavadinimas, a.fk_marke=?marke WHERE a.id=?id";
            MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);
            mySqlCommand.Parameters.Add("?id", MySqlDbType.VarChar).Value = modelis.id;
            mySqlCommand.Parameters.Add("?pavadinimas", MySqlDbType.VarChar).Value = modelis.pavadinimas;
            mySqlCommand.Parameters.Add("?marke", MySqlDbType.VarChar).Value = modelis.fk_marke;
            mySqlConnection.Open();
            mySqlCommand.ExecuteNonQuery();
            mySqlConnection.Close();
            return true;
        }

        public bool addModelis(ModelisEditViewModel modelis)
        {
            string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mySqlConnection = new MySqlConnection(conn);
            string sqlquery = @"INSERT INTO "+Globals.dbPrefix+"modeliai(pavadinimas,fk_marke)VALUES(?pavadinimas,?marke)";
            MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);
            mySqlCommand.Parameters.Add("?pavadinimas", MySqlDbType.VarChar).Value = modelis.pavadinimas;
            mySqlCommand.Parameters.Add("?marke", MySqlDbType.VarChar).Value = modelis.fk_marke;
            mySqlConnection.Open();
            mySqlCommand.ExecuteNonQuery();
            mySqlConnection.Close();
            return true;
        }

        public int getModelisCount(int id)
        {
            int naudota = 0;
            string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mySqlConnection = new MySqlConnection(conn);
            string sqlquery = @"SELECT count(id) as kiekis from "+Globals.dbPrefix+"automobiliai where fk_modelis=" + id;
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

        public void deleteModelis(int id)
        {
            string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mySqlConnection = new MySqlConnection(conn);
            string sqlquery = @"DELETE FROM "+Globals.dbPrefix+"modeliai where id=?id";
            MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);
            mySqlCommand.Parameters.Add("?id", MySqlDbType.Int32).Value = id;
            mySqlConnection.Open();
            mySqlCommand.ExecuteNonQuery();
            mySqlConnection.Close();
        }


    }
}