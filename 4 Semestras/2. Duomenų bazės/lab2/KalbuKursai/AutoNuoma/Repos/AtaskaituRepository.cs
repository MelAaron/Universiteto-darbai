using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using AutoNuoma.Models;
using AutoNuoma.ViewModels;
using MySql.Data.MySqlClient;

namespace AutoNuoma.Repos
{
    public class AtaskaituRepository
    {
        public List<MokiniuFinansai2> getMokiniai(DateTime ?nuo, DateTime ?iki, decimal? kainaNuo, decimal? kainaIki, decimal? sumokejoNuo, decimal? sumokejoIki)
        {
            List<MokiniuFinansai2> mokiniai = new List<MokiniuFinansai2>();
            string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mySqlConnection = new MySqlConnection(conn);
            string sqlquery = @"SELECT CONCAT(mok.vardas,' ',mok.pavarde) as Mokinio_Vardas, t.skolingas as Pilna_kaina, g.Suma as Sumokejo, IF((t.skolingas-g.Suma)<=0,'Sumokėjo',(t.skolingas-g.Suma)) as Skola, COUNT(t.asmens_kodas) as Kursu_Kiekis, sut.sutarties_data, sut.nr
                                FROM mokinys mok INNER JOIN sutartis sut ON sut.fk_MOKINYSasmens_kodas = mok.asmens_kodas
                                LEFT JOIN(SELECT mok.asmens_kodas, SUM(moke.suma) as Suma 
                                    FROM mokinys mok INNER JOIN mokejimas moke ON mok.asmens_kodas = moke.fk_MOKINYSasmens_kodas 
                                    GROUP BY mok.asmens_kodas) AS g ON mok.asmens_kodas = g.asmens_kodas 
                                LEFT JOIN(SELECT mok.asmens_kodas, SUM(kur.kaina) as skolingas 
                                    FROM mokinys mok INNER JOIN sutartis sut ON mok.asmens_kodas = sut.fk_MOKINYSasmens_kodas 
                                    INNER JOIN lankomas_kursas lkur ON lkur.fk_SUTARTISnr = sut.nr 
                                LEFT JOIN kursas kur ON kur.id = lkur.fk_KURSASid 
                                    GROUP BY mok.asmens_kodas) AS t ON mok.asmens_kodas = t.asmens_kodas 
                                WHERE sut.sutarties_data >= IFNULL(?nuo, sut.sutarties_data)
                                AND sut.sutarties_data <= IFNULL(?iki, sut.sutarties_data)
                                AND t.skolingas>=IFNULL(?kainaNuo, t.skolingas)
                                AND t.skolingas<=IFNULL(?kainaIki, t.skolingas)
                                AND g.Suma>=IFNULL(?sumokejoNuo, g.Suma)
                                AND g.Suma<=IFNULL(?sumokejoIki, g.Suma)
                                GROUP BY mok.asmens_kodas
                                ORDER BY sut.sutarties_data";
            MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);
            mySqlCommand.Parameters.Add("?nuo", MySqlDbType.DateTime).Value = nuo;
            mySqlCommand.Parameters.Add("?iki", MySqlDbType.DateTime).Value = iki;
            mySqlCommand.Parameters.Add("?kainaNuo", MySqlDbType.Decimal).Value = kainaNuo;
            mySqlCommand.Parameters.Add("?kainaIki", MySqlDbType.Decimal).Value = kainaIki;
            mySqlCommand.Parameters.Add("?sumokejoNuo", MySqlDbType.Decimal).Value = sumokejoNuo;
            mySqlCommand.Parameters.Add("?sumokejoIki", MySqlDbType.Decimal).Value = sumokejoIki;
            mySqlConnection.Open();
            MySqlDataAdapter mda = new MySqlDataAdapter(mySqlCommand);
            DataTable dt = new DataTable();
            mda.Fill(dt);
            mySqlConnection.Close();

