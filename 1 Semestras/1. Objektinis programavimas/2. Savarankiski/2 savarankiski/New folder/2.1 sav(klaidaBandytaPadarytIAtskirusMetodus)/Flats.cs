using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._1_sav
{
    class Flats
    {
        public int FlatNr { get; set; }
        public int FlatArea { get; set; }
        public int RoomNr { get; set; }
        public double Price { get; set; }
        public int PhoneNr { get; set; }

        public Flats (int flatNr, int flatArea, int roomNr, double price, int phoneNr)
        {
            FlatNr = flatNr;
            FlatArea = flatArea;
            RoomNr = roomNr;
            Price = price;
            PhoneNr = phoneNr;
        }

        public override string ToString()
        {
            //Console.WriteLine("Buto sk | Bendras Plotas | Kambariu sk | Pardavimo Kaina | Telefono nr |");
            return String.Format("{0,-8}| {1, -15}| {2,-12}| {3,-16}| {4,-12}|", FlatNr, FlatArea, RoomNr, Price, PhoneNr);
        }

    }
}
