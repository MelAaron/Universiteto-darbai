using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3._2_sav
{
    class Zaidejas
    {
        public string KomPavadinimas { get; set; }
        public string Vardas { get; set; }
        public string Pavarde { get; set; }
        public DateTime GimData { get; set; }
        public int ZaistuRungSk { get; set; }
        public int Taskai { get; set; }

        public Zaidejas (string komPavadinimas, string vardas, string pavarde, DateTime gimData, int zaistuRungSk, int taskai)
        {
            KomPavadinimas = komPavadinimas;
            Vardas = vardas;
            Pavarde = pavarde;
            GimData = gimData;
            ZaistuRungSk = zaistuRungSk;
            Taskai = taskai;
        }
        
    }
}
