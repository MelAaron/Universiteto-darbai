using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sportininkai
{
    class Krepšininkas : Žaidėjas
    {
        public int AtkovotuKamuoliuSkaicius { get; set; }
        public int RezultatyviuPerdavimuSkaicius { get; set; }
        public Krepšininkas(string komandosPavadinimas, string pavarde, string vardas, DateTime gimimoData, int zaistuRungtyniuSkaicius, int taskuSkaicius, int atkovotuKamuoliuSkaicius, int rezultatyviuPerdavimuSkaicius) : base(komandosPavadinimas, pavarde, vardas, gimimoData, zaistuRungtyniuSkaicius, taskuSkaicius)
        {
            AtkovotuKamuoliuSkaicius = atkovotuKamuoliuSkaicius;
            RezultatyviuPerdavimuSkaicius = rezultatyviuPerdavimuSkaicius;
        }
        override public void SetData(string line)
        {
            string[] values = line.Split(',');
            KomandosPavadinimas = values[0];
            Pavarde = values[1];
            Vardas = values[2];
            GimimoData = DateTime.Parse(values[3]);
            ZaistuRungtiniuSkaicius = int.Parse(values[4]);
            TaskuSkaicius = int.Parse(values[5]);
            AtkovotuKamuoliuSkaicius = int.Parse(values[6]);
            RezultatyviuPerdavimuSkaicius = int.Parse(values[7]);
        }
        public Krepšininkas(string line):base(line)
        {
            SetData(line);
        }
        public override string ToString()
        {
            return String.Format("{0,-15} {1,-15} {2,-10} {3:yyyy - MM - dd} Žaistų rungtyniu skacius: {4,5} Taskų skaičius: {5,5} Atkovotų kamuolių skaičius: {6,5} Rezultatyvių perdavymų skaičius: {7,5}", KomandosPavadinimas, Pavarde, Vardas, GimimoData, ZaistuRungtiniuSkaicius, TaskuSkaicius, AtkovotuKamuoliuSkaicius, RezultatyviuPerdavimuSkaicius);
        }

    }
}
