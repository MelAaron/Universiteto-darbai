using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace U5_9
{
    class Serialas : Irasas
    {
        public DateTime PradziosM { get; set; }
        public int SerijuK { get; set; }
        public DateTime PabaigosM { get; set; }
        public bool ArTesiasi { get; set; }

        public Serialas(string pavadinimas, string zanras, string studija, string aktorius1, string aktorius2, DateTime pradziosM, int serijuK, DateTime pabaigosM, bool arTesiasi) : 
            base (pavadinimas, zanras, studija, aktorius1, aktorius2)
        {
            PradziosM = pradziosM;
            SerijuK = serijuK;
            PabaigosM = pabaigosM;
            ArTesiasi = arTesiasi;
        }

        public Serialas (string data) : base (data)
        {
            SetData(data);
        }

        public override void SetData(string line)
        {
            base.SetData(line);
            string[] values = line.Split(',');
            PradziosM = DateTime.Parse(values[6]);
            SerijuK = int.Parse(values[7]);
            PabaigosM = DateTime.Parse(values[8]);
            ArTesiasi = bool.Parse(values[9]);
        }

        public override string ToString()
        {
            return String.Format("{0} {1} {2} {3} {4} {5} {6} {7} {8} {9}", Pavadinimas, Zanras, Studija, Aktorius1, Aktorius2, PradziosM, SerijuK, PabaigosM, ArTesiasi);

        }
    }
}
