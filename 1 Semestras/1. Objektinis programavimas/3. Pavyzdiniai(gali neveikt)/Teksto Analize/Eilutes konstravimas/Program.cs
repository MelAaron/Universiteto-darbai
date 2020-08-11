using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Eilutes_konstravimas
{
    class Program
    {
        static void Main(string[] args)
        {
            const string CFd = "..\\..\\Duomenys.txt";
            const string CFr = "..\\..\\Rezultatai.txt";
            string skyr = " .,!?:;()\t'";
            string vardas = "Arvydas";
            string pavarde = "Sabonis";
            Program p = new Program();
            p.Apdoroti(CFd, CFr, skyr, vardas, pavarde);
        }

        /**Skaito faila ir analizuoja eilutes
         * @param df - duomenu failo vardas
         * @param fr - rezultatu failo vardas
         * @param skyrikliai - zodziu skyrikliai
         * @param vardas - zodis kurio ieskome */
        void Apdoroti (string fd, string fr, string skyrikliai, string vardas, string pavarde)
        {
            string[] lines = File.ReadAllLines(fd, Encoding.GetEncoding(1257));
            using (var far = File.CreateText(fr))
            {
                foreach (string line in lines)
                {
                    StringBuilder nauja = new StringBuilder();
                    Zodziai(line, skyrikliai, vardas, pavarde, nauja);
                    far.WriteLine(nauja);
                }
            }
        }
        ///**Analizuoja viena eilute
        // * fd - analizuojama eilute
        // * fr - rezultatu failo vardas
        // * skyrikliai - zodziu skyrikliai
        // * vardas - zodis kurio ieskome
        // * pavrde - zodis kuriuo papildome
        // * */
        //void Apdoroti (string fd, string fr, string skyrikliai, string vardas, string pavarde)
        //{
        //    string line = fd;
        //    StringBuilder nauja = new StringBuilder();
        //    Zodziai(line, skyrikliai, vardas, pavarde, nauja);
        //    Console.WriteLine(nauja);
        //}


            /** Iesko eiluteje zodziu ir konstruoja nauja eilute
             * line - duomenu eilute
             * skyrikliai - zodziu skyrikliai
             * vardas - zodis kurio ieskome
             * pavarde - zodis kuriuo papildom
             * nauja - rezultatu eilute */
        void Zodziai (string line, string skyrikliai, string vardas, string pavarde, StringBuilder nauja)
        {
            string papild = " " + line + " ";
            int prad = 1;
            int ind = papild.IndexOf(vardas);
            while (ind != -1)
            {
                if (skyrikliai.IndexOf(papild[ind - 1]) != -1 && skyrikliai.IndexOf(papild[ind + vardas.Length]) != -1)
                {
                    nauja.Append(papild.Substring(prad, ind + vardas.Length - prad));
                    nauja.Append(pavarde);
                    prad = ind + vardas.Length;
                }
                ind = papild.IndexOf(vardas, ind + 1);
            }
            nauja.Append(line.Substring(prad - 1));
        }
    }
}
