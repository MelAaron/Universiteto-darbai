using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace U5_9
{
    class Irasas
    {
        public string Pavadinimas { get; set; }
        public string Zanras { get; set; }
        public string Studija { get; set; }
        public string Aktorius1 { get; set; }
        public string Aktorius2 { get; set; }

        public Irasas(string pavadinimas, string zanras, string studija, string aktorius1, string aktorius2)
        {
            Pavadinimas = pavadinimas;
            Zanras = zanras;
            Studija = studija;
            Aktorius1 = aktorius1;
            Aktorius2 = aktorius2;
        }

        public Irasas (string data)
        {
            SetData(data);
        }

        public virtual void SetData (string line)
        {
            string[] values = line.Split(',');
            Pavadinimas = values[1];
            Zanras = values[2];
            Studija = values[3];
            Aktorius1 = values[4];
            Aktorius2 = values[5];
        }

        public override bool Equals(object obj)
        {
            return this.Equals(obj as Irasas);
        }
        public bool Equals(Irasas irasas)
        {
            if (Object.ReferenceEquals(irasas, null))
            {
                return false;
            }
            if (this.GetType() != irasas.GetType())
            {
                return false;
            }
            return (Pavadinimas == irasas.Pavadinimas) && (Studija == irasas.Studija);
        }
        public override int GetHashCode()
        {
            return Pavadinimas.GetHashCode() ^ Studija.GetHashCode();
        }
        public static bool operator ==(Irasas lhs, Irasas rhs)
        {
            if (Object.ReferenceEquals(lhs, null))
            {
                if (Object.ReferenceEquals(rhs, null))
                {
                    return false;
                }
            }
            return lhs.Equals(rhs);
        }
        public static bool operator !=(Irasas lhs, Irasas rhs)
        {
            return !(lhs == rhs);
        }

    }
}
