using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace U5_9
{
    class Branch
    {
        public string Vardas { get; set; }
        public string GimM { get; set; }
        public string Miestas { get; set; }
        //private Irasas[] Irasai;
        private IrasuKonteineris Irasai;
        public int Count { get; private set; }

        public Branch (string vardas, string gimM, string miestas)
        {
            Vardas = vardas;
            GimM = gimM;
            Miestas = miestas;
            //Irasai = new Irasas[Program.MaxNrOfBranches];
            Irasai = new IrasuKonteineris(Program.MaxNrOfCinema);
        }

        public void PridetiIrasa (Irasas irasas)
        {
            //Irasai[Count] = irasas;
            Irasai.PridetiIrasa(irasas);
            Count++;
        }

        public Irasas GautiIrasa (int index)
        {
            //return Irasai[index];
            return Irasai.GautiIrasa(index);
        }

        //public static Branch operator +(Branch a, Branch b)
        //{
        //    Branch c = new Branch(a.Vardas, a.GimM, a.Miestas);
        //    for (int i = 0; i < a.Count; i++)
        //    {
        //        c.PridetiIrasa(a.Irasai[i]);
        //    }
        //    for (int i = 0; i < b.Count; i++)
        //    {
        //        c.PridetiIrasa(b.Irasai[i]);
        //    }
        //    return c;
        //}

        //public bool Contains(Branch irasas)
        //{
        //    return Irasai.Contains(irasas);
        //}
    }
}
