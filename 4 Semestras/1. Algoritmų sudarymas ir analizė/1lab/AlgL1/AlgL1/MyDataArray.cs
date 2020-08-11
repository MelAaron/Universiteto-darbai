using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgL1
{
    class MyDataArray : DataArray
    {
        Objektas[] data;
        public MyDataArray(int n, int seed)
        {
            data = new Objektas[n];
            length = n;
            Random rand = new Random(seed);
            for(int i = 0; i < length; i++)
            {
                Objektas temp = new Objektas((float)rand.NextDouble(), CreateString(4, rand));
                data[i] = temp;
            }
        }
        internal static string CreateString(int stringLength, Random rd)
        {
            const string allowedChars = "ABCDEFGHJKLMNOPQRSTUVWXYZ";
            char[] chars = new char[stringLength];

            for (int i = 0; i < stringLength; i++)
            {
                chars[i] = allowedChars[rd.Next(0, allowedChars.Length)];
            }
            return new string(chars);
        }
        public override Objektas this[int index]
        {
            get { return data[index]; }
        }
        public override void Swap(int j, Objektas a, Objektas b)
        {
            data[j - 1] = a;
            data[j] = b;
        }
        public override void Change(int index, Objektas naujas)
        {
            data[index] = naujas;
        }
    }
}
