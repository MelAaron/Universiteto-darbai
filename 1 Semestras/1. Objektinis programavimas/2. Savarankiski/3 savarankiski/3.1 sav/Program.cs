using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3.Step1
{
    class Program
    {
        public const int NumberOfBranches = 3;
        public const int MaxNumberOfBreeds = 30;
        public const int MaxNumberOfAnimals = 50;

        static void Main(string[] args)
        {
            Program p = new Program();
            Branch[] branches = new Branch[NumberOfBranches];
            branches[0] = new Branch("Kaunas");
            branches[1] = new Branch("Vilnius");
            branches[2] = new Branch("Šiauliai");
            string[] filePaths = Directory.GetFiles(Directory.GetCurrentDirectory(), "*.txt");
            foreach (string path in filePaths)
            {
                bool rado = p.ReadAnimalData(path, branches);
                if (rado == false)
                    Console.WriteLine("Neatpažintas failo {0} miestas", path);
            }
            Console.WriteLine("Kaune užregistruoti šunys:");
            p.PrintAnimalsToConsole(branches[0].Dogs);
            Console.WriteLine();

            Console.WriteLine("Agresyvūs Kauno šunys: {0}", p.CountAggressive(branches[0].Dogs));
            Console.WriteLine("Agresyvūs Vilniaus šunys: {0}", p.CountAggressive(branches[1].Dogs));
            AnimalsContainer kaunasDogs = branches[0].Dogs;
            AnimalsContainer vilniusCats = branches[1].Cats;
            Console.WriteLine("Populiariausia šunų veislė Kaune: {0}", p.GetMostPopularBreed(kaunasDogs));
            Console.WriteLine("Populiariausia kačių veislė Vilniuje: {0}", p.GetMostPopularBreed(vilniusCats));
            Console.WriteLine();
            Console.WriteLine("Surūšiuotas visų filialų šunų sąrašas:");
            Console.WriteLine();

            AnimalsContainer allDogs = p.FindAllDogs(branches);
            AnimalsContainer allGuineaPigs = p.FindAllGuineaPigs(branches);
            AnimalsContainer allCats = p.FindAllCats(branches);

            allDogs.SortAnimals();
            allCats.SortAnimals();
            allGuineaPigs.SortAnimals();

            p.PrintAnimalsToConsole(allDogs);

            Console.WriteLine();
            Console.WriteLine("Visų filialų katės:");
            Console.WriteLine();
            p.PrintAnimalsToConsole(allCats);

            Console.WriteLine();
            Console.WriteLine("Visų filialų jūrų kiaulytės:");
            Console.WriteLine();
            p.PrintAnimalsToConsole(allGuineaPigs);


            Console.ReadKey();
        }

        private Branch GetBranchByTown(Branch[] branches, string town)
        {
            for (int i = 0; i < NumberOfBranches; i++)
            {
                if (branches[i].Town == town)
                {
                    return branches[i];
                }
            }
            return null;
        }

        private bool ReadAnimalData(string file, Branch[] branches)
        {
            string town = null;
            using (StreamReader reader = new StreamReader(@file))
            {
                string line = null;
                line = reader.ReadLine();
                if (line != null)
                {
                    town = line;
                }
                Branch branch = GetBranchByTown(branches, town);
                if (branch == null) // neatpažino miesto
                    return false;
                while (null != (line = reader.ReadLine()))
                {
                    string[] values = line.Split(',');
                    char type = line[0];
                    //string name = values[1];
                    //int chipId = int.Parse(values[2]);
                    //string breed = values[3];
                    //string owner = values[4];
                    //string phone = values[5];
                    //DateTime vd = DateTime.Parse(values[6]);
                    switch (type)
                    {
                        case 'D':
                            //atkreipkite dėmesį - šunys turi papildomą požymį "aggressive"
                            string name = values[1];
                            int chipId = int.Parse(values[2]);
                            string breed = values[3];
                            string owner = values[4];
                            string phone = values[5];
                            DateTime vd = DateTime.Parse(values[6]);
                            bool aggressive = bool.Parse(values[7]);
                            Dog dog = new Dog(name, chipId, breed, owner, phone, vd,
                           aggressive);
                            if (!branch.Dogs.Contains(dog))
                            {
                                branch.AddDog(dog);
                            }
                            break;

                        case 'C':
                            name = values[1];
                            chipId = int.Parse(values[2]);
                            breed = values[3];
                            owner = values[4];
                            phone = values[5];
                            vd = DateTime.Parse(values[6]);
                            Cat cat = new Cat(name, chipId, breed, owner, phone, vd);
                            if (!branch.Cats.Contains(cat))
                            {
                                branch.AddCat(cat);
                            }
                            break;

                        case 'G':
                            name = values[1];
                            breed = values[2];
                            owner = values[3];
                            phone = values[4];
                            vd = DateTime.Parse(values[5]);
                            GuineaPig guineaPig = new GuineaPig(name, breed, owner, phone, vd);
                            if (!branch.GuineaPigs.Contains(guineaPig))
                            {
                                branch.AddGuineaPigs(guineaPig);
                            }
                            break;
                    }
                }
                return true;
            }
        }

        void PrintAnimalsToConsole(AnimalsContainer animals)
        {
            for (int i = 0; i < animals.Count; i++)
            {
                Console.WriteLine("Nr {0, 2}: {1}", (i + 1), animals.GetAnimal(i).ToString());
            }
        }

        private int CountAggressive(AnimalsContainer animals)
        {
            int counter = 0;
            for (int i = 0; i < animals.Count; i++)
            {
                Dog dog = animals.GetAnimal(i) as Dog;
                if (dog != null && dog.Aggressive)
                {
                    counter++;
                }
            }
            return counter;
        }

        private void GetBreeds(AnimalsContainer animals, out string[] breeds, out int breedCount)
        {
            breeds = new string[MaxNumberOfBreeds];
            breedCount = 0;
            for (int i = 0; i < animals.Count; i++)
            {
                string breed = animals.GetAnimal(i).Breed;
                if (!breeds.Contains(breed))
                {
                    breeds[breedCount++] = breed;
                }
            }
        }

        private AnimalsContainer FilterByBreed(AnimalsContainer animals, string breed)
        {
            AnimalsContainer filteredAnimals = new
           AnimalsContainer(Program.MaxNumberOfAnimals);
            for (int i = 0; i < animals.Count; i++)
            {
                if (animals.GetAnimal(i).Breed == breed)
                {
                    filteredAnimals.AddAnimal(animals.GetAnimal(i));
                }
            }
            return filteredAnimals;
        }

        private string GetMostPopularBreed(AnimalsContainer animals)
        {
            String popular = "not found";
            int count = 0;
            int breedCount = 0;
            string[] breeds;
            GetBreeds(animals, out breeds, out breedCount);
            for (int i = 0; i < breedCount; i++)
            {
                AnimalsContainer filteredAnimals = FilterByBreed(animals, breeds[i]);
                if (filteredAnimals.Count > count)
                {
                    popular = breeds[i];
                    count = filteredAnimals.Count;
                }
            }
            return popular;
        }

        AnimalsContainer FindAllDogs(Branch[] branches)
        {
            AnimalsContainer AllDogs = new AnimalsContainer(NumberOfBranches * MaxNumberOfAnimals);
            for (int i = 0; i < NumberOfBranches; i++)
            {
                for (int j = 0; j < branches[i].Dogs.Count; j++)
                {
                    AllDogs.AddAnimal(branches[i].Dogs.GetAnimal(j));
                }
            }
            return AllDogs;
        }
        AnimalsContainer FindAllCats(Branch[] branches)
        {
            AnimalsContainer AllCats = new AnimalsContainer(NumberOfBranches * MaxNumberOfAnimals);
            for (int i = 0; i < NumberOfBranches; i++)
            {
                for (int j = 0; j < branches[i].Cats.Count; j++)
                {
                    AllCats.AddAnimal(branches[i].Cats.GetAnimal(j));
                }
            }
            return AllCats;
        }

        AnimalsContainer FindAllGuineaPigs(Branch[] branches)
        {
            AnimalsContainer AllGuineaPigs = new AnimalsContainer(NumberOfBranches * MaxNumberOfAnimals);
            for (int i = 0; i < NumberOfBranches; i++)
            {
                for (int j = 0; j < branches[i].GuineaPigs.Count; j++)
                {
                    AllGuineaPigs.AddAnimal(branches[i].GuineaPigs.GetAnimal(j));
                }
            }
            return AllGuineaPigs;
        }
    }
}