            foreach (DataRow item in dt.Rows)
            {
                mokiniai.Add(new MokiniuFinansai2
                {
                    mokinio_vardas = Convert.ToString(item["Mokinio_Vardas"]),
                    pilna_kaina = Convert.ToDecimal(item["Pilna_kaina"]),
                    sumokejo = Convert.ToDecimal(item["Sumokejo"]),
                    Skola = Convert.ToString(item["Skola"]),
                    kursu_kiekis = Convert.ToInt32(item["Kursu_Kiekis"]),
                    sutarties_data = Convert.ToDateTime(item["sutarties_data"]),
                    sutarties_nr = Convert.ToInt32(item["nr"])
                });
            }
            return mokiniai;
        }
        public MokiniuFinansai getBedrosSumos(DateTime? nuo, DateTime? iki, decimal? kainaNuo, decimal? kainaIki, decimal? sumokejoNuo, decimal? sumokejoIki)
        {
            MokiniuFinansai viso = new MokiniuFinansai();
            string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mySqlConnection = new MySqlConnection(conn);
            string sqlquery = @"SELECT SUM(t.skolingas) AS Pilna_kaina, SUM(g.Suma) AS Sumokejo, COUNT(t.asmens_kodas) AS Kursu_Kiekis
                                    FROM mokinys mok INNER JOIN sutartis sut ON sut.fk_MOKINYSasmens_kodas = mok.asmens_kodas
                                    LEFT JOIN (SELECT mok.asmens_kodas, SUM(moke.suma) as Suma
	                                    FROM mokinys mok INNER JOIN mokejimas moke ON mok.asmens_kodas = moke.fk_MOKINYSasmens_kodas
	                                    GROUP BY mok.asmens_kodas) AS g ON mok.asmens_kodas = g.asmens_kodas
                                    LEFT JOIN (SELECT mok.asmens_kodas, SUM(kur.kaina) as skolingas
	                                    FROM mokinys mok INNER JOIN sutartis sut ON mok.asmens_kodas = sut.fk_MOKINYSasmens_kodas
	                                    INNER JOIN lankomas_kursas lkur ON lkur.fk_SUTARTISnr = sut.nr
	                                    LEFT JOIN kursas kur ON kur.id = lkur.fk_KURSASid
	                                    GROUP BY mok.asmens_kodas) AS t ON mok.asmens_kodas = t.asmens_kodas
                                    WHERE sut.sutarties_data>=IFNULL(?nuo, sut.sutarties_data)
                                    AND sut.sutarties_data<=IFNULL(?iki, sut.sutarties_data)
                                    AND t.skolingas>=IFNULL(?kainaNuo, t.skolingas)
                                    AND t.skolingas<=IFNULL(?kainaIki, t.skolingas)
                                    AND g.Suma>=IFNULL(?sumokejoNuo, g.Suma)
                                    AND g.Suma<=IFNULL(?sumokejoIki, g.Suma)";
            MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);
            mySqlCommand.Parameters.Add("?nuo", MySqlDbType.DateTime).Value = nuo;
            mySqlCommand.Parameters.Add("?iki", MySqlDbType.DateTime).Value = iki;
            mySqlCommand.Parameters.Add("?kainaNuo", MySqlDbType.Decimal).Value = kainaNuo;
            mySqlCommand.Parameters.Add("?kainaIki", MySqlDbType.Decimal).Value = kainaIki;
            mySqlCommand.Parameters.Add("?sumokejoNuo", MySqlDbType.Decimal).Value = sumokejoNuo;
            mySqlCommand.Parameters.Add("?sumokejoIki", MySqlDbType.Decimal).Value = sumokejoIki;
            mySqlConnection.Open();
            MySqlDataAdapter mda = new MySqlDataAdapter(mySqlCommand);
            DataTable dt = new DataTable();
            mda.Fill(dt);
            mySqlConnection.Close();

