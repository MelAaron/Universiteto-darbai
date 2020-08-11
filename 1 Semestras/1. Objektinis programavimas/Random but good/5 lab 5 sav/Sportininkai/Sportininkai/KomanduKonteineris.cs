using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sportininkai
{
    class KomanduKonteineris
    {
        private Komanda[] Komandos;
        public int KomanduSkaicius { get; set; }
        public KomanduKonteineris(int size)
        {
            Komandos = new Komanda[size];
        }
        public void PridedaKomanda(Komanda komanda)
        {
            Komandos[KomanduSkaicius] = komanda;
            KomanduSkaicius++;
        }
        public void NustatoKomanda(int indeksas, Komanda komanda)
        {
            Komandos[indeksas] = komanda;
        }
        public Komanda PaimaKomanda(int indeksas)
        {
            return Komandos[indeksas];
        }
    }
}
