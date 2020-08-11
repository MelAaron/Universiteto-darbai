using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _2._2_sav
{
    class Program
    {
        public const int MaxStudentCount = 50;
        public const int NumberOfBranches = 3;
        static void Main(string[] args)
        {
            Program p = new Program();

            //Branch[] branches = new Branch[MaxStudentCount];

            //int Count = 0;
            //string[] filePaths = Directory.GetFiles(Directory.GetCurrentDirectory(), "*.csv");

            //foreach(string path in filePaths)
            //{
            //    branches[Count++] = ReadStudentData(path);
            //    bool rado = p.ReadStudentData(path);
            //    if (rado == false)
            //    {
            //        Console.WriteLine("Neatpazinas failo miestas.");
            //    }
            //}


            //for (int i = 0; i < Count; i++)
            //{
            //    FakultetuKonteineris studentai = PaimtiStudenta(branches[i]);
            //    //studentai.Rikiavimas();
            //    Console.WriteLine(branches[i].Fakultetas);
            //    for (int j = 0; j < studentai.Count; j++)
            //    {
            //        double vidurkis = p.GetAverage(studentai);
            //        Console.WriteLine("{0}, {1}", studentai.RastiFakulteta(j).Vardas, vidurkis);
            //    }
            //}

            //Branch[] branches = new Branch[NumberOfBranches];

            //branches[0] = new Branch("Informatikos fakultetas");
            //branches[1] = new Branch("Chemijos fakultetas");
            //branches[2] = new Branch("Ekonomikos fakultetas");

            //string[] filePaths = Directory.GetFiles(Directory.GetCurrentDirectory(), "*.csv");

            //foreach (string path in filePaths)
            //{
            //    bool rado = p.ReadStudentData(path, branches);
            //    if (rado == false)
            //    {
            //        Console.WriteLine("Neatpazintas failo {0} miestas.", path);
            //    }
            //}

            FakultetuKonteineris StudentData = p.ReadStudentData();
            p.PrintStudentsToConsole(StudentData);
        }

        private FakultetuKonteineris ReadStudentData()
        {
            FakultetuKonteineris Studentai = new FakultetuKonteineris(MaxStudentCount);
            string fakultetas = null;
            using (StreamReader reader = new StreamReader(@"2.2Duomenys1.csv"))
            {
                string line = null;
                line = reader.ReadLine();
                if(line != null)
                {
                    fakultetas = line;
                }
                while (null != (line = reader.ReadLine()))
                {
                    int suma = 0;
                    string[] values = line.Split(',');
                    string pavarde = values[0];
                    string vardas = values[1];
                    string grupe = values[2];
                    int pazKiekis = int.Parse(values[3]);

                    for (int i = 4; i < pazKiekis + 4; i++)
                    {
                        int pazymiai = int.Parse(values[i]);
                        suma = suma + pazymiai;
                    }
                    Fakultetas studentas = new Fakultetas(pavarde, vardas, grupe, pazKiekis, suma);
                    Studentai.PridetiFakulteta(studentas);
                }
                return Studentai;
            }
        }

        public FakultetuKonteineris GroupAverageCount(FakultetuKonteineris StudentData)
        {
            Fakultetas rastaGrupe;
            FakultetuKonteineris GrupiuVidurkiai = new FakultetuKonteineris(MaxStudentCount);

            for (int i = 0; i < StudentData.Count; i++)
            {
                Fakultetas f = StudentData.RastiFakulteta(i);
                rastaGrupe = null;
                int pazymiuSuma = 0;
                int pazymiuKiekis = 0;
                for (int j = 0; j < StudentData.Count; j++)
                {
                    Fakultetas v = StudentData.RastiFakulteta(j);

                    if (f.Grupe.CompareTo(v.Grupe) == 0)
                    {
                        rastaGrupe = v;
                        pazymiuSuma = f.Suma + v.Suma;
                        pazymiuKiekis = f.PazKiekis + v.PazKiekis;
                        break;
                    }
                }
                if (rastaGrupe == null)
                {
                    rastaGrupe = new Fakultetas(f.Grupe);
                    GrupiuVidurkiai.PridetiFakulteta(rastaGrupe);
                    pazymiuSuma = f.Suma;
                    pazymiuKiekis = f.PazKiekis;
                }
                rastaGrupe.Vidurkis = pazymiuSuma / pazymiuKiekis;
            }
            return GrupiuVidurkiai;
        }

        //public FakultetuKonteineris Rikiavimas (FakultetuKonteineris GrupiuVidurkiai)
        //{
        //    FakultetuKonteineris Surikiuota = new FakultetuKonteineris(MaxStudentCount);
        //    for (int i = 0; i < GrupiuVidurkiai.Count; i++)
        //    {
        //        bool found = false;
        //        for (int j = 0; j < GrupiuVidurkiai.Count; j++)
        //        {
        //            if(GrupiuVidurkiai.RastiFakulteta(j).Vidurkis > GrupiuVidurkiai.RastiFakulteta(i).Vidurkis)
        //            {
        //                //Fakultetas x = GrupiuVidurkiai.RastiFakulteta(i);
        //                //GrupiuVidurkiai.PridetiFakulteta(i) = GrupiuVidurkiai.RastiFakulteta(j);
        //                Surikiuota.PridetiFakulteta(GrupiuVidurkiai.RastiFakulteta(j));
        //            }
        //        }
        //    }
        //}

        //private bool ReadStudentData(string file, Branch[] branches)
        //{
        //    Branch branch = null;
        //    using (StreamReader reader = new StreamReader(@file))
        //    {
        //        string line = null;
        //        line = reader.ReadLine();
        //        if (line != null)
        //        {
        //            branch = new Branch(line);
        //        }
        //        while (null != (line = reader.ReadLine()))
        //        {
        //            int suma = 0;
        //            string[] values = line.Split(',');
        //            string pavarde = values[0];
        //            string vardas = values[1];
        //            string grupe = values[2];
        //            int pazKiekis = int.Parse(values[3]);
        //            for (int i = 4; i < pazKiekis + 4; i++)
        //            {
        //                int pazymiai = int.Parse(values[i]);
        //                suma = suma + pazymiai;
        //            }
        //            Fakultetas studentas = new Fakultetas(pavarde, vardas, grupe, pazKiekis, suma);
        //            branch.Studentai.PridetiFakulteta(studentas);
        //        }
        //    }
        //    return true;
        //}

        public void PrintStudentsToConsole(FakultetuKonteineris Studentai)
        {

            for (int i = 0; i < Studentai.Count; i++)
            {
                Fakultetas f = Studentai.RastiFakulteta(i);
                Console.WriteLine("{0} ", f.ToString());
            }
        }

        public void StudentoVidurkis (FakultetuKonteineris StudentData)
        {
            GrupiuKonteineris Grupes = new GrupiuKonteineris(MaxStudentCount);
            for (int i = 0; i < StudentData.Count; i++)
            {
                for (int j = 0; j < StudentData.Count; j++)
                {
                    if (StudentData.RastiFakulteta(i).Grupe == StudentData.RastiFakulteta(j).Grupe)
                    {
                        //Grupes.PridetiGrupe(i).Grupe(StudentData.RastiFakulteta(i).Grupe);
                        string grupespav = StudentData.RastiFakulteta(i).Grupe;
                        double vidurkis = StudentData.RastiFakulteta(i).Suma / StudentData.RastiFakulteta(i).PazKiekis;
                        Grupes.PridetiGrupe(grupespav);
                    }
                }
            }
        }

        public double GetAverage(FakultetuKonteineris Studentai)
        {
            double suma = 0;
            int pazKiekis = 0;
            for (int i = 0; i < Studentai.Count; i++)
            {
                Fakultetas f = Studentai.RastiFakulteta(i);
                suma += f.Suma;
                pazKiekis += f.PazKiekis;
                Studentai.PridetiFakulteta();
            }
            return suma / pazKiekis;
        }

        //public static FakultetuKonteineris PaimtiStudenta (Branch branch)
        //{
        //    FakultetuKonteineris studentai = new FakultetuKonteineris();
        //    for (int i = 0; i < branch.Count; i++)
        //    {
        //        bool rastas = false;
        //        for (int i = 0; i < studentai.Count; i++)
        //        {

        //        }
        //    }
        //}

        //private bool ReadStudentData(string file, Branch[] branches)
        //{
        //    string fakultetas = null;

        //    using (StreamReader reader = new StreamReader(@file))
        //    {
        //        string line = null;
        //        line = reader.ReadLine();
        //        if (line != null)
        //        {
        //            fakultetas = line;
        //        }
        //        Branch branch = GetBranchByFakultetas(branches, fakultetas);
        //        if (branch == null) // neatpazino fakulteto
        //            return false;

        //        while (null != (line = reader.ReadLine()))
        //        {
        //            string[] values = line.Split(',');
        //            string pavarde = values[0];
        //            string vardas = values[1];
        //            string grupe = values[2];
        //            int pazKiekis = int.Parse(values[3]);
        //            int pazymiai = int.Parse(values[4]);

        //            Fakultetas studentas = new Fakultetas(pavarde, vardas, grupe, pazKiekis, pazymiai);

        //            branch.Studentai.PridetiFakulteta(studentas);

        //        }
        //        return true;
        //    }
        //}

        //private Branch GetBranchByFakultetas(Branch[] branches, string fakultetas)
        //{
        //    for (int i = 0; i < NumberOfBranches; i++)
        //    {
        //        if(branches[i].Fakultetas == fakultetas)
        //        {
        //            return branches[i];
        //        }
        //    }
        //    return null;
        //}


    }
}
