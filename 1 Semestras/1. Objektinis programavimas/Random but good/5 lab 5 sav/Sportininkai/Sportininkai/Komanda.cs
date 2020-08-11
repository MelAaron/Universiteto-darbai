using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sportininkai
{
    class Komanda
    {
        public string KomandosPavadinimas { get; set; }
        public string Miestas { get; set; }
        public string KomandosTreneris { get; set; }
        public int ZaistuRungtyniuSkaicius { get; set; }
        public Komanda(string komandosPavadinimas, string miestas, string komandosTreneris, int zaistuRungtyniuSkaicius)
        {
            KomandosPavadinimas = komandosPavadinimas;
            Miestas = miestas;
            KomandosTreneris = komandosTreneris;
            ZaistuRungtyniuSkaicius = zaistuRungtyniuSkaicius;
        }
        public static bool operator ==(string PasirinktasMiestas, Komanda komanda)
        {
            return PasirinktasMiestas == komanda.Miestas;
        }
        public static bool operator !=(string PasirinktasMiestas, Komanda komanda)
        {
            return PasirinktasMiestas != komanda.Miestas;
        }
        public override string ToString()
        {
            return String.Format("{0} {1} {2} {3} ", KomandosPavadinimas, Miestas, KomandosTreneris, ZaistuRungtyniuSkaicius);
        }
    }
}
