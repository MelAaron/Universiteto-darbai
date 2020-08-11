using System;
using System.Collections.Generic;
using System.IO;

namespace _1_Laboratorinis
{
    class Program
    {
        void Main2()
        {
            List<Fantasy> herojai = Nuskaitymas();

            DuomenuFailas(herojai);

            //Pirmas punktas
            int stipriausioSk = Stipriausias(herojai);
            StipriausiuSpausdinimas(herojai, stipriausioSk);

            //Antras punktas
            List<Fantasy> r = DazniausiosRasesv2(herojai);
            string dazniausiaRase = DazniausiaRaseTest(r);
            List<Fantasy> dazniausi = DazniausiuVarduAtrinkimas(herojai, dazniausiaRase);
            SpausdiniTest(dazniausiaRase, dazniausi);

            //Trecias punktas
            List<Fantasy> a = ElfuRadimas(herojai);
            ElfuSpausdinimas(a);

            //Ketvirtas punktas
            List<Fantasy> b = TankuRadimas(herojai);
            TankuSpausdinimas(b);

        }
        static void Main(string[] args)
        {
            Program p = new Program();
            p.Main2();
        }
        /// <summary>
        /// Nuskaito duomenis is failo,
        /// paskirsto eilutes i duomenis
        /// </summary>
        /// <returns>grazina sukurta list'a</returns>
        List<Fantasy> Nuskaitymas()
        {
            List<Fantasy> herojai = new List<Fantasy>();
            string[] lines = File.ReadAllLines(@"Duomenys1.csv");
            foreach (string line in lines)
            {
                string[] values = line.Split(';');
                string vardas = values[0];
                string rase = values[1];
                string klase = values[2];
                int gyvybestaskai = int.Parse(values[3]);
                int mana = int.Parse(values[4]);
                int zalostaskai = int.Parse(values[5]);
                int gynybostaksai = int.Parse(values[6]);
                int jega = int.Parse(values[7]);
                int vikrumas = int.Parse(values[8]);
                int intelektas = int.Parse(values[9]);
                string ypatingagalia = values[10];
                Fantasy herojus = new Fantasy(vardas, rase, klase, gyvybestaskai, mana, zalostaskai, gynybostaksai, jega, vikrumas, intelektas, ypatingagalia);
                herojai.Add(herojus);
            }
            return herojai;
        }
        /// <summary>
        /// Spausdina pradinius duomenis lentele
        /// </summary>
        /// <param name="herojai">heroju duomenu list</param>
        public void DuomenuFailas(List<Fantasy> herojai)
        {
                int j = 1;
                string[] lines = new string[herojai.Count + 1];
                lines[0] = String.Format("|{0, -15}|{1, -7}|{2, -10}|{3, -15}|{4, -5}|{5, -13}|{6, -15}|{7, -5}|{8, -9}|{9, -11}|{10, -24}|", "Vardas", "Rase", "Klase", "Gyvybes Taskai", "Mana", "Zalos Taskai", "Gynybos Taskai", "Jega", "Vikrumas", "Intelektas", "Ypatinga Galia");
                for (int i = 0; i < herojai.Count; i++)
                {
                    
                    lines[j] = String.Format("|{0, -15}|{1, -7}|{2, -10}|{3, -15}|{4, -5}|{5, -13}|{6, -15}|{7, -5}|{8, -9}|{9, -11}|{10, -24}|", herojai[i].Vardas, herojai[i].Rase, herojai[i].Klase, herojai[i].GyvybesTaskai, herojai[i].Mana, herojai[i].ZalosTaskai, herojai[i].GynybosTaskai, herojai[i].Jega, herojai[i].Vikrumas, herojai[i].Intelektas, herojai[i].YpatingaGalia);
                    j++;
                }
                File.WriteAllLines(@"Duomenys.txt", lines);
        }

