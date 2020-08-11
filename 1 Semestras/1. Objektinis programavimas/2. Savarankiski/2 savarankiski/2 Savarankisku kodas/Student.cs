using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace _2savarankiskas
{
    class Student
    {
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Group { get; set; }
        public int Amount { get; set; }
        public int Sum { get; set; }

        public Student()
        {
        }

        public Student(string surname, string name, string group, int amount, int sum)
        {
            Surname = surname;
            Name = name;
            Group = group;
            Amount = amount;
            Sum = sum;

        }
    }
}
