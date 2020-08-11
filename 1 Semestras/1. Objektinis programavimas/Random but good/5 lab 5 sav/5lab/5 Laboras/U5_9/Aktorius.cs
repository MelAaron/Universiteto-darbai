using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace U5_9
{
    class Aktorius
    {
        public string Vardas { get; set; }
        public int Pasikartojimas { get; set; }

        public Aktorius (string vardas, int pasikartojimas)
        {
            Vardas = vardas;
            Pasikartojimas = pasikartojimas;
        }
        
    }
}
