using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _3_Laboras
{
    class Program
    {
        public const int MaxBranchNr = 3;
        public const int MaxPrietaisuSk = 20;
        static void Main(string[] args)
        {
            Program p = new Program();

            BranchuKonteineris branches = p.BranchuKonteinerioSukurimas();
            p.PradiniaiDuomenys(branches, "Duomenys.txt");

            //Pirmas Punktas
            p.SiemensProduktai(branches);

            //Antras Punktas
            var Saldytuvai = p.SaldytuvuSarasas(branches);
            Saldytuvai.RusiuotiPrietaisus();
            p.TinkamuSaldytuvuS(Saldytuvai);

            //Trecias Punktas
            var APlius = p.EnergijosKlase(branches);
            p.SpausdinimasIFaila(APlius, "A+.csv");

            //Ketvirtas Punktas
            var Nesikartoja = p.KurieNesikartoja(branches);
            p.SpausdinimasIFaila(Nesikartoja, "TikTen.csv");

            Console.ReadLine();
            
        }

        /// <summary>
        /// Pradiniai duomenys lentele txt faile
        /// </summary>
        /// <param name="branch">visa parduotuviu informacija</param>
        /// <param name="file">failo vieta</param>
        private void PradiniaiDuomenys(BranchuKonteineris branch, string file)
        {
            using (StreamWriter sw = new StreamWriter(@file, false))
            {
                for (int i = 0; i < branch.Count; i++)
                {
                    sw.WriteLine("--------------------------------------------------------");
                    sw.WriteLine("{0} {1} {2}", branch.GautiBrancha(i).Pavadinimas, branch.GautiBrancha(i).Adresas, branch.GautiBrancha(i).Telefonas);
                    sw.WriteLine("--------------------------------------------------------");
                    //SpausdinimasIFaila(branch.GautiBrancha(i).Saldytuvai, file);
                    //SpausdinimasIFaila(branch.GautiBrancha(i).MikrobanguKrosneles, file);
                    //SpausdinimasIFaila(branch.GautiBrancha(i).ElektriniaiViduliai, file);

                    sw.WriteLine("Saldytuvai");
                    sw.WriteLine("Gamintojas Modelis  E. Tipas  Spalva     Kaina  Talpa   Montavimo Tipas Saldiklis Aukstis Plotis Gylis");
                    for (int j = 0; j < branch.GautiBrancha(i).Saldytuvai.Count; j++)
                    {
                        sw.WriteLine(branch.GautiBrancha(i).Saldytuvai.GautiPrietaisa(j).ToString());
                    }
                    sw.WriteLine();

                    sw.WriteLine("Mikrobangu Krosneles");
                    sw.WriteLine("Gamintojas Modelis   E.  Tipas  Spalva  Kaina  Galingumas Programu Sk.");
                    for (int j = 0; j < branch.GautiBrancha(i).MikrobanguKrosneles.Count; j++)
                    {
                        sw.WriteLine(branch.GautiBrancha(i).MikrobanguKrosneles.GautiPrietaisa(j).ToString());
                    }
                    sw.WriteLine();

                    sw.WriteLine("Elektriniai Virduliai");
                    sw.WriteLine("Gamintojas Modelis   E.  Tipas  Spalva  Kaina Galia Turis");
                    for (int j = 0; j < branch.GautiBrancha(i).ElektriniaiViduliai.Count; j++)
                    {
                        sw.WriteLine(branch.GautiBrancha(i).ElektriniaiViduliai.GautiPrietaisa(j).ToString());
                    }
                    sw.WriteLine();
                }
            }
        }

        /// <summary>
        /// Iesko prietaisu, kurie nesikartoja ir juos iraso i nauja prietaisu konteineri
        /// </summary>
        /// <param name="Parduotuves">parduotuviu informacija</param>
        /// <returns>nesikartojanciu prietaisu konteineris</returns>
        private PrietaisuKonteineris KurieNesikartoja(BranchuKonteineris Parduotuves)
        {
            PrietaisuKonteineris Nauji = new PrietaisuKonteineris();

            for(int i = 0; i < Parduotuves.Count; i++)
            {
                for(int j = 0; j < Parduotuves.GautiBrancha(i).Saldytuvai.Count; j++)
                {
                    if (!AryYraParduotuvese(Parduotuves, i, Parduotuves.GautiBrancha(i).Saldytuvai.GautiPrietaisa(j), Nauji))
                    {
                        Nauji.PridetiPrietaisa(Parduotuves.GautiBrancha(i).Saldytuvai.GautiPrietaisa(j));
                    }
                }
                for (int j = 0; j < Parduotuves.GautiBrancha(i).MikrobanguKrosneles.Count; j++)
                {
                    if (!AryYraParduotuvese(Parduotuves, i, Parduotuves.GautiBrancha(i).MikrobanguKrosneles.GautiPrietaisa(j), Nauji))
                    {
                        Nauji.PridetiPrietaisa(Parduotuves.GautiBrancha(i).MikrobanguKrosneles.GautiPrietaisa(j));
                    }
                }
                for (int j = 0; j < Parduotuves.GautiBrancha(i).ElektriniaiViduliai.Count; j++)
                {
                    if (!AryYraParduotuvese(Parduotuves, i, Parduotuves.GautiBrancha(i).ElektriniaiViduliai.GautiPrietaisa(j), Nauji))
                    {
                        Nauji.PridetiPrietaisa(Parduotuves.GautiBrancha(i).ElektriniaiViduliai.GautiPrietaisa(j));
                    }
                }
            }
            return Nauji;
        }

        /// <summary>
        /// Tikrina ar kiekviena parduotuve turi tikrinama prietaisa
        /// </summary>
        /// <param name="Parduotuves">parduotuviu informacija</param>
        /// <param name="ind">tikrinamo prietaiso vieta konteineryje</param>
        /// <param name="prietaisas">prietaiso informacija</param>
        /// <returns>true arba false(yra arba nera)</returns>
        bool AryYraParduotuvese(BranchuKonteineris Parduotuves, int ind, BuitinisPrietaisas prietaisas, PrietaisuKonteineris nauji)
        {
            for(int i = ind + 1 ; i < Parduotuves.Count; i++)
            {
                if (Parduotuves.GautiBrancha(i).Saldytuvai.Contains(prietaisas) || (nauji.Contains(prietaisas)))
                    return true;
                if (Parduotuves.GautiBrancha(i).MikrobanguKrosneles.Contains(prietaisas) || (nauji.Contains(prietaisas)))
                    return true;
                if (Parduotuves.GautiBrancha(i).ElektriniaiViduliai.Contains(prietaisas) || (nauji.Contains(prietaisas)))
                    return true;
            }
            return false;
        }

        /// <summary>
        /// Spausdina pirmus 10 tinkamu saldytuvu
        /// </summary>
        /// <param name="saldytuvai">saldytuvu konteineris</param>
        private void TinkamuSaldytuvuS (PrietaisuKonteineris saldytuvai)
        {
            int skaicius = 0;
            //Saldytuvas saldyt = saldytuvai.GautiPrietaisa(i) as Saldytuvas;
            Console.WriteLine("Saldytuvai, kuriu talpa didesne uz 80 surusiuoti pagal kaina: ");
            Console.WriteLine();
            Console.WriteLine("Gamintojas Modelis   Talpa  Kaina");
            Console.WriteLine("---------------------------------");
            for (int i = 0; i < saldytuvai.Count; i++)
            {
                Saldytuvas saldyt = saldytuvai.GautiPrietaisa(i) as Saldytuvas;
                if (skaicius == 10)
                    break;
                Console.WriteLine("{0,-10} {1,-10} {2,-5} {3,-5}", saldytuvai.GautiPrietaisa(i).Gamintojas, saldytuvai.GautiPrietaisa(i).Modelis, saldyt.Talpa, saldytuvai.GautiPrietaisa(i).Kaina);
                Console.WriteLine("---------------------------------");
                skaicius++;
            }
        }

        /// <summary>
        /// is visu saldytuvu atrenka tinkamus ir kurie nesikartoja
        /// </summary>
        /// <param name="saldytuvai">sadytuvu konteineris</param>
        /// <param name="prietaisai">pildomas prietaisu konteineris</param>
        /// <returns>tinkamu saldytuvu sarasas</returns>
        private PrietaisuKonteineris TinkamiSaldytuvai (PrietaisuKonteineris saldytuvai, PrietaisuKonteineris prietaisai)
        {
            
            for (int i = 0; i < saldytuvai.Count; i++)
            {
                Saldytuvas saldyt = saldytuvai.GautiPrietaisa(i) as Saldytuvas;

                if ((saldyt.Talpa >= 80) && (saldyt.MontavimoTipas == "Pastatomas") && (!prietaisai.Contains(saldytuvai.GautiPrietaisa(i))))
                {
                    prietaisai.PridetiPrietaisa(saldytuvai.GautiPrietaisa(i));
                }
            }
            return prietaisai;
        }

        /// <summary>
        /// sukuria saldytuvu sarasa, kuriame yra visu parduotuviu saldytuvai
        /// </summary>
        /// <param name="branch">parduotuviu informacija</param>
        /// <returns>Visu saldytuvu sarasas</returns>
        private PrietaisuKonteineris SaldytuvuSarasas (BranchuKonteineris branch)
        {
            //branch.GautiBrancha(0).Saldytuvai.GautiPrietaisa(0).
            var prietaisai = new PrietaisuKonteineris();

            for (int i = 0; i < branch.Count; i++)
            {
                var S = branch.GautiBrancha(i).Saldytuvai;
                prietaisai = TinkamiSaldytuvai(S, prietaisai);

            }
            return prietaisai;
        }

        /// <summary>
        /// Spausdinima paduoto prietaiso konteinerio duomenis i paduoto failo pavadinima
        /// </summary>
        /// <param name="prietaisas">prietaisu konteineris, prietaisu informacija</param>
        /// <param name="fileName">failo pavadinimas</param>
        private void SpausdinimasIFaila (PrietaisuKonteineris prietaisas, string fileName)
        {
            int j = 1;

            using (StreamWriter sw = new StreamWriter(@fileName, false))
            {
                if (prietaisas.Count != 0)
                {
                    sw.WriteLine("Gamintojas, Modelis, Energijos Klase, Spalva, Kaina, Talpa/Galingumas/Galia, Montavimo t./Programu sk. /Turis, Saldiklis, Aukstis, Plotis, Gylis");
                    for (int i = 0; i < prietaisas.Count; i++)
                    {
                        sw.WriteLine("{0}", prietaisas.GautiPrietaisa(i).ToString());
                        j++;
                    }
                }
                else
                    sw.WriteLine("Prietaisu nera");
            }
        }

        /// <summary>
        /// sukuria konteineri prietaisu, kuriu energijos klase yra A+ arba didesne
        /// </summary>
        /// <param name="prietaisai">prietaisu informacija</param>
        /// <param name="aPlius">pildomas konteineris tinkamais prietaisais</param>
        /// <returns>Tinkamos energijos klases prietaisu konteineris</returns>
        private PrietaisuKonteineris PrietaisaiEK(PrietaisuKonteineris prietaisai, PrietaisuKonteineris aPlius)
        {

            for (int i = 0; i < prietaisai.Count; i++)
            {
                if ((prietaisai.GautiPrietaisa(i).EKlase == "A+") || (prietaisai.GautiPrietaisa(i).EKlase == "A++") || (prietaisai.GautiPrietaisa(i).EKlase == "A+++"))
                {
                    if(!aPlius.Contains(prietaisai.GautiPrietaisa(i)))
                    {
                        aPlius.PridetiPrietaisa(prietaisai.GautiPrietaisa(i));
                    }
                    //aPlius.PridetiPrietaisa(prietaisai.GautiPrietaisa(i));
                }
            }
            return aPlius;
        }

        /// <summary>
        /// Surenka visus prietaisus i viena konteineri
        /// </summary>
        /// <param name="branch">parduotuviu informacija</param>
        /// <returns>visu prietaisu konteineris</returns>
        private PrietaisuKonteineris EnergijosKlase (BranchuKonteineris branch)
        {
            var APlius = new PrietaisuKonteineris();
            for (int i = 0; i < branch.Count; i++)
            {
                var Saldytuvai = branch.GautiBrancha(i).Saldytuvai;
                APlius = PrietaisaiEK(Saldytuvai, APlius);

                var MikrobanguK = branch.GautiBrancha(i).MikrobanguKrosneles;
                APlius = PrietaisaiEK(MikrobanguK, APlius);

                var ElektrinisV = branch.GautiBrancha(i).ElektriniaiViduliai;
                APlius = PrietaisaiEK(ElektrinisV, APlius);

            }
            return APlius;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parduotuvesDuom">parduotuves duomenys</param>
        /// <param name="saldytuvuK">parduotuves saldytuvu kiekis</param>
        /// <param name="MikrobanguKK">parduotuves mikrobangu k. kiekis</param>
        /// <param name="eleVK">parduotuves elektriniu virduliu kiekis</param>
        private void SiemensSpausdinimas (string parduotuvesDuom, int saldytuvuK, int MikrobanguKK, int eleVK)
        {
            Console.WriteLine("{0}", parduotuvesDuom);
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("Siemens saldytuvu: {0}", saldytuvuK);
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("Siemens Mikrobangu K.: {0}", MikrobanguKK);
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("Siemens Elektriniu V.: {0}", eleVK);
            Console.WriteLine("----------------------------------------");
            Console.WriteLine();
        }

        /// <summary>
        /// Randa kiekvieno produkto tipo siemens produktu kieki, atspausdina atsakyma i konsole
        /// </summary>
        /// <param name="branch">parduotuviu informacija</param>
        private void SiemensProduktai(BranchuKonteineris branch)
        {
            for (int i = 0; i < branch.Count; i++)
            {
                string parduotuvesDuomenys = (branch.GautiBrancha(i).Pavadinimas + ", " + branch.GautiBrancha(i).Adresas + ", " + branch.GautiBrancha(i).Telefonas);

                var saldytuvai = branch.GautiBrancha(i).Saldytuvai;
                var siemensSaldytuvai = SiemensKiekis(saldytuvai);

                var mikrobanguK = branch.GautiBrancha(i).MikrobanguKrosneles;
                var siemensMikrobanguK = SiemensKiekis(mikrobanguK);
                
                var eleVirduliai = branch.GautiBrancha(i).ElektriniaiViduliai;
                var siemensEleVirduliai = SiemensKiekis(eleVirduliai);

                SiemensSpausdinimas(parduotuvesDuomenys, siemensSaldytuvai, siemensMikrobanguK, siemensEleVirduliai);
                
            }
        }

        /// <summary>
        /// Tikrina kiek siemens vieno produkto tipo turi
        /// </summary>
        /// <param name="prietaisai">simens produktu konteineris</param>
        /// <returns> siemens produkto tipo kieki</returns>
        private int SiemensKiekis (PrietaisuKonteineris prietaisai)
        {
            int kiekis = 0;
            for (int i = 0; i < prietaisai.Count; i++)
            {
                if (prietaisai.GautiPrietaisa(i).Gamintojas.Contains("Siemens"))
                {
                    kiekis++;
                }
            }
            return kiekis;
        }

        /// <summary>
        /// sukuria branchu konteineri, i ji iraso parduotuves ir prekiu duomenis
        /// </summary>
        /// <returns>Branchu konteineti</returns>
        private BranchuKonteineris BranchuKonteinerioSukurimas ()
        {
            string[] filePaths = Directory.GetFiles(Directory.GetCurrentDirectory(), "*Parduotuve.csv");
            var branchai = new BranchuKonteineris(MaxBranchNr);
            foreach (var path in filePaths)
            {
                Branch branch = null;
                bool rado = ParduotuviuDuomenuSkaitymas(path, ref branch, out string vardas, out string adresas, out string numeris);
                if (rado == false)
                {
                    Console.WriteLine("Nera Parduotuves");
                }
                //SausdintiBrancha(branch);
                branchai.PridetiBrancha(branch);
            }
            return branchai;
        }

        /// <summary>
        /// Nuskaito parduotuves ir jos prekiu duomenis
        /// </summary>
        /// <param name="path">failo vardas</param>
        /// <param name="branchai">naujas issisakojimas (parduotuve)</param>
        /// <param name="pavadinimas">parduotuves pavadinimas</param>
        /// <param name="adresas">parduotuves adresas</param>
        /// <param name="numeris">parduotuves telefono nr</param>
        /// <returns></returns>
        public bool ParduotuviuDuomenuSkaitymas(string path, ref Branch branchai, out string pavadinimas, out string adresas, out string numeris)
        {
            using (StreamReader sr = new StreamReader(path))
            {
                string line = null;
                pavadinimas = sr.ReadLine();
                adresas = sr.ReadLine();
                numeris = sr.ReadLine();
                line = pavadinimas;
                if (line == null)
                    return false;
                branchai = new Branch(pavadinimas, adresas, numeris);
                while(null != (line = sr.ReadLine()))
                {
                    string[] values = line.Split(';');
                    char type = line[0];
                    string gamintojas = values[1];
                    string modelis = values[2];
                    string eneKlase = values[3];
                    string spalva = values[4];
                    double kaina = double.Parse(values[5]);

                    switch(type)
                    {
                        case 'S':
                            int talpa = int.Parse(values[6]);
                            string montavimoTipas = values[7];
                            bool saldiklis = bool.Parse(values[8]);
                            double aukstis = double.Parse(values[9]);
                            double plotis = double.Parse(values[10]);
                            double gylis = double.Parse(values[11]);
                            Saldytuvas saldytuvas = new Saldytuvas(gamintojas, modelis, eneKlase, spalva, kaina, talpa, montavimoTipas, saldiklis, aukstis, plotis, gylis);
                            if (!branchai.Saldytuvai.Contains(saldytuvas))
                            {
                                branchai.PridetiSaldytuva(saldytuvas);
                            }
                            //branchai.PridetiSaldytuva(saldytuvas);
                            break;

                        case 'M':
                            int galingumas = int.Parse(values[6]);
                            int progSkaicius = int.Parse(values[7]);
                            MikrobanguKrosnele mKrosnele = new MikrobanguKrosnele(gamintojas, modelis, eneKlase, spalva, kaina, galingumas, progSkaicius);
                            if (!branchai.MikrobanguKrosneles.Contains(mKrosnele))
                            {
                                branchai.PridetiMikrobanguKr(mKrosnele);
                            }
                            //branchai.PridetiMikrobanguKr(mKrosnele);
                            break;

                        case 'E':
                            int galia = int.Parse(values[6]);
                            int turis = int.Parse(values[7]);
                            ElektrinisVidrulys eVirdulys = new ElektrinisVidrulys(gamintojas, modelis, eneKlase, spalva, kaina, galia, turis);
                            if (!branchai.ElektriniaiViduliai.Contains(eVirdulys))
                            {
                                branchai.PridetiElektriniVir(eVirdulys);
                            }
                            //branchai.PridetiElektriniVir(eVirdulys);
                            break;
                    }
                }
                return true;
            }
        }
    }
}
