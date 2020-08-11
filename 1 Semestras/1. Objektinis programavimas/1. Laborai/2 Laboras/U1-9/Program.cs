using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace U1_9
{
    class Program
    {
        /// <summary>
        /// Duomenų nuskaitymas ir sudėjimas į sarašą
        /// </summary>
        /// <returns>Struktūrinį sąrašą</returns>
        List<Sąrašas> Skaitymas()
        {
            List<Sąrašas> sąrašas = new List<Sąrašas>();
            string[] eilutes = File.ReadAllLines(@"Duota.csv");
            foreach (string eilute in eilutes)
            {
                string[] duomuo = eilute.Split(';');
                string filmas = duomuo[0];
                int metai = int.Parse(duomuo[1]);
                string zanras = duomuo[2];
                string studija = duomuo[3];
                string rezisieriausvardas = duomuo[4];
                string rezisieriauspavarde = duomuo[5];
                string aktorius1 = duomuo[6];
                string aktorius2 = duomuo[7];
                double pajamos = Convert.ToDouble(duomuo[8]);
                //Sukuriamas šalutinis sąrašas, kuriame pridedame nuskaitytus duomenis
                Sąrašas surašymas = new Sąrašas(filmas, metai, zanras, studija,
                    rezisieriausvardas, rezisieriauspavarde, aktorius1, aktorius2, pajamos);
                //Sąrašą išsaugojame ir įdedame į struktūrinį sąrašą
                sąrašas.Add(surašymas);
            }
            return sąrašas;
        }
        /// <summary>
        /// Ieškome didžiausių pajamų
        /// </summary>
        /// <param name="sąrašas">Visų filmų sąrašas</param>
        /// <returns>Pelningiausio filmo suma</returns>
        double Pelningas(List<Sąrašas> sąrašas)
        {
            double pelningas = 0;
            foreach (Sąrašas sąraš in sąrašas)
            {
                if (sąraš.Pajamos > pelningas && sąraš.Metai == 2014)
                {
                    pelningas = sąraš.Pajamos;
                }
            }
            return pelningas;
        }
        /// <summary>
        /// Suradus didžiausias pajamas, išsaugojame filmus, kurios yra pelningiausios
        /// </summary>
        /// <param name="sąrašas">Visų filmų sąrašas</param>
        /// <param name="Pelningas">Pelningiausio filmo suma</param>
        /// <returns>Pelningiausius filmus</returns>
        List<Sąrašas> Pelningiausias(List<Sąrašas> sąrašas, double Pelningas)
        {
            List<Sąrašas> Pelningasis = new List<Sąrašas>();
            foreach (Sąrašas sąraš in sąrašas)
            {
                if (Pelningas == sąraš.Pajamos)
                {
                    Pelningasis.Add(sąraš);
                }
            }
            return Pelningasis;
        }
        /// <summary>
        /// Surandame filmus, kuriuose vaidino Nicolas Cage
        /// </summary>
        /// <param name="sąrašas">Visų filmų sąrašas</param>
        /// <returns>Filmai kuriuose vaidino Nicolas Cage</returns>
        List<Sąrašas> Cage(List<Sąrašas> sąrašas)
        {
            List<Sąrašas> Nicolas = new List<Sąrašas>();
            foreach (Sąrašas sąraš in sąrašas)
            {
                if (sąraš.Aktorius1 == "N. Cage" || sąraš.Aktorius2 == "N. Cage")
                {
                    Nicolas.Add(sąraš);
                }
            }
            return Nicolas;
        }
        /// <summary>
        /// Randame visus žanrus
        /// </summary>
        /// <param name="sąrašas">Visų filmų sąrašas</param>
        /// <returns>Visi filmų žanrai iš sąrašo</returns>
        List<Sąrašas> Zanrai(List<Sąrašas> sąrašas)
        {
            List<Sąrašas> zanrai = new List<Sąrašas>();
            foreach (Sąrašas saras in sąrašas)
            {
                bool Nera = true;
                foreach (Sąrašas zan in zanrai)
                {
                    if (saras.Zanras == zan.Zanras)
                    {
                        Nera = false;
                        break;
                    }
                }
                if (Nera)
                {
                    zanrai.Add(saras);
                }
            }
            return zanrai;
        }
        /// <summary>
        /// Rašome į koncolę pelningiausius filmus
        /// </summary>
        /// <param name="Pelningiausias">Pelningiausi filmai</param>
        /// <param name="Zanrai">Visi filmų žanrai iš sąrašo</param>
        void Rasymas(List<Sąrašas> Pelningiausias, List<Sąrašas> Zanrai)
        {
            Console.WriteLine("Pelningiausi(-as) filma(-i)(-as)");
            foreach (Sąrašas Peln in Pelningiausias)
            {
                Console.WriteLine(Peln.Filmas, "; Režisierius: ", Peln.RezisieriausVardas, " ",
                    Peln.RezisieriausPavarde, "; Pajamos: ", Peln.Pajamos);
            }
        }
        /// <summary>
        /// Surandame daugiausiai filmų pastačius(-į)(ius) režisieriu(-s)
        /// </summary>
        /// <param name="vardai">Režisierių vardai</param>
        /// <param name="pavardes">Režisierių pavardes</param>
        /// <param name="Kiek">Kiek filmų surežisuota</param>
        /// <param name="sąrašas">Visų filmų sąrašas</param>
        void DaugSkaiciavimai(string[] vardai, string[] pavardes, int[] Kiek, List<Sąrašas> sąrašas)
        {
            int kiekis = 0;
            foreach (Sąrašas sąraš in sąrašas)
            {
                bool yra = true;
                for (int i = 0; i < kiekis; i++)
                {
                    if (vardai[i] == sąraš.RezisieriausVardas && pavardes[i] == sąraš.RezisieriausPavarde)
                    {
                        yra = false;
                        Kiek[i]++;
                        break;
                    }
                }
                if (yra)
                {
                    vardai[kiekis] = sąraš.RezisieriausVardas;
                    pavardes[kiekis] = sąraš.RezisieriausPavarde;
                    Kiek[kiekis] = 1;
                    kiekis++;
                }
            }
        }
        /// <summary>
        /// Surašom visus žanrus į failą
        /// </summary>
        /// <param name="Zanrai">Visi filmų žanrai iš sąrašo</param>
        void ZanrasRasymas(List<Sąrašas> Zanrai)
        {
            using (StreamWriter sw = new StreamWriter("Žanrai.csv", false))
            {
                foreach (Sąrašas zan in Zanrai)
                {
                    sw.WriteLine(zan.Zanras);
                }
            }
        }
        /// <summary>
        /// Surašom visus filmus kuriuose vaidino Nicolas Cage
        /// </summary>
        /// <param name="Nicolas">Nicolo Cage vaidinti filmai</param>
        void CageRasymas(List<Sąrašas> Nicolas)
        {
            using (StreamWriter sw = new StreamWriter("Cage.csv", false))
            {
                foreach (Sąrašas nic in Nicolas)
                {
                    sw.WriteLine(nic.Filmas + "; " + nic.Metai + "; " + nic.Studija + "; ");
                }
            }
        }
        /// <summary>
        /// Radimas kelintas režisierius daugiausiai surežisavo filmų
        /// </summary>
        /// <param name="vardai">Režisierių vardai</param>
        /// <param name="pavardes">Režisierių pavardė</param>
        /// <param name="Kiek">Kiek surežisuota filmų</param>
        /// <returns>Indeksą</returns>
        int Indeksas(string[] vardai, string[] pavardes, int[] Kiek)
        {

            int ind = 0;
            for (int i = 1; i < Kiek.Length; i++)
            {
                if (Kiek[i] > Kiek[ind])
                {
                    ind = i;
                }
            }
            return ind;
        }
        /// <summary>
        /// Į koncolę spausdinamas režisierius kuris surežisavo daugiausiai filmų
        /// </summary>
        /// <param name="vardai">Režisieriaus vardas</param>
        /// <param name="pavardes">Režisieriaus pavardė</param>
        /// <param name="Kiek">Kiek filmų surežisuota</param>
        void Spausdinimas(string vardai, string pavardes, int Kiek)
        {
            Console.WriteLine("Daugiausiai filmų pastatęs:");
            Console.WriteLine("");
            Console.WriteLine("Režisieriaus vardas: " + vardai);
            Console.WriteLine("Režisieriaus pavardė: " + pavardes);
            Console.WriteLine("Kiek filmų surežisuota: " + Kiek);
            Console.WriteLine("");
            Console.WriteLine("");
        }
        /// <summary>
        /// Metodas skirtas spausdinti pradinius duomenis lentelėje
        /// </summary>
        /// <param name="sąrašas">Visų filmų sąrašas</param>
        void SpausdinamPradiniusDuomenis(List<Sąrašas> sąrašas)
        {
            using (StreamWriter sw = new StreamWriter("duomenys.txt"))
            {
                sw.WriteLine("-----------------------------------------" +
                    "--------------------------------------------------" +
                    "--------------------------------------------------" +
                    "--------------------------------------------------" +
                    "------------------");
                sw.WriteLine("{0, -10} | {1, -8} | {2, -15} | {3, -15}" +
                    " | {4, -21} | {5, -19} | {6, -15} | {7, -15} | {8, -15}",
                    "Filmas", "Metai", "Žanras",
                    "Studija", "Režisieriaus Vardas", "Režisierius Pavardė",
                    "1 Aktorius", "2 Aktorius", "Pajamos");
                sw.WriteLine("-----------------------------------------" +
                    "--------------------------------------------------" +
                    "--------------------------------------------------" +
                    "--------------------------------------------------" +
                    "------------------");

                for (int i = 0; i < sąrašas.Count; i++)
                {
                    sw.WriteLine("{0, -10} | {1, -8} | {2, -15} | {3, -15}" +
                        " | {4, -21} | {5, -19} | {6, -15} | {7, -15} | {8, -25}",
                        sąrašas[i].Filmas, sąrašas[i].Metai, sąrašas[i].Zanras,
                    sąrašas[i].Studija, sąrašas[i].RezisieriausVardas,
                    sąrašas[i].RezisieriausPavarde, sąrašas[i].Aktorius1,
                    sąrašas[i].Aktorius2, sąrašas[i].Pajamos);
                }
                sw.WriteLine("------------------------------------------" +
                    "---------------------------------------------------" +
                    "--------------------------------------------------" +
                    "--------------------------------------------------" +
                    "----------------");
            }
        }

        public const int MaxFilmuSk = 500;
        public const int MaxBranchSk = 3;
        static void Main(string[] args)
        {
            //--------------------------1Lab---------------------------
            Program p = new Program();
            //List<Sąrašas> sąrašas = p.Skaitymas();
            //List<Sąrašas> Pelningasis = p.Pelningiausias(sąrašas, p.Pelningas(sąrašas));
            //string[] vardai = new string[99999];
            //string[] pavardes = new string[99999];
            //int[] Kiek = new int[99999];
            //p.DaugSkaiciavimai(vardai, pavardes, Kiek, sąrašas);
            //int ind = p.Indeksas(vardai, pavardes, Kiek);
            //p.Spausdinimas(vardai[ind], pavardes[ind], Kiek[ind]);
            //List<Sąrašas> Nicolas = p.Cage(sąrašas);
            //List<Sąrašas> Zanras = p.Zanrai(sąrašas);
            //p.Rasymas(Pelningasis, Zanras);
            //p.ZanrasRasymas(Zanras);
            //p.CageRasymas(Nicolas);
            //p.SpausdinamPradiniusDuomenis(sąrašas);

            //Console.Read();
            //--------------------------2Lab------------------------------
            
            var branchai = p.BranchuKonteinerioSukurimas();

            p.MegstamiausioRezIeskojimas(branchai);

            var visumatytifilmai = p.VisuMatytiFilmai(branchai);
            p.VisuMatytuFilmuSpausdinimas(visumatytifilmai);

            p.RekomenduojamiFilmai(branchai);
            
            p.PradiniaiDuomenysLentele(branchai);
            
        }

        /// <summary>
        /// Sukuriamas Branch'u konteineris, branchams priskiriami filmu konteineriai
        /// </summary>
        /// <returns>grazina branchu konteineri</returns>
        public BranchuKonteineris BranchuKonteinerioSukurimas ()
        {
            string[] filePaths = Directory.GetFiles(Directory.GetCurrentDirectory(),
                "*Duom.csv");
            var branchai = new BranchuKonteineris(MaxBranchSk);
            foreach (string path in filePaths)
            {
                Branch branch = null;
                bool rado = DuomenuSkaitymas(path, ref branch, out string vardas);
                if (rado == false)
                {
                    Console.WriteLine("Nera ziurovo");
                }
                SpausdintiBrancha(branch);
                branchai.PridetiBrancha(branch);
            }
            return branchai;
        }
        
        /// <summary>
        /// Nuskaitomi duomenys is failu
        /// </summary>
        /// <param name="path">failo vieta</param>
        /// <param name="branchess">viena atsaka(ziurovas)</param>
        /// <param name="vardas">ziurovo vardas</param>
        /// <returns>grazina ziurovo varda, filmu konteineri</returns>
        private bool DuomenuSkaitymas(string path, ref Branch branchess, out string vardas)
        {
            using (StreamReader reader = new StreamReader(path))
            {
                string line = null;
                vardas = reader.ReadLine();
                if (vardas != null)
                {
                    line = reader.ReadLine();
                    line = reader.ReadLine();
                }
                branchess = new Branch(vardas);
                while (null != (line = reader.ReadLine()))
                {
                    string[] values = line.Split(';');
                    string filmas = values[0];
                    int metai = int.Parse(values[1]);
                    string zanras = values[2];
                    string studija = values[3];
                    string rezisieriausvardas = values[4];
                    string rezisieriauspavarde = values[5];
                    string aktorius1 = values[6];
                    string aktorius2 = values[7];
                    double pajamos = double.Parse(values[8]);

                    Sąrašas movie = new Sąrašas(filmas, metai, zanras, studija,
                        rezisieriausvardas, rezisieriauspavarde, aktorius1,
                        aktorius2, pajamos);
                    branchess.Filmai.PridetiFilma(movie);
                }
            }
            return true;
        }

        /// <summary>
        /// pradiniai duomenys surasomi i lentele tekstiniame faile
        /// </summary>
        /// <param name="branchai">ziurovu duomenys</param>
        public void PradiniaiDuomenysLentele (BranchuKonteineris branchai)
        {
           int u = 1;
            //jei true, sukurti nauja faila, o jei false, prideti
            using (StreamWriter sw = new StreamWriter(@"Duomenys2.txt", false))
            {
                for (int i = 0; i < branchai.Count; i++)
                {
                    //sw.WriteLine("{0}", )
                    var laikinas = branchai.GautiBrancha(i);
                    sw.WriteLine("{0}", laikinas.Vardas);
                    if (laikinas == null)
                    {
                        continue;
                    }
                    //string[] lines = new string[MaxFilmuSk + u];
                    sw.WriteLine("{0, 12}| {1, 7}| {2, 13}| {3, 17}|" +
                        " {4, 21}| {5, 22}| {6, 13}| {7, 14}| {8, 9}|",
                        "Pavadinimas", "Metai", "Zanras", "Studija",
                        "Rezisieriaus Vardas", "Rezisieriaus Pavarde",
                        "Aktorius1", "Aktorius2", "Pajamos");
                    sw.WriteLine("----------------------------" +
                        "-------------------------------------" +
                        "-------------------------------------" +
                        "-------------------------------------------");

                    for (int j = 0; j < laikinas.Filmai.Count; j++)
                    {
                        if (laikinas.Filmai.RastiFilma(j) == null)
                        {
                            continue;
                        }
                        sw.WriteLine("{0}", laikinas.Filmai.RastiFilma(j).ToString());
                        u++;
                        //lines[u+1] = String.Format("{0}", branchai)
                    }
                    sw.WriteLine("-----------------------------" +
                        "--------------------------------------" +
                        "--------------------------------------" +
                        "----------------------------------------");
                    sw.WriteLine();

                }
            }
        }

        /// <summary>
        /// Ieskomas dazniausiai pasikartojantis rezisierius
        /// </summary>
        /// <param name="branchai">ziurovu duomenys</param>
        public void MegstamiausioRezIeskojimas (BranchuKonteineris branchai)
        {
            Console.WriteLine("{0,20} | {1, 26} |", "Ziurovo Vardas",
                "Megstamiausias rezisierius");
            for (int i = 0; i < branchai.Count; i++)
            {
                var laikinasbranch = branchai.GautiBrancha(i);
                var laikinifilmai = laikinasbranch.Filmai;
                string megstRezPav = MegstamiausiasRezisierius(laikinifilmai);
                SpausdintiMegstRez(laikinasbranch.Vardas, megstRezPav);
            }
        }

        /// <summary>
        /// Spausdinami ziurovai ir ju megstamiausi rezisieriai
        /// </summary>
        /// <param name="ziurovas">ziurovo vardas</param>
        /// <param name="megstRezPav">jo megstamiausio rezisieriaus vardas</param>
        public void SpausdintiMegstRez (string ziurovas, string megstRezPav)
        {
            Console.WriteLine("---------------------------------------------------");
            Console.WriteLine("{0,20} | {1, 26} |", ziurovas, megstRezPav);
            
        }

        /// <summary>
        /// randa unikalius rezisierius ir ju kieki
        /// </summary>
        /// <param name="Filmai">ziurovo ziuretu filmu konteineris</param>
        /// <returns> grazina dazniausiai pasikartojancio rezisieriaus varda</returns>
        public string MegstamiausiasRezisierius(FilmuKonteineris Filmai)
        {
            var rezpasikartojimodictionary = new Dictionary<string, int>();
            for (int i = 0; i < Filmai.Count; i++)
            {
                string rezPavarde = Filmai.RastiFilma(i).RezisieriausVardas
                    + " " + Filmai.RastiFilma(i).RezisieriausPavarde;
                //rezPasDict.ContainsKey(rezPavarde); // grazina arba true arba false
                if(!rezpasikartojimodictionary.ContainsKey(rezPavarde)) // jei true, reik pridet rezisieriu i dictionary
                {
                    rezpasikartojimodictionary.Add(rezPavarde, 1);
                }
                else // jei false, padidinam jo kieki
                {
                    rezpasikartojimodictionary.TryGetValue(rezPavarde, out int value); // paimam value
                    value++; // ji padidinam
                    rezpasikartojimodictionary[rezPavarde] = value++; // grazinam padidinta
                }
            }
            string rezultatas = DazniausiasRez(rezpasikartojimodictionary);
            return rezultatas;
        }

        /// <summary>
        /// suzinomas dazniausio rezisieriaus konteineryje vardas
        /// </summary>
        /// <param name="rezpasikartojimodictionary">unikalus rezisieriai
        /// ir ju pasikartojimo kiekis</param>
        /// <returns>grazina dazniausiai pasikartojancio rezisieriaus varda</returns>
        public string DazniausiasRez (Dictionary<string, int> rezpasikartojimodictionary)
        {
            string dazniausiasrez = null;
            int maxvalue = 0;
            foreach (var entry in rezpasikartojimodictionary)
            {
                string localrezisierius = entry.Key;
                int localmax = entry.Value;
                if (localmax > maxvalue)
                {
                    maxvalue = localmax;
                    dazniausiasrez = localrezisierius;
                }
            }
            return dazniausiasrez;
        }

        /// <summary>
        /// kreipiamasi i metoda, kuris sukuria nauja visu matytu filmu konteineri
        /// </summary>
        /// <param name="branchai">visi ziurovu duomenys</param>
        /// <returns>spausdinimui grazinamas visu matytu filmu konteineris</returns>
        public FilmuKonteineris VisuMatytiFilmai (BranchuKonteineris branchai)
        {
            var branch1 = branchai.GautiBrancha(0).Filmai;
            var branch2 = branchai.GautiBrancha(1).Filmai;
            var branch3 = branchai.GautiBrancha(2).Filmai;
            var visumatytifilmai = RastiVisuMatytusFilmus(branch1, branch2, branch3);
            return visumatytifilmai;
        }

        /// <summary>
        /// sudaromas visu matytu filmu konteineris
        /// </summary>
        /// <param name="filmai1">tikrinamas filmu konteineris</param>
        /// <param name="filmai2">lyginamas filmu konteineris</param>
        /// <param name="filmai3">lyginamas filmu konteineris</param>
        /// <returns>grazina visu matytu filmu konteineri</returns>
        private FilmuKonteineris RastiVisuMatytusFilmus(FilmuKonteineris filmai1,
            FilmuKonteineris filmai2, FilmuKonteineris filmai3)
        {
            FilmuKonteineris VisuMatytiFilmai = new FilmuKonteineris(MaxFilmuSk);
            for (int i = 0; i < filmai1.Count; i++)
            {
                //Jei filmai3 konteineris i filmai 2 konteineris turi filma
                //is filmai1 konteinerio, jis pridedamas i matytu vilmu konteineri
                if (filmai3.Contains(filmai1.RastiFilma(i)) &&
                    filmai2.Contains(filmai1.RastiFilma(i))) 
                {
                    VisuMatytiFilmai.PridetiFilma(filmai1.RastiFilma(i));
                }
            }
            return VisuMatytiFilmai;
        }

        /// <summary>
        /// Ieskoma rekomenduojamu filmu, kreipiamasi i metoda, pridedanti nematytus filmus
        /// </summary>
        /// <param name="branchai">ziurovu duomenys</param>
        public void RekomenduojamiFilmai(BranchuKonteineris branchai)
        {
            //var rekfilmukont = new FilmuKonteineris(MaxFilmuSk);
            for (int i = 0; i < MaxBranchSk; i++)
            {
                var branch1 = branchai.GautiBrancha(i % 3);
                var branch2 = branchai.GautiBrancha((i + 1) % 3);
                var branch3 = branchai.GautiBrancha((i + 2) % 3);

                var rekfilmukont = RastiRekomenduojamusFilmus(branch1, branch2, branch3);
                var vardas = branchai.GautiBrancha(i).Vardas;
                RekSpausdinimas(vardas, rekfilmukont);
            }
        }

        /// <summary>
        /// Pridedami rekomenduojami filmai i konteineri
        /// </summary>
        /// <param name="branch1">vienas ziurovas</param>
        /// <param name="branch2">antras ziurovas</param>
        /// <param name="branch3">trecias ziurovas</param>
        /// <returns></returns>
        private FilmuKonteineris RastiRekomenduojamusFilmus (Branch branch1, Branch branch2,
            Branch branch3)
        {
            var RekFilmuKont = new FilmuKonteineris(Branch.MaxFilmuSk);
            for (int i = 0; i < branch2.Filmai.Count; i++)
            {
                if (!(branch1.Filmai.Contains(branch2.Filmai.RastiFilma(i))))
                {
                    RekFilmuKont.PridetiFilma(branch2.Filmai.RastiFilma(i));
                }
                if(!(branch1.Filmai.Contains(branch3.Filmai.RastiFilma(i))))
                {
                    RekFilmuKont.PridetiFilma(branch3.Filmai.RastiFilma(i));
                }
            }
            return RekFilmuKont;
        }

        /// <summary>
        /// Spausdinami rekomenduojami filmai i ziurovui atskirai sukurta faila
        /// </summary>
        /// <param name="vardas">ziurovo vardas</param>
        /// <param name="RekomenduojamiF">jam rekomenduojamu filmu spausdinimas</param>
        public void RekSpausdinimas (string vardas, FilmuKonteineris RekomenduojamiF)
        {
            if (RekomenduojamiF.Count != 0)
            {
                int j = 1;
                string[] lines = new string[RekomenduojamiF.Count + 1];
                lines[0] = String.Format("Pavadinimas,Metai,Zanras,Studija," +
                    "Rezisieriaus Vardas,Rezisieriaus Pavarde,Aktorius1," +
                    "Aktorius 2,Pajamos");
                for (int i = 0; i < RekomenduojamiF.Count; i++)
                {
                    lines[j] = String.Format("{0}", RekomenduojamiF.RastiFilma(i).ToString());
                    j++;
                }
                File.WriteAllLines("Rekomendacija " + vardas + ".csv", lines);
            }
            else
                File.WriteAllText("Rekomendacija " + vardas + ".csv", "Rekomenduojamu filmu nera");
        }

        /// <summary>
        /// spausdinamas visu ziurovu matyti filmai i faila
        /// </summary>
        /// <param name="VisuMatytiFilmai">visu matytu filmu konteineris</param>
        public void VisuMatytuFilmuSpausdinimas(FilmuKonteineris VisuMatytiFilmai)
        {
            if (VisuMatytiFilmai.Count != 0)
            {
                int j = 1;
                string[] lines = new string[VisuMatytiFilmai.Count + 1];
                lines[0] = String.Format("Pavadinimas,Metai,Zanras,Studija," +
                    "Rezisieriaus Vardas,Rezisieriaus Pavarde,Aktorius1," +
                    "Aktorius 2,Pajamos");
                for (int i = 0; i < VisuMatytiFilmai.Count; i++)
                {
                    lines[j] = String.Format("{0}", VisuMatytiFilmai.RastiFilma(i).ToString());
                    j++;
                }
                File.WriteAllLines(@"MateVisi.csv", lines);
            }
            else
                File.WriteAllText(@"MateVisi.csv", "Visu matytu filmu nera");
        }

        /// <summary>
        /// spausdinami branch'ai consoleje lenteles formoje
        /// </summary>
        /// <param name="branch">spausdina ziurovu informacija lentele</param>
        void SpausdintiBrancha(Branch branch)
        {
            Console.WriteLine("{0, 12}| {1, 7}| {2, 13}| {3, 17}| {4, 21}|" +
                " {5, 22}| {6, 13}| {7, 14}| {8, 9}|", "Pavadinimas", "Metai",
                "Zanras", "Studija" ,"Rezisieriaus Vardas", "Rezisieriaus Pavarde",
                "Aktorius1", "Aktorius2", "Pajamos");
            Console.WriteLine("-------------------------------------------------" +
                "---------------------------------------------------------------" +
                "---------------------------------");
            Console.WriteLine("{0}", branch.ToString());
            Console.WriteLine("-------------------------------------------------" +
                "---------------------------------------------------------------" +
                "---------------------------------");

        }

    }
}
