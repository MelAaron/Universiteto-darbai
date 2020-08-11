using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buitinės_technikos_parduotuvė
{
    class Saldytuvu_konteineris
    {
        private Saldytuvas[] Saldytuvai;
        public int Kiekis { get; private set; }
        /// <summary>
        /// Sukuriamas konteineris
        /// </summary>
        /// <param name="dydis">Koks konteinerio dydis</param>
        public Saldytuvu_konteineris(int dydis)
        {
            Saldytuvai = new Saldytuvas[dydis];
            Kiekis = 0;
        }
        /// <summary>
        /// Pridėjimas prie konteinerio šaldytuvas
        /// </summary>
        /// <param name="saldytuvas">Šaldytuvo parametrai</param>
        public void PridėtiŠaldytuvą(Saldytuvas saldytuvas)
        {
            Saldytuvai[Kiekis] = saldytuvas;
            Kiekis++;
        }
        /// <summary>
        /// Pridėjimas prie konteinerio
        /// </summary>
        /// <param name="saldytuvas">Šaldytuvo parametrai</param>
        /// <param name="indeksas">Kelintas šaldytuvas</param>
        public void PridėtiŠaldytuvą(Saldytuvas saldytuvas, int indeksas)
        {
            Saldytuvai[indeksas] = saldytuvas;
        }
        /// <summary>
        /// Gauname iš konteinerio šaldytuvą
        /// </summary>
        /// <param name="indeksas">Kurį šaldytuvą</param>
        /// <returns>Mes paduodame tą šaldytuvą</returns>
        public Saldytuvas GautiŠaldytuvą(int indeksas)
        {
            return Saldytuvai[indeksas];
        }
    }
}
