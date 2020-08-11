using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgL1
{
    class Objektas
    {
        public string str { get; set; }
        public float flo { get; set; }


        public Objektas(float newF, string newS)
        {
            str = newS;
            flo = newF;
        }

        public static bool operator <(Objektas lhs, Objektas rhs)
        {
            if (lhs.flo == rhs.flo)
                return lhs.str.CompareTo(rhs.str) == 1;

            return lhs.flo < rhs.flo;
        }
        public static bool operator >(Objektas lhs, Objektas rhs)
        {
            if (lhs.flo == rhs.flo)
                return lhs.str.CompareTo(rhs.str) == -1;

            return lhs.flo > rhs.flo;
        }
    }
}
