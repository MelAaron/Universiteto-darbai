using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _1savarankiskas
{
    class FlatContainer
    {
        private Flat[] Flats { get; set; }
        public int Count { get; private set; }

        public FlatContainer(int size)
        {
            Flats = new Flat[size];
        }

        public void AddFlat(Flat flat)
        {
            Flats[Count++] = flat;
        }

        public Flat GetFlat(int index)
        {
            return Flats[index];
        }

        public void GetFloor()
        {
            for (int i = 0; i < Count; i++)
            {
                Flats[i].FindFloor();
            }
        }
    }
}
