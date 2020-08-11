using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace U1_9
{
    class Sąrašas
    {
        public string Filmas { get; set; }
        public int Metai { get; set; }
        public string Zanras { get; set; }
        public string Studija { get; set; }
        public string RezisieriausVardas { get; set; }
        public string RezisieriausPavarde { get; set; }
        public string Aktorius1 { get; set; }
        public string Aktorius2 { get; set; }
        public double Pajamos { get; set; }

        /// <summary>
        /// ziurovo ziuretu filmu informacija
        /// </summary>
        /// <param name="filmas">pavadinimas</param>
        /// <param name="metai">isleidimo metai</param>
        /// <param name="zanras">zanras</param>
        /// <param name="studija">studija</param>
        /// <param name="rezisieriausvardas">rezisieriaus vardas</param>
        /// <param name="rezisieriauspavarde">rezisieriaus pavarde</param>
        /// <param name="aktorius1">vienas aktorius filme</param>
        /// <param name="aktorius2">antras aktorius filme</param>
        /// <param name="pajamos">filmo pajamos</param>
        public Sąrašas(string filmas, int metai, string zanras, string studija,
               string rezisieriausvardas, string rezisieriauspavarde, string aktorius1,
               string aktorius2, double pajamos)
         {
            Filmas = filmas;
            Metai = metai;
            Zanras = zanras;
            Studija = studija;
            RezisieriausVardas = rezisieriausvardas;
            RezisieriausPavarde = rezisieriauspavarde;
            Aktorius1 = aktorius1;
            Aktorius2 = aktorius2;
            Pajamos = pajamos;
         }

        /// <summary>
        /// to string uzklojimas
        /// </summary>
        /// <returns>suformatuotai atspausdina filmuo duomenis</returns>
        public override string ToString()
        {
            return String.Format("{0, 12}|, {1, 6}|, {2, 12}|," +
                " {3, 16}|, {4, 20}|, {5, 21}|, {6, 12}|, {7, 13}|," +
                " {8, 8}|", Filmas, Metai, Zanras, Studija, RezisieriausVardas,
                RezisieriausPavarde, Aktorius1, Aktorius2, Pajamos);
        }

        /// <summary>
        /// equals uzklojimas
        /// lygina filmus
        /// </summary>
        /// <param name="obj">lyginamas objektas</param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            return this.Equals(obj as Sąrašas);
        }

        public bool Equals (Sąrašas filmass)
        {
            //tikrina, ar objektas egzistuoja
            if(Object.ReferenceEquals(filmass, null))
            {
                return false;
            }
            //Tikrina, ar tokia pati klase
            if (this.GetType() != filmass.GetType())
                return false;
            //graziname true, jei objektu savybes sutampa
                return (Filmas == filmass.Filmas);
        }

        /// <summary>
        /// randa filmo hashcode
        /// </summary>
        /// <returns>filmo hashcode</returns>
        public override int GetHashCode()
        {
            return Filmas.GetHashCode();
        }

        /// <summary>
        /// uzlojimas, leidziantis lyginti filmus
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns></returns>
        public static bool operator == (Sąrašas lhs, Sąrašas rhs)
        {
            //Patikriname kaire puse (ar egzistuoja objektas)
            //negalima naudoti lhs==null.
            if(Object.ReferenceEquals(lhs, null))
            {
                if(Object.ReferenceEquals(rhs, null))
                {
                    //jei objektas neeigzistuoja nei kaireje puseje, nei desineje puseje
                    //palyginimo operatoriaus puseje, graziname true (null == null = true)
                    return true;
                }
                return false;// jei objetas neegzistuoja tik kaireje puseje
            }
            return lhs.Equals(rhs);
        }
        public static bool operator != (Sąrašas lhs, Sąrašas rhs)
        {
            return !(lhs == rhs);
        }

    }
    
}
