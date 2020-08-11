using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sav4
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Console.WriteLine("Įveskite savo vardą: ");
            string vardas = Console.ReadLine();
            Console.Write("Labas, ");
            int ilgis = vardas.Length;
            //Console.WriteLine(ilgis);
            //Console.WriteLine(vardas[ilgis]);

            if ((vardas[ilgis - 2] == 'a') && (vardas[ilgis - 1] == 's'))
            {
                
               //vardas[ilgis - 1] = 'i';
                //Console.WriteLine("{0}", vardas);
                for(int i = 0; i < ilgis - 2; i++)
                {
                    Console.Write("{0}", vardas[i]);
                }
                Console.Write("ai");
                Console.WriteLine("");
            }
            else
                if ((vardas[ilgis - 2] == 'i') && (vardas[ilgis - 1] == 's'))
            {
                for (int i = 0; i < ilgis - 2; i++)
                {
                    Console.Write("{0}", vardas[i]);
                }
                Console.Write("i");
                Console.WriteLine("");
            }
            else
                if ((vardas[ilgis - 2] == 'y') && (vardas[ilgis - 1] == 's'))
            {
                for (int i = 0; i < ilgis - 2; i++)
                {
                    Console.Write("{0}", vardas[i]);
                }
                Console.Write("y");
                Console.WriteLine("");
            }
            if (vardas[ilgis - 1] == 'ė')
            {
                for (int i = 0; i < ilgis - 1; i++)
                {
                    Console.Write("{0}", vardas[i]);
                }
                Console.Write("e");
                Console.WriteLine("");
            }
        }
    }
}
