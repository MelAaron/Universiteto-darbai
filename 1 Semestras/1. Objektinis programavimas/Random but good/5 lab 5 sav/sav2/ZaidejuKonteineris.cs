using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sav2
{
    
    class ZaidejuKonteineris
    {
        //const int maxzaideju = 25;
        private Zaidejas[] Zaidejai { get; set; }
        public int Count { get; set; }
        public ZaidejuKonteineris(int maxzaideju)
        {
            Zaidejai = new Zaidejas[maxzaideju];
            Count = 0;
        }
        public void PridetiZaideja(Zaidejas naujasZaidejas)
        {
            Zaidejai[Count++] = naujasZaidejas;
        }
        public Zaidejas GetZaidejas(int index)
        {
            return Zaidejai[index];
        }
        public double Vidurkis()
        {
            double vid = 0;
            for (int i = 0; i < Count; i++)
                vid += Zaidejai[i].Taskai;
            return (vid /= Count);
        }
        public bool Contains(Zaidejas zaidejas)
        {
            return Zaidejai.Contains(zaidejas);
        }
        public static ZaidejuKonteineris operator +(ZaidejuKonteineris a, Zaidejas b)
        {
            a.PridetiZaideja(b);
            return a;
        }
    }
}
