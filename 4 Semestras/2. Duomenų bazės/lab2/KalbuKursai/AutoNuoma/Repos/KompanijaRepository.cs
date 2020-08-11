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
    public class KompanijaRepository
    {
        public List<KompanijaViewModel> getKompanijos()
        {
            List<KompanijaViewModel> kompanijaViewModels = new List<KompanijaViewModel>();

            string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mySqlConnection = new MySqlConnection(conn);
            string sqlquery = @"SELECT m.id_KOMPANIJA, m.pavadinimas, m.telefonas, m.el_pastas, mm.pavadinimas AS miestass 
                                FROM kompanija m
                                LEFT JOIN miestas mm ON mm.id_MIESTAS=m.fk_MIESTASid_MIESTAS";
            MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);
            mySqlConnection.Open();
            MySqlDataAdapter mda = new MySqlDataAdapter(mySqlCommand);
            DataTable dt = new DataTable();
            mda.Fill(dt);
            mySqlConnection.Close();

            foreach (DataRow item in dt.Rows)
            {
                kompanijaViewModels.Add(new KompanijaViewModel
                {
                    id = Convert.ToInt32(item["id_KOMPANIJA"]),
                    pavadinimas = Convert.ToString(item["pavadinimas"]),
                    fk_miestas = Convert.ToString(item["miestass"]),
                    telefonas = Convert.ToString(item["telefonas"]),
                    el_pastas = Convert.ToString(item["el_pastas"])
                });
            }

            return kompanijaViewModels;
        }
        public bool addKompanija(KompanijaEditViewModel modelis)
        {
            string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mySqlConnection = new MySqlConnection(conn);
            string sqlquery = @"INSERT INTO kompanija(pavadinimas,telefonas,el_pastas,id_KOMPANIJA,fk_MIESTASid_MIESTAS)VALUES(?pavadinimas,?telefonas,?el_pastas,?id,?fk_miestas)";
            MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);
            mySqlCommand.Parameters.Add("?pavadinimas", MySqlDbType.VarChar).Value = modelis.pavadinimas;
            mySqlCommand.Parameters.Add("?telefonas", MySqlDbType.VarChar).Value = modelis.telefonas;
            mySqlCommand.Parameters.Add("?el_pastas", MySqlDbType.VarChar).Value = modelis.el_pastas;
            mySqlCommand.Parameters.Add("?id", MySqlDbType.Int32).Value = getMaxId()+1;
            mySqlCommand.Parameters.Add("?fk_miestas", MySqlDbType.Int32).Value = modelis.fk_miestas;
            mySqlConnection.Open();
            mySqlCommand.ExecuteNonQuery();
            mySqlConnection.Close();
            return true;
        }
        public KompanijaEditViewModel getKompanija(int id)
        {
            KompanijaEditViewModel kompanija = new KompanijaEditViewModel();

            string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mySqlConnection = new MySqlConnection(conn);
            string sqlquery = @"SELECT m.* 
                                FROM kompanija m WHERE m.id_KOMPANIJA=" + id;
            MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);
            mySqlConnection.Open();
            MySqlDataAdapter mda = new MySqlDataAdapter(mySqlCommand);
            DataTable dt = new DataTable();
            mda.Fill(dt);
            mySqlConnection.Close();

            foreach (DataRow item in dt.Rows)
            {
                kompanija.id = Convert.ToInt32(item["id_KOMPANIJA"]);
                kompanija.pavadinimas = Convert.ToString(item["pavadinimas"]);
                kompanija.fk_miestas = Convert.ToInt32(item["fk_MIESTASid_MIESTAS"]);
                kompanija.telefonas = Convert.ToString(item["telefonas"]);
                kompanija.el_pastas = Convert.ToString(item["el_pastas"]);
            }

            return kompanija;
        }
        public bool updateKompanija(KompanijaEditViewModel kompanija)
        {
            string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mySqlConnection = new MySqlConnection(conn);
            string sqlquery = @"UPDATE kompanija a SET a.pavadinimas=?pavadinimas,a.telefonas=?telefonas,a.el_pastas=?el_pastas,a.fk_MIESTASid_MIESTAS=?fk_miestas WHERE a.id_KOMPANIJA=?id";
            MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);
            mySqlCommand.Parameters.Add("?id", MySqlDbType.Int32).Value = kompanija.id;
            mySqlCommand.Parameters.Add("?pavadinimas", MySqlDbType.VarChar).Value = kompanija.pavadinimas;
            mySqlCommand.Parameters.Add("?telefonas", MySqlDbType.VarChar).Value = kompanija.telefonas;
            mySqlCommand.Parameters.Add("?el_pastas", MySqlDbType.VarChar).Value = kompanija.el_pastas;
            mySqlCommand.Parameters.Add("?fk_miestas", MySqlDbType.Int32).Value = kompanija.fk_miestas;
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
            string sqlquery = @"SELECT count(id_MOKYKLA) as kiekis from mokykla where fk_KOMPANIJAid_KOMPANIJA=" + id;
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
        public void deleteKompanija(int id)
        {
            string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mySqlConnection = new MySqlConnection(conn);
            string sqlquery = @"DELETE FROM kompanija where id_KOMPANIJA=?id";
            MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);
            mySqlCommand.Parameters.Add("?id", MySqlDbType.Int32).Value = id;
            mySqlConnection.Open();
            mySqlCommand.ExecuteNonQuery();
            mySqlConnection.Close();
        }
        //public void getMaxId()
        //{
        //    string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
        //    MySqlConnection mySqlConnection = new MySqlConnection(conn);
        //    string sqlquery = @"SELECT MAX(id) as max FROM kompanija";
        //    MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);
        //    //mySqlCommand.Parameters.Add("?id", MySqlDbType.Int32).Value = id;
        //    mySqlConnection.Open();
        //    mySqlCommand.ExecuteNonQuery();
        //    mySqlConnection.Close();
        //}
        public int getMaxId()
        {
            int naudota = 0;
            string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mySqlConnection = new MySqlConnection(conn);
            string sqlquery = @"SELECT MAX(id_KOMPANIJA) as max FROM kompanija";
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