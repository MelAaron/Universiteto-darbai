using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3._2_sav
{
    class KomanduKonteineris
    {
        private Komanda[] komandos;
        public int Count { get; private set; }

        public KomanduKonteineris(int size)
        {
            komandos = new Komanda[size];
            Count = 0;
        }
        public void PridetiKomanda(Komanda komanda)
        {
            komandos[Count++] = komanda;
        }
        public void NustatytiKomanda(Komanda komanda, int index)
        {
            komandos[index] = komanda;
        }
        public Komanda GautiKomanda(int index)
        {
            return komandos[index];
        }
    }
}
