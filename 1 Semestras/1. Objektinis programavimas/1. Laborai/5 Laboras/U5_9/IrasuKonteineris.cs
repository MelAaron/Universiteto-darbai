using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace U5_9
{
    class IrasuKonteineris
    {
        private Irasas[] Irasai;
        public int Count { get; private set; }

        public IrasuKonteineris(int size)
        {
            Irasai = new Irasas[size];
            Count = 0;
        }
        public void PridetiIrasa (Irasas irasas)
        {
            Irasai[Count++] = irasas;
        }
        public void NustatytiIrasa (Irasas irasas, int index)
        {
            Irasai[index] = irasas;
        }
        public Irasas GautiIrasa (int index)
        {
            return Irasai[index];
        }


        public bool Contains(Irasas irasas)
        {
            return Irasai.Contains(irasas);
        }

        //public void RusiuotiPrietaisus()
        //{
        //    for (int i = 0; i < Count - 1; i++)
        //    {
        //        BuitinisPrietaisas mazReiksmesPrietaisas = Prietaisai[i];
        //        int mazReiksmesIndeksas = i;
        //        for (int j = i + 1; j < Count; j++)
        //        {
        //            if (Prietaisai[j] <= mazReiksmesPrietaisas)
        //            {
        //                mazReiksmesPrietaisas = Prietaisai[j];
        //                mazReiksmesIndeksas = j;
        //            }
        //        }
        //        Prietaisai[mazReiksmesIndeksas] = Prietaisai[i];
        //        Prietaisai[i] = mazReiksmesPrietaisas;
        //    }
        //}
    }
}
