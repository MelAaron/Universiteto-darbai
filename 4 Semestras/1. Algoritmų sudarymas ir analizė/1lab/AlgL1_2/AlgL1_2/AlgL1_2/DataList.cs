using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgL1_2
{
    abstract class DataList
    {
        protected int length;
        public int Length { get { return length; } }
        public abstract Objektas Head();
        public abstract Objektas Next();
        public abstract void Swap(Objektas a, Objektas b);
        public abstract void SetValue(int i, Objektas v);
        public abstract Objektas ElementAt(int n);
        public void Print(int n)
        {
            Console.Write(" {0:F5} {1}", Head().flo, Head().str);
            for (int i = 1; i < n; i++)
            {
                Objektas temp = Next();
                Console.Write(" {0:F5} {1}", temp.flo, temp.str);
            }
            Console.WriteLine();
        }
    }
}