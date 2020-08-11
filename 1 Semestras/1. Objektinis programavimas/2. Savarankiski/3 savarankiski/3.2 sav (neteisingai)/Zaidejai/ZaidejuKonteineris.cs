using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3._2_sav
{
    class ZaidejuKonteineris
    {
        private Zaidejas[] zaidejai;
        public int Count { get; private set; }

        public ZaidejuKonteineris (int size)
        {
            zaidejai = new Zaidejas[size];
            Count = 0;
        }
        public void PridetiZaideja (Zaidejas zaidejas)
        {
            zaidejai[Count++] = zaidejas;
        }
        public void NustatytiZaideja (Zaidejas zaidejas, int index)
        {
            zaidejai[index] = zaidejas;
        }
        public Zaidejas GautiZaideja (int index)
        {
            return zaidejai[index];
        }

        


    }
}
