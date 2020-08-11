using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buitinės_technikos_parduotuvė
{
    class Branch_Konteineris
    {
        public Branch[] branch_konteineriai { get; private set; }
        public int Kiekis { get; private set; }
        /// <summary>
        /// Sukuriamas konteineris
        /// </summary>
        /// <param name="dydis">Konteinerio dydis</param>
        public Branch_Konteineris(int dydis)
        {
            branch_konteineriai = new Branch[dydis];
            Kiekis = 0;
        }
        /// <summary>
        /// Pridėjimas prie konteinerio
        /// </summary>
        /// <param name="Branchas">Konteinerio klasė</param>
        public void PridėtiBranch(Branch Branchas)
        {
            branch_konteineriai[Kiekis] = Branchas;
            Kiekis++;
        }
        /// <summary>
        /// Gauname iš konteinerio branch
        /// </summary>
        /// <param name="indeksas">Kelintas branch</param>
        /// <returns></returns>
        public Branch GautiBranch(int indeksas)
        {
            return branch_konteineriai[indeksas];
        }
    }
}
