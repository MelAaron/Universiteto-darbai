using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace U5_9
{
    class Filmas : Irasas
    {
        public DateTime LeidimoM { get; set; }
        public string Rezisierius { get; set; }
        public int Pajamos { get; set; }

        public Filmas (string pavadinimas, string zanras, string studija, string aktorius1, string aktorius2, DateTime leidomoM, string rezisierius, int pajamos) : 
            base (pavadinimas, zanras, studija, aktorius1, aktorius2)
        {
            LeidimoM = leidomoM;
            Rezisierius = rezisierius;
            Pajamos = pajamos;
        }

        public Filmas (string data) : base (data)
        {
            SetData(data);
        }

        public override void SetData(string line)
        {
            base.SetData(line);
            string[] values = line.Split(',');
            LeidimoM = DateTime.Parse(values[6]);
            Rezisierius = values[7];
            Pajamos = int.Parse(values[8]);
        }

        public override string ToString()
        {
            return String.Format("{0} {1} {2} {3} {4} {5} {6} {7} {8}", Pavadinimas, Zanras, Studija, Aktorius1, Aktorius2, LeidimoM, Rezisierius, Pajamos);
        }

        public override bool Equals(object obj)
        {
            return this.Equals(obj as Filmas); //kvieciame tipui specifini metoda toje pacioje klaseje

        }
        public bool Equals(Filmas filmas)
        {
            return base.Equals(filmas);
        }
        public override int GetHashCode()
        {
            return Pavadinimas.GetHashCode() ^ Rezisierius.GetHashCode();
        }
        public static bool operator ==(Filmas lhs, Filmas rhs)
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
        public static bool operator !=(Filmas lhs, Filmas rhs)
        {
            return !(lhs == rhs);
        }
    }
}
