namespace Lab3.Step1
{
    class Branch
    {
        public string Town { get; private set; }
        private Animal[] Animals;
        public int Count { get; private set; }
        public Branch(string town = "")
        {
            Town = town;
            Animals = new Animal[Program.MaxNumberOfAnimals];
        }
        /// <summary>
        /// Prideda gyvūną į rinkinį
        /// </summary>
        /// <param name="a">Pridedamas gyvūnas</param>
        public void AddAnimal(Animal a)
        {
            Animals[Count] = a;
            Count++;
        }
        public Animal GetAnimal(int index)
        {
            return Animals[index];
        }
        /// <summary>
        /// Metodas rikiuoja gyvūnų sąrašą
        /// </summary>
        public void SortAnimals()
        {
            for (int i = 0; i < Count - 1; i++)
            {

                Animal minValueAnimal = Animals[i];
                int minValueIndex = i;
                for (int j = i + 1; j < Count; j++)
                {
                    if (Tikrina(Animals[j], minValueAnimal))
                    {
                        minValueAnimal = Animals[j];
                        minValueIndex = j;
                    }
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
            return a<=b;
        }


        public static Branch operator +(Branch a, Branch b)
        {
            Branch c = new Branch(a.Town);
            for (int i = 0; i < a.Count; i++)
                c.AddAnimal(a.GetAnimal(i));
            for (int i = 0; i < b.Count; i++)
                c.AddAnimal(b.GetAnimal(i));
            return c;
        }
    }
}
