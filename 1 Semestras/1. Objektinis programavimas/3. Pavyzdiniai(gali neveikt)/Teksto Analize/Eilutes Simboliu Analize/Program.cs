using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Eilutes_Simboliu_Analize
{
    class Program
    {
        static void Main(string[] args)
        {
            const string CFd = "..\\..\\Duomenys.txt";
            const string CFr = "..\\..\\Rezultatai.txt";


            Program p = new Program();
            RaidziuDazniai eil = new RaidziuDazniai();

            p.Dazniai(CFd, eil);
            p.Spausdinti(CFr, eil);

        }

        //---------------------------------------------
        /** Iveda is nurodyto failo ir skaiciuoja raidziu daznius.
         * @param fv - failo vardas
         * @param eil 0 eilutes objektas */
        void Dazniai(string fv, RaidziuDazniai eil)
        {
            using (StreamReader reader = new StreamReader(fv))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    eil.eil = line;
                    eil.kiek();
                }
            }
        }
        
        void Spausdinti(string fv, RaidziuDazniai eil)
        {
            using (var fr = File.CreateText(fv))
            {
                for (char sim = 'a'; sim <= 'z'; sim++)
                {
                    fr.WriteLine("{0, 3:c} {1, 4:d}   |{2, 3:c} {3, 4:d}", sim, eil.Imti(sim), Char.ToUpper(sim), eil.Imti(Char.ToUpper(sim)));
                }
            }
        }

        class RaidziuDazniai
        {
            private const int CMax = 256;
            private int[] Rn; // raidziu pasikartojimai
            public string eil { get; set; }
            public RaidziuDazniai()
            {
                eil = "";
                Rn = new int[CMax];
                for (int i = 0; i < CMax; i++)
                {
                    Rn[i] = 0;
                }
            }
            public int Imti(char sim)
            {
                return Rn[sim];
            }
            //--------------------------------------
            /**Skaiciuoja raidziu pasikartojimus */
            public void kiek()
            {
                for (int i = 0; i < eil.Length; i++)
                {
                    if (('a' <= eil[i] && eil[i] <= 'z') || ('A' <= eil[i] && eil[i] <= 'Z'))
                    {
                        Rn[eil[i]]++;
                    }

                }
            }
        }
    }
}
