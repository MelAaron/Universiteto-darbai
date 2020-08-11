using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2sav
{
    class Krepsininkas : Zaidejas
    {
        
        public int AtkovotiKam { get; set; }
        public int RezultatyvusPerd { get; set; }

        public Krepsininkas (string komanda, string pavarde, string vardas, int rungtyniuSk, int taskuSk, int atkovotiKam, int rezultatyvusPerd) :
            base (komanda, pavarde, vardas, rungtyniuSk, taskuSk)
        {
            //TaskuSk = taskuSk;
            AtkovotiKam = atkovotiKam;
            RezultatyvusPerd = rezultatyvusPerd;

        }

        public Krepsininkas (string data) : base (data)
        {
            SetData(data);
        }

        public override void SetData(string line)
        {
            base.SetData(line);
            string[] values = line.Split(',');
            Komanda = values[0];
            Pavarde = values[1];
            Vardas = values[2];
            RungtyniuSk = int.Parse(values[3]);
            TaskuSk = int.Parse(values[4]);
            //TaskuSk = int.Parse(values[5]);
            AtkovotiKam = int.Parse(values[5]);
            RezultatyvusPerd = int.Parse(values[6]);
        }

        public override string ToString()
        {
            return base.ToString() + String.Format("{0, -33}|{1, -20}|", AtkovotiKam, RezultatyvusPerd);
        }
    }
}
