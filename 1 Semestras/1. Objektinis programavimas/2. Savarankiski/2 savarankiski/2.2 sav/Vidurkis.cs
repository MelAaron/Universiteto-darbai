using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._2_sav
{
    class Vidurkis
    {
        public string Grupe { get; set; }
        public double  GrupesVidurkis { get; set; }

        public Vidurkis (string grupe, int grupesVidurkis)
        {
            Grupe = grupe;
            GrupesVidurkis = grupesVidurkis;
        }
    }
}
