using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _3._2_sav
{
    class Program
    {
        static void Main(string[] args)
        {
            Program p = new Program();
            
            var Komandos = p.KomanduSkaitymas();

            var Zaidejai = p.ZaidejuSkaitymas();
            
            Console.WriteLine("Nurodykite miesta: ");
            string miestas = Console.ReadLine();

            var Geriausi = p.MiestoKomandos(Komandos, miestas, Zaidejai);

            p.Spausdinimas(Geriausi);
        }

        private void Spausdinimas (ZaidejuKonteineris geriausi)
        {
            for (int i = 0; i < geriausi.Count; i++)
            {
                Console.WriteLine("{0}", geriausi.GautiZaideja(i).ToString());
            }
        }

        private double Vidurkis(ZaidejuKonteineris zaidejai)
        {
            double suma = 0;
            double vidurkis = 0;
            for (int i = 0; i < zaidejai.Count; i++)
            {
                suma = zaidejai.GautiZaideja(i).Taskai + suma;
            }
            vidurkis = suma / zaidejai.Count;
            return vidurkis;
        }

        private ZaidejuKonteineris ZaidejuIeskojimas (ZaidejuKonteineris zaidejai, string komanda, ZaidejuKonteineris geriausi)
        {
            double vidurkis = vidurkis = Vidurkis(zaidejai);
            for (int i = 0; i < zaidejai.Count; i++)
            {
                if((zaidejai.GautiZaideja(i).KomPavadinimas == komanda) && (zaidejai.GautiZaideja(i).Taskai >= vidurkis))
                {
                    geriausi.PridetiZaideja(zaidejai.GautiZaideja(i));

                }
            }
            return geriausi;
        }

        private ZaidejuKonteineris MiestoKomandos (KomanduKonteineris komandos, string miestas, ZaidejuKonteineris zaidejai)
        {
            var Geriausi = new ZaidejuKonteineris(20);
            string komandosPav = null;
            for (int i = 0; i < komandos.Count; i++)
            {
                if(komandos.GautiKomanda(i).Miestas == miestas)
                {
                    komandosPav = komandos.GautiKomanda(i).KPavadinimas;
                    Geriausi =  ZaidejuIeskojimas(zaidejai, komandosPav, Geriausi);
                }
            }
            return Geriausi;
        }

        private KomanduKonteineris KomanduSkaitymas ()
        {
            KomanduKonteineris Komandos = new KomanduKonteineris(20);

            string[] lines = File.ReadAllLines(@"Komandos.csv");
            foreach (var line in lines)
            {
                string[] values = line.Split(',');
                string komandosPav = values[0];
                string miestas = values[1];
                string treneris = values[2];
                int rungtynes = int.Parse(values[3]);

                Komanda komanda = new Komanda(komandosPav, miestas, treneris, rungtynes);
                Komandos.PridetiKomanda(komanda);
            }
            return Komandos;
        }

        private ZaidejuKonteineris ZaidejuSkaitymas()
        {
            var Zaidejai = new ZaidejuKonteineris(20);
            var branchai = new Branch();

            string[] lines = File.ReadAllLines(@"Zaidejai.csv");
            foreach (var line in lines)
            {
                string[] values = line.Split(',');
                char type = line[0];
                string komPav = values[1];
                string vardas = values[2];
                string pavarde = values[3];
                DateTime gimData = DateTime.Parse(values[4]);
                int rungtyniuSk = int.Parse(values[5]);
                int taskuSk = int.Parse(values[6]);

                switch(type)
                {
                    case 'K':
                        int atkovotuKamSk = int.Parse(values[7]);
                        int rezultatyviuPerSk = int.Parse(values[8]);
                        Krepsininkas krepsininkas = new Krepsininkas(komPav, vardas, pavarde, gimData, rungtyniuSk, taskuSk, atkovotuKamSk, rezultatyviuPerSk);
                        Zaidejai.PridetiZaideja(krepsininkas);
                        //branchai.PridetiKrepsininka(krepsininkas);
                        break;

                    case 'F':
                        int geltonuKorSk = int.Parse(values[7]);
                        Futbolininkas futbolininkas = new Futbolininkas(komPav, vardas, pavarde, gimData, rungtyniuSk, taskuSk, geltonuKorSk);
                        Zaidejai.PridetiZaideja(futbolininkas);
                        //branchai.PridetiFutbolininka(futbolininkas);
                        break;
                }

            }
            return Zaidejai;
        }
    }
}
