using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _2sav
{
    class Program
    {
        public const int MaxAmountOfPlayers = 100;
        public const int MaxAmountOfTeams = 100;

        static void Main(string[] args)
        {
            Program p = new Program();
            const string krepsininkuFile = "Krepsininkai.csv";
            const string futbolininkuFile = "Futbolininkai.csv";
            const string komanduFile = "Komandos.csv";

            var krepsininkai = new ZaidejuKonteineris(MaxAmountOfPlayers);
            var futbolininkai = new ZaidejuKonteineris(MaxAmountOfPlayers);
            var komandos = new KomanduKonteineris();

            p.KrepsininkuSkaitymas(krepsininkuFile, ref krepsininkai);
            p.FutbolininkuSkaitymas(futbolininkuFile, ref futbolininkai);
            p.KomanduSkaitymas(komanduFile, ref komandos);
            var Visi = p.VisiViename(futbolininkai, krepsininkai);

            var Atrinkti = p.Atrinkimas(Visi, komandos);

            p.Spausdinimas(Atrinkti);
            Console.ReadLine();
        }

        private void Spausdinimas (ZaidejuKonteineris Atrinkti)
        {
            Console.WriteLine("Komanda       | Pavarde | Vardas | Rungtyniu Sk | Tasku Sk | Atkovoti Kam/ Geltonu Kort. Sk. | Rezultatyvus perd. |");
            for (int i = 0; i < Atrinkti.Count; i++)
            {
                Console.WriteLine(Atrinkti.GautiZaidja(i).ToString());
            }
        }

        private ZaidejuKonteineris Atrinkimas (ZaidejuKonteineris zaidejai, KomanduKonteineris komandos)
        {
            ZaidejuKonteineris Atrinkti = new ZaidejuKonteineris(MaxAmountOfPlayers * 2);
            for (int i = 0; i < zaidejai.Count; i++)
            {
                var zaidejas = zaidejai.GautiZaidja(i);
                for (int j = 0; j < komandos.Count; j++)
                {
                    var komanda = komandos.GautiKomanda(j);
                    if((zaidejas.Komanda == komanda.Pavadinimas) && (zaidejas.RungtyniuSk == komanda.ZaistosRung))
                    {
                        if(zaidejas is Krepsininkas)
                        {
                            if (zaidejas.TaskuSk >= KrepsininkuVidurkis(zaidejai))
                                Atrinkti.PridetiZaideja(zaidejas);

                        }
                        if(zaidejas is Futbolininkas)
                        {
                            if (zaidejas.TaskuSk >= FutbolininkuVidurkis(zaidejai))
                                Atrinkti.PridetiZaideja(zaidejas);
                        }
                    }
                }
            }
            return Atrinkti;
        }

        private ZaidejuKonteineris VisiViename (ZaidejuKonteineris futb, ZaidejuKonteineris kreps)
        {
            ZaidejuKonteineris visi = new ZaidejuKonteineris(MaxAmountOfPlayers * 2);
            PridetiF(ref visi, futb);
            PridetiK(ref visi, kreps);
            return visi;
        }

        private void PridetiK (ref ZaidejuKonteineris visi, ZaidejuKonteineris krep)
        {
            for (int i = 0; i < krep.Count; i++)
            {
                if (!visi.Contains(krep.GautiZaidja(i)))
                {
                    visi.PridetiZaideja(krep.GautiZaidja(i));
                }
            }
        }

        private void PridetiF (ref ZaidejuKonteineris visi, ZaidejuKonteineris futb)
        {
            for (int i = 0; i < futb.Count; i++)
            {
                if (!visi.Contains(futb.GautiZaidja(i)))
                {
                    visi.PridetiZaideja(futb.GautiZaidja(i));
                }
            }
        }

        private double FutbolininkuVidurkis (ZaidejuKonteineris futbolininkai)
        {
            int IvarciuK = 0;
            for (int i = 0; i < futbolininkai.Count; i++)
            {
                IvarciuK += futbolininkai.GautiZaidja(i).TaskuSk;
            }
            return IvarciuK / futbolininkai.Count;
        }

        private double KrepsininkuVidurkis (ZaidejuKonteineris krepsininkai)
        {
            int TaskuK = 0;
            for (int i = 0; i < krepsininkai.Count; i++)
            {
                TaskuK += krepsininkai.GautiZaidja(i).TaskuSk;
            }
            return TaskuK / krepsininkai.Count;
        }

        private double GeltonuKorteliuVid (ZaidejuKonteineris futbolininkai)
        {
            int GeltonuKK = 0;
            for (int i = 0; i < futbolininkai.Count; i++)
            {
                GeltonuKK += ((Futbolininkas)futbolininkai.GautiZaidja(i)).GeltonuKorteliuSk;
            }
            return GeltonuKK / futbolininkai.Count;
        }

        private double KamuoliuAtkovojimoVid (ZaidejuKonteineris krepsininkai)
        {
            int TaskuK = 0;
            for (int i = 0; i < krepsininkai.Count; i++)
            {
                TaskuK += ((Krepsininkas)krepsininkai.GautiZaidja(i)).AtkovotiKam;
            }
            return TaskuK / krepsininkai.Count;
        }

        private void KrepsininkuSkaitymas (string file, ref ZaidejuKonteineris krepsininkai)
        {
            string[] lines = File.ReadAllLines(file);
            foreach (var line in lines)
            {
                Krepsininkas krepsininkas = new Krepsininkas(line);
                krepsininkai.PridetiZaideja(krepsininkas);
            }
        }

        private void FutbolininkuSkaitymas(string file, ref ZaidejuKonteineris futbolininkai)
        {
            string[] lines = File.ReadAllLines(file);
            foreach (var line in lines)
            {
                Futbolininkas futbolininkas = new Futbolininkas(line);
                futbolininkai.PridetiZaideja(futbolininkas);
            }
        }

        private void KomanduSkaitymas (string file, ref KomanduKonteineris komandos)
        {
            string[] lines = File.ReadAllLines(file);
            foreach (var line in lines)
            {
                Komanda komanda = new Komanda(line);
                komandos.PridetiKomanda(komanda);
            }
        }

        //static void SudarytiKomandas(KomanduKonteineris komandos)
        //{
        //    ZaidejuKonteineris visiZaidejai = new ZaidejuKonteineris(maxzaidejai);
        //    SkaitytiZaidejusIsFailo(visiZaidejai);
        //    SkaitytiKomandasIsFailo(komandos, visiZaidejai);
        //}
        //static void SkaitytiZaidejusIsFailo(ZaidejuKonteineris visiZaidejai)
        //{
        //    using (StreamReader reader = new StreamReader(@"..\..\Zaidejai.txt"))
        //    {
        //        string line = "";
        //        while (null != (line = reader.ReadLine()))
        //        {
        //            switch (line[0])
        //            {
        //                case 'K':
        //                    visiZaidejai.PridetiZaideja(new Krepsininkas(line));
        //                    break;
        //                case 'F':
        //                    visiZaidejai.PridetiZaideja(new Futbolininkas(line));
        //                    break;
        //            }
        //        }
        //    }
        //}
    }
}
