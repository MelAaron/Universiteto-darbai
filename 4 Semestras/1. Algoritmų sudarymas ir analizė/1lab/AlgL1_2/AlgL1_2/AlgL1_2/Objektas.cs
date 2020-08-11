using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgL1_2
{
    class Objektas
    {
        public float flo { get; set; }
        public string str { get; set; }

        public Objektas(string nstring, float nfloat)
        {
            flo = nfloat;
            str = nstring;
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
        public override string ToString()
        {
            return String.Format(" {0}, {1:F5}\n", str, flo);
        }

        public string ToFileString()
        {
            return String.Format("{0}{1:F5}\n", str, flo);
        }
    }
}
