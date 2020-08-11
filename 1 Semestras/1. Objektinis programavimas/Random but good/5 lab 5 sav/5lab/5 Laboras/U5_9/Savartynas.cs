using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace U5_9
{
    class Savartynas
    {
        //private void Skaitymas (string file, Branch[] branches, ref int number)
        //{
        //    string[] filePaths = Directory.GetFiles(file, "*.csv");
        //    foreach (string path in filePaths)
        //    {
        //        SkaitytiIrasuData(path, branches, ref number);
        //    }
        //}

        //private void SkaitytiIrasuData (string file, Branch[] branches, ref int number)
        //{
        //    using (StreamReader sr = new StreamReader(@file, Encoding.GetEncoding(1257)))
        //    {
        //        string vardas = sr.ReadLine();
        //        string gimD = sr.ReadLine();
        //        string miestas = sr.ReadLine();
        //        string line;
        //        //string line = sr.ReadLine();
        //        Branch branch = GetBranchByData(branches, ref number, vardas, gimD, miestas);
        //        while (null != (line = sr.ReadLine()))
        //        {
        //            switch(line[0])
        //            {
        //                case 'F':
        //                    branch.PridetiIrasa(new Filmas(line));
        //                    break;
        //                case 'S':
        //                    branch.PridetiIrasa(new Serialas(line));
        //                    break;
        //            }
        //        }
        //    }
        //}

        //private Branch GetBranchByData(Branch[] branches, ref int number, string vardas, string gimD, string miestas)
        //{
        //    for (int i = 0; i < number; i++)
        //    {
        //        if((branches[i].Vardas == vardas) && (branches[i].GimM == gimD) && (branches[i].Miestas == miestas))
        //        {
        //            return branches[i];
        //        }
        //    }
        //    branches[number++] = new Branch(vardas, gimD, miestas);
        //    return branches[number - 1];
        //}




        //void MateVisi(BranchuKonteineris branches, int NrOfBranches, ref IrasuKonteineris/*[]*/ VisiIrasai)
        //{
        //    for (int i = 0; i < branches.Count; i++)
        //    {
        //        for (int j = 0; j < branches.GautiBrancha(i).Count; j++)
        //        {
        //            if (!VisiIrasai.Contains(branches.GautiBrancha(i).GautiIrasa(j)))
        //            {
        //                VisiIrasai.PridetiIrasa(branches.GautiBrancha(i).GautiIrasa(j));
        //            }
        //        }
        //        //Branch pIrasai = GautiIrasus(branches[i]);
        //        //VisiIrasai += pIrasai;
        //    }
        //}

        //private Branch GautiIrasus (Branch branch)
        //{
        //    Branch irasai = new Branch("Zmogaus filmai", "", "");
        //    for (int i = 0; i < branch.Count; i++)
        //    {

        //    }
        //}



        //public bool Tikrina(Animal a, Animal b)
        //{
        //    if (a is AnimalMarked && b is AnimalMarked)
        //    {
        //        AnimalMarked aa = a as AnimalMarked;
        //        AnimalMarked bb = b as AnimalMarked;
        //        return aa <= bb;
        //    }
        //    return a <= b;
        //}
    }
}
