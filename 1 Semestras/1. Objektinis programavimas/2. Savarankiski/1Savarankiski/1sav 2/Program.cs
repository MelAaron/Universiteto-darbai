using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1sav_2
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Console.WriteLine("Įveskite simbolį: ");
            string character = Console.ReadLine();

            Console.WriteLine("Įveskite simbolių skaičių: ");
            int simboliu_kiekis = int.Parse(Console.ReadLine());

            Console.WriteLine("Įveskite simbolių skaičių eilutėje: ");
            int simboliu_skaicius = int.Parse(Console.ReadLine());

            int eiluciu_skaicius = simboliu_kiekis / simboliu_skaicius;
            double simboliu_likutis = simboliu_kiekis - (eiluciu_skaicius * simboliu_skaicius);
            
            for (int i = 0; i < eiluciu_skaicius; i++)
            {
                for (int j = 0; j < simboliu_skaicius; j++)
                {
                    Console.Write("{0}", character);
                }
                Console.WriteLine("");
            }

            for (int y = 0; y < simboliu_likutis; y++)
            {
                Console.Write("{0}", character);
            }
            Console.WriteLine("");
            /*while(simboliu_kiekis > 0)
            {
                for (int u = 0; u < simboliu_skaicius; u++)
                {
                    Console.Write("{0}", character);
                    simboliu_kiekis--;
                }
                Console.WriteLine("");
            }*/
        }
    }
}
