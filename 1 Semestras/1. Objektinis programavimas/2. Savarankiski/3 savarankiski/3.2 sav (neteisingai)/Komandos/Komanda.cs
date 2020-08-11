using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3._2_sav
{
    class Komanda
    {
        public string KPavadinimas { get; set; }
        public string Miestas { get; set; }
        public string Treneris { get; set; }
        public int RungtyniuSk { get; set; }

        public Komanda (string kPavadinimas, string miestas, string treneris, int rungtyniuSk)
        {
            KPavadinimas = kPavadinimas;
            Miestas = miestas;
            Treneris = treneris;
            RungtyniuSk = rungtyniuSk;
        }
    }
}
