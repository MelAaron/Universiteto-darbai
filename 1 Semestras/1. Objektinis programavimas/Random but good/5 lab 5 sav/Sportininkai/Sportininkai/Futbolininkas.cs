using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sportininkai
{
    class Futbolininkas : Žaidėjas
    {
        public int SurinktuKorteliuSkaicius { get; set; }
        public Futbolininkas(string komandosPavadinimas, string pavarde, string vardas, DateTime gimimoData, int zaistuRungtyniuSKaicius, int taskuSkaicius, int surinktuKorteliuSkaicius) : base(komandosPavadinimas, pavarde, vardas, gimimoData, zaistuRungtyniuSKaicius, taskuSkaicius)
        {
            SurinktuKorteliuSkaicius = surinktuKorteliuSkaicius;
        }
        public override string ToString()
        {
            return String.Format("{0,-15} {1,-15} {2,-10} {3:yyyy - MM - dd} Žaistų rungtyniu skacius: {4,5} Taskų skaičius: {5,5} Geltonų kortelių skaičius: {6,5}", KomandosPavadinimas, Pavarde, Vardas, GimimoData, ZaistuRungtiniuSkaicius, TaskuSkaicius, SurinktuKorteliuSkaicius);
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
            SurinktuKorteliuSkaicius = int.Parse(values[6]);
        }
        public Futbolininkas(string line):base(line)
        {
            SetData(line);
        }
    }
}
