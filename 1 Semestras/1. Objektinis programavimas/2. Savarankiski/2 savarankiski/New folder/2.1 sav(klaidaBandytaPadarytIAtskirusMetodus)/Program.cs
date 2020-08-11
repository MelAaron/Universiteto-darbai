using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _2._1_sav
{
    class Program
    {
        public const int NumberOfStairways = 20;

        static void Main(string[] args)
        {
            int WantedRoomNr, WantedFloorFrom, WantedFloorTo;
            double WantedPrice;

            Program p = new Program();

            FlatContainer FlatsInitial = p.ReadFlatData();
            p.PrintFlatsToConsole(FlatsInitial);

            Console.WriteLine("Įveskite pageidaujamą kambarių skaičių bute: ");
            WantedRoomNr = int.Parse(Console.ReadLine());
            Console.WriteLine("Įveskite pageidaujamų aukštų intervalą: ");
            WantedFloorFrom = int.Parse(Console.ReadLine());
            WantedFloorTo = int.Parse(Console.ReadLine());
            Console.WriteLine("Įveskite pageidaujamą buto kainą: ");
            WantedPrice = double.Parse(Console.ReadLine());

            int FloorOfFlat = p.FindFloorFlat(FlatsInitial);
            FlatContainer SuitableFlats = p.SuitableFlatSearch(FlatsInitial, FloorOfFlat, WantedRoomNr, WantedPrice, WantedFloorFrom, WantedFloorTo);
            p.PrintSuitableFlats(SuitableFlats);


        }
        private FlatContainer ReadFlatData()
        {
            FlatContainer FlatsC = new FlatContainer(19*27);
            
            string[] lines = File.ReadAllLines(@"2.1Duomenys.csv");
            foreach (var line in lines)
            {
                string[] values = line.Split(',');
                int flatNr = int.Parse(values[0]);
                int flatArea = int.Parse(values[1]);
                int roomNr = int.Parse(values[2]);
                double price = double.Parse(values[3]);
                int phoneNr = int.Parse(values[4]);

                Flats flat = new Flats(flatNr, flatArea, roomNr, price, phoneNr);
                FlatsC.AddFlat(flat);

            }
            return FlatsC;
        }

        public void PrintFlatsToConsole(FlatContainer FlatsInitial)
        {
            Console.WriteLine("Buto sk | Bendras Plotas | Kambariu sk | Pardavimo Kaina | Telefono nr |");
            Console.WriteLine("------------------------------------------------------------------------");
            for (int i = 0; i < FlatsInitial.Count; i++)
            {
                Flats f = FlatsInitial.GetFlat(i);
                Console.WriteLine(f.ToString());
                Console.WriteLine("------------------------------------------------------------------------");
            }
        }

        private FlatContainer SuitableFlatSearch(FlatContainer FlatsInitial, int FloorOfFlat, int WantedRoomNr, double WantedPrice, int WantedFloorFrom, int WantedFloorTo)
        {
            FlatContainer SuitableFlats = new FlatContainer(19 * 27);
            SuitableFlats = null;

            for (int i = 0; i < FlatsInitial.Count; i++)
            {
                Flats f = FlatsInitial.GetFlat(i);
                //int FloorOfFlat = p.FindFloorFlat;
                //int StaircaseOfFlat = 0;
                //int StaircaseIndex = 19;
                //for (int j = 19*27; j > 0; j = j - 27)
                //{
                //    if(f.FlatNr <= j)
                //    {
                //        StaircaseOfFlat = StaircaseIndex;
                //    }
                //    StaircaseIndex--;
                //}
                ////Console.WriteLine(StaircaseOfFlat);
                //int FloorOfFlat = 0;
                //int FloorIndex = 9;
                //for (int y = StaircaseOfFlat * 27; y > (StaircaseOfFlat - 1) * 27; y -= 3)
                //{
                //    if(f.FlatNr <= y)
                //    {
                //        FloorOfFlat = FloorIndex;
                //    }
                //    FloorIndex--;
                //}
                //Console.WriteLine("{0}, {1}, {2}, {3}, {4}", f.FlatNr, f.FlatArea, f.RoomNr, f.Price, f.PhoneNr);
                //Console.WriteLine("Kambariu norimas sk: {0}, Aukstas nuo {1}, Aukstas iki {2}, Norima kaina {3}", WantedRoomNr, WantedFloorFrom, WantedFloorTo, WantedPrice);
                //Console.WriteLine("Aukstas: " + FloorOfFlat);
                ////Console.WriteLine(StaircaseIndex);
                if ((f.RoomNr == WantedRoomNr) && (FloorOfFlat >= WantedFloorFrom) && (FloorOfFlat <= WantedFloorTo) && (WantedPrice <= f.Price))
                {
                    //Console.WriteLine("{0}, {1}, {2}, {3}, {4}", f.FlatNr, f.FlatArea, f.RoomNr, f.Price, f.PhoneNr);
                    SuitableFlats.AddFlat(f);
                }
            }
            return SuitableFlats;
        }
        public int FindFloorFlat (Flats f)
        {
            int StaircaseOfFlat = 0;
            int StaircaseIndex = 19;
            for (int j = 19 * 27; j > 0; j = j - 27)
            {
                if (f.FlatNr <= j)
                {
                    StaircaseOfFlat = StaircaseIndex;
                }
                StaircaseIndex--;
            }
            //Console.WriteLine(StaircaseOfFlat);
            int FloorOfFlat = 0;
            int FloorIndex = 9;
            for (int y = StaircaseOfFlat * 27; y > (StaircaseOfFlat - 1) * 27; y -= 3)
            {
                if (f.FlatNr <= y)
                {
                    FloorOfFlat = FloorIndex;
                }
                FloorIndex--;
            }
            return FloorOfFlat;
        }
        public void PrintSuitableFlats (FlatContainer SuitableFlats)
        {
            if (SuitableFlats == null)
            {
                Console.WriteLine("Parduodamu butu su tokiomis charakteristikomis nera.");
            }
            else
            {
                Console.WriteLine("Buto sk | Bendras Plotas | Kambariu sk | Pardavimo Kaina | Telefono nr |");
                Console.WriteLine("------------------------------------------------------------------------");
                for (int i = 0; i < SuitableFlats.Count; i++)
                {
                    Flats f = SuitableFlats.GetFlat(i);
                    Console.WriteLine(f.ToString());
                    Console.WriteLine("------------------------------------------------------------------------");
                }
            }
        }

    }
}
