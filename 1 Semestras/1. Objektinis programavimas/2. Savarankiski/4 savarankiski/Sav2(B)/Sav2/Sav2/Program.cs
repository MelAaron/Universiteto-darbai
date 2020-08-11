using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sav2
{
    class Program
    {
        static void Main(string[] args)
        {
            const string CFd = "..\\..\\Duomenys.txt";
            const string CFr = "..\\..\\Rezultatai.txt";
            const string CFa = "..\\..\\Analize.txt";
            Program p = new Program();
            p.Apdoroti(CFd, CFr, CFa);
            Console.ReadKey();
        }

        /* Skaito, analizuoja ir rašo į skirtingus failus.
        @param fv - duomenų failo vardas
        @param fvr - rezultatų failo vardas
        @param fa - analizės failo vardas */
        void Apdoroti(string fv, string fvr, string fa)
        {
            string[] tlines = File.ReadAllLines(fv, Encoding.GetEncoding(1257));
            string[] lines = PanaikinaKomentarus(tlines);
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
                                far.WriteLine(line);
                            if (nauja.Length > 0)
                                fr.WriteLine(nauja);
                        }
                        else
                            fr.WriteLine(line);
                    }
                }
            }
        }

        //------------------------------------------------------------
        /* Pašalina iš eilutės komentarus ir grąžina požymį, ar šalino.
@param line - eilutė su komentarais
@param nauja - eilutė be komentarų */
        bool BeKomentaru(string line, out string nauja)
        {
            nauja = line;
            for (int i = 0; i < line.Length - 1; i++)
                if (line[i] == '/' && line[i + 1] == '/')
                {
                    nauja = line.Remove(i);
                    return true;
                }
            return false;
        }

        bool Tikrina(string eilute) //Iesko komentaro pradžios
        {
            int Skaicius = 0;
            for (int j = 0; j < eilute.Length - 1; j++)
            {
                if (eilute[j] == '/' && eilute[j + 1] == '*')
                {
                    return true;
                }
            }
            return false;
        }

        bool IeskoPabaigos(string eilute) //Iesko komentaro pabaigos
        {
            int Skaicius = 0;
            for (int j = 0; j < eilute.Length - 1; j++)
            {
                if (eilute[j] == '*' && eilute[j + 1] == '/')
                {
                    return true;
                }
            }
            return false;
        }

        public string[] PanaikinaKomentarus(string[] lines) //Pašalina komentarus su /* */  skyrikliais
        {
            int Pabaiga = 0;
            int z = 0;

            for (int i = 0; i < lines.Count(); i++)
            {
                if (Tikrina(lines[i]))
                {
                    Pabaiga = i;
                    while (z == 0)
                    {
                        if (IeskoPabaigos(lines[Pabaiga]))
                        {
                            z++;
                        }
                        lines[Pabaiga] = lines[Pabaiga].Remove(0);
                        Pabaiga++;
                    }
                    z = 0;
                }
            }
            return lines;
        }
        

    }
}
