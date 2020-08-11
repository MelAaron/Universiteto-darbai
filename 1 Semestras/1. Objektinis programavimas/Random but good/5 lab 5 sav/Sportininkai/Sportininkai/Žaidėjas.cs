using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sportininkai
{
    abstract class Žaidėjas
    {
        public string KomandosPavadinimas { get; set; }
        public string Pavarde { get; set; }
        public string Vardas { get; set; }
        public DateTime GimimoData { get; set; }
        public int ZaistuRungtiniuSkaicius { get; set; }
        public int TaskuSkaicius { get; set; }
        public Žaidėjas(string komandosPavadinimas, string pavarde, string vardas, DateTime gimimoData, int zaistuRungtyniuSkaicius, int taskuSkaicius)
        {
            KomandosPavadinimas = komandosPavadinimas;
            Pavarde = pavarde;
            Vardas = vardas;
            GimimoData = gimimoData;
            ZaistuRungtiniuSkaicius = zaistuRungtyniuSkaicius;
            TaskuSkaicius = taskuSkaicius;
        }
        public static bool operator ==(Žaidėjas zaidejas, Komanda komanda)
        {
            return zaidejas.KomandosPavadinimas == komanda.KomandosPavadinimas && zaidejas.ZaistuRungtiniuSkaicius == komanda.ZaistuRungtyniuSkaicius;
        }
        public static bool operator !=(Žaidėjas zaidejas, Komanda komanda)
        {
            return zaidejas.KomandosPavadinimas != komanda.KomandosPavadinimas && zaidejas.ZaistuRungtiniuSkaicius != komanda.ZaistuRungtyniuSkaicius;
        }
        public virtual void SetData(string line)
        {
            string[] values = line.Split(',');
            KomandosPavadinimas = values[0];
            Pavarde = values[1];
            Vardas = values[2];
            GimimoData = DateTime.Parse(values[3]);
            ZaistuRungtiniuSkaicius = int.Parse(values[4]);
            TaskuSkaicius = int.Parse(values[5]);
        }
        public Žaidėjas (string line)
        {
            SetData(line);
        }

    }
}
