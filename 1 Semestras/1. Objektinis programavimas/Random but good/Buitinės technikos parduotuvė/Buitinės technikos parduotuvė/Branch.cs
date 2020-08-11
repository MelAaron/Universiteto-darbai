using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buitinės_technikos_parduotuvė
{
    class Branch
    {
        public const int Maksimaliai = 100;
        public string Pav { get; set; }
        public string Adresas { get; set; }
        public string Tlf { get; set; }
        public Saldytuvu_konteineris Saldytuvai { get; private set; }
        /// <summary>
        /// Elementų saugojimas
        /// </summary>
        /// <param name="pav">Pavadinimas</param>
        /// <param name="adresas">Adresas</param>
        /// <param name="tlf">Telefonas</param>
        public Branch(string pav, string adresas, string tlf)
        {
            Pav = pav;
            Saldytuvai = new Saldytuvu_konteineris(Maksimaliai);
        }
    }
}
