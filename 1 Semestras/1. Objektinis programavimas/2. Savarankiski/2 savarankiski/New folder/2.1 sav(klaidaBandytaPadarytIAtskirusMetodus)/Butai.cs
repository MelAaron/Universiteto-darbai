using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._1_sav
{
    class Butai
    {
        public const int CN = 20;
        private Flats[] Bt1;
        public int Kiekis { get; private set; }

        public Butai()
        {
            Kiekis = 0;
            Bt1 = new Flats[CN];
        }
        public Flats Imti(int kuris)
        {
            return Bt1[kuris];
        }
        public void Deti(Flats b1)
        {
            Bt1[Kiekis++] = b1;
        }
        public void Deti (int kuris, Flats b1)
        {
            Bt1[kuris] = b1;
        }
    }
}
