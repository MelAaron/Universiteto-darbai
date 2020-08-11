using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._2_sav
{
    class Branch
    {
        public const int MaxNumberOfStudents = 50;

        public string Fakultetas { get; set; }
        public FakultetuKonteineris Studentai { get; private set; }

        public Branch (string fakultetas)
        {
            Fakultetas = fakultetas;
            Studentai = new FakultetuKonteineris(MaxNumberOfStudents);

        }
    }
}
