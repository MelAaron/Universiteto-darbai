using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    class Branch
    {
        public string Town { get; set; }
        public AnimalsContainer Dogs { get; set; }
        public AnimalsContainer Cats { get; set; }
        public AnimalsContainer GuineaPigs { get; set; }

        public Branch (string town)
        {
            Town = town;
            Dogs = new AnimalsContainer(Program.MaxNumberOfAnimals);
            Cats = new AnimalsContainer(Program.MaxNumberOfAnimals);
            GuineaPigs = new AnimalsContainer(Program.MaxNumberOfAnimals);
        }
        public void AddDog(Dog dog)
        {
            Dogs.AddAnimal(dog);
        }
        public void AddCat(Cat cat)
        {
            Cats.AddAnimal(cat);
        }
        public void AddGPig (GuineaPig pig)
        {
            GuineaPigs.AddAnimal(pig);
        }
    }
}
