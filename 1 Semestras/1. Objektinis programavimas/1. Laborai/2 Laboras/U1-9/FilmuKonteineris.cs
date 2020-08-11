using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace U1_9
{
    class FilmuKonteineris
    {
        private Sąrašas[] filmai;
        public int Count { get; private set; }

        /// <summary>
        /// sukuriamas naujas filmu konteineris
        /// </summary>
        /// <param name="size">filmu konteinerio dydis</param>
        public FilmuKonteineris (int size)
        {
            filmai = new Sąrašas[size];
            Count = 0;
        }
        /// <summary>
        /// prideti filma i konteineri
        /// </summary>
        /// <param name="filmas">filmo duomenys</param>
        public void PridetiFilma (Sąrašas filmas)
        {
            filmai[Count++] = filmas;
        }
        /// <summary>
        /// prideti filma i nustatyta vieta
        /// </summary>
        /// <param name="filmas">filmo duomenys</param>
        /// <param name="index">vieta konteineryje</param>
        public void PridetiFilma (Sąrašas filmas, int index)
        {
            filmai[index] = filmas;
        }
        /// <summary>
        /// randa filma konteyneryje
        /// padavus jo vieta
        /// </summary>
        /// <param name="index">filmo vieta konteineryje</param>
        /// <returns></returns>
        public Sąrašas RastiFilma (int index)
        {
            return filmai[index];
        }

        /// <summary>
        /// ToString uzklojimas,
        /// leidziantis formatuotai spausdinti
        /// filmu duomenis
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            var builder = new StringBuilder();
            foreach(var filmas in filmai)
            {
                
                if (filmas == null)
                    break;
                builder.AppendLine(filmas.ToString());
            }
            return builder.ToString();
            
        }

        /// <summary>
        /// contains uzklojimas
        /// leidzia ziureti ar konteineris turi
        /// pauota filma
        /// </summary>
        /// <param name="filmas">paduotas filmas tikrinamas</param>
        /// <returns>grazina ar filmas yra komnteineryje</returns>
        public bool Contains(Sąrašas filmas)
        {
            return filmai.Contains(filmas);
        }
        
    }
}
