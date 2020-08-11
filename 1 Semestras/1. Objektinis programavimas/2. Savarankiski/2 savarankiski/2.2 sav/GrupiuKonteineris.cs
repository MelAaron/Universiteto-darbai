using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._2_sav
{
    class GrupiuKonteineris
    {
        private Vidurkis[] Vidurkis;
        public int Count { get; private set; }

        public GrupiuKonteineris(int size)
        {
            Vidurkis = new Vidurkis[size];
                Count = 0;
        }
        public void PridetiGrupe(Vidurkis vidurkis)
        {
            Vidurkis[Count++] = vidurkis;
        }
        public void PridetiGrupe(Vidurkis vidurkis, int index)
        {
            Vidurkis[index] = vidurkis;
        }
        public Vidurkis RastiVidurki(int index)
        {
            return Vidurkis[index];
        }
    }
}
