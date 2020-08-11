using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3._2_sav
{
    class Krepsininkas : Zaidejas
    {
        public int AtkovotuKamSk  { get; set; }
        public int RezPerdSk { get; set; }

        public Krepsininkas(string komPavadinimas, string vardas, string pavarde, DateTime gimData, int zaistuRungSk, int taskai, int atkovotuKamsk, int rezPerdSk) :
            base(komPavadinimas, vardas, pavarde, gimData, zaistuRungSk, taskai)
        {
            AtkovotuKamSk = atkovotuKamsk;
            RezPerdSk = rezPerdSk;
        }

        public override string ToString()
        {
            return String.Format("{0} {1} {2} {3} {4} {5} {6} {7}", KomPavadinimas, Vardas, Pavarde, GimData, ZaistuRungSk, Taskai, AtkovotuKamSk, RezPerdSk);

        }
    }
}
