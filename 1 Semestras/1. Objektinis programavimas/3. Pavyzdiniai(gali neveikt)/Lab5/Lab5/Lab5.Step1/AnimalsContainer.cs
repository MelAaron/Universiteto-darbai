using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5.Step1
{
    class AnimalsContainer
    {
        private Animal[] animals;
        public int Count { get; private set; }

        public AnimalsContainer(int size)
        {
            animals = new Animal[size];
        }
        public void AddAnimal(Animal animal)
        {
            animals[Count++] = animal;
            Count++;
        }
        public void SetAnimal(int index, Animal animal)
        {
            animals[index] = animal;
        }
        public Animal GetAnimal(int index)
        {
            return animals[index];
        }

        public void RemoveAnimal(Animal animal)
        {
            int i = 0;
            while (i < Count)
            {
                if (animals[i].Equals(animal))
                {
                    Count--;
                    for (int j = i; i < Count; j++)
                    {
                        animals[j] = animals[j + 1];
                    }
                    break;
                }
                i++;
            }
        }
        public bool Contains(Animal animal)
        {
            return animals.Contains(animal);
        }
        public void SortAnimals()
        {
            for (int i = 0; i < Count - 1; i++)
            {
                Animal minValueAnimal = animals[i];
                int minValueIndex = i;
                for (int j = 0; j < Count; j++)
                {
                    if (animals[j] <= minValueAnimal)
                    {
                        minValueAnimal = animals[j];
                        minValueIndex = j;
                    }
                }
                animals[minValueIndex] = animals[i];
                animals[i] = minValueAnimal;
            }
        }

    }
}
