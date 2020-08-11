using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoNuoma.ViewModels;
using AutoNuoma.Models;
using System.Configuration;
using MySql.Data.MySqlClient;
using System.Data;

namespace AutoNuoma.Repos
{
    public class SutartisRepository
    {
        public List<SutartisEditViewModel> getSutartys()
        {
            List<SutartisEditViewModel> sutartys = new List<SutartisEditViewModel>();
            string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mySqlConnection = new MySqlConnection(conn);
            string sqlquery = @"SELECT s.nr, s.sutarties_data, s.pradzios_data, s.busena, m.pavadinimas AS mokyklaa, CONCAT(mm.vardas,' ',mm.pavarde) AS mokinyss
                                FROM sutartis s, mokykla m, mokinys mm
                                WHERE s.fk_MOKYKLAid_MOKYKLA=m.id_MOKYKLA and s.fk_MOKINYSasmens_kodas=mm.asmens_kodas";
            MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);
            mySqlConnection.Open();
            MySqlDataAdapter mda = new MySqlDataAdapter(mySqlCommand);
            DataTable dt = new DataTable();
            mda.Fill(dt);
            mySqlConnection.Close();

            foreach (DataRow item in dt.Rows)
            {
                sutartys.Add(new SutartisEditViewModel
                {
                    nr = Convert.ToInt32(item["nr"]),
                    sutarties_data = Convert.ToDateTime(item["sutarties_data"]),
                    pradzios_data = Convert.ToDateTime(item["pradzios_data"]),
                    busena = Convert.ToString(item["busena"]),
                    fk_mokykla = Convert.ToString(item["mokyklaa"]),
                    fk_mokinys = Convert.ToString(item["mokinyss"])
                });
            }
            return sutartys;
        }

        public SutartisEditViewModel getSutartis(int nr)
        {
            SutartisEditViewModel sutartis = new SutartisEditViewModel();
            string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mySqlConnection = new MySqlConnection(conn);
            string sqlquery = @"SELECT * FROM sutartis where nr="+nr;
            MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);
            mySqlConnection.Open();
            MySqlDataAdapter mda = new MySqlDataAdapter(mySqlCommand);
            DataTable dt = new DataTable();
            mda.Fill(dt);
            mySqlConnection.Close();

            foreach (DataRow item in dt.Rows)
            {
                sutartis.nr = Convert.ToInt32(item["nr"]);
                sutartis.sutarties_data = Convert.ToDateTime(item["sutarties_data"]);
                sutartis.pradzios_data = Convert.ToDateTime(item["pradzios_data"]);
                sutartis.busena = Convert.ToString(item["busena"]);
                sutartis.fk_mokykla = Convert.ToString(item["fk_MOKYKLAid_MOKYKLA"]);
                sutartis.fk_mokinys = Convert.ToString(item["fk_MOKINYSasmens_kodas"]);
            }

            return sutartis;
        }

        public bool updateSutartis(SutartisEditViewModel sutartis)
        {
            string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mySqlConnection = new MySqlConnection(conn);
            string sqlquery = @"UPDATE `sutartis` SET
                                    `sutarties_data` = ?sutdata,
                                    `pradzios_data` = ?praddata,
                                    `busena` = ?busena,
                                    `fk_MOKYKLAid_MOKYKLA` = ?fk_mokykla,
                                    `fk_MOKINYSasmens_kodas` = ?fk_mokinys
                                    WHERE nr=" + sutartis.nr;
            MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);
            mySqlCommand.Parameters.Add("?sutdata", MySqlDbType.Date).Value = sutartis.sutarties_data.ToString("yyyy-MM-dd hh:mm:ss");
            mySqlCommand.Parameters.Add("?praddata", MySqlDbType.Date).Value = sutartis.pradzios_data.ToString("yyyy-MM-dd hh:mm:ss");
            mySqlCommand.Parameters.Add("?busena", MySqlDbType.VarChar).Value = sutartis.busena;
            mySqlCommand.Parameters.Add("?fk_mokykla", MySqlDbType.VarChar).Value = sutartis.fk_mokykla;
            mySqlCommand.Parameters.Add("?fk_mokinys", MySqlDbType.VarChar).Value = sutartis.fk_mokinys;
            mySqlConnection.Open();
            mySqlCommand.ExecuteNonQuery();
            mySqlConnection.Close();

            return true;
        }

        public bool addSutartis(SutartisEditViewModel sutartis)
        {
            string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mySqlConnection = new MySqlConnection(conn);
            string sqlquery = @"INSERT INTO sutartis (
                                    `nr`,
                                    `sutarties_data`,
                                    `pradzios_data`,
                                    `busena`,
                                    `fk_MOKYKLAid_MOKYKLA`,
                                    `fk_MOKINYSasmens_kodas`)
                                    VALUES(
                                     ?nr,
                                     ?sutarties_data,
                                     ?pradzios_data,
                                     ?busena,
                                     ?fk_mokykla,
                                     ?fk_mokinys)";
            MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);
            mySqlCommand.Parameters.Add("?nr", MySqlDbType.Int32).Value = getMaxId()+1;
            mySqlCommand.Parameters.Add("?sutarties_data", MySqlDbType.DateTime).Value = sutartis.sutarties_data.ToString("yyyy-MM-dd hh:mm:ss");
            mySqlCommand.Parameters.Add("?pradzios_data", MySqlDbType.DateTime).Value = sutartis.pradzios_data.ToString("yyyy-MM-dd hh:mm:ss");
            mySqlCommand.Parameters.Add("?busena", MySqlDbType.VarChar).Value = sutartis.busena;
            mySqlCommand.Parameters.Add("?fk_mokykla", MySqlDbType.VarChar).Value = sutartis.fk_mokykla;
            mySqlCommand.Parameters.Add("?fk_mokinys", MySqlDbType.VarChar).Value = sutartis.fk_mokinys;
            mySqlConnection.Open();
            mySqlCommand.ExecuteNonQuery();
            mySqlConnection.Close();

            return true;
        }

        public void deleteSutartis(int id)
        {
            string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mySqlConnection = new MySqlConnection(conn);
            string sqlquery = @"DELETE FROM sutartis where nr=?id";
            MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);
            mySqlCommand.Parameters.Add("?id", MySqlDbType.Int32).Value = id;
            mySqlConnection.Open();
            mySqlCommand.ExecuteNonQuery();
            mySqlConnection.Close();
        }
        public int getMaxId()
        {
            int naudota = 0;
            string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mySqlConnection = new MySqlConnection(conn);
            string sqlquery = @"SELECT MAX(nr) as max FROM sutartis";
            MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);
            mySqlConnection.Open();
            MySqlDataAdapter mda = new MySqlDataAdapter(mySqlCommand);
            DataTable dt = new DataTable();
            mda.Fill(dt);
            mySqlConnection.Close();

            foreach (DataRow item in dt.Rows)
            {
                naudota = Convert.ToInt32(item["max"] == DBNull.Value ? 0 : item["max"]);
            }
            return naudota;
        }
    }
}