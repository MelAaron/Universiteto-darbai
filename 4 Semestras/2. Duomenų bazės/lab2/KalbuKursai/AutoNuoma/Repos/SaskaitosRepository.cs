using AutoNuoma.Models;
using AutoNuoma.ViewModels;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;

namespace AutoNuoma.Repos
{
    public class SaskaitosRepository
    {
        public List<Saskaita> getUzsakytosSaskaitos(int sutartis)
        {
            List<Saskaita> paslaugos = new List<Saskaita>();
            string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mySqlConnection = new MySqlConnection(conn);
            string sqlquery = "select * from saskaita WHERE fk_SUTARTISnr=" + sutartis;
            MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);
            mySqlConnection.Open();
            MySqlDataAdapter mda = new MySqlDataAdapter(mySqlCommand);
            DataTable dt = new DataTable();
            mda.Fill(dt);
            mySqlConnection.Close();

            foreach (DataRow item in dt.Rows)
            {
                paslaugos.Add(new Saskaita
                {
                    nr = Convert.ToInt32(item["nr"]),
                    data = Convert.ToDateTime(item["data"]),
                    suma = Convert.ToDouble(item["suma"]),
                    fk_sutartis = Convert.ToInt32(item["fk_SUTARTISnr"])
                });
            }

            return paslaugos;
        }

        public bool insertSaskaita(Saskaita uzsSaskaita)
        {
            string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mySqlConnection = new MySqlConnection(conn);
            string sqlquery = @"INSERT INTO saskaita(
                                        fk_SUTARTISnr,
                                        suma,
                                        data,
                                        nr)
                                        VALUES(
                                        ?fk_sutartis,
                                        ?suma,
                                        ?data,
                                        ?nr)";
            MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);
            mySqlCommand.Parameters.Add("?fk_sutartis", MySqlDbType.Int32).Value = uzsSaskaita.fk_sutartis;
            mySqlCommand.Parameters.Add("?data", MySqlDbType.Date).Value = uzsSaskaita.data.ToString("yyyy-MM-dd");
            mySqlCommand.Parameters.Add("?suma", MySqlDbType.Decimal).Value = uzsSaskaita.suma;
            mySqlCommand.Parameters.Add("?nr", MySqlDbType.Int32).Value = getMaxId() + 1;
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
            string sqlquery = @"SELECT MAX(nr) as max FROM saskaita";
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
        public bool deleteSaskaitos(int sutartis)
        {
            string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mySqlConnection = new MySqlConnection(conn);
            string sqlquery = @"DELETE FROM a USING saskaita as a
                                where a.fk_SUTARTISnr=?fkid";
            MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);
            mySqlCommand.Parameters.Add("?fkid", MySqlDbType.Int32).Value = sutartis;
            mySqlConnection.Open();
            mySqlCommand.ExecuteNonQuery();
            mySqlConnection.Close();
            return true;
        }
    }
}