using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5.Step1
{
    class Branch
    {
        public string Town { get; set; }
        private Animal[] Animals;
        public int Count { get; private set; }

        public Branch(string town)
        {
            Town = town;
            Animals = new Animal[Program.MaxNumberOfAnimals];

        }
        
        public void AddAnimal(Animal a)
        {
            Animals[Count] = a;
            Count++;
        }

        public Animal GetAnimal(int index)
        {
            return Animals[index];
        }

        public void SortAnimals()
        {
            for (int i = 0; i < Count - 1; i++)
            {

                Animal minValueAnimal = Animals[i];
                int minValueIndex = i;
                for (int j = i + 1; j < Count; j++)
                {
                    if (Animals[j] is AnimalMarked && minValueAnimal is AnimalMarked)
                    {
                        AnimalMarked aa = Animals[j] as AnimalMarked;
                        AnimalMarked bb = minValueAnimal as AnimalMarked;
                        if (aa<=bb)
                        {
                            minValueAnimal = Animals[j];
                            minValueIndex = j;
                        }
                    }
                    else if (minValueAnimal<= Animals[j])
                        {
                            minValueAnimal = Animals[j];
                            minValueIndex = j;
                        }
                    //if (Tikrina(Animals[j], minValueAnimal))
                    //{
                    //    minValueAnimal = Animals[j];
                    //    minValueIndex = j;
                    //}
                }
                Animals[minValueIndex] = Animals[i];
                Animals[i] = minValueAnimal;
            }
        }
        public bool Tikrina(Animal a, Animal b)
        {
            if (a is AnimalMarked && b is AnimalMarked)
            {
                AnimalMarked aa = a as AnimalMarked;
                AnimalMarked bb = b as AnimalMarked;
                return aa <= bb;
            }
            return a <= b;
        }

        //public void SortAnimals()
        //{
        //    for (int i = 0; i < Count - 1; i++)
        //    {
        //        int m = 1;
        //        for (int j = i + 1; j < Count; j++)
        //        {
        //            if (Animals[j] <= Animals[m])
        //                m = j;
        //            Animal a = Animals[i];
        //            Animals[i] = Animals[m];
        //            Animals[m] = a;
        //        }
        //    }
        //}

        public static Branch operator + (Branch a, Branch b)
        {
            Branch c = new Branch(a.Town);
            for (int i = 0; i < a.Count; i++)
            {
                c.AddAnimal(a.Animals[i]);
            }
            for (int i = 0; i < b.Count; i++)
            {
                c.AddAnimal(b.Animals[i]);
            }
            return c;
        }
    }
}
