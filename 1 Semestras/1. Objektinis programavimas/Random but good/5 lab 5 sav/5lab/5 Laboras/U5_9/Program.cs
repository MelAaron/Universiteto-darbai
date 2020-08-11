using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace U5_9
{
    class Program
    {
        public const int MaxNrOfBranches = 5;
        public const int MaxNrOfCinema = 15;

        static void Main(string[] args)
        {
            Program p = new Program();

            //Branch[] branches = new Branch[MaxNrOfBranches];
            //int NumberOfBranches = 0;
            const string DataDir = @"..\..\Data";

            //p.Skaitymas(DataDir, branches, ref NumberOfBranches);

            var branchai = p.BranchuKonteinerioSukurimas(DataDir);

            //p.MegstAkt(branches, NumberOfBranches);

            IrasuKonteineris VisiViename = new IrasuKonteineris(MaxNrOfBranches * branchai.Count);
            p.VisiVienameK(branchai, ref VisiViename);
            IrasuKonteineris Filtruoti = new IrasuKonteineris(MaxNrOfBranches * branchai.Count);
            p.Atrinkimas(VisiViename, ref Filtruoti, branchai);

            p.MegstAktorius(branchai);
            
            //Branch VisiIrasai = new Branch("Visi Irasai", "", "");
            //p.MateVisi(branches, NumberOfBranches, ref VisiIrasai);
            //Irasas[] VisiIrasai = new Irasas[MaxNrOfBranches * MaxNrOfCinema];


            Console.ReadLine();
        }

        private void MegstAktSpausdinimas (BranchuKonteineris branchai, int index, string megstAktorius)
        {
            Console.WriteLine("{0} {1}", branchai.GautiBrancha(index).Vardas, megstAktorius);
        }

        private void MegstAktorius(BranchuKonteineris branches)
        {
            int MaxAktorius;
            string MaxAktoriusName = "";
            for (int i = 0; i < branches.Count; i++)
            {
                MaxAktorius = 0;
                MaxAktoriusName = "";
                for (int j = 0; j < branches.GautiBrancha(i).Count; j++)
                {
                    var Aktorius1 = branches.GautiBrancha(i).GautiIrasa(j).Aktorius1;
                    var Aktorius2 = branches.GautiBrancha(i).GautiIrasa(j).Aktorius2;
                    int aktorius1K = Tikrinimas(branches, i, Aktorius1);
                    int aktorius2K = Tikrinimas(branches, i, Aktorius2);
                    if (aktorius1K > MaxAktorius)
                    {
                        MaxAktorius = aktorius1K;
                        MaxAktoriusName = Aktorius1;
                    }
                    if (aktorius2K > MaxAktorius)
                    {
                        MaxAktorius = aktorius2K;
                        MaxAktoriusName = Aktorius2;
                    }
                }
                MegstAktSpausdinimas(branches, i, MaxAktoriusName);
            }
            //return MaxAktoriusName;
        }

        private int Tikrinimas(BranchuKonteineris branches, int index, string aktorius1)
        {
            int k = 0;
            for (int j = 0; j < branches.GautiBrancha(index).Count; j++)
            {
                if ((branches.GautiBrancha(index).GautiIrasa(j).Aktorius1 == aktorius1) && (branches.GautiBrancha(index).GautiIrasa(j).Aktorius2 == aktorius1))
                {
                    k++;
                }
            }
            return k;
        }

        void Atrinkimas(IrasuKonteineris Visi, ref IrasuKonteineris Filtruoti, BranchuKonteineris branch)
        {
            for (int i = 0; i < Visi.Count; i++)
            {
                int k = 0;
                var irasas = Visi.GautiIrasa(i);
                for (int j = 0; j < Visi.Count; j++)
                {
                    if (irasas == Visi.GautiIrasa(j))
                    {
                        k++;
                    }
                }
                if (k == branch.Count)
                    if (!Filtruoti.Contains(irasas))
                        Filtruoti.PridetiIrasa(irasas);
            }
        }

        void VisiVienameK(BranchuKonteineris branches, ref IrasuKonteineris VisiCia)
        {
            for (int i = 0; i < branches.Count; i++)
            {
                for (int j = 0; j < branches.GautiBrancha(i).Count; j++)
                {
                    var irasas = branches.GautiBrancha(i).GautiIrasa(j);
                    VisiCia.PridetiIrasa(irasas);
                }
            }
        }

        //public void MegstamiausioRezIeskojimas(BranchuKonteineris branchai)
        //{
        //    Console.WriteLine("{0,20} | {1, 26} |", "Ziurovo Vardas",
        //        "Megstamiausias rezisierius");
        //    for (int i = 0; i < branchai.Count; i++)
        //    {
        //        var laikinasbranch = branchai.GautiBrancha(i);
        //        var laikinifilmai = laikinasbranch.
        //        string megstRezPav = MegstamiausiasRezisierius(laikinifilmai);
        //        SpausdintiMegstRez(laikinasbranch.Vardas, megstRezPav);
        //    }
        //}

        ///// <summary>
        ///// Spausdinami ziurovai ir ju megstamiausi rezisieriai
        ///// </summary>
        ///// <param name="ziurovas"></param>
        ///// <param name="megstRezPav"></param>
        //public void SpausdintiMegstRez(string ziurovas, string megstRezPav)
        //{
        //    Console.WriteLine("---------------------------------------------------");
        //    Console.WriteLine("{0,20} | {1, 26} |", ziurovas, megstRezPav);

        //}

        ///// <summary>
        ///// randa unikalius rezisierius ir ju kieki
        ///// </summary>
        ///// <param name="Filmai"></param>
        ///// <returns> grazina dazniausiai pasikartojancio rezisieriaus varda</returns>
        //public string MegstamiausiasRezisierius(FilmuKonteineris Filmai)
        //{
        //    var rezpasikartojimodictionary = new Dictionary<string, int>();
        //    for (int i = 0; i < Filmai.Count; i++)
        //    {
        //        string rezPavarde = Filmai.RastiFilma(i).RezisieriausVardas
        //            + " " + Filmai.RastiFilma(i).RezisieriausPavarde;
        //        //rezPasDict.ContainsKey(rezPavarde); // grazina arba true arba false
        //        if (!rezpasikartojimodictionary.ContainsKey(rezPavarde)) // jei true, reik pridet rezisieriu i dictionary
        //        {
        //            rezpasikartojimodictionary.Add(rezPavarde, 1);
        //        }
        //        else // jei false, padidinam jo kieki
        //        {
        //            rezpasikartojimodictionary.TryGetValue(rezPavarde, out int value); // paimam value
        //            value++; // ji padidinam
        //            rezpasikartojimodictionary[rezPavarde] = value++; // grazinam padidinta
        //        }
        //    }
        //    string rezultatas = DazniausiasRez(rezpasikartojimodictionary);
        //    return rezultatas;
        //}

        ///// <summary>
        ///// suzinomas dazniausio rezisieriaus konteineryje vardas
        ///// </summary>
        ///// <param name="rezpasikartojimodictionary"></param>
        ///// <returns>grazina dazniausiai pasikartojancio rezisieriaus varda</returns>
        //public string DazniausiasRez(Dictionary<string, int> rezpasikartojimodictionary)
        //{
        //    string dazniausiasrez = null;
        //    int maxvalue = 0;
        //    foreach (var entry in rezpasikartojimodictionary)
        //    {
        //        string localrezisierius = entry.Key;
        //        int localmax = entry.Value;
        //        if (localmax > maxvalue)
        //        {
        //            maxvalue = localmax;
        //            dazniausiasrez = localrezisierius;
        //        }
        //    }
        //    return dazniausiasrez;
        //}



        void MegstAkt(Branch[] branches, int NumberOfBranches)
        {
            for (int i = 0; i < NumberOfBranches; i++)
            {
                Console.WriteLine(branches[i].Vardas + "\n" + branches[i].GimM + "\n" + branches[i].Miestas);

            }
        }

        private BranchuKonteineris BranchuKonteinerioSukurimas(string file)
        {
            string[] filePaths = Directory.GetFiles(file, "*.csv");
            var branchai = new BranchuKonteineris(MaxNrOfBranches);
            foreach (var path in filePaths)
            {
                Branch branch = null;
                bool rado = IrasuDuomenuSkaitymas(path, ref branch, out string vardas, out string adresas, out string numeris);
                if (rado == false)
                {
                    Console.WriteLine("Nera Ziurovo");
                }
                //SausdintiBrancha(branch);
                branchai.PridetiBrancha(branch);
            }
            return branchai;
        }

        public bool IrasuDuomenuSkaitymas(string path, ref Branch branch, out string vardas, out string gimM, out string miestas)
        {
            using (StreamReader sr = new StreamReader(path))
            {
                string line = null;
                vardas = sr.ReadLine();
                gimM = sr.ReadLine();
                miestas = sr.ReadLine();
                line = vardas;
                if (line == null)
                    return false;
                branch = new Branch(vardas, gimM, miestas);
                while (null != (line = sr.ReadLine()))
                {
                    switch (line[0])
                    {
                        case 'F':
                            branch.PridetiIrasa(new Filmas(line));
                            break;
                        case 'S':
                            branch.PridetiIrasa(new Serialas(line));
                            break;
                    }
                }
                return true;
            }
        }
    }
}
