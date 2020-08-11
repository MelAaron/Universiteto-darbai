using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._2_sav
{
    class FakultetuKonteineris
    {
        private Fakultetas[] Fakultetai;
        public int Count { get; private set; }

        public FakultetuKonteineris (int size)
        {
            Fakultetai = new Fakultetas[size];
            Count = 0;
        }
        public void PridetiFakulteta (Fakultetas fakultetas)
        {
            Fakultetai[Count++] = fakultetas;
        }
        public void PridetiFakulteta (Fakultetas fakultetas, int index)
        {
            Fakultetai[index] = fakultetas;
        }
        public Fakultetas RastiFakulteta(int index)
        {
            return Fakultetai[index];
        }
    }
}
