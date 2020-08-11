using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2sav
{
    class ZaidejuKonteineris
    {
        private Zaidejas[] Zaidejai;
        public int Count { get; private set; }

        public ZaidejuKonteineris(int size)
        {
            Zaidejai = new Zaidejas[size];
            Count = 0;
        }
        public void PridetiZaideja(Zaidejas zaidejas)
        {
            Zaidejai[Count++] = zaidejas;
        }
        public void NustatytiZaideja(Zaidejas zaidejas, int index)
        {
            Zaidejai[index] = zaidejas;
        }
        public Zaidejas GautiZaidja(int index)
        {
            return Zaidejai[index];
        }


        public bool Contains(Zaidejas zaidejas)
        {
            return Zaidejai.Contains(zaidejas);
        }
    }
}
