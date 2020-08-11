using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3._2_sav
{
    class Futbolininkas : Zaidejas
    {
        public int GeltonuKortSk { get; set; }

        public Futbolininkas (string komPavadinimas, string vardas, string pavarde, DateTime gimData, int zaistuRungSk, int taskai, int geltonuKortSk) :
            base(komPavadinimas, vardas, pavarde, gimData, zaistuRungSk, taskai)
        {
            GeltonuKortSk = geltonuKortSk;
        }

        public override string ToString()
        {
            return String.Format("{0} {1} {2} {3} {4} {5} {6}", KomPavadinimas, Vardas, Pavarde, GimData, ZaistuRungSk, Taskai, GeltonuKortSk);

        }
    }
}
