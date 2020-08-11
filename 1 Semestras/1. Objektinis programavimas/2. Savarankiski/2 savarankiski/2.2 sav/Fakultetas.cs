using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._2_sav
{
    class Fakultetas
    {
        public string Pavarde { get; set; }
        public string Vardas { get; set; }
        public string Grupe { get; set; }
        public int PazKiekis { get; set; }
        public int Suma { get; set; }

        public double Vidurkis { get; set; }

        public Fakultetas(string grupe)
        {
            Grupe = grupe;
            Vidurkis = 0;
        }

        public Fakultetas(string pavarde, string vardas, string grupe, int pazKiekis, int suma, int vidurkis)
        {
            Pavarde = pavarde;
            Vardas = vardas;
            Grupe = grupe;
            PazKiekis = pazKiekis;
            Suma = suma;

            Vidurkis = vidurkis;
        }

        public override string ToString()
        {
            return String.Format("{0}, {1}, {2}, {3}, {4}", Pavarde, Vardas, Grupe, PazKiekis, Suma);

        }
    }
}
