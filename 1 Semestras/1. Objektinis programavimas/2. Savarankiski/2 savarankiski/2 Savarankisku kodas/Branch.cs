using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2savarankiskas
{
    class Branch
    {
        public const int MaxNumberOfStudents = 50;

        public string Faculty { get; set; }
        public Student[] Students { get; set; }
        public int Count { get; private set; }

        public Branch()
        {
        }

        public Branch(string faculty)
        {
            Faculty = faculty;
            Students = new Student[MaxNumberOfStudents];
            Count = 0;
        }

        public void AddStudent (Student student)
        {
            Students[Count++] = student;
        }
        
    }
}
