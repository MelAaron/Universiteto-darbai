using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Teksto_eiluciu_daliu_salinimas
{
    class Program
    {
        static void Main(string[] args)
        {
            const string CFd = "..\\..\\Duomenys.txt";
            const string CFr = "..\\..\\Reultatai.txt";
            const string CFa = "..\\..\\Analize.txt";
            Program p = new Program();
            p.Apdotori(CFd, CFr, CFa);
        }

        /**Skaito, analizuoja ir raso i skirtingus failus.
         * @param fv - duomenu failo vardas
         * @param fvr - rezultatu failo vardas
         * @param fa - analizes failo vardas*/
        void Apdotori (string fv, string fvr, string fa)
        {
            string[] lines = File.ReadAllLines(fv, Encoding.GetEncoding(1257));
            using (var fr = File.CreateText(fvr))
            {
                using (var far = File.CreateText(fa))
                {
                    foreach (string line in lines)
                    {
                        if (line.Length > 0)
                        {
                            string nauja = line;
                            if (BeKomentaru(line, out nauja))
                            {
                                far.WriteLine(line);
                            }
                            if (nauja.Length > 0)
                            {
                                fr.WriteLine(nauja);
                            }
                        }
                        else
                            fr.WriteLine(line);
                    }
                }
            }
        }

        /**Pasalina is eilutes komentarus ir grazina pozymi, ar salino
         * @param line - eilute su komentarais
         * @param nauja - eilute be komentaru */
        bool BeKomentaru (string line, out string nauja)
        {
            nauja = line;
            for (int i = 0; i < line.Length - 1; i++)
            {
                if (line[i] == '/' && line[i + 1] == '/')
                {
                    nauja = line.Remove(i);
                    return true;
                }
            }
            return false;
        }
    }
}
