using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insertion_sort_1
{
    class Line
    {
        float Number { get; set; }
        string Letters { get; set; }
        public Line(string letters, float number)
        {
            Number = number;
            Letters = letters;
        }

        public int ComapareTo(Line key)
        {
            if (Letters.CompareTo(key.Letters) > 0)
            { return 1; }
            if (Letters.CompareTo(key.Letters) < 0)
                return -1;
            if (Letters.CompareTo(key.Letters) == 0)
            {
                if (Number > key.Number)
                {
                    return 1;
                }
                if (Number < key.Number)
                {
                    return -1;
                }
                if (Number == key.Number)
                {
                    return 0;
                }
            }
            return 0;
        }
        public string toString()
        {
            return string.Format("{0} {1}", Letters, Number);

        }
    }
}
