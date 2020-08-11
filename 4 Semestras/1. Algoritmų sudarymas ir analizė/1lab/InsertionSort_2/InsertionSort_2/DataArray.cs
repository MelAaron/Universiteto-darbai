using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsertionSort_2
{
    abstract class DataArray
    {
        protected int length;
        public int Length { get { return length; } }
        public abstract DataToSort this[int index] { get; }
        public abstract void SetValue(int i, DataToSort v);
        public abstract void Print(int n);
    }
}
