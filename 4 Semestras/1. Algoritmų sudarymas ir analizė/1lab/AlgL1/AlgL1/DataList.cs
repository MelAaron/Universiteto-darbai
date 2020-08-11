using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgL1
{
    abstract class DataList
    {
        protected int length;
        public int Length { get { return length; } }
        public abstract Objektas Head();
        public abstract Objektas Next();
        public abstract void Swap(Objektas a, Objektas b);
        public abstract void addAll(List<Objektas> items);
        public abstract void clear();
        public void Print(int n)
        {
            Console.Write(" {0:F5} {1}", Head().flo, Head().str);
            Objektas tee = Next();
            while (tee != null)
            {
                Console.Write(" {0:F5} {1}", tee.flo, tee.str);
                tee = Next();
            }
            Console.WriteLine();
        }
    }
}
