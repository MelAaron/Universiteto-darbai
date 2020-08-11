using System;
using System.IO;
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
            const string CFd = "..\\..\\Duomenys.txt";
            const string CFr = "..\\..\\Rezultatai.txt";
            string zodis = "Arvydas";
            Program p = new Program();
            p.Apdoroti(CFd, CFr, zodis);
            Console.ReadKey();
        }
        void Apdoroti(string fd, string fr, string zodis)  //Nuskaito failus ir juos apdoroja
        {
            string[] lines = File.ReadAllLines(fd, Encoding.GetEncoding(1257));
            Spausdinimas(lines);
            Console.WriteLine();
            using (StreamWriter far = File.CreateText(fr))
            {
                foreach (string line in lines)
                {
                    Console.WriteLine(Zodziai(line,zodis));
                    far.WriteLine(Zodziai(line,zodis));
                }
            }
        }
        string Zodziai(string line, string zodis) 
        {
            if (line.Contains(zodis))
            {
                while (line.Contains(zodis))
                {
                    if(line.Length-zodis.Length == line.IndexOf(zodis))   //jei zodis eilutes gale
                    {
                        line = line.Remove(line.IndexOf(zodis), zodis.Length);
                    }
                    else   //jei zodis ne gale
                    {
                        line = line.Remove(line.IndexOf(zodis), zodis.Length+1);
                    }
                }
            }
            return line;
        }
        void Spausdinimas(string[] lines)
        {
            for(int i = 0; i < lines.Count(); i++)
            {
                Console.WriteLine(lines[i]);
            }
        }
    }
}
