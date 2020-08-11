using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sportininkai
{
    class ZaidejuKonteineris
    {
        private Žaidėjas[] Zaidejai;
        public int Skaicius { get; set; }
        public ZaidejuKonteineris(int size)
        {
            Zaidejai = new Žaidėjas[size];
        }
        public void PridedaZaideja(Žaidėjas zaidejas)
        {
            Zaidejai[Skaicius] = zaidejas;
            Skaicius++;
        }
        public void NustatoZaideja(int indeksas, Žaidėjas zaidejas)
        {
            Zaidejai[indeksas] = zaidejas;
        }
        public Žaidėjas PaimaZaideja(int indeksas)
        {
            return Zaidejai[indeksas];
        }
    }
}
