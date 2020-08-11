using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Buitinės_technikos_parduotuvė
{
    class Program
    {
        /// <summary>
        /// Main funkcija
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Program p = new Program();
            Branch_Konteineris branch_konteineris = new Branch_Konteineris(100);
            using (StreamWriter sw = new StreamWriter(@"Duomenys.txt", false))
            {
                p.FailuNuskaitymas(branch_konteineris, sw);
            }
            Saldytuvu_konteineris saldytuvas = new Saldytuvu_konteineris(100);
            saldytuvas = p.VisiSaldytuvai(branch_konteineris, saldytuvas);
            p.Siemens(branch_konteineris);
            p.Rikiuoti(saldytuvas);
            Saldytuvu_konteineris nesikartoja = p.Nepasikartoja(saldytuvas);
            p.Pigiausi(nesikartoja);
            Saldytuvu_konteineris gamintojai = p.Nesikartoja(saldytuvas);
            Branch_Konteineris tikten = p.TikTen(branch_konteineris);
            p.SpausdintiGamintojus(gamintojai);
            p.Spausdinti(tikten);
            Console.ReadKey();
        }
        /// <summary>
        /// Metodas skirtas sudaryti bendrą visų praduotuvių parduodamų šaldytuvų konteinerį
        /// </summary>
        /// <param name="branch">Branch konteineris</param>
        /// <param name="saldytuvas">Išsaugojamų saldytuvu konteineris</param>
        /// <returns>Gražinamas pilnas visų parduotuvių šaldytuvų konteineris</returns>
        Saldytuvu_konteineris VisiSaldytuvai(Branch_Konteineris branch, Saldytuvu_konteineris saldytuvas)
        {
            for (int a = 0; branch.Kiekis > a; a++)
            {
                for (int b = 0; branch.GautiBranch(a).Saldytuvai.Kiekis > b; b++)
                {
                    saldytuvas.PridėtiŠaldytuvą(branch.GautiBranch(a).Saldytuvai.GautiŠaldytuvą(b));
                }
            }
            return saldytuvas;
        }
        /// <summary>
        /// Failų nuskaitymas
        /// </summary>
        /// <param name="Konteineris">Tusčias konteineris</param>
        /// <param name="sw">Duomenys.txt</param>
        void FailuNuskaitymas(Branch_Konteineris Konteineris, StreamWriter sw)
        {
            DirectoryInfo d = new DirectoryInfo(@"Duomenys");
            FileInfo[] Files = d.GetFiles("*.csv");
            Program p = new Program();
            foreach (FileInfo file in Files)
            {
                string[] lines = File.ReadAllLines("Duomenys/" + file.Name);
                using (StreamReader reader = new StreamReader("Duomenys/" + file.Name))
                {
                    string eilute;
                    string pav = reader.ReadLine();
                    string adresas = reader.ReadLine();
                    string tlf = reader.ReadLine();
                    Branch branch = new Branch(pav, adresas, tlf);
                    Konteineris.PridėtiBranch(branch);
                    while (null != (eilute = reader.ReadLine()))
                    {
                        string[] va = eilute.Split(';');
                        string gamintojas = va[0];
                        string modelis = va[1];
                        int talpa = Convert.ToInt32(va[2]);
                        string energijosklase = va[3];
                        string montavimotipas = va[4];
                        string spalva = va[5];
                        string pozymis = va[6];
                        double kaina = double.Parse(va[7]);
                        int aukstis = Convert.ToInt32(va[8]);
                        int plotis = Convert.ToInt32(va[9]);
                        int gylis = Convert.ToInt32(va[10]);
                        Saldytuvas saldytuvas = new Saldytuvas(gamintojas,
                            modelis, talpa, energijosklase, montavimotipas, spalva, pozymis,
                            kaina, aukstis, plotis, gylis);
                        branch.Saldytuvai.PridėtiŠaldytuvą(saldytuvas);
                    }
                }
            }
            p.LenteleSpausdinimas(Konteineris, sw);
        }
        /// <summary>
        /// Duomenų spausdinimas
        /// </summary>
        /// <param name="Konteineris">Konteineris</param>
        /// <param name="sw">Duomenys.txt</param>
        void LenteleSpausdinimas(Branch_Konteineris Konteineris, StreamWriter sw)
        {
            for (int i = 0; Konteineris.Kiekis > i; i++)
            {
                sw.WriteLine("-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------");
                sw.WriteLine("{0,-10} {1,-10} {2,-10} {3,-17} {4,-20} {5,-15} {6,-10} {7,-10} {8,-10} {9,-10} {10,-10}", "Gamintojas", "Modelis",
                            "Talpa", "Energijos klase", "Montavimo tipas", "Spalva", "Požymis", "Kaina", "Aukštis", "Plotis", "Gylis");
                sw.WriteLine("-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------");
                sw.WriteLine("{0} {1} {2}", Konteineris.GautiBranch(i).Pav, Konteineris.GautiBranch(i).Adresas, Konteineris.GautiBranch(i).Tlf);
                sw.WriteLine("-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------");
                for (int a = 0; Konteineris.GautiBranch(i).Saldytuvai.Kiekis > a; a++)
                {
                    sw.WriteLine("{0,-10} {1,-10} {2,-15} {3,-17} {4,-15} {5,-15} {6,-10} {7,-11} {8,-11} {9,-10} {10,-10}", Konteineris.GautiBranch(i).Saldytuvai.GautiŠaldytuvą(a).Gamintojas, 
                        Konteineris.GautiBranch(i).Saldytuvai.GautiŠaldytuvą(a).Modelis, Konteineris.GautiBranch(i).Saldytuvai.GautiŠaldytuvą(a).Talpa,
                        Konteineris.GautiBranch(i).Saldytuvai.GautiŠaldytuvą(a).EnergijosKlase, Konteineris.GautiBranch(i).Saldytuvai.GautiŠaldytuvą(a).MontavimoTipas,
                        Konteineris.GautiBranch(i).Saldytuvai.GautiŠaldytuvą(a).Spalva, Konteineris.GautiBranch(i).Saldytuvai.GautiŠaldytuvą(a).Pozymis,
                        Konteineris.GautiBranch(i).Saldytuvai.GautiŠaldytuvą(a).Kaina, Konteineris.GautiBranch(i).Saldytuvai.GautiŠaldytuvą(a).Aukstis,
                        Konteineris.GautiBranch(i).Saldytuvai.GautiŠaldytuvą(a).Plotis, Konteineris.GautiBranch(i).Saldytuvai.GautiŠaldytuvą(a).Gylis);
                }
                sw.WriteLine();
            }
            
        }
        /// <summary>
        /// Skaičiuojame kiek kiekvienoje parduotuvėje yra Siemens šaldytuvų
        /// </summary>
        /// <param name="branch">Branch konteineris</param>
        void Siemens(Branch_Konteineris branch)
        {
            Program p = new Program();
            for (int i = 0; i < branch.Kiekis; i++)
            {
                int kiekis = 0;
                for (int a = 0; branch.GautiBranch(i).Saldytuvai.Kiekis > a; a++)
                {
                    string gamintojas = branch.GautiBranch(i).Saldytuvai.GautiŠaldytuvą(a).Gamintojas;
                    if (a > 0 && branch.GautiBranch(i).Saldytuvai.GautiŠaldytuvą(a).Gamintojas == "Siemens")
                    {
                        kiekis++;
                        for (int j = a + 1; j < branch.GautiBranch(i).Saldytuvai.Kiekis; j++)
                        {
                            if (branch.GautiBranch(i).Saldytuvai.GautiŠaldytuvą(a) == branch.GautiBranch(i).Saldytuvai.GautiŠaldytuvą(j) &&
                                branch.GautiBranch(i).Saldytuvai.GautiŠaldytuvą(j).Gamintojas == "Siemens")
                            {
                                kiekis--;
                                break;
                            }
                        }
                    }
                    else if (a == 0)
                    {
                        if (branch.GautiBranch(i).Saldytuvai.GautiŠaldytuvą(a).Gamintojas == "Siemens")
                        {
                            kiekis++;
                        }
                    }
                }
                p.SiemensSpausdinimas(branch.GautiBranch(i).Pav, kiekis);
            }
        }
        /// <summary>
        /// Siemens šaldytuvų spausdinimas
        /// </summary>
        /// <param name="pav">Parduotuvės pavadinimas</param>
        /// <param name="kiekis">Kiek Siemens šaldytuvų</param>
        void SiemensSpausdinimas(string pav, int kiekis)
        {
            Console.WriteLine("Skirtingų modelių Siemens šaldytuvų kiekis " + pav + " parduotuvėje");
            Console.WriteLine(kiekis);
            Console.WriteLine("------------------------------------------------------------------------------");
        }
        /// <summary>
        /// Rikiavimas palei kainą
        /// </summary>
        /// <param name="saldytuvu_konteineris">Visų šaldytuvų konteineris</param>
        /// <returns>Surikiuotą konteinerį</returns>
        Saldytuvu_konteineris Rikiuoti(Saldytuvu_konteineris saldytuvu_konteineris)
        {
            Saldytuvas laikina = new Saldytuvas(null, null, 0, null, null, null, null, 0, 0, 0, 0);
            for (int a = 0; saldytuvu_konteineris.Kiekis > a; a++)
            {
                for (int b = a + 1; saldytuvu_konteineris.Kiekis > b; b++)
                {
                    if (saldytuvu_konteineris.GautiŠaldytuvą(a).Kaina > saldytuvu_konteineris.GautiŠaldytuvą(b).Kaina)
                    {
                        laikina = saldytuvu_konteineris.GautiŠaldytuvą(b);
                        saldytuvu_konteineris.PridėtiŠaldytuvą(saldytuvu_konteineris.GautiŠaldytuvą(a), b);
                        saldytuvu_konteineris.PridėtiŠaldytuvą(laikina, a);
                    }
                }
            }
            return saldytuvu_konteineris;
        }
        /// <summary>
        /// Randu nepasikartojancius modelius ir gamintojus
        /// </summary>
        /// <param name="saldytuvu_konteineris">Visų šaldytuvų konteineris</param>
        /// <returns></returns>
        Saldytuvu_konteineris Nepasikartoja(Saldytuvu_konteineris saldytuvu_konteineris)
        {
            Saldytuvu_konteineris Konteineris = new Saldytuvu_konteineris(100);
            for (int a = 0; saldytuvu_konteineris.Kiekis > a; a++)
            {
                bool kartojasi = false;
                for (int b = 0; Konteineris.Kiekis > b; b++)
                {
                    if (saldytuvu_konteineris.GautiŠaldytuvą(a).Equals(Konteineris.GautiŠaldytuvą(b)))
                    {
                        kartojasi = true;
                    }
                }
                if (!kartojasi)
                {
                    Konteineris.PridėtiŠaldytuvą(saldytuvu_konteineris.GautiŠaldytuvą(a));
                }
            }
            return Konteineris;
        }
        /// <summary>
        /// Apskaičiuoju pigiausius top 10 šaldytuvus
        /// </summary>
        /// <param name="saldytuvu_konteineris">Šaldytuvų konteineris</param>
        void Pigiausi(Saldytuvu_konteineris saldytuvu_konteineris)
        {
            int iki = 10;
            Console.WriteLine("Top 10 šaldytuvų");
            Console.WriteLine("");
            Console.WriteLine("{0,-10} {1,-10} {2,-10} {3,-10}", "Gamintojas", "Modelis", "Talpa", "Kaina");
            Console.WriteLine("------------------------------------------------------------------------------");
            for (int a = 0; saldytuvu_konteineris.Kiekis > a; a++)
            {
                if (saldytuvu_konteineris.GautiŠaldytuvą(a).Talpa >= 80 && iki > 0)
                {
                    Console.WriteLine(saldytuvu_konteineris.GautiŠaldytuvą(a).ToString());
                    iki--;
                }
            }
            Console.WriteLine("------------------------------------------------------------------------------");
        }
        /// <summary>
        /// Spausdina visus gamintojus
        /// </summary>
        /// <param name="gamintojai">Konetineris kuriame jau suskaičiuoti gamintojai</param>
        void SpausdintiGamintojus(Saldytuvu_konteineris gamintojai)
        {
            using (StreamWriter sw = new StreamWriter(@"Gamintojai.csv", false))
            {
                for (int a = 0; gamintojai.Kiekis > a; a++)
                {
                    sw.WriteLine("{0}", gamintojai.GautiŠaldytuvą(a).Gamintojas);
                }
            }
        }
        /// <summary>
        /// Skaičiuoju visus gamintojus
        /// </summary>
        /// <param name="saldytuvai">Paduodamas konteineris</param>
        /// <returns>Suskaičiuotus gamintojus</returns>
        Saldytuvu_konteineris Nesikartoja(Saldytuvu_konteineris saldytuvai)
        {
            Saldytuvu_konteineris tiks = new Saldytuvu_konteineris(100);
            for (int a = 0; saldytuvai.Kiekis > a; a++)
            {
                bool contains = false;
                for (int i = 0; i < tiks.Kiekis; i++)
                {
                    if (tiks.GautiŠaldytuvą(i).Gamintojas == saldytuvai.GautiŠaldytuvą(a).Gamintojas)
                    {
                        contains = true;
                        break;
                    }
                }
                if (!contains)
                {
                    tiks.PridėtiŠaldytuvą(saldytuvai.GautiŠaldytuvą(a));
                }
            }
            return tiks;
        }
        /// <summary>
        /// Spausdinu TikTen.csv
        /// </summary>
        /// <param name="tikten">Tik toje parduotuvėje konteineris</param>
        void Spausdinti(Branch_Konteineris tikten)
        {
            using (StreamWriter sw = new StreamWriter(@"TikTen.csv", false))
            {
                for (int a = 0; tikten.Kiekis > a; a++)
                {
                    for (int b = 0; tikten.GautiBranch(a).Saldytuvai.Kiekis > b; b++)
                    sw.WriteLine("{0};{1}", tikten.GautiBranch(a).Saldytuvai.GautiŠaldytuvą(b).Gamintojas, tikten.GautiBranch(a).Pav);
                }
            }
        }
        /// <summary>
        /// Surandame šaldytuvus kuriuos galima įsigyti tik vienoje parduotuvėje
        /// </summary>
        /// <param name="branch">Branch konteineris</param>
        /// <returns>Konteinerį</returns>
        Branch_Konteineris TikTen(Branch_Konteineris branch)
        {
            Branch_Konteineris Tik = new Branch_Konteineris(100);
            for (int a = 0;  branch.Kiekis > a; a++)
            {
                for (int b = 0; branch.GautiBranch(a).Saldytuvai.Kiekis > b; b++)
                {
                    bool Netinka = false;
                    bool Ne = false;
                    for (int c = 0; branch.Kiekis > c; c++)
                    {
                        for (int d = 0; branch.GautiBranch(c).Saldytuvai.Kiekis > d; d++)
                        {
                            if (branch.GautiBranch(a).Saldytuvai.GautiŠaldytuvą(b).Gamintojas == branch.GautiBranch(c).Saldytuvai.GautiŠaldytuvą(d).Gamintojas &&
                                        branch.GautiBranch(a).Pav != branch.GautiBranch(c).Pav)
                            {
                                Netinka = true;
                                break;
                            }
                        }
                    }
                    if (Netinka == false)
                    {
                        if (Tik.Kiekis > 0)
                        {
                            for (int i = 0; Tik.Kiekis > i; i++)
                            {
                                for (int y = 0; Tik.GautiBranch(i).Saldytuvai.Kiekis >y; y++)
                                {
                                    if (branch.GautiBranch(a).Saldytuvai.GautiŠaldytuvą(b).Gamintojas ==
                                        Tik.GautiBranch(i).Saldytuvai.GautiŠaldytuvą(y).Gamintojas)
                                    {
                                        Ne = true;
                                    }
                                }

                            }
                        }
                        if (Ne == false)
                        {
                            Branch branches = new Branch(branch.GautiBranch(a).Pav, null, null);
                            Tik.PridėtiBranch(branches);
                            branches.Saldytuvai.PridėtiŠaldytuvą(branch.GautiBranch(a).Saldytuvai.GautiŠaldytuvą(b));
                        }
                    }
                }
            }
            return Tik;
        }
    }
}
