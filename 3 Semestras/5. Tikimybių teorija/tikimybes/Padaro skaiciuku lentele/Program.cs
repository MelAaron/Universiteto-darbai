using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Padaro_skaiciuku_lentele
{
    class Program
    {
        // Priskiriami duomenų failai
        const string CFd = "...\\...\\duomenys.txt";
        const string CFr = "...\\...\\Rezultatas.txt";

        static void Main(string[] args)
        {
            double[] masyvasp = new double[100]; //Nustato kad bus tik 100 skaiciu masyve
            double[] masyvasb = new double[100];
            // Tikrina ar jau egzistuoaj rezultatų failas. Jei taip ji ištrina
            if (File.Exists(CFr))
                File.Delete(CFr);
            Console.WriteLine("Nuskaitomas masyvas.");
            Skaityti(CFd, masyvasp);
            Console.WriteLine("Vyksta rykiavimas. Neišjunkite programos.");
            Surikiavimas(masyvasp, masyvasb);
            Console.WriteLine("Spausdinami rezultatai.");
            SpausdintiRezultatus(CFr, masyvasb);
            Console.WriteLine("Programa baigė darbą.");
            Console.WriteLine();
        }
        /// <summary>
        /// Nuskaito pradinius duomenys
        /// </summary>
        /// <param name="Fd">Pradiniu duomenų failas</param>
        /// <param name="masyvas">Masyvas į kurį sukeliami duomenys</param>
        static void Skaityti(string Fd, double[] masyvas)
        {
            using (StreamReader reader = new StreamReader(Fd))
            {
                string line;
                int n;
                n = 100;
                for (int i = 0; i < n; i++)
                {
                    line = reader.ReadLine();
                     masyvas[i] = double.Parse(line);
                }
            }
        }

        /// <summary>
        /// Perkelia iš pradinio masyvo maziausia narį į naują masyvą
        /// </summary>
        /// <param name="masyvasp">Pradinis masyvas</param>
        /// <param name="masyvasb">Naujas masyvas</param>
        static void Surikiavimas(double[] masyvasp, double[] masyvasb)
        {
            double min = 1000;
            int kiek = 0;
            for (int j = 0; j < masyvasp.Length; j++)
            {
                for (int i = 0; i < masyvasp.Length; i++)
                {
                    if (min >= masyvasp[i])
                        min = masyvasp[i];
                }
                for (int i = 0; i < masyvasp.Length; i++)
                {
                    if (min == masyvasp[i])
                    {
                        masyvasp[i] = 1000;
                        break;
                    }
                }
                masyvasb[kiek] = min;
                kiek++;
                min = 1000;
            }
        }

        /// <summary>
        /// Spausdina naują masyva į rezultatų failą
        /// </summary>
        /// <param name="fv">Rezultatų failas</param>
        /// <param name="masyvasb">Naujas masyvas</param>
        static void SpausdintiRezultatus(string fv, double[] masyvasb)
        {
            using (var fr = File.AppendText(fv))
            {
                for (int i = 0; i < masyvasb.Length; i++)
                {
                    fr.WriteLine(masyvasb[i]);
                }
            }
        }
    }
}