            foreach (DataRow item in dt.Rows)
            {
                viso.lankomuKursuK = Convert.ToInt32(item["Kursu_kiekis"] == System.DBNull.Value ? 0 : item["Kursu_kiekis"]);
                viso.visoSuma = Convert.ToDecimal(item["Pilna_kaina"] == System.DBNull.Value ? 0 : item["Pilna_kaina"]);
                viso.visoSumoketa = Convert.ToInt32(item["Sumokejo"] == System.DBNull.Value ? 0 : item["Sumokejo"]);
            }
            return viso;
        }

        public PslgAtaskaitaViewModel getBedraSumaUzsakytuPaslaugu(DateTime? nuo, DateTime? iki)
        {
            PslgAtaskaitaViewModel viso = new PslgAtaskaitaViewModel();
            string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mySqlConnection = new MySqlConnection(conn);
            //string sqlquery2 = @"SELECT SUM(a.suma"
            string sqlquery = @"select sum(b.kiekis) as kiekis, sum(b.kiekis*b.kaina) as suma 
                                from "+Globals.dbPrefix+"paslaugos a, "+Globals.dbPrefix+"uzsakytos_paslaugos b, "+Globals.dbPrefix+@"sutartys c
	                            where a.id=b.fk_paslauga and b.fk_sutartis=c.nr 
                                and c.sutarties_data>=IFNULL(?nuo, c.sutarties_data) and c.sutarties_data <= IFNULL(?iki, c.sutarties_data)";
            MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);
            mySqlCommand.Parameters.Add("?nuo", MySqlDbType.DateTime).Value = nuo;
            mySqlCommand.Parameters.Add("?iki", MySqlDbType.DateTime).Value = iki;
            mySqlConnection.Open();
            MySqlDataAdapter mda = new MySqlDataAdapter(mySqlCommand);
            DataTable dt = new DataTable();
            mda.Fill(dt);
            mySqlConnection.Close();

            foreach (DataRow item in dt.Rows)
            {
                viso.visoUzsakyta = Convert.ToInt32(item["kiekis"] == System.DBNull.Value ? 0 : item["kiekis"]);
                viso.bendraSuma = Convert.ToDecimal(item["suma"] == System.DBNull.Value ? 0 : item["suma"]);
            }

            return viso;
        }

        public List<SAtaskaitaViewModel> getAtaskaitaSutartciu(DateTime? nuo, DateTime? iki)
        {
            List<SAtaskaitaViewModel> sutartys = new List<SAtaskaitaViewModel>();
            string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mySqlConnection = new MySqlConnection(conn);
            string sqlquery = @"select a.nr, a.sutarties_data, k.vardas, k.pavarde, k.asmens_kodas, a.kaina, IFNULL(sum(ps.kaina*ps.kiekis), 0) paslaugu_kaina,
                                t.bendra_suma, s.bendra_suma bendra_suma_paslaugu from "+Globals.dbPrefix+@"sutartys a
	                                                inner join "+Globals.dbPrefix+@"klientai k on k.asmens_kodas=a.fk_klientas
                                                    left join "+Globals.dbPrefix+@"uzsakytos_paslaugos ps on ps.fk_sutartis=a.nr
                                                    left join (select x.asmens_kodas, sum(z.kaina) as bendra_suma from "+Globals.dbPrefix+@"sutartys z, "+Globals.dbPrefix+@"klientai x where x.asmens_kodas=z.fk_klientas
                                                               and z.sutarties_data>=IFNULL(?nuo, z.sutarties_data) and z.sutarties_data<=IFNULL(?iki, z.sutarties_data)
                                                               group by x.asmens_kodas) as t on t.asmens_kodas = k.asmens_kodas
                                                    left join (select kk.asmens_kodas, IFNULL(sum(uzs.kiekis*uzs.kaina), 0) as bendra_suma from "+Globals.dbPrefix+@"sutartys aa
              	                                                inner join "+Globals.dbPrefix+@"klientai kk on kk.asmens_kodas=aa.fk_klientas
                                                                left join "+Globals.dbPrefix+@"uzsakytos_paslaugos uzs on uzs.fk_sutartis=aa.nr 
                                                               where aa.sutarties_data>=IFNULL(?nuo, aa.sutarties_data) and aa.sutarties_data<=IFNULL(?iki, aa.sutarties_data)
                                                               group by kk.asmens_kodas) as s on s.asmens_kodas = k.asmens_kodas
                                                    where a.sutarties_data>=IFNULL(?nuo, a.sutarties_data) and a.sutarties_data<=IFNULL(?iki, a.sutarties_data)
                                                    group by a.nr, k.pavarde
                                                    order by k.pavarde ASC";
            MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);
            mySqlCommand.Parameters.Add("?nuo", MySqlDbType.DateTime).Value = nuo;
            mySqlCommand.Parameters.Add("?iki", MySqlDbType.DateTime).Value = iki;
            mySqlConnection.Open();
            MySqlDataAdapter mda = new MySqlDataAdapter(mySqlCommand);
            DataTable dt = new DataTable();
            mda.Fill(dt);
            mySqlConnection.Close();

            foreach (DataRow item in dt.Rows)
            {
                sutartys.Add(new SAtaskaitaViewModel
                {
                    nr = Convert.ToInt32(item["nr"]),
                    sutartiesData = Convert.ToDateTime(item["sutarties_data"]),
                    asmensKodas = Convert.ToString(item["asmens_kodas"]),
                    vardas = Convert.ToString(item["vardas"]),
                    pavarde = Convert.ToString(item["pavarde"]),
                    kaina = Convert.ToDecimal(item["kaina"]),
                    paslauguKaina = Convert.ToDecimal(item["paslaugu_kaina"]),
                    bendraSuma = Convert.ToDecimal(item["bendra_suma"]),
                    bendraSumaPaslaug = Convert.ToDecimal(item["bendra_suma_paslaugu"])
                });
            }
            return sutartys;
        }

        public List<VeluojanciosSutartysViewModel> getVeluojanciosGrazinti(DateTime? nuo, DateTime? iki)
        {
            List<VeluojanciosSutartysViewModel> sutartys = new List<VeluojanciosSutartysViewModel>();
            string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mySqlConnection = new MySqlConnection(conn);
            string sqlquery = @"SELECT a.nr, a.sutarties_data, CONCAT(b.vardas, ' ', b.pavarde) as mokinyss, a.pradzios_data
                                    FROM sutartis a INNER JOIN mokinys b ON a.fk_MOKINYSasmens_kodas = b.asmens_kodas
                                    AND a.sutarties_data>=IFNULL(?nuo, a.sutarties_data)
                                    AND a.sutarties_data<=IFNULL(?iki, a.sutarties_data)
                                    ORDER BY a.sutarties_data DESC";
            //string sqlquery2 = @"select a.nr, a.sutarties_data, Concat(b.vardas, ' ',b.pavarde) as klientas, a.planuojama_grazinimo_data_laikas, 
		          //                  if(IFNULL(a.faktine_grazinimo_data_laikas,'0000-00-00') like '0000%', 'negražinta', a.faktine_grazinimo_data_laikas) as grazinimo_data   
            //                        from "+Globals.dbPrefix+"sutartys a, "+Globals.dbPrefix+@"klientai b 
	           //                 where b.asmens_kodas=a.fk_klientas
            //                    and (DATEDIFF(a.faktine_grazinimo_data_laikas, a.planuojama_grazinimo_data_laikas)>=1
            //                    or IFNULL(a.faktine_grazinimo_data_laikas, '0000-00-00') like '0000%' and DATEDIFF(NOW(), a.planuojama_grazinimo_data_laikas)>=1 )
            //                    and a.sutarties_data>=IFNULL(?nuo, a.sutarties_data) and a.sutarties_data<=IFNULL(?iki, a.sutarties_data)";
            MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);
            mySqlCommand.Parameters.Add("?nuo", MySqlDbType.DateTime).Value = nuo;
            mySqlCommand.Parameters.Add("?iki", MySqlDbType.DateTime).Value = iki;
            mySqlConnection.Open();
            MySqlDataAdapter mda = new MySqlDataAdapter(mySqlCommand);
            DataTable dt = new DataTable();
            mda.Fill(dt);
            mySqlConnection.Close();

            foreach (DataRow item in dt.Rows)
            {
                sutartys.Add(new VeluojanciosSutartysViewModel
                {
                    nr = Convert.ToInt32(item["nr"]),
                    sutartiesData = Convert.ToDateTime(item["sutarties_data"]),
                    mokinys = Convert.ToString(item["mokinyss"]),
                    pradzios_data = Convert.ToDateTime(item["pradzios_data"])
                    
                });
            }
            return sutartys;
        }

    }
}