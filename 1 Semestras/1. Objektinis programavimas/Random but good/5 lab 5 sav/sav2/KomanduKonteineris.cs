using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sav2
{
    class KomanduKonteineris
    {
        Komanda[] Komandos { get; set; }
        public int Count { get; set; }
        public KomanduKonteineris(int maxkomandos)
        {
            Komandos = new Komanda[maxkomandos];
            Count = 0;
        }
        public void PridetiKomanda(Komanda naujaKomanda)
        {
            Komandos[Count++] = naujaKomanda;
        }
        public Komanda GetKomanda(int index)
        {
            return Komandos[index];
        }
        
        public int ZaidejuCount(int index)
        {
            return Komandos[index].ZaidejuCount();
        }
        public Zaidejas GetZaidejas(int indexZ, int indexK)
        {
            return Komandos[indexK].GetZaidejas(indexZ);
        }
    }
}
