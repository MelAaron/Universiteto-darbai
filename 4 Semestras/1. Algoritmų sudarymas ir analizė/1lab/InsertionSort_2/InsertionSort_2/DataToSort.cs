using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsertionSort_2
{
    class DataToSort
    {
        public string dataString { get; set; }
        public float dataFloat { get; set; }

        public DataToSort(string datastring, float dataFloat)
        {
            this.dataString = datastring;
            this.dataFloat = dataFloat;
        }

        public override string ToString()
        {
            return String.Format(" {0}, {1:F5}\n", dataString, dataFloat);
        }

        public string ToFileString()
        {
            return String.Format("{0}{1:F5}\n", dataString, dataFloat);
        }
    }
}
