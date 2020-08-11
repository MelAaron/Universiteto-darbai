using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3_Laboras
{
    class ElektrinisVidrulys : BuitinisPrietaisas
    {
        public int Galia { get; set; }
        public int Turis { get; set; }

        /// <summary>
        /// naujas elektrinis vird.
        /// </summary>
        /// <param name="gamintojas">gamintojas</param>
        /// <param name="modelis">modelis</param>
        /// <param name="eKlase">energijos klase</param>
        /// <param name="spalva">spalva</param>
        /// <param name="kaina">kaina</param>
        /// <param name="galia">galia</param>
        /// <param name="turis">turis</param>
        public ElektrinisVidrulys (string gamintojas, string modelis, string eKlase
            , string spalva, double kaina, int galia, int turis) :
            base (gamintojas, modelis, eKlase, spalva, kaina)
        {
            Galia = galia;
            Turis = turis;
        }

        /// <summary>
        /// Metodas, i kuri kreipiamasi norint spausdinti elektrinio virdulio duomenis
        /// </summary>
        /// <returns>suformatuota informacija</returns>
        public override string ToString()
        {
            return String.Format("{0, -10}, {1, -9}, {2, -8}, {3, -7}, {4, -3}, {5, -5}," +
                " {6, -5}", Gamintojas, Modelis, EKlase, Spalva, Kaina, Galia, Turis);

        }

        /// <summary>
        /// leidzia lyginti du virdulius
        /// </summary>
        /// <param name="obj">tikrinamas objektas/param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            return this.Equals(obj as ElektrinisVidrulys);
        }

        public bool Equals(ElektrinisVidrulys elektrinisVirdulys)
        {
            return base.Equals(elektrinisVirdulys);
        }

        public override int GetHashCode()
        {
            return Gamintojas.GetHashCode() ^ Modelis.GetHashCode();
        }

        /// <summary>
        /// lygina desine ir kaire reiksmes, jei jos lygios, grazina true, o jei ne, grazina false
        /// </summary>
        /// <param name="lhs">kairysis lyginamasis</param>
        /// <param name="rhs">desinysis lyginamasis</param>
        /// <returns></returns>
        public static bool operator ==(ElektrinisVidrulys lhs, ElektrinisVidrulys rhs)
        {
            if (Object.ReferenceEquals(lhs, null))
            {
                if (Object.ReferenceEquals(rhs, null))
                {
                    return true;
                }
                return false;
            }
            return lhs.Equals(rhs);
        }

        public static bool operator !=(ElektrinisVidrulys lhs, ElektrinisVidrulys rhs)
        {
            return !(lhs == rhs);
        }
    }
}
