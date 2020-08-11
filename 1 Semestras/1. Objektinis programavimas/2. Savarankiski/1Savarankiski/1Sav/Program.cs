using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1Sav
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Įveskite simbolį: ");
            string character = Console.ReadLine();

            Console.WriteLine("Įveskite eilučių kieki: ");
            int eiluciukiekis = int.Parse( Console.ReadLine());

            Console.WriteLine("Įveskite simbolių kiekį eilutėje: ");
            int simboliukiekis = int.Parse( Console.ReadLine());

            for (int i = 1; i <= eiluciukiekis; i++)
            {
                for (int y = 1; y <= simboliukiekis; y++)
                {
                    Console.Write("{0}", character);
                }
                Console.WriteLine("");
            }
            Console.ReadKey();
        }
    }
}
/*
 * Console.WriteLine("Įveskite simbolį: ");
            string character = Console.ReadLine();
            for (int i = 1; i < 51; i++)
            {
                Console.Write("{0}", character);
                if (i % 5 == 0)
                        Console.WriteLine("");
            }
            Console.WriteLine("");
            Console.ReadKey();
            */