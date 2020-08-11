using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace U5_9
{
    class AktoriuKonteineris
    {
        private Aktorius[] Aktoriai;
        public int Count { get; private set; }

        public AktoriuKonteineris(int size)
        {
            Aktoriai = new Aktorius[size];
            Count = 0;
        }
        public void PridetiAktoriu(Aktorius aktorius)
        {
            Aktoriai[Count++] = aktorius;
        }
        public void NustatytiAktoriu(Aktorius aktorius, int index)
        {
            Aktoriai[index] = aktorius;
        }
        public Aktorius GautiAktoriu(int index)
        {
            return Aktoriai[index];
        }


        public bool Contains(Aktorius aktorius)
        {
            return Aktoriai.Contains(aktorius);
        }
    }
}
