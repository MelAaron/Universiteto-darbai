using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgL1_2
{
    abstract class DataArray
    {
        protected int length;
        public int Length { get { return length; } }
        public abstract Objektas this[int index] { get; }
        public abstract void Swap(int j, Objektas a, Objektas b);
        public abstract void SetValue(int i, Objektas v);
        public abstract void Print(int n);
    }

}
