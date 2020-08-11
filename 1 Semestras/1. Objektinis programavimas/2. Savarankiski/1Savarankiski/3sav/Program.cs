using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3sav
{
    class Program
    {
        static void Main(string[] args)
        {
            
            char veiksmas;
            double ats;

            Console.WriteLine("Įveskite pirmą skaičių: ");
            double x = double.Parse(Console.ReadLine());

            Console.WriteLine("Įveskite antrą skaičių: ");
            double y = double.Parse(Console.ReadLine());

            Console.WriteLine("Įeskite veiksmo ženklą: ");
            veiksmas = char.Parse(Console.ReadLine());

            if (veiksmas == '+')
            {
                ats = x + y;
                Console.WriteLine("{0} {1} {2} = {3}", x, veiksmas, y, Math.Round(ats, 3));
            }
            else if (veiksmas == '-')
            {
                ats = x - y;
                Console.WriteLine("{0} {1} {2} = {3}", x, veiksmas, y, Math.Round(ats, 3));
            }
            else if (veiksmas == '*')
            {
                ats = x * y;
                Console.WriteLine("{0} {1} {2} = {3}", x, veiksmas, y, Math.Round(ats, 3));
            }
            else if (veiksmas == '/')
            {
                if (y == 0)
                {
                    Console.WriteLine("K L A I D A");
                }
                else
                {
                    ats = x / y;
                    Console.WriteLine("{0} {1} {2} = {3}", x, veiksmas, y, Math.Round(ats, 3));
                }
            }
            else
            {
                Console.WriteLine("K L A I D A");
            }
        }
    }
}
