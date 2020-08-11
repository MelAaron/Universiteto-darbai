using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sav2
{
    class Komanda
    {
        public ZaidejuKonteineris Zaidejai { get; private set; }
        public string KomandosPavadinimas { get; set; }
        public string Miestas { get; set; }
        public string Treneris { get; set; }
        public int RungtyniuSk { get; set; }
        public Komanda(string komandosPavadinimas, string miestas, string treneris, int rungtyniuSk, ZaidejuKonteineris zaidejai)
        {
            KomandosPavadinimas = komandosPavadinimas;
            Miestas = miestas;
            Treneris = treneris;
            RungtyniuSk = rungtyniuSk;
            Zaidejai = zaidejai;
        }
        public double TaskuVidurkis()
        {
            return Zaidejai.Vidurkis();
        }
        public Komanda(string data, ZaidejuKonteineris zaidejai)
        {
            SetData(data, zaidejai);
        }
        public virtual void SetData(string line, ZaidejuKonteineris zaidejai)
        {
            string[] values = line.Split(',');
            KomandosPavadinimas = values[0];
            Miestas = values[1];
            Treneris = values[2];
            RungtyniuSk = int.Parse(values[3]);
            Zaidejai = zaidejai;
        }
        public int ZaidejuCount()
        {
            return Zaidejai.Count;
        }
        public Zaidejas GetZaidejas(int index)
        {
            return Zaidejai.GetZaidejas(index);
        }
        public double AtkovotuKamuoliuVidurkis()
        {
            double vid = 0;
            for (int i = 0; i < ZaidejuCount(); i++)
            {
                Krepsininkas zaidejas = Zaidejai.GetZaidejas(i) as Krepsininkas;
                vid += zaidejas.AKamuoliuSkaicius;
            }
            return (vid / (double)ZaidejuCount());
        }
        public double GeltonuKorteliuVid()
        {
            double vid = 0;
            for (int i = 0; i < ZaidejuCount(); i++)
            {
                Futbolininkas zaidejas = GetZaidejas(i) as Futbolininkas;
                vid += zaidejas.GeltonuKorteliuSk;
            }
            return (vid / (double)ZaidejuCount());
        }
        
    }

}
