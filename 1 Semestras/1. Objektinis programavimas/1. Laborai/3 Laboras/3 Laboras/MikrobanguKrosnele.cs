using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3_Laboras
{
    class MikrobanguKrosnele : BuitinisPrietaisas
    {
        public int Galingumas { get; set; }
        public int ProgSkaicius { get; set; }

        /// <summary>
        /// nauja krosnele
        /// </summary>
        /// <param name="gamintojas">gamintojas</param>
        /// <param name="modelis">modelis</param>
        /// <param name="eKlase">energijos klase</param>
        /// <param name="spalva">slapva</param>
        /// <param name="kaina">kaina</param>
        /// <param name="galingumas">galingumas</param>
        /// <param name="progSkaicius">programu skaicius</param>
        public MikrobanguKrosnele (string gamintojas, string modelis, string eKlase,
            string spalva, double kaina, int galingumas, int progSkaicius) :
            base(gamintojas, modelis, eKlase, spalva, kaina)
        {
            Galingumas = galingumas;
            ProgSkaicius = progSkaicius;
        }

        /// <summary>
        /// Metodas, i kuri kreipiamasi norint spausdinti mikrobangu krosneles duomenis
        /// </summary>
        /// <returns>suformatuota informacija</returns>
        public override string ToString()
        {
            return String.Format("{0, -10}, {1, -7}, {2, -10}, {3, -7}, {4, -5}, {5, -9}," +
                " {6, -5}", Gamintojas, Modelis, EKlase, Spalva, Kaina, Galingumas,
                ProgSkaicius);

        }

        /// <summary>
        /// leidzia lyginti dvi krosneles
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            return this.Equals(obj as MikrobanguKrosnele);
        }

        public bool Equals(MikrobanguKrosnele mikrobanguKrosnele)
        {
            return base.Equals(mikrobanguKrosnele);
        }

        public override int GetHashCode()
        {
            return Gamintojas.GetHashCode() ^ Modelis.GetHashCode();
        }

        /// <summary>
        /// sulygina kaire ir desine reiksmes, jei jos lygios grazina true
        /// </summary>
        /// <param name="lhs">kairysis lyginamasis</param>
        /// <param name="rhs">desinysis lyginamasis</param>
        /// <returns></returns>
        public static bool operator ==(MikrobanguKrosnele lhs, MikrobanguKrosnele rhs)
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

        public static bool operator !=(MikrobanguKrosnele lhs, MikrobanguKrosnele rhs)
        {
            return !(lhs == rhs);
        }
    }
}
