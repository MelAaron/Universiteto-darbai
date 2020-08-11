using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5sav
{
    class Grupe
    {
        public string Name { get; set; }
        public int Euros { get; set; }
        public int Cents { get; set; }

        public Grupe(string name, int euros, int cents)
        {
            Name = name;
            Euros = euros;
            Cents = cents;
        }
    }
}