        /// <summary>
        /// Stipriausio herojaus skaiciaus List'e radimas
        /// </summary>
        /// <param name="herojai">heroju duomenu list</param>
        /// <returns> Grazina stipriausio herojaus skaiciu list'e </returns>
        int Stipriausias(List<Fantasy> herojai)
        {
            int stiprumas = herojai[0].Jega + herojai[0].Vikrumas + herojai[0].Intelektas;
            int stipriausioSk = 0;
            int max = stiprumas;

            for (int i = 0; i < herojai.Count; i++)
            {
                stiprumas = herojai[i].Jega + herojai[i].Vikrumas + herojai[i].Intelektas;
                if (stiprumas > max)
                {
                    max = stiprumas;
                    stipriausioSk = i; // suzinomas stipriausio herojaus skaicius List'e
                }
            }
            return stipriausioSk;
        }
        /// <summary>
        /// Consolėje spausdinamas stipriausias herojus pagal zinoma jo skaiciu list'e
        /// </summary>
        /// <param name="herojai">heroju duomenu list</param>
        /// <param name="stipriausioSk">stipriausio herojaus indeksas</param>
        public void StipriausiuSpausdinimas(List<Fantasy> herojai, int stipriausioSk)
        {
            Console.WriteLine("Stipriausias herojus yra: ");
            Console.WriteLine("---------------------------------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("|{0, -15}|{1, -7}|{2, -10}|{3, -15}|{4, -5}|{5, -13}|{6, -15}|{7, -5}|{8, -9}|{9, -11}|{10, -24}|", "Vardas", "Rase", "Klase", "Gyvybes Taskai", "Mana", "Zalos Taskai", "Gynybos Taskai", "Jega", "Vikrumas", "Intelektas", "Ypatinga Galia");
            Console.WriteLine("---------------------------------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("|{0, -15}|{1, -7}|{2, -10}|{3, -15}|{4, -5}|{5, -13}|{6, -15}|{7, -5}|{8, -9}|{9, -11}|{10, -24}|", herojai[stipriausioSk].Vardas, herojai[stipriausioSk].Rase, herojai[stipriausioSk].Klase, herojai[stipriausioSk].GyvybesTaskai, herojai[stipriausioSk].Mana, herojai[stipriausioSk].ZalosTaskai, herojai[stipriausioSk].GynybosTaskai, herojai[stipriausioSk].Jega, herojai[stipriausioSk].Vikrumas, herojai[stipriausioSk].Intelektas, herojai[stipriausioSk].YpatingaGalia);
            Console.WriteLine("---------------------------------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("");
        }

        /// <summary>
        /// Sukuriamas naujas list'as, kuriame yra suzinoma kiek kiiekviena rasė turi herojų
        /// </summary>
        /// <param name="herojai">heroju duomenu list</param>
        /// <returns>Gražina kiekvienos rasės herojų skaičių ir tos rasės pavadinimą </returns>
        public List<Fantasy> DazniausiosRasesv2(List<Fantasy> herojai)
        {
            List<Fantasy> unikalus_herojai = new List<Fantasy>();
            Fantasy rastas_h; // rastas herojus sarase
            

            for (int i = 0; i < herojai.Count; i++)
            {
                rastas_h = null;
                for (int j = 0; j < unikalus_herojai.Count; ++j) // ieskome sarase unikalus_herojai ar toks jau herojus yra
                {
                    if (unikalus_herojai[j].Rase.CompareTo(herojai[i].Rase) == 0)
                    {
                        rastas_h = unikalus_herojai[j];
                        break;
                    }

                }
                    if (rastas_h == null) // tokios rases nera, pridedame elementą į sarašą
                    {
                        rastas_h = new Fantasy(herojai[i].Rase);
                        unikalus_herojai.Add(rastas_h);
                    }
                rastas_h.Skaitkliukas += 1;

            }
            return unikalus_herojai;
        }
        /// <summary>
        /// Tikriname kurios rasės herojų daugiausia
        /// </summary>
        /// <param name="unikalus_herojai">rasiu ir ju pasikartojimo list</param>
        /// <returns>Gražinamas dažniausios rasės pavadinimas</returns>
        public string DazniausiaRaseTest(List<Fantasy> unikalus_herojai)
        {

            string dazniausia_r = unikalus_herojai[0].Rase; //Tikriname kurios rasės herojų yra daugiausia
            int max = unikalus_herojai[0].Skaitkliukas;
            for (int u = 0; u < unikalus_herojai.Count; u++)
            {
                if (unikalus_herojai[u].Skaitkliukas > max)
                {
                    dazniausia_r = unikalus_herojai[u].Rase;
                    max = unikalus_herojai[u].Skaitkliukas;
                }
            }
            return dazniausia_r;
        }
        /// <summary>
        /// Į naują list'ą įdedami visi dažniausios rasės herojų vardai
        /// </summary>
        /// <param name="herojai">visu heroju list</param>
        /// <param name="dazniausia_r">dazniausios rases pavadinimas</param>
        /// <returns>Gražinamas vardų list'as</returns>
        public List<Fantasy> DazniausiuVarduAtrinkimas(List<Fantasy> herojai, string dazniausia_r)
        {
            List<Fantasy> vardai = new List<Fantasy>();
            for (int i = 0; i < herojai.Count; i++)
            {
                if (herojai[i].Rase == dazniausia_r) //Jei herojaus rasė sutampa su dažniausia rase, jo vardas pridedamas į vardų list'ą
                {
                    vardai.Add(herojai[i]);
                }
            }
            return vardai;
        }
        /// <summary>
        /// Spausdinamas dažniausios rasės pavadinimas ir visi tos rasės herojų vardai
        /// </summary>
        /// <param name="dazniausiaRase">dazniausios rases pavadinimas</param>
        /// <param name="dazniausiuVardai">dazniauiu rasiu list</param>
        public void SpausdiniTest(string dazniausiaRase, List<Fantasy> dazniausiuVardai)
        {
            Console.WriteLine("Dazniausia rase: " + dazniausiaRase);
            Console.WriteLine("---------------------------------");
            Console.WriteLine("|Dazniausios rases heroju vardai|");
            Console.WriteLine("---------------------------------");
            foreach (var herojus in dazniausiuVardai)
            {
                Console.WriteLine("|{0, -31}|", herojus.Vardas);
                Console.WriteLine("---------------------------------");
            }
        }

        /// <summary>
        /// Einama per herojų sarašą ir ieškoma elfų. Elfai įrašomi į naują list'ą
        /// </summary>
        /// <param name="herojai">heroju duomenu list</param>
        /// <returns>Gražinamas sukurtas elfų list'as</returns>
        public List<Fantasy> ElfuRadimas(List<Fantasy> herojai)
        {
            List<Fantasy> Elfai = new List<Fantasy>();
            

            for (int i = 0; i < herojai.Count; i++) // einama per visą herojų list'ą
            {
                if (herojai[i].Rase == "Elfas") // jei herojus yra elfas jis įrašomas į elfų sarašą
                {
                    Elfai.Add(herojai[i]);
                }
            }
            return Elfai;
        }
        /// <summary>
        /// Į failą "Elfai.csv" įrašomi elfai iš elfų list'o
        /// </summary>
        /// <param name="Elfai">tik elfu listas</param>
        public void ElfuSpausdinimas(List<Fantasy> Elfai)
        {
            if (Elfai.Count != 0)
            {
                int j = 1;
                string[] lines = new string[Elfai.Count + 1];
                lines[0] = String.Format("Vardas; Rase; Klase; Gyvybes Taskai; Mana; Zalos Taskai; Gynybos Taskai; Jega; Vikrumas; Intelektas; Ypatinga Galia");
                for (int i = 0; i < Elfai.Count; i++)
                {
                    lines[j] = String.Format("{0};{1};{2};{3};{4};{5};{6};{7};{8};{9};{10}", Elfai[i].Vardas, Elfai[i].Rase, Elfai[i].Klase, Elfai[i].GyvybesTaskai, Elfai[i].Mana, Elfai[i].ZalosTaskai, Elfai[i].GynybosTaskai, Elfai[i].Jega, Elfai[i].Vikrumas, Elfai[i].Intelektas, Elfai[i].YpatingaGalia);
                    j++;
                }
                File.WriteAllLines(@"Elfai.csv", lines);
            }
            else
                File.WriteAllText(@"Elfai.csv", "Elfu Nera");

            
        }

        /// <summary>
        /// Einama per herojų sarašą ir tikrina kiekvieno herojaus charakteristikas.
        /// Jei jos atitinka tanko charakteristikas, herojus pridedamas į tankų sarašą
        /// </summary>
        /// <param name="herojai">heroju duomenu listas</param>
        /// <returns>Gražina tankų list'ą</returns>
        public List<Fantasy> TankuRadimas(List<Fantasy> herojai)
        {
            List<Fantasy> Tankai = new List<Fantasy>();
            

            for (int i = 0; i < herojai.Count; i++) //Einama per visą herojų list'ą
            {
                if ((herojai[i].GyvybesTaskai >= 100)&&(herojai[i].GynybosTaskai >= 30)) //jei herojaus charakteristikos atitinka tanko apibūdinimą,
                {
                    Tankai.Add(herojai[i]); //herojus įrašomas į tankų listą
                }
            }
            return Tankai;
        }
        /// <summary>
        /// Į failą "Tankai.csv" įrašomi tankai iš tankų list'o
        /// </summary>
        /// <param name="Tankai">tanku duomenu listas</param>
        public void TankuSpausdinimas(List<Fantasy> Tankai)
        {
            if (Tankai.Count != 0)
            {
                int j = 1;
                string[] lines = new string[Tankai.Count + 1];
                lines[0] = String.Format("Vardas; Klase; Rase; Ypatinga Galia");
                for (int i = 0; i < Tankai.Count; i++)
                {
                    lines[j] = String.Format("{0};{1};{2};{3}", Tankai[i].Vardas, Tankai[i].Klase, Tankai[i].Rase, Tankai[i].YpatingaGalia);
                    j++;
                }
                File.WriteAllLines(@"Tankai.csv", lines);
            }
            else
                File.WriteAllText(@"Tankai.csv", "Tanku nera");
        }

    }
}