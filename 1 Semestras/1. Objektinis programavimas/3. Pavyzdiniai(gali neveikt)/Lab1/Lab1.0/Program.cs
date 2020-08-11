﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Lab1._0
{
    class Program
    {
        static void Main(string[] args)
        {
            Program p = new Program();

            List<Dog> dogs = p.ReadDogData();
            p.SaveReportToFile(dogs);

            Console.WriteLine("Kokio amžiaus agresyvius šunis skaičiuoti?");
            int age = int.Parse(Console.ReadLine());
            Console.WriteLine("Agresyvių šunų kiekis: " + p.CountAggressive(dogs, age));

            Console.WriteLine("Kurios veislės šunis filtruoti?");
            string breedToFilter = Console.ReadLine();
            List<Dog> filteredByBreed = p.FilterByBreed(dogs, breedToFilter);
            p.PrintDogNamesToConsole(filteredByBreed);

            Console.WriteLine("Kurios veisles seniausius sunis surasti?");
            breedToFilter = Console.ReadLine();
            List<Dog> oldestDogs = p.FindOldestDogs(dogs, breedToFilter);
            p.PrintDogNamesToConsole(oldestDogs);

            Console.WriteLine("Sunu veisles:");
            List<string> breeds = p.GetBreeds(dogs);
            p.BreedPrinting(breeds);

            Console.WriteLine("Vakcinos galiojimas baigesi: ");
            List<Dog> needVaccnes = p.FilteredByVaccinationExpired(dogs);
            p.PrintDogNamesToConsole(needVaccnes);
        }
        List<Dog> ReadDogData()
        {
            List<Dog> dogs = new List<Dog>();
            string[] lines = File.ReadAllLines(@"duom1.csv");
            foreach (string line in lines)
            {
                string[] values = line.Split(';');
                string name = values[0];
                int chipId = int.Parse(values[1]);
                double weight = Convert.ToDouble(values[2]);
                int age = int.Parse(values[3]);
                string breed = values[4];
                string owner = values[5];
                string phone = values[6];
                DateTime vaccinationDate = DateTime.Parse(values[7]);
                bool aggressive = bool.Parse(values[8]);
                Dog dog = new Dog(name, chipId, weight, age, breed, owner, phone, vaccinationDate, aggressive);
                dogs.Add(dog);
            }
            return dogs;
        }
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
        void PrintDogsToConsole (List<Dog> dogs)
        {
            foreach (Dog dog in dogs)
            {
                Console.WriteLine("Vardas: {0}\nMikroschemos ID: {1}\nSvoris: {2}\nAmžius: " +
                    "{3}\nSavininkas: {4}\nTelefonas: {5}\nVakcinacijos data: {6}\n" +
                    "Agresyvus : {7}\n", dog.Name, dog.ChipId, dog.Weight, dog.Age, dog.Owner,
                    dog.Phone, dog.VaccinationDate, dog.Aggressive);
            }
        }
        int CountAggressive(List<Dog> dogs, int age)
        {
            int counter = 0;
            foreach (Dog dog in dogs)
            {
                if (dog.Aggressive && (dog.Age == age))
                {
                    counter++;
                }
            }
            return counter;
        }
        List<Dog> FilterByBreed(List<Dog> dogs, string breed)
        {
            List<Dog> filtered = new List<Dog>();
            foreach (Dog dog in dogs)
            {
                if (breed.Equals(dog.Breed))
                {
                    filtered.Add(dog);
                }
            }
            return filtered;
        }
        void PrintDogNamesToConsole (List<Dog> dogs)
        {
            foreach(Dog dog in dogs)
            {
                Console.WriteLine("Vardas: {0}", dog.Name);
            }
        }
        int FindOldestDogAge (List<Dog> dogs)
        {
            int maxAge = 0;
            foreach(Dog dog in dogs)
            {
                if (dog.Age > maxAge)
                {
                    maxAge = dog.Age;
                }
            }
            return maxAge;
        }
        List<Dog> FindOldestDogs (List<Dog> dogs, string breed)
        {
            List<Dog> filteredDogs = FilterByBreed(dogs, breed);
            int maxAge = FindOldestDogAge(filteredDogs);

            List<Dog> oldestDogs = new List<Dog>();
            foreach(Dog dog in filteredDogs)
            {
                if(dog.Age == maxAge)
                {
                    oldestDogs.Add(dog);
                }
            }
            return oldestDogs;
        }
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
        public void BreedPrinting (List<string> breeds)
        {
            for(int i = 0; i < breeds.Count; i++)
            {
                Console.WriteLine(breeds[i]);
            }
        }
        List<Dog> FilteredByVaccinationExpired(List<Dog> dogs)
        {
            List<Dog> filtered = new List<Dog>();
            foreach (Dog dog in dogs)
            {
                if(dog.IsVaccinationExpired())
                {
                    filtered.Add(dog);
                }
            }
            return filtered;
        }
    }
}
