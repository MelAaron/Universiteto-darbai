using AutoNuoma.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;

namespace AutoNuoma.Repos
{
    public class MokinysRepository
    {
        public List<Mokinys> getMokiniai()
        {
            List<Mokinys> kompanijaViewModels = new List<Mokinys>();

            string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mySqlConnection = new MySqlConnection(conn);
            string sqlquery = @"SELECT *
                                FROM mokinys";
            MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);
            mySqlConnection.Open();
            MySqlDataAdapter mda = new MySqlDataAdapter(mySqlCommand);
            DataTable dt = new DataTable();
            mda.Fill(dt);
            mySqlConnection.Close();

            foreach (DataRow item in dt.Rows)
            {
                kompanijaViewModels.Add(new Mokinys
                {
                    vardas = Convert.ToString(item["vardas"]),
                    pavarde = Convert.ToString(item["pavarde"]),
                    gimimo_data = Convert.ToDateTime(item["gimimo_data"]),
                    asmens_kodas = Convert.ToString(item["asmens_kodas"]),
                    telefonas = Convert.ToString(item["telefonas"]),
                    el_pastas = Convert.ToString(item["el_pastas"]),
                    adresas = Convert.ToString(item["adresas"]),
                    lytis = Convert.ToString(item["lytis"])
                });
            }

            return kompanijaViewModels;
        }
    }
}