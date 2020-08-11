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
            int WantedPrice;

            Program p = new Program();

            FlatContainer FlatsInitial = p.ReadFlatData();
            p.PrintFlatsToConsole(FlatsInitial);

            Console.WriteLine("Įveskite pageidaujamą kambarių skaičių bute: ");
            WantedRoomNr = int.Parse(Console.ReadLine());
            Console.WriteLine("Įveskite pageidaujamų aukštų intervalą: ");
            WantedFloorFrom = int.Parse(Console.ReadLine());
            WantedFloorTo = int.Parse(Console.ReadLine());
            Console.WriteLine("Įveskite pageidaujamą buto kainą: ");
            WantedPrice = int.Parse(Console.ReadLine());

            FlatContainer SuitableFlats = p.SuitableFlatSearch(FlatsInitial, WantedRoomNr, WantedPrice, WantedFloorFrom, WantedFloorTo);
            p.PrintSuitableFlats(SuitableFlats);


        }
        private FlatContainer ReadFlatData ()
        {
            FlatContainer FlatsC = new FlatContainer(19*27);
            
            string[] lines = File.ReadAllLines(@"2.1Duomenys.csv");
            foreach (var line in lines)
            {
                string[] values = line.Split(',');
                int flatNr = int.Parse(values[0]);
                int flatArea = int.Parse(values[1]);
                int roomNr = int.Parse(values[2]);
                int price = int.Parse(values[3]);
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

        public int FloorOfFlat (Flats f)
        {
            int StaircaseOfFlat = 0;
            int FloorOfFlat = 0;
            if(f.FlatNr % 27 == 0)
            {
                StaircaseOfFlat = f.FlatNr / 27;
            }
            else
            {
                StaircaseOfFlat = (f.FlatNr / 27) + 1;
            }

            if (f.FlatNr < 27)
            {
                FloorOfFlat = (int)Math.Ceiling(f.FlatNr * 1.0 / 3);
            }
            else
            {
                FloorOfFlat = (int)Math.Ceiling((f.FlatNr * 1.0 - ((StaircaseOfFlat - 1) * 27 * 1.0)) / 3);
            }
            //Console.WriteLine(f.FlatNr + " " + FloorOfFlat);
            return FloorOfFlat;
        }

        private FlatContainer SuitableFlatSearch (FlatContainer FlatsInitial, int WantedRoomNr, double WantedPrice, int WantedFloorFrom, int WantedFloorTo)
        {
            Program v = new Program();
            FlatContainer SuitableFlats = new FlatContainer(19 * 27);
            //SuitableFlats = null;
            

            for (int i = 0; i < FlatsInitial.Count; i++)
            {
                Flats f = FlatsInitial.GetFlat(i);

                int FloorOfFlat = v.FloorOfFlat(f);
                
                if(f.RoomNr == WantedRoomNr)
                {
                    if(f.Price <= WantedPrice)
                    {
                        if((FloorOfFlat >= WantedFloorFrom) && (FloorOfFlat <= WantedFloorTo))
                        {
                            SuitableFlats.AddFlat(f);
                        }
                    }
                }
            }
            return SuitableFlats;
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
