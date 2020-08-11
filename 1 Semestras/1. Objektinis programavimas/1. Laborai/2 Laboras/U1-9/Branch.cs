using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace U1_9
{
    class Branch
    {
        public const int MaxFilmuSk = 500;

        public string Vardas { get; set; }
        public FilmuKonteineris Filmai { get; private set; }

        /// <summary>
        /// sukuriamas naujas branch
        /// ziurovo informacija
        /// jo matyti filmai
        /// </summary>
        /// <param name="vardas">ziurovo vardas</param>
        public Branch (string vardas)
        {
            Vardas = vardas;
            Filmai = new FilmuKonteineris(MaxFilmuSk);
            
        }

        /// <summary>
        /// uzklojimas tostring
        /// leidzia formatuotai spausdinti informacija
        /// </summary>
        /// <returns>suformatuota informacija</returns>
        public override string ToString()
        {
            var builder = new StringBuilder();
            builder.AppendLine(Filmai.ToString());
            builder.AppendLine("Ziurovas: " + Vardas);
            builder.AppendLine("");
            return builder.ToString();
            //return String.Format("Pav: {0}, Metai: {1}, Zanras: {2}, Studija {3}, Rezisierius: {4} {5}, Aktoriai: {6}, {7}, Pajamos: {8}", Filmas, Metai, Zanras, Studija, RezisieriausVardas, RezisieriausPavarde, Aktorius1, Aktorius2, Pajamos);
        }
    }
}
