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
    public class MokyklaRepository
    {
        public List<Mokykla> getMokyklos()
        {
            List<Mokykla> kompanijaViewModels = new List<Mokykla>();

            string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mySqlConnection = new MySqlConnection(conn);
            string sqlquery = @"SELECT m.id_MOKYKLA, m.pavadinimas, m.telefonas, m.adresas, m.tinklalapis, m.el_pastas, mm.pavadinimas AS kompanijaa 
FROM mokykla m 
LEFT JOIN kompanija mm ON mm.id_KOMPANIJA=m.fk_KOMPANIJAid_KOMPANIJA";
            MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);
            mySqlConnection.Open();
            MySqlDataAdapter mda = new MySqlDataAdapter(mySqlCommand);
            DataTable dt = new DataTable();
            mda.Fill(dt);
            mySqlConnection.Close();

            foreach (DataRow item in dt.Rows)
            {
                kompanijaViewModels.Add(new Mokykla
                {
                    id = Convert.ToInt32(item["id_MOKYKLA"]),
                    pavadinimas = Convert.ToString(item["pavadinimas"]),
                    fk_kompanija = Convert.ToString(item["kompanijaa"]),
                    telefonas = Convert.ToString(item["telefonas"]),
                    el_pastas = Convert.ToString(item["el_pastas"]),
                    adresas = Convert.ToString(item["adresas"]),
                    tinklalapis = Convert.ToString(item["tinklalapis"])
                });
            }

            return kompanijaViewModels;
        }
    }
}