using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3_Laboras
{
    class BuitinisPrietaisas
    {
        public string Gamintojas { get; set; }
        public string Modelis { get; set; }
        public string EKlase { get; set; }
        public string Spalva { get; set; }
        public double Kaina { get; set; }

        public BuitinisPrietaisas (string gamintojas, string modelis,
            string eKlase, string spalva, double kaina)
        {
            Gamintojas = gamintojas;
            Modelis = modelis;
            EKlase = eKlase;
            Spalva = spalva;
            Kaina = kaina;
        }
        

        public override bool Equals(object obj)
        {
            return this.Equals(obj as BuitinisPrietaisas);
        }
        public bool Equals(BuitinisPrietaisas prietaisas)
        {
            if (Object.ReferenceEquals(prietaisas, null))
            {
                return false;
            }
            if (this.GetType() != prietaisas.GetType())
            {
                return false;
            }
            return (Gamintojas == prietaisas.Gamintojas) && (Modelis == prietaisas.Modelis);
        }
        public override int GetHashCode()
        {
            return Gamintojas.GetHashCode() ^ Modelis.GetHashCode();
        }
        /// <summary>
        /// == uzklojimas. Sulygina desine ir kaire reiksmes, jei jos lygios, grazina true
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns></returns>
        public static bool operator ==(BuitinisPrietaisas lhs,  BuitinisPrietaisas rhs)
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
        public static bool operator !=(BuitinisPrietaisas lhs, BuitinisPrietaisas rhs)
        {
            return !(lhs == rhs);
        }

        /// <summary>
        /// Tikrina kairi ir desini prietaisus pagal kaina
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns></returns>
        public static bool operator <=(BuitinisPrietaisas lhs, BuitinisPrietaisas rhs)
        {
            return (lhs.Kaina <= rhs.Kaina);
        }
        public static bool operator >=(BuitinisPrietaisas lhs, BuitinisPrietaisas rhs)
        {
            return (lhs.Kaina >= rhs.Kaina);
        }
    }
}
