using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2savarankiskas
{
    class Group
    {
        public const int MaxNumberOfGroup = 50;

        public string Name { get; set; }
        private Student[] Students;
        private int Count;

        public Group(string name)
        {
            Students = new Student[MaxNumberOfGroup];
            Name = name;
        }

        public void AddStudent(Student student)
        {
            Students[Count++] = student;
        }

        public double GetAverage()
        {
            double sum = 0;
            int markCount = 0;
            for (int i = 0; i < Count; i++)
            {
                sum += Students[i].Sum;
                markCount += Students[i].Amount;
            }
            return sum / markCount;
        }

      
    }
}
