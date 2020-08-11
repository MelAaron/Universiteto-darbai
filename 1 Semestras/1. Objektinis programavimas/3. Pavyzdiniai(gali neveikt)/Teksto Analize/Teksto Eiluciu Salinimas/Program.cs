using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Teksto_Eiluciu_Salinimas
{
    class Program
    {
        static void Main(string[] args)
        {
            const string CFd = "..\\..\\Duomenys.txt";
            const string CFr = "..\\..\\Rezultatai.txt";
            int nr;
            Program p = new Program();
            p.Skaityti(CFd, out nr);
            p.Spausdinti(CFd, CFr, nr);
            Console.WriteLine("Ilgiausios eilutes nr. {0, 4:d}", nr + 1);
        }

        void Spausdinti (string fv, string fvr, int nr)
        {
            string[] lines = File.ReadAllLines(fv, Encoding.GetEncoding(1257));
            int nreil = 0;
            using (var fr = File.CreateText(fvr))
            {
                foreach (string line in lines)
                {
                    if (nr != nreil)
                    {
                        fr.WriteLine(line);
                    }
                    nreil++;
                }
            }
        }

        /** Suranda ilgiausios eilute numeri.
         * @param fv - duomenu failo vardas
         * @param nr - ilgiausios eilutes nr */
        void Skaityti (string fv, out int nr)
        {
            string[] lines = File.ReadAllLines(fv, Encoding.GetEncoding(1257));
            int ilgis = 0;
            nr = 0;
            int nreil = 0;
            foreach (string line in lines)
            {
                if (line.Length > ilgis)
                {
                    ilgis = line.Length;
                    nr = nreil;
                }
                nreil++;
            }
        }
    }
}
