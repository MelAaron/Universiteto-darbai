using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3_Laboras
{
    class Saldytuvas : BuitinisPrietaisas
    {
        public int Talpa { get; set; }
        public string MontavimoTipas { get; set; }
        public bool Saldiklis { get; set; }
        public double Aukstis { get; set; }
        public double Plotis { get; set; }
        public double Gylis { get; set; }

        /// <summary>
        /// saldytuvo informacija
        /// </summary>
        /// <param name="gamintojas">gamintojas</param>
        /// <param name="modelis">modelis</param>
        /// <param name="eKlase">energijos klase</param>
        /// <param name="spalva">spalva</param>
        /// <param name="kaina">kaina</param>
        /// <param name="talpa">talpa</param>
        /// <param name="montavimoTipas">montavimo tipas</param>
        /// <param name="saldiklis">ar yra saldiklis</param>
        /// <param name="aukstis">aukstis</param>
        /// <param name="plotis">plotis</param>
        /// <param name="gylis">gylis</param>
        public Saldytuvas(string gamintojas, string modelis, string eKlase,
            string spalva, double kaina, int talpa, string montavimoTipas,
            bool saldiklis, double aukstis, double plotis, double gylis) :
            base(gamintojas, modelis, eKlase, spalva, kaina)
        {
            Talpa = talpa;
            MontavimoTipas = montavimoTipas;
            Saldiklis = saldiklis;
            Aukstis = aukstis;
            Plotis = plotis;
            Gylis = gylis;
        }

        /// <summary>
        /// Metodas, i kuri kreipiamasi norint spausdinti saldytuvo duomenis
        /// </summary>
        /// <returns>suformatuotus saldytuvo duomenis</returns>
        public override string ToString()
        {
            return String.Format("{0, -10}, {1, -7}, {2, -8}, {3, -10}, {4, -5}," +
                " {5, -5}, {6, -15}, {7, -8}, {8, -6}, {9, -5}, {10, -5}", Gamintojas,
                Modelis, EKlase, Spalva, Kaina, Talpa, MontavimoTipas, Saldiklis, Aukstis,
                Plotis, Gylis);

        }

        /// <summary>
        /// leizia lyginti saldytuvus
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            return this.Equals(obj as Saldytuvas);
        }

        public bool Equals(Saldytuvas saldytuvas)
        {
            return base.Equals(saldytuvas);
        }

        public override int GetHashCode()
        {
            return Gamintojas.GetHashCode() ^ Modelis.GetHashCode();
        }

        /// <summary>
        /// Lyginamos kaires ir desines reiksmes, jei lygiios, grazinama true
        /// </summary>
        /// <param name="lhs">kairys lyginamasis</param>
        /// <param name="rhs">desinysis lyginamasis</param>
        /// <returns></returns>
        public static bool operator ==(Saldytuvas lhs, Saldytuvas rhs)
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

        public static bool operator !=(Saldytuvas lhs, Saldytuvas rhs)
        {
            return !(lhs == rhs);
        }
    }
}
