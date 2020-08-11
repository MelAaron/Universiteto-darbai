using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sav2
{
    class Futbolininkas : Zaidejas
    {
        public Futbolininkas(string komandospavadinimas, string vardas, string pavarde, DateTime gimimodata, int zaistosrungtynes, int taskai, int geltonuKorteliuSk)
            : base(komandospavadinimas, vardas, pavarde, gimimodata, zaistosrungtynes, taskai)
        {
            GeltonuKorteliuSk = geltonuKorteliuSk;
        }
        public int GeltonuKorteliuSk { get; set; }
        public Futbolininkas(string data)
        {
            SetData(data);
        }
        public override void SetData(string line)
        {
            string[] values = line.Split(';');
            KomandosPavadinimas = values[1];
            Vardas = values[2];
            Pavarde = values[3];
            GimimoData = DateTime.Parse(values[4]);
            ZaistosRungtynes = int.Parse(values[5]);
            Taskai = int.Parse(values[6]);
            GeltonuKorteliuSk = int.Parse(values[7]);
        }
        public override int GetHashCode()
        {
            return Taskai.GetHashCode() ^ GeltonuKorteliuSk.GetHashCode();
        }
        public static bool operator <=(Futbolininkas lhs, Komanda rhs)
        {
            return (double)lhs.Taskai <= rhs.TaskuVidurkis() && (double)lhs.GeltonuKorteliuSk <= rhs.GeltonuKorteliuVid();
        }
        public static bool operator >=(Futbolininkas lhs, Komanda rhs)
        {
            return (double)lhs.Taskai >= rhs.TaskuVidurkis() && (double)lhs.GeltonuKorteliuSk >= rhs.GeltonuKorteliuVid();
        }
        public override string ToString()
        {
            return base.ToString()+String.Format("{0,5}", GeltonuKorteliuSk);
        }
    }

}
