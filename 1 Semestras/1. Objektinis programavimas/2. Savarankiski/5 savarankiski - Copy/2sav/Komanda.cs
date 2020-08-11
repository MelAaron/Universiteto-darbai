using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2sav
{
    class Komanda
    {
        public string Pavadinimas { get; set; }
        public string Miestas { get; set; }
        public string Treneris { get; set; }
        public int ZaistosRung { get; set; }

        public Komanda (string pavadinimas, string miestas, string treneris, int zaistosrung)
        {
            Pavadinimas = pavadinimas;
            Miestas = miestas;
            Treneris = treneris;
            ZaistosRung = zaistosrung;
        }

        public Komanda(string data)
        {
            SetData(data);
        }

        public virtual void SetData(string line)
        {
            string[] values = line.Split(',');
            Pavadinimas = values[0];
            Miestas = values[1];
            Treneris = values[2];
            ZaistosRung = int.Parse(values[3]);
        }
    }
}
