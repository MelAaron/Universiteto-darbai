using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3_Laboras
{
    class PrietaisuKonteineris
    {
        private BuitinisPrietaisas[] Prietaisai;
        public int Count { get; private set; }

        /// <summary>
        /// naujas prietaisu konteineris
        /// </summary>
        public PrietaisuKonteineris ()
        {
            Prietaisai = new BuitinisPrietaisas[100];
            Count = 0;
        }
        /// <summary>
        /// prideda prietaisa i konteineri
        /// </summary>
        /// <param name="prietaisas">prietaiso informacija</param>
        public void PridetiPrietaisa (BuitinisPrietaisas prietaisas)
        {
            Prietaisai[Count++] = prietaisas;
        }
        /// <summary>
        /// prideda prietaisa i nurodyta konteinerio vieta
        /// </summary>
        /// <param name="prietaisas">prietaiso info</param>
        /// <param name="index">konteinerio vieta</param>
        public void NustatytiPrietaisa (BuitinisPrietaisas prietaisas, int index)
        {
            Prietaisai[index] = prietaisas;
        }
        /// <summary>
        /// gauna prietaisa is konteinerio
        /// </summary>
        /// <param name="index">vieta konteineryje</param>
        /// <returns>prietaiso info</returns>
        public BuitinisPrietaisas GautiPrietaisa (int index)
        {
            return Prietaisai[index];
        }

        /// <summary>
        /// contains metodas. Tikrina ar konteineryje yra duodamas metodui prietaisas
        /// </summary>
        /// <param name="prietaisas">prietaiso info</param>
        /// <returns></returns>
        public bool Contains(BuitinisPrietaisas prietaisas)
        {
            return Prietaisai.Contains(prietaisas);
        }

        /// <summary>
        /// rusiuoja prietaisus (pagal ka rusiuoja galima pakeisti uzklojimuose)
        /// </summary>
        public void RusiuotiPrietaisus()
        {
            for (int i = 0; i < Count - 1; i++)
            {
                BuitinisPrietaisas mazReiksmesPrietaisas = Prietaisai[i];
                int mazReiksmesIndeksas = i;
                for (int j = i + 1; j < Count; j++)
                {
                    if(Prietaisai[j] <= mazReiksmesPrietaisas)
                    {
                        mazReiksmesPrietaisas = Prietaisai[j];
                        mazReiksmesIndeksas = j;
                    }
                }
                Prietaisai[mazReiksmesIndeksas] = Prietaisai[i];
                Prietaisai[i] = mazReiksmesPrietaisas;
            }
        }

        /// <summary>
        /// istrina prietaisa
        /// </summary>
        /// <param name="prietaisas">prietaiso info</param>
        public void IstrintiPrietaisa(BuitinisPrietaisas prietaisas)
        {
            int i = 0;
            while (i < Count)
            {
                if (Prietaisai[i].Equals(prietaisas))
                {
                    Count--;
                    for (int j = i; j < Count; j++)
                    {
                        Prietaisai[j] = Prietaisai[j + 1];
                    }
                    break;
                }
                i++;
            }
        }
    }
}
