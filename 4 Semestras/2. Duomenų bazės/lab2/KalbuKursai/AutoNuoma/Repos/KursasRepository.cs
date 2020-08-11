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
    public class KursasRepository
    {
        public List<Kursas> getKursai()
        {
            List<Kursas> kursai = new List<Kursas>();
            string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mySqlConnection = new MySqlConnection(conn);
            string sqlquery = @"SELECT m.id, m.kalba, m.trukme_menesiais, m.kaina, m.max_mokiniu, m.mokymosi_medziaga, m.lygis, m.savaites_diena, m.fk_MOKYTOJASasmens_kodas
                                FROM kursas m";
            MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);
            mySqlConnection.Open();
            MySqlDataAdapter mda = new MySqlDataAdapter(mySqlCommand);
            DataTable dt = new DataTable();
            mda.Fill(dt);
            mySqlConnection.Close();

            foreach (DataRow item in dt.Rows)
            {
                kursai.Add(new Kursas
                {
                    id = Convert.ToInt32(item["id"]),
                    kalba = Convert.ToString(item["kalba"]),
                    trukme_menesiais = Convert.ToInt32(item["trukme_menesiais"]),
                    kaina = Convert.ToDouble(item["kaina"]),
                    max_mokiniu = Convert.ToInt32(item["max_mokiniu"]),
                    mokymosi_medziaga = Convert.ToString(item["mokymosi_medziaga"]),
                    lygis = Convert.ToString(item["lygis"]),
                    savaites_diena = Convert.ToString(item["savaites_diena"]),
                    mokytojo_asmens_kodas = Convert.ToString(item["fk_MOKYTOJASasmens_kodas"]),
                });
            }

            return kursai;
        }

        public Kursas getKursas(int id)
        {
            Kursas kursas = new Kursas();

            string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mySqlConnection = new MySqlConnection(conn);
            string sqlquery = @"SELECT m.id, m.kalba, m.trukme_menesiais, m.kaina, m.max_mokiniu, m.mokymosi_medziaga, m.lygis, m.savaites_diena, m.fk_MOKYTOJASasmens_kodas
                                FROM kursas m WHERE m.id=" + id;
            MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);
            mySqlConnection.Open();
            MySqlDataAdapter mda = new MySqlDataAdapter(mySqlCommand);
            DataTable dt = new DataTable();
            mda.Fill(dt);
            mySqlConnection.Close();

            foreach (DataRow item in dt.Rows)
            {

                kursas.id = Convert.ToInt32(item["id"]);
                kursas.kalba = Convert.ToString(item["kalba"]);
                kursas.trukme_menesiais = Convert.ToInt32(item["trukme_menesiais"]);
                kursas.kaina = Convert.ToDouble(item["kaina"]);
                kursas.max_mokiniu = Convert.ToInt32(item["max_mokiniu"]);
                kursas.mokymosi_medziaga = Convert.ToString(item["mokymosi_medziaga"]);
                kursas.lygis = Convert.ToString(item["lygis"]);
                kursas.savaites_diena = Convert.ToString(item["savaites_diena"]);
                kursas.mokytojo_asmens_kodas = Convert.ToString(item["fk_MOKYTOJASasmens_kodas"]);
            }

            return kursas;
        }

        public bool addKursas(Kursas kursas)
        {

            string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mySqlConnection = new MySqlConnection(conn);
            string sqlquery = @"INSERT INTO kursas(kalba, trukme_menesiais, kaina, max_mokiniu, id, mokymosi_medziaga, lygis, savaites_diena, fk_MOKYTOJASasmens_kodas)
                                    VALUES(?kalba, ?trukme_menesiais, ?kaina, ?max_mokiniu, ?id, ?mokymosi_medziaga, ?lygis, ?savaites_diena, ?mokytojo_asmens_kodas)";
            MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);
            mySqlCommand.Parameters.Add("?kalba", MySqlDbType.VarChar).Value = kursas.kalba;
            mySqlCommand.Parameters.Add("?trukme_menesiais", MySqlDbType.Int32).Value = kursas.trukme_menesiais;
            mySqlCommand.Parameters.Add("?kaina", MySqlDbType.Decimal).Value = kursas.kaina;
            mySqlCommand.Parameters.Add("?max_mokiniu", MySqlDbType.Int32).Value = kursas.max_mokiniu;
            mySqlCommand.Parameters.Add("?id", MySqlDbType.Int32).Value = getMaxId() + 1;
            mySqlCommand.Parameters.Add("?mokymosi_medziaga", MySqlDbType.VarChar).Value = kursas.mokymosi_medziaga;
            mySqlCommand.Parameters.Add("?lygis", MySqlDbType.VarChar).Value = kursas.lygis;
            mySqlCommand.Parameters.Add("?savaites_diena", MySqlDbType.VarChar).Value = kursas.savaites_diena;
            mySqlCommand.Parameters.Add("?mokytojo_asmens_kodas", MySqlDbType.VarChar).Value = kursas.mokytojo_asmens_kodas;
            mySqlConnection.Open();
            mySqlCommand.ExecuteNonQuery();
            mySqlConnection.Close();
            return true;
        }
        public int getMaxId()
        {
            int naudota = 0;
            string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mySqlConnection = new MySqlConnection(conn);
            string sqlquery = @"SELECT MAX(id) as max FROM kursas";
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
        public int getKursasCount(int id)
        {
            int naudota = 0;
            string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mySqlConnection = new MySqlConnection(conn);
            string sqlquery = @"SELECT count(id_LANKOMAS_KURSAS) as kiekis from lankomas_kursas where fk_KURSASid=" + id;
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

        public void deleteKursas(int id)
        {
            string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mySqlConnection = new MySqlConnection(conn);
            string sqlquery = @"DELETE FROM kursas where id=?id";
            MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);
            mySqlCommand.Parameters.Add("?id", MySqlDbType.Int32).Value = id;
            mySqlConnection.Open();
            mySqlCommand.ExecuteNonQuery();
            mySqlConnection.Close();
        }
        public bool updateKursas(Kursas kursas)
        {
            string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mySqlConnection = new MySqlConnection(conn);
            string sqlquery = @"UPDATE kursas a SET a.kalba=?kalba, a.trukme_menesiais=?trukme_menesiais, a.kaina=?kaina, a.max_mokiniu=?max_mokiniu, a.mokymosi_medziaga=?mokymosi_medziaga, a.lygis=?lygis, a.savaites_diena=?savaites_diena, a.fk_MOKYTOJASasmens_kodas=?mokytojo_asmens_kodas WHERE a.id=?id";
            MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);
            mySqlCommand.Parameters.Add("?kalba", MySqlDbType.VarChar).Value = kursas.kalba;
            mySqlCommand.Parameters.Add("?trukme_menesiais", MySqlDbType.Int32).Value = kursas.trukme_menesiais;
            mySqlCommand.Parameters.Add("?kaina", MySqlDbType.Decimal).Value = kursas.kaina;
            mySqlCommand.Parameters.Add("?max_mokiniu", MySqlDbType.Int32).Value = kursas.max_mokiniu;
            mySqlCommand.Parameters.Add("?id", MySqlDbType.Int32).Value = kursas.id;
            mySqlCommand.Parameters.Add("?mokymosi_medziaga", MySqlDbType.VarChar).Value = kursas.mokymosi_medziaga;
            mySqlCommand.Parameters.Add("?lygis", MySqlDbType.VarChar).Value = kursas.lygis;
            mySqlCommand.Parameters.Add("?savaites_diena", MySqlDbType.VarChar).Value = kursas.savaites_diena;
            mySqlCommand.Parameters.Add("?mokytojo_asmens_kodas", MySqlDbType.VarChar).Value = kursas.mokytojo_asmens_kodas;
            mySqlConnection.Open();
            mySqlCommand.ExecuteNonQuery();
            mySqlConnection.Close();
            return true;
        }
    }
}