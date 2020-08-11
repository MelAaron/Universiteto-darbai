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
