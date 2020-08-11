using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2sav
{
    class Program
    {
        static void Main(string[] args)
        {
            double y, x;
            Console.WriteLine("Įveskite x reikšmę: ");
            x = double.Parse(Console.ReadLine ());
            if ((x >= -4) && (x <= 0))
            {
                y = Math.Cos(x);
                Console.WriteLine("Cos(x) = {0}", Math.Round(y, 3));
            }
            else if ((x > 0) && (x < 4))
            {
                y = 1 / (Math.Pow(x + 5, 3));
                Console.WriteLine("1 / (x + 5) ^ 3 = {0}", Math.Round(y, 3));
            }
            else
            {
                y = Math.Pow(Math.Pow(x, 2) + 1, 0.5);
                Console.WriteLine("(x ^ 2 + 1) ^ 0,5 = {0}", Math.Round(y, 3));
            }
            //Console.WriteLine("{0}, {1}", x, y);
        }
    }
}
