using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace Zodziu_isskyrimas_eluteje
{
    class Program
    {
        static void Main(string[] args)
        {
            const string CFd = "..\\..\\Duomenys.txt";
            string skirt = "[\\s,.;:!?()\\-]+"; //skyrikliai tarp zodziu
            Program p = new Program();
            Console.WriteLine("Sutampanciu zodziu {0, 3:d}", p.Apdoroti(CFd, skirt));



            //const string CFd = "..\\..\\Duomenys.txt";
            //char [] skyrikliai = { ' ', '.', ',', '!', '?', ':', ';', '(', ')', '\t' };
            //Program p = new Program();
            //Console.WriteLine("Sutampanciu zodziu {0, 3:d}", p.Apdoroti(CFd, skyrikliai));
        }

        /**Skaito faila ir analizuoja eilutes
         * @param fv - duomenu failo vardas
         * @param skyrikliai - zodziu skyrikliai */
        int Apdoroti (string fv, string skyrikliai)
        {
            string[] lines = File.ReadAllLines(fv, Encoding.GetEncoding(1257));
            int sutampa = 0;
            foreach (string line in lines)
            {
                if (line.Length > 0)
                {
                    sutampa += Zodziai(line, skyrikliai);
                }
            }
            return sutampa;
        }

        /**Skaido eilute i zodzius ir analizuoja zodzius
         * @param eilute - duomenu eilute
         * @param skyrikliai - zodziu skyrikliai */
        int Zodziai (string eilute, string skyrikliai)
        {
            string[] parts = Regex.Split(eilute, skyrikliai);
            int sutampa = 0;
            foreach (string zodis in parts)
            {
                if (zodis.Length > 0) // yra tusciu zodziu eiluciu pabaigoje
                {
                    if (zodis[0] == zodis[zodis.Length - 1])
                    {
                        sutampa++;
                    }
                }
            }
            return sutampa;
        }


        ///** Skaito faila ir analizuoja eilutes.
        // * @param fv - duomenu failo vardas
        // * @param skyrikliai - zodziu skyrikliai */
        //int Apdoroti (string fv, char [] skyrikliai)
        //{
        //    string[] lines = File.ReadAllLines(fv, Encoding.GetEncoding(1257));
        //    int sutampa = 0;
        //    foreach (string line in lines)
        //    {
        //        if(line.Length > 0)
        //        {
        //            sutampa += Zodziai(line, skyrikliai);
        //        }
        //    }
        //    return sutampa;
        //}

        ///** Skaido eilute i zodzius ir analizuoja zodzius
        // * @param eilute - duomenu eilute
        // * @param skyrikliai - zodziu skyrikliai */
        //int Zodziai (string eilute, char [] skyrikliai)
        //{
        //    string[] parts = eilute.Split(skyrikliai, StringSplitOptions.RemoveEmptyEntries);
        //    int sutampa = 0;
        //    foreach (string zodis in parts)
        //    {
        //        if (zodis [0] == zodis[zodis.Length - 1])
        //        {
        //            sutampa++;
        //        }
        //    }
        //    return sutampa;
        //}
    }
}
