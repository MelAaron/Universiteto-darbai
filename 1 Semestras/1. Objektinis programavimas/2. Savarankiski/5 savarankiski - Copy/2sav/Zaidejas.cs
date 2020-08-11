using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2sav
{
    class Zaidejas
    {
        public string Komanda { get; set; }
        public string Pavarde { get; set; }
        public string Vardas { get; set; }
        public int RungtyniuSk { get; set; }
        public int TaskuSk { get; set; }

        public Zaidejas (string komanda, string pavarde, string vardas, int rungtyniuSk, int taskuSk)
        {
            Komanda = komanda;
            Pavarde = pavarde;
            Vardas = vardas;
            RungtyniuSk = rungtyniuSk;
            TaskuSk = taskuSk;
        }

        public Zaidejas (string data)
        {
            SetData(data);
        }

        public virtual void SetData (string line)
        {
            string[] values = line.Split(',');
            Komanda = values[0];
            Pavarde = values[1];
            Vardas = values[2];
            RungtyniuSk = int.Parse(values[3]);
            TaskuSk = int.Parse(values[4]);
        }

        public override string ToString()
        {
            return String.Format("{0,-14}|{1,-9}|{2,-8}|{3,-14}|{4,-10}|", Komanda, Vardas, Pavarde, RungtyniuSk, TaskuSk);
        }
    }
}
