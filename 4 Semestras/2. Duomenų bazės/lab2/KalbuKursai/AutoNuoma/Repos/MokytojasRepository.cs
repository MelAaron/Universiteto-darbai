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
    public class MokytojasRepository
    {
        public List<Mokytojas> getMokytojai()
        {
            List<Mokytojas> kompanijaViewModels = new List<Mokytojas>();

            string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mySqlConnection = new MySqlConnection(conn);
            string sqlquery = @"SELECT m.vardas, m.pavarde, m.amzius, m.lytis, m.asmens_kodas, m.specializacija, mm.pavadinimas AS mokyklaa 
                                FROM mokytojas m
                                LEFT JOIN mokykla mm ON mm.id_MOKYKLA=m.fk_MOKYKLAid_MOKYKLA";
            MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);
            mySqlConnection.Open();
            MySqlDataAdapter mda = new MySqlDataAdapter(mySqlCommand);
            DataTable dt = new DataTable();
            mda.Fill(dt);
            mySqlConnection.Close();

            foreach (DataRow item in dt.Rows)
            {
                kompanijaViewModels.Add(new Mokytojas
                {
                    vardas = Convert.ToString(item["vardas"]),
                    pavarde = Convert.ToString(item["pavarde"]),
                    amzius = Convert.ToInt32(item["amzius"]),
                    asmens_kodas = Convert.ToString(item["asmens_kodas"]),
                    specializacija = Convert.ToString(item["specializacija"]),
                    lytis = Convert.ToString(item["lytis"]),
                    mokykla = Convert.ToString(item["mokyklaa"])

                });
            }

            return kompanijaViewModels;
        }
    }
}