using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Lab_2;

namespace Lab_2
{
    class Program
    {
        public const int NumberOfBranches = 3;
        public const int MaxNumberOfBreeds = 10;

        static void Main(string[] args)
        {

            Program p = new Program();
            Branch[] branches = new Branch[NumberOfBranches];

            branches[0] = new Branch("Kaunas");
            branches[1] = new Branch("Vilnius");
            branches[2] = new Branch("Šiauliai");

            string[] filePaths = Directory.GetFiles(Directory.GetCurrentDirectory(), "*.csv");

            foreach(string path in filePaths)
            {
                bool rado = p.ReadDogData(path, branches);
                if (rado == false)
                    Console.WriteLine("Neatpazintas failo {0} miestas", path);
            }

            p.PrintDogsToConsole(branches[1].Dogs);

            List<string> breeds = p.GetBreeds(branches[2].Dogs);

            Console.WriteLine("Siauliuose uzregistruotos sunu veisles: ");
            for (int i = 0; i < breeds.Count; i++)
            {
                Console.WriteLine(breeds[i]);
            }

            Console.WriteLine("Agresyviausi Kauno sunys: {0}", p.CountAggressive(branches[0].Dogs));

            Console.WriteLine("Populiariausia veisle Vilniuje: {0}", p.GetMostPopularBreed(branches[1].Dogs));

            Console.WriteLine("Dvigubai uzregistruoti sunys: ");

            Console.WriteLine();
            Console.WriteLine("Vilniuje ir Kaune: ");

            DogsContainer doublePlacedDogs = p.GetDoublePlacedDogs(branches[1], branches[0]);
            p.PrintDogsToConsole(doublePlacedDogs);

            Console.WriteLine();
            Console.WriteLine("Sarasas, is Vilniaus registro pasalinus besikartojancius:");
            Console.WriteLine();
            p.RemoveDoublePlacedDogs(branches[1], doublePlacedDogs);
            p.PrintDogsToConsole(branches[1].Dogs);

            Console.WriteLine();
            Console.WriteLine("Surusiuotas Kauno sunu sarasas: ");

            Console.WriteLine();
            branches[0].Dogs.SortDogs();
            p.PrintDogsToConsole(branches[0].Dogs);
            //Program p = new Program();

            //List<Dog> dogs = p.ReadDogData();
            //p.SaveReportToFile(dogs);

            ////Console.WriteLine("Kokio amžiaus agresyvius šunis skaičiuoti?");
            ////int age = int.Parse(Console.ReadLine());
            ////Console.WriteLine("Agresyvių šunų kiekis: " + p.CountAggressive(dogs, age));

            //Console.WriteLine("Kurios veislės šunis filtruoti?");
            //string breedToFilter = Console.ReadLine();
            //List<Dog> filteredByBreed = p.FilterByBreed(dogs, breedToFilter);
            //p.PrintDogNamesToConsole(filteredByBreed);

            ////Console.WriteLine("Kurios veisles seniausius sunis surasti?");
            ////breedToFilter = Console.ReadLine();
            ////List<Dog> oldestDogs = p.FindOldestDogs(dogs, breedToFilter);
            ////p.PrintDogNamesToConsole(oldestDogs);

            //Console.WriteLine("Sunu veisles:");
            //List<string> breeds = p.GetBreeds(dogs);
            //p.BreedPrinting(breeds);

            //Console.WriteLine("Vakcinos galiojimas baigesi: ");
            //List<Dog> needVaccnes = p.FilteredByVaccinationExpired(dogs);
            //p.PrintDogNamesToConsole(needVaccnes);
        }
        //List<Dog> ReadDogData()
        //{
        //    List<Dog> dogs = new List<Dog>();
        //    string[] lines = File.ReadAllLines(@"duom1.csv");
        //    foreach (string line in lines)
        //    {
        //        string[] values = line.Split(';');
        //        string name = values[0];
        //        int chipId = int.Parse(values[1]);
        //        double weight = Convert.ToDouble(values[2]);
        //        int age = int.Parse(values[3]);
        //        string breed = values[4];
        //        string owner = values[5];
        //        string phone = values[6];
        //        DateTime vaccinationDate = DateTime.Parse(values[7]);
        //        bool aggressive = bool.Parse(values[8]);
        //        Dog dog = new Dog(name, chipId, weight, age, breed, owner, phone, vaccinationDate, aggressive);
        //        dogs.Add(dog);
        //    }
        //    return dogs;
        //}
        void SaveReportToFile(List<Dog> dogs)
        {
            string[] lines = new string[dogs.Count];
            for (int i = 0; i < dogs.Count; i++)
            {
                lines[i] = String.Format("{0};{1};{2};{3};{4};{5};{6};{7}", dogs[i].Name,
                    dogs[i].ChipId, dogs[i].Weight, dogs[i].Age, dogs[i].Owner, dogs[i].Phone,
                    dogs[i].VaccinationDate, dogs[i].Aggressive);
            }
            File.WriteAllLines(@"L1rezultatai.csv", lines);
        }
        void PrintDogsToConsole(DogsContainer dogs)
        {
            for (int i = 0; i < dogs.Count; i++)
            {
                Console.WriteLine("Nr {0}: {1}", (i + 1), dogs.GetDog(i).ToString());
            }

            //foreach (Dog dog in dogs)
            //{
            //    Console.WriteLine("Vardas: {0}\nMikroschemos ID: {1}\nSvoris: {2}\nAmžius: " +
            //        "{3}\nSavininkas: {4}\nTelefonas: {5}\nVakcinacijos data: {6}\n" +
            //        "Agresyvus : {7}\n", dog.Name, dog.ChipId, dog.Weight, dog.Age, dog.Owner,
            //        dog.Phone, dog.VaccinationDate, dog.Aggressive);
            //}
        }
        private int CountAggressive(DogsContainer dogs)
        {
            int counter = 0;
            for (int i = 0; i < dogs.Count; i++)
            {
                if(dogs.GetDog(i).Aggressive)
                {
                    counter++;
                }
            }
            return counter;
        }
        private DogsContainer FilterByBreed(DogsContainer dogs, string breed)
        {
            DogsContainer filteredDogs = new DogsContainer(Branch.MaxNumberOfDogs);
            for (int i = 0; i < dogs.Count; i++)
            {
                if(dogs.GetDog(i).Breed == breed)
                {
                    filteredDogs.AddDog(dogs.GetDog(i));
                }
            }
            return filteredDogs;
        }
        private string GetMostPopularBreed(DogsContainer dogs)
        {
            Program p = new Program();
            String popular = "not found";
            int count = 0;

            List<string> breeds = p.GetBreeds(dogs);

            for (int i = 0; i < breeds.Count; i++)
            {
                DogsContainer filtered = FilterByBreed(dogs, breeds[i]);
                if (filtered.Count > count)
                {
                    popular = breeds[i];
                    count = filtered.Count;
                }
            }
            return popular;
        }
        void PrintDogNamesToConsole(List<Dog> dogs)
        {
            foreach (Dog dog in dogs)
            {
                Console.WriteLine("Vardas: {0}", dog.Name);
            }
        }
        int FindOldestDogAge(List<Dog> dogs)
        {
            int maxAge = 0;
            foreach (Dog dog in dogs)
            {
                if (dog.Age > maxAge)
                {
                    maxAge = dog.Age;
                }
            }
            return maxAge;
        }
        //List<Dog> FindOldestDogs(List<Dog> dogs, string breed)
        //{
        //    List<Dog> filteredDogs = FilterByBreed(dogs, breed);
        //    int maxAge = FindOldestDogAge(filteredDogs);

        //    List<Dog> oldestDogs = new List<Dog>();
        //    foreach (Dog dog in filteredDogs)
        //    {
        //        if (dog.Age == maxAge)
        //        {
        //            oldestDogs.Add(dog);
        //        }
        //    }
        //    return oldestDogs;
        //}
        List<string> GetBreeds(List<Dog> dogs)
        {
            List<string> breeds = new List<string>();
            foreach (Dog dog in dogs)
            {
                if (!breeds.Contains(dog.Breed))
                {
                    breeds.Add(dog.Breed);
                }
            }
            return breeds;
        }
        public void BreedPrinting(List<string> breeds)
        {
            for (int i = 0; i < breeds.Count; i++)
            {
                Console.WriteLine(breeds[i]);
            }
        }
        List<Dog> FilteredByVaccinationExpired(List<Dog> dogs)
        {
            List<Dog> filtered = new List<Dog>();
            foreach (Dog dog in dogs)
            {
                if (dog.IsVaccinationExpired())
                {
                    filtered.Add(dog);
                }
            }
            return filtered;
        }
        //------------------------------------------------------
        private Branch GetBranchByTown (Branch[] branches, string town)
        {
            for (int i = 0; i < NumberOfBranches; i++)
            {
                if(branches[i].Town == town)
                {
                    return branches[i];
                }
            }
            return null;
        }

        private bool ReadDogData (string file, Branch[] branches)
        {
            string town = null;
            using (StreamReader reader = new StreamReader(@file))
            {
                string line = null;
                line = reader.ReadLine();
                if (line!= null)
                {
                    town = line;
                }
                Branch branch = GetBranchByTown(branches, town);
                    if (branch == null) //neatpazino miesto
                    return false;

                while(null != (line = reader.ReadLine()))
                {
                    string[] values = line.Split(',');
                    string name = values[0];
                    int chipId = int.Parse(values[1]);
                    string breed = values[2];
                    string owner = values[3];
                    string phone = values[4];
                    DateTime vd = DateTime.Parse(values[5]);
                    bool aggressive = bool.Parse(values[6]);

                    Dog dog = new Dog(name, chipId, breed, owner, phone, vd, aggressive);
                    branch.Dogs.AddDog(dog);
                }
                return true;
            }
        }

        public override string ToString()
        {
            return String.Format
                ("ChipID: {0, 5}, Name: {1, 10}, Owner: {2, 16}, ({3})," +
                " Last Vaccination date: {4:yyyy-MM-dd}", ChipId, Name,
                Owner, Phone, VaccinationDate);

        }

        public bool Equals(Dog dog)
        {
            // tikrina, ar objektas egzistuoja
            if(Object.ReferenceEquals(dog, null))
            {
                return false;
            }

            //Tikrina, ar tokia pati klase (reikia tam atvejui, jei Dog klase pavaldetu tarkim klases buldogas ir pudelis)
            if (this.GetType() != dog.GetType())
                return false;

            //Graziname true, jei objektu laukai (savybes) sutampa.
            return (ChipId == dog.ChipId) && (Name == dog.Name);
        }
        public override int GetHashCode()
        {
            return ChipId.GetHashCode() ^ Name.GetHashCode();
        }
        public static bool operator ==(Dog lhs, Dog rhs)
        {
            //Patikriname kaire puse (ar egzistuoja objektas).
            //Negalima naudoti 1hs == null. amzinas ciklas
            if(Object.ReferenceEquals(lhs, null))
            {
                if(Object.ReferenceEquals(rhs, null))
                {
                    //jei objektas neegzistuoja nei kaireje nei dezineje,
                    // palyginimo operatoriaus puseje, graziname true (null == null = true).
                    return true;
                }
                //jei objektas neegzistoja tik kaireje puseje
                return false;
            }
            //equals metodas padengia kitus atvejus.
            return lhs.Equals(rhs);
        }

        public static bool operator != (Dog lhs, Dog rhs)
        {
            return !(lhs == rhs);
        }

        private DogsContainer GetDoublePlacedDogs (Branch branch1, Branch branch2)
        {
            DogsContainer doublePlacedDogs = new DogsContainer(Branch.MaxNumberOfDogs);
            for (int i = 0; i < branch1.Dogs.Count; i++)
            {
                if (branch2.Dogs.Contains(branch1.Dogs.GetDog(i)))
                {
                    doublePlacedDogs.AddDog(branch1.Dogs.GetDog(i));
                }
            }
            return doublePlacedDogs;
        }
        private void RemoveDoublePlacedDogs(Branch branch, DogsContainer doublePlacedDogs)
        {
            for (int i = 0; i < doublePlacedDogs.Count; i++)
            {
                branch.Dogs.RemoveDog(doublePlacedDogs.GetDog(i));
            }
        }
    }
}
