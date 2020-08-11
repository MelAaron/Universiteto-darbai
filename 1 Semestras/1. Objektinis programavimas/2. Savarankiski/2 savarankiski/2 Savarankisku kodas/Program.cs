using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _1savarankiskas
{
    class Program
   {
        public const int MaxFlatAmount = 514;
        static void Main(string[] args)
        {
            Console.Write("Iveskite kambariu skaiciu  ");
            int roomAmount = int.Parse(Console.ReadLine());
            Console.Write("Iveskite kaina  ");
            double maxprice = double.Parse(Console.ReadLine());
            Console.Write("Aukstai nuo: ");
            int minfloor = int.Parse(Console.ReadLine());
            Console.Write("iki: ");
            int maxfloor = int.Parse(Console.ReadLine());

            FlatContainer flats = new FlatContainer(MaxFlatAmount);
            ReadFlatData(flats);

            flats.GetFloor();

            Console.WriteLine("Pradiniai duomenys");
            PrintToConsole(flats);

            FlatContainer filteredFlats = FilteredFlats(flats, roomAmount, maxprice, minfloor, maxfloor);
            Console.WriteLine("Atrinkti butai");
            PrintToConsole(filteredFlats);

            Console.ReadKey();


            
        }

        private static void ReadFlatData(FlatContainer flats)
        {
           using (StreamReader reader = new StreamReader(@"Butai.txt"))
           {
               string line = null;
               line = reader.ReadLine();

               while (null != (line = reader.ReadLine()))
               {
                   string[] values = line.Split(';');
                   int number = int.Parse(values[0]);
                   double area = double.Parse(values[1]);
                   int rooms = int.Parse(values[2]);
                   double price = double.Parse(values[3]);     
                   string phone = values[4];

                   Flat flat = new Flat(number, area, rooms, price, phone);

                   flats.AddFlat(flat);
               }
           }

        }

        private static void PrintToConsole(FlatContainer flats)
        {
            for (int i = 0; i < flats.Count; i++)
            {
                Console.WriteLine(flats.GetFlat(i));
            }
        }

        private static FlatContainer FilteredFlats(FlatContainer flats, int roomAmount, double maxprice, int minfloor, int maxfloor)
        {
            FlatContainer filteredFlats = new FlatContainer(MaxFlatAmount);
            for (int i = 0; i < flats.Count; i++)
            {
                if (flats.GetFlat(i).Rooms == roomAmount)
                {
                    if (flats.GetFlat(i).Price <= maxprice)
                    {
                        Console.WriteLine(flats.GetFlat(i).Floor);
                        if (flats.GetFlat(i).Floor >= minfloor && flats.GetFlat(i).Floor <= maxfloor)
                        {
                            filteredFlats.AddFlat(flats.GetFlat(i));
                        }
                    }
                }
            }
            return filteredFlats;
        }
    }
}
