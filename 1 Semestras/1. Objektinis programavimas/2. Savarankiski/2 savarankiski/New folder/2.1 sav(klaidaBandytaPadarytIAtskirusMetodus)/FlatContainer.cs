using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._1_sav
{
    class FlatContainer
    {
        private Flats[] Flats;
        public int Count { get; private set; }

        public FlatContainer(int size)
        {
            Flats = new Flats[size];
            Count = 0;
        }
        public void AddFlat(Flats flat)
        {
            Flats[Count++] = flat;
        }
        public void AddFlat(Flats flat, int index)
        {
            Flats[index] = flat;
        }
        public Flats GetFlat (int index)
        {
            return Flats[index];
        }
    }
}
