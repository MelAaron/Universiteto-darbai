using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2sav
{
    class KomanduKonteineris
    {
        private Komanda[] Komandos;
        public int Count { get; set; }
        public KomanduKonteineris()
        {
            Komandos = new Komanda[Program.MaxAmountOfTeams];
        }
        public void PridetiKomanda(Komanda komanda)
        {
            Komandos[Count] = komanda;
            Count++;
        }
        public void NustatytiKomanda(int index, Komanda komanda)
        {
            Komandos[index] = komanda;
        }
        public Komanda GautiKomanda(int index)
        {
            return Komandos[index];
        }

        public bool Contains(Komanda komanda)
        {
            return Komandos.Contains(komanda);
        }
    }
}
