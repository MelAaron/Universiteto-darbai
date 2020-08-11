using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sav2
{
    class Krepsininkas : Zaidejas
    {
        public Krepsininkas(string komandospavadinimas, string vardas, string pavarde, DateTime gimimodata, int zaistosrungtynes, int taskai,int aKamuoliuSkaicius, int rPerdavimuSkaicius)
            : base (komandospavadinimas,vardas,pavarde,gimimodata,zaistosrungtynes,taskai)
        {
            AKamuoliuSkaicius = aKamuoliuSkaicius;
            RPerdavimuSkaicius = rPerdavimuSkaicius;
        }
        public Krepsininkas(string data)
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
            AKamuoliuSkaicius = int.Parse(values[7]);
            RPerdavimuSkaicius = int.Parse(values[8]);
        }
        public int AKamuoliuSkaicius { get; set; }
        public int RPerdavimuSkaicius { get; set; }
        public override int GetHashCode()
        {
            return Taskai.GetHashCode() ^ AKamuoliuSkaicius.GetHashCode();
        }
        public static bool operator <=(Krepsininkas lhs, Komanda rhs)
        {
            return (double)lhs.Taskai <= rhs.TaskuVidurkis() && (double)lhs.AKamuoliuSkaicius<=rhs.AtkovotuKamuoliuVidurkis();
        }
        public static bool operator >=(Krepsininkas lhs, Komanda rhs)
        {
            return (double)lhs.Taskai >= rhs.TaskuVidurkis() && (double)lhs.AKamuoliuSkaicius >= rhs.AtkovotuKamuoliuVidurkis();
        }
        public override string ToString()
        {
            return base.ToString() + String.Format("{0, 5} {1, 5}", AKamuoliuSkaicius, RPerdavimuSkaicius);
        }
    }
}
