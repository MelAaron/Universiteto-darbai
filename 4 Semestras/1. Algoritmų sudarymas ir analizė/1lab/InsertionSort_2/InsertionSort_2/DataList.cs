using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsertionSort_2
{
    abstract class DataList
    {
        protected int length;
        public int Length { get { return length; } }
        public abstract DataToSort Head();
        public abstract DataToSort Next();
        public abstract DataToSort ElementAt(int n);
        public abstract void SetValue(int i, DataToSort v);
        public void Print(int n)
        {
            Console.Write(Head().ToString());
            for (int i = 1; i < Length; i++)
                Console.Write(Next().ToString());
            Console.WriteLine();
        }
    }
}
