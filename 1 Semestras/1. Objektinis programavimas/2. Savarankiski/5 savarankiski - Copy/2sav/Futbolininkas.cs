using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2sav
{
    class Futbolininkas : Zaidejas
    {
        //public int IvarciuSk { get; set; }
        public int GeltonuKorteliuSk { get; set; }

        public Futbolininkas (string komanda, string pavarde, string vardas, int rungtyniuSk, int ivarciuSk, int geltonuKortSk) : 
            base(komanda, pavarde, vardas, rungtyniuSk, ivarciuSk)
        {
            //IvarciuSk = ivarciuSk;
            GeltonuKorteliuSk = geltonuKortSk;

        }

        public Futbolininkas(string data) : base(data)
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
            //IvarciuSk = int.Parse(values[5]);
            GeltonuKorteliuSk = int.Parse(values[5]);
        }

        public override string ToString()
        {
            return base.ToString() + String.Format("{0,-33}|", GeltonuKorteliuSk);
        }
    }
}
