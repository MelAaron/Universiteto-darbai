using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _5sav
{
    class Program
    {
        static void Main(string[] args)
        {
             Program p = new Program();
            List<Grupe> zmones = p.Nuskaitymas();
            //List<Dosniausi> turtingi = new List<Dosniausi>();
            Console.WriteLine("Suma: {0}", p.Skaiciavimas(zmones));
            //p.Spausdinimas(p.DaugiausiaiDave(zmones, turtingi), zmones, turtingi);
            int index = p.DaugiausiaiDave(zmones);
            List<Dosniausi> turtingi = p.DosniausiuRadimas(zmones, index);
            p.Spausdinimas(index, zmones, turtingi);
           

        }
        List<Grupe>  Nuskaitymas()
        {
            List<Grupe> zmones = new List<Grupe>();
            string[] lines = File.ReadAllLines(@"Duomenys1.csv");
            foreach(string line in lines)
                {
                string[] values = line.Split(';');
                string name = values[0];
                int euros = int.Parse(values[1]);
                int cents = int.Parse(values[2]);
                Grupe zmogus = new Grupe(name, euros, cents);
                zmones.Add(zmogus);
            }
            return zmones;
        }
        double Skaiciavimas(List<Grupe> zmones)
        {
            double sum = 0;
            for (int i = 0; i < zmones.Count; i++)
            {
                double centais = zmones[i].Euros * 100 + zmones[i].Cents;
                sum = sum + (centais / 4);
            }
            sum = sum / 100;
            /*foreach (var z in zmones)
            {
                double zmogusturi = z.Cents + z.Euros * 100;
                sum = sum + (z.Euros / 4);
            }
            */
            return sum;
        }
        int DaugiausiaiDave(List<Grupe> zmones)
        {
            double centais = zmones[0].Euros * 100 + zmones[0].Cents;
            double max = centais;
            int index = 0;

            for (int i = 0; i < zmones.Count; i++)
            {
                centais = zmones[i].Euros * 100 + zmones[i].Cents;
                if (centais > max)
                {
                    max = centais;
                    index = i;
                }
            }
            return index;
        }
        List<Dosniausi> DosniausiuRadimas(List<Grupe> zmones, int index)
        {
            
            List<Dosniausi> turtingi = new List<Dosniausi>();
            double max = zmones[index].Euros * 100 + zmones[index].Cents;
            
            for (int y = 0; y < zmones.Count; y++)
            {
                double centais = zmones[y].Euros * 100 + zmones[y].Cents;
                
                if ( centais == max)
                {

                    string name = zmones[y].Name;
                    int euros = zmones[y].Euros;
                    int cents = zmones[y].Cents;
                    Dosniausi turtingas = new Dosniausi(name, euros, cents);
                    turtingi.Add(turtingas);
                }
            }
            return turtingi;
        }
        public void Spausdinimas(int index, List<Grupe> zmones, List<Dosniausi> turtingi)
        {
            //Console.WriteLine(zmones[index].Name + " " + zmones[index].Euros / 4);
            for (int i = 0; i < turtingi.Count; i++)
            {
                
                Console.WriteLine(turtingi[i].Name + " " + turtingi[i].Euros + " " + turtingi[i].Cents);
            }
        }
        
    }
}

/*List<Grupe> ReadTouristData()
        {
            StreamReader Reader = new StreamReader();
            List<Grupe> zmogus = new List<Grupe>();
            string[] lines = File.ReadAllLines(@"duomenys1.csv");
            foreach (string line in lines)
            {
                string[] values = line.Split(';');
                string name = values[0];
                int euros = values[1];
                int cents = valuse[2];
                Grupe zmogus = new Grupe(name, euros, cents);
                zmones.Add(zmogus);
            }
            return zmones;
        }
*/
