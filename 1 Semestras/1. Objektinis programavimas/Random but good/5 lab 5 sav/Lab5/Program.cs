using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Lab3.Step1
{
    class Program
    {
        public const int MaxNumberOfBranches = 10;
        public const int MaxNumberOfAnimals = 50;
        public const int MaxNumberOfBreeds = 50;
        static void Main(string[] args)
        {
            Program p = new Program();
            Branch[] branches = new Branch[MaxNumberOfBranches];
            int NumberOfBranches = 0;
            const string DataDir = @"..\..\";
            p.ReadData(DataDir, branches, ref NumberOfBranches);
            Console.WriteLine("Užregistruoti šunys:");
            p.PrintAnimalsToConsole(branches[0], branches[0].Town, 'D');
            Console.WriteLine();
            Console.WriteLine("Užregistruotos katės:");
            p.PrintAnimalsToConsole(branches[0], branches[0].Town, 'c');
            Console.WriteLine();
            Console.WriteLine("Agresyvūs šunys\n {0}: {1}", branches[0].Town, p.CountAggressive(branches[0]));
            Console.WriteLine("Agresyvūs šunys\n {0}: {1}", branches[1].Town, p.CountAggressive(branches[1]));
            Console.WriteLine("Populiariausia šunų veislė\n {0}: {1}", branches[0].Town, p.GetMostPopularBreed(p.GetAnimals("Filialas: {0} Gyvūnas: šuo", branches[0], 'D')));
            Console.WriteLine("Populiariausia kačių veislė\n {0}: {1}", branches[1].Town, p.GetMostPopularBreed(p.GetAnimals("Filialas: {0} Gyvūnas: katė", branches[1], 'C')));
            Console.WriteLine();
            p.SpausdintiVisusGyvunus(branches, NumberOfBranches, 'D');
            p.SpausdintiVisusGyvunus(branches, NumberOfBranches, 'C');
            p.SpausdintiVisusGyvunus(branches, NumberOfBranches, 'G');
            Console.ReadKey();
        }
        private void SpausdintiVisusGyvunus(Branch[] branches, int NumberOfBranches, char Gyvunas)
        {
            string gyvunai = "";
            switch (Gyvunas)
            {
                case 'C':
                case 'c':
                    gyvunai = "kaciu";
                    break;
                case 'D':
                case 'd':
                    gyvunai = "sunu";
                    break;
                case 'G':
                case 'g':
                    gyvunai = "juru kiaulyciu";
                    break;
            }
            Console.WriteLine("surūšiuotas visų filialų {0} sąrašas:", gyvunai);
            Console.WriteLine();
            string line = "";
            switch (Gyvunas)
            {
                case 'C':
                case 'c':
                    line = "Visos kates";
                    break;
                case 'D':
                case 'd':
                    line = "Visi šunys";
                    break;
                case 'G':
                case 'g':
                    line = "Visos juru kiaulytes";
                    break;
            }
            Branch allAnimals = new Branch(line);
            GetAllAnimals(branches, NumberOfBranches, ref allAnimals, "Filialas: {0} Gyvūnas: šuo", Gyvunas);
            allAnimals.SortAnimals();
            PrintAnimalsToConsole(allAnimals, allAnimals.Town, '-');
        }
        private void GetAllAnimals(Branch[] ba, int NumberOfBranches, ref Branch allAnimals, string forma, char Gyvunas)
        {
            for (int i = 0; i < NumberOfBranches; i++)
            {
                Branch Guneapigs = GetAnimals(forma, ba[i], char.ToUpper(Gyvunas));
                allAnimals += Guneapigs;
            }
        }
        void PrintAnimalsToConsole(Branch ba, string title, char type)
        {
            string s = new string('-', ba.GetAnimal(0).ToString().Length);
            Console.WriteLine(title);
            Console.WriteLine(s);
            for (int i = 0; i < ba.Count; i++)
            {
                switch (type)
                {
                    case 'D':
                    case 'd':
                        if (ba.GetAnimal(i) is Dog)
                            Console.WriteLine(ba.GetAnimal(i));
                        break;
                    case 'C':
                    case 'c':
                        if (ba.GetAnimal(i) is Cat)
                            Console.WriteLine(ba.GetAnimal(i));
                        break;
                    case 'G':
                    case 'g':
                        if (ba.GetAnimal(i) is GuineaPig)
                            Console.WriteLine(ba.GetAnimal(i));
                        break;
                    default:
                        Console.WriteLine(ba.GetAnimal(i));
                        break;
                }
            }
            Console.WriteLine(s);
        }
        /// <summary>
        /// Suranda filialą pagal pavadinimą
        /// </summary>
        /// <param name="branches">Filialų rinkinys</param>
        /// <param name="number">Filialų kiekis</param>
        /// <param name="town">Miesto pavadinimas</param>
        /// <returns>Surastas arba naujai sukurtas Branch objektas</returns>
        private Branch GetBranchByTown(Branch[] branches, ref int number, string town)
        {
            for (int i = 0; i < number; i++)
            {
                if (branches[i].Town == town)
                {
                    return branches[i];
                }
            }
            branches[number++] = new Branch(town);
            return branches[number - 1];
        }
        private Branch GetAnimals(string forma, Branch ba, char type)
        {
            Branch dogs = new Branch(String.Format(forma, ba.Town));
            for (int i = 0; i < ba.Count; i++)
                switch (type)
                {
                    case 'D':
                    case 'd':
                        if (ba.GetAnimal(i) is Dog)
                            dogs.AddAnimal(ba.GetAnimal(i));
                        break;
                    case 'C':
                    case 'c':
                        if (ba.GetAnimal(i) is Cat)
                            dogs.AddAnimal(ba.GetAnimal(i));
                        break;
                    case 'G':
                    case 'g':
                        if (ba.GetAnimal(i) is GuineaPig)
                            dogs.AddAnimal(ba.GetAnimal(i));
                        break;
                }
            return dogs;
        }
        private void ReadData(string file, Branch[] branches, ref int number)
        {
            string[] filePaths = Directory.GetFiles(file, "*.csv");
            foreach (string path in filePaths)
            {
                ReadAnimalData(path, branches, ref number);
            }
        }
        private void ReadAnimalData(string file, Branch[] branches, ref int number)
        {
            using (StreamReader reader = new StreamReader(@file))
            {
                string line = reader.ReadLine();
                Branch branch = GetBranchByTown(branches, ref number, line);
                while (null != (line = reader.ReadLine()))
                {
                    switch (line[0])
                    {
                        case 'D':
                            branch.AddAnimal(new Dog(line));
                            break;
                        case 'C':
                            branch.AddAnimal(new Cat(line));
                            break;
                        case 'G':
                            branch.AddAnimal(new GuineaPig(line));
                            break;
                    }
                }
            }
        }
        private void GetBreeds(Branch ba, out string[] breeds, out int breedCount)
        {
            breeds = new string[MaxNumberOfBreeds];
            breedCount = 0;
            for (int i = 0; i < ba.Count; i++)
            {
                if (!breeds.Contains(ba.GetAnimal(i).Breed))
                {
                    breeds[breedCount++] = ba.GetAnimal(i).Breed;
                }
            }
        }


        private Branch FilterByBreed(Branch ba, string breed)
        {
            Branch filtered = new Branch(breed);
            for (int i = 0; i < ba.Count; i++)
                if (ba.GetAnimal(i).Breed == breed)
                    filtered.AddAnimal(ba.GetAnimal(i));
            return filtered;
        }

        private int CountAggressive(Branch ba)
        {
            int counter = 0;
            for (int i = 0; i < ba.Count; i++)
                if ((ba.GetAnimal(i) is Dog) && (ba.GetAnimal(i) as Dog).Aggressive)
                    counter++;
            return counter;
        }

        private string GetMostPopularBreed(Branch ba)
        {
            String popular = "not found";
            int count = 0;
            int breedCount = 0;
            string[] breeds;
            GetBreeds(ba, out breeds, out breedCount);
            for (int i = 0; i < breedCount; i++)
            {
                Branch filtered = FilterByBreed(ba, breeds[i]);
                if (filtered.Count > count)
                {
                    popular = breeds[i];
                    count = filtered.Count;
                }
            }
            return popular;
        }
    }
}
