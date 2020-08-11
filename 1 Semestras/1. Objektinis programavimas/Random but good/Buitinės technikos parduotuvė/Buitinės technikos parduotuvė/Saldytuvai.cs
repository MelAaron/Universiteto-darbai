using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Buitinės_technikos_parduotuvė
{
    class Saldytuvas
    {
        public string Gamintojas { get; set; }
        public string Modelis { get; set; }
        public int Talpa { get; set; }
        public string EnergijosKlase { get; set; }
        public string MontavimoTipas { get; set; }
        public string Spalva { get; set; }
        public string Pozymis { get; set; }
        public double Kaina { get; set; }
        public int Aukstis { get; set; }
        public int Plotis { get; set; }
        public int Gylis { get; set; }
        public Saldytuvas() { }
        /// <summary>
        /// Sukuriamas konstruktorius
        /// </summary>
        /// <param name="pav">Parduotuvės pavadinimas</param>
        /// <param name="adresas">Parduotuvės adresas</param>
        /// <param name="tlf">Parduotuvės telefonas</param>
        /// <param name="gamintojas">Šaldytuvo gamintojas</param>
        /// <param name="modelis">Šaldytuvo modelis</param>
        /// <param name="talpa">Šaldytuvo talpa</param>
        /// <param name="energijosklase">Šaldytuvo energijos klasė</param>
        /// <param name="montavimotipas">Šaldytuvo montavimo tipas</param>
        /// <param name="spalva">Šaldytuvo spalva</param>
        /// <param name="pozymis">Šaldytuvo požymis</param>
        /// <param name="kaina">Šaldytuvo kaina</param>
        /// <param name="aukstis">Šaldytuvo aukstis</param>
        /// <param name="plotis">Šaldytuvo plotis</param>
        /// <param name="gylis">Šaldytuvo gylis</param>
        public Saldytuvas(string gamintojas, string modelis,
            int talpa, string energijosklase, string montavimotipas, string spalva,
            string pozymis, double kaina, int aukstis, int plotis, int gylis)
        {
            Gamintojas = gamintojas;
            Modelis = modelis;
            Talpa = talpa;
            EnergijosKlase = energijosklase;
            MontavimoTipas = montavimotipas;
            Spalva = spalva;
            Pozymis = pozymis;
            Kaina = kaina;
            Aukstis = aukstis;
            Plotis = plotis;
            Gylis = gylis;
        }
        public override bool Equals(object obj)
        {
            return this.Equals(obj as Saldytuvas);
        }
        /// <summary>
        /// Užklojimas
        /// </summary>
        /// <param name="saldytuvas">Konstruktorius</param>
        /// <returns>Palygina ture ar false</returns>
        public bool Equals(Saldytuvas saldytuvas)
        {
            if (Object.ReferenceEquals(saldytuvas, null))
            {
                return false;
            }
            if (this.GetType() != saldytuvas.GetType())
            {
                return false;
            }
            return (Gamintojas == saldytuvas.Gamintojas) && (Modelis == saldytuvas.Modelis);
        }
        public override int GetHashCode()
        {
            return Gamintojas.GetHashCode() ^ Modelis.GetHashCode();
        }
        /// <summary>
        /// Tikrinamas ar operatorius naudoja lygu
        /// </summary>
        /// <param name="lhs">Kairė</param>
        /// <param name="rhs">Dešinė</param>
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
            return lhs.Modelis == rhs.Modelis;
        }
        /// <summary>
        /// Tikrinamas ar nelygus
        /// </summary>
        /// <param name="lhs">Kairė</param>
        /// <param name="rhs">Dešinė</param>
        /// <returns></returns>
        public static bool operator !=(Saldytuvas lhs, Saldytuvas rhs)
        {
            return !(lhs.Modelis == rhs.Modelis);
        }
        /// <summary>
        /// ToString užklojimas
        /// </summary>
        /// <returns>Tekstą</returns>
        public override string ToString()
        {
            string text = String.Format("{0,-10} {1,-10} {2,-9} {3,-8}", Gamintojas, Modelis, Talpa, Kaina);
            return text;
        }
    }
}

