using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _1Laboras
{
    public class Konteineris
    {
        private string[] kauliukai;
        public int Count { get; private set; }

        /// <summary>
        /// Sukuria nauja kauliuku konteineri 7 dydzio
        /// </summary>
        public Konteineris ()
        {
            kauliukai = new string[7];
            Count = 0;
        }

        /// <summary>
        /// sukuria nauja konteineri, dydi leidziama nustatyti
        /// </summary>
        /// <param name="dydis">konteinerio dydis</param>
        public Konteineris (int dydis)
        {
            kauliukai = new string[dydis];
                Count = 0;
        }

        /// <summary>
        /// Prideti kauliuka i konteineri
        /// </summary>
        /// <param name="kauliukas">kauliukas</param>
        public void PridetiKauliuka(string kauliukas)
        {
            kauliukai[Count++] = kauliukas;
        }

        /// <summary>
        /// Nustatyti kauliuko duomenis
        /// </summary>
        /// <param name="kauliukas">naujas kauliukas</param>
        /// <param name="ind">naujo kauliuko vieta konteineryje</param>
        public void NustatytiKauliuka (string kauliukas, int ind)
        {
            kauliukai[ind] = kauliukas;
        }

        /// <summary>
        /// Paima kauliuka is konteinerio
        /// </summary>
        /// <param name="ind">norimo kauliuko vieta konteineryje</param>
        /// <returns>kauliuka</returns>
        public string GautiKauliuka (int ind)
        {
            return kauliukai[ind];
        }

        public string ApverstiKauliuka (int index)
        {
            return kauliukai[index][1] + kauliukai[index][0].ToString();
        }

        /// <summary>
        /// Sukuria nauja konteineri be nurodyto kauliuko
        /// </summary>
        /// <param name="a">paduotas konteineris</param>
        /// <param name="index">nenorimas kauliukas</param>
        public Konteineris(Konteineris a, int index)
        {
            int aa = 0;
                kauliukai = new string[a.Count - 1];
                for (int i = 0; i < a.Count; i++)
                    if (i != index) kauliukai[aa++] = a.GautiKauliuka(i);
            Count = a.Count-1;
        }
    }
}