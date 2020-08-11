using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgL1
{
    abstract class DataArray
    {
        protected int length;
        public int Length { get { return length; } }
        public abstract Objektas this[int index] { get; }
        public abstract void Change(int index, Objektas naujas);
        public abstract void Swap(int j, Objektas a, Objektas b);
        public void Print(int n)
        {
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine(" {0:F5} {1}", this[i].flo, this[i].str);
                Console.WriteLine();
            }
        }
    }
}
