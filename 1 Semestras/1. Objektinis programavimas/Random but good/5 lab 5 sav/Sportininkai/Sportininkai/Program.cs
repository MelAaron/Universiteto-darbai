using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sportininkai
{
    class Program
    {
        static void Main(string[] args)
        {

            Program p = new Program();
            string PasirinktasMiestas = null;
            Console.WriteLine("Įveskite miestą");
            PasirinktasMiestas = Console.ReadLine();
            KomanduKonteineris komandos = p.SkaitoKomanduDuomenis("Komandos.txt");
            ZaidejuKonteineris krepsininkai = p.SkaitoKrepsininkuDuomenis("Krepsininkai.txt");
            ZaidejuKonteineris futbolininkai = p.SkaitoFutbolininkuDuomenis("Futbolininkai.txt");
            KomanduKonteineris AtrinktosKomandos = p.AtrenkaKomandas(PasirinktasMiestas, komandos);
            ZaidejuKonteineris AtrinktiKrepsininkai = p.AtrenkaZaidejus(AtrinktosKomandos, krepsininkai);
            ZaidejuKonteineris AtrinktiFutbolininkai = p.AtrenkaZaidejus(AtrinktosKomandos, futbolininkai);
            Console.WriteLine("Komandų duomenys:");
            p.SpausdinaKomanduDuomenis(komandos);
            Console.WriteLine("Krepsininku Duomenys:");
            p.SpausdinaDuomenis(krepsininkai);
            Console.WriteLine("Futbolininkų duomenys:");
            p.SpausdinaDuomenis(futbolininkai);
            Console.WriteLine("Atrinkti žaidėjai:");
            if (AtrinktiFutbolininkai.Skaicius > 0)
            {
                p.SpausdinaDuomenis(AtrinktiFutbolininkai);
            }
            if (AtrinktiKrepsininkai.Skaicius > 0)
            {
                p.SpausdinaDuomenis(AtrinktiKrepsininkai);
            }
            if (AtrinktiKrepsininkai.Skaicius == 0 && AtrinktiFutbolininkai.Skaicius == 0)
            {
                Console.WriteLine("Tinkamų žaidėjų nėra");
            }
            Console.ReadKey();
        }
        KomanduKonteineris SkaitoKomanduDuomenis(string Failas)
        {
            KomanduKonteineris komandos = new KomanduKonteineris(10);
            using (StreamReader reader = new StreamReader(@Failas))
            {
                string[] eilutes = File.ReadAllLines(@Failas);
                foreach (var eilute in eilutes)
                {
                    string[] vertes = eilute.Split(',');
                    string komandosPavadinimas = vertes[0];
                    string miestas = vertes[1];
                    string komandosTreneris = vertes[2];
                    int zaistuRungtyniuSkaicius = int.Parse(vertes[3]);
                    Komanda komanda = new Komanda(komandosPavadinimas, miestas, komandosTreneris, zaistuRungtyniuSkaicius);
                    komandos.PridedaKomanda(komanda);
                }

            }
            return komandos;
        }
        ZaidejuKonteineris SkaitoKrepsininkuDuomenis(string Failas)
        {
            ZaidejuKonteineris krepsininkai = new ZaidejuKonteineris(50);
            string[] eilutes = File.ReadAllLines(Failas);
            foreach (var eilute in eilutes)
            {
                Krepšininkas krepsininkas = new Krepšininkas(eilute);
                krepsininkai.PridedaZaideja(krepsininkas);
            }
            return krepsininkai;
        }
        ZaidejuKonteineris SkaitoFutbolininkuDuomenis(string Failas)
        {
            ZaidejuKonteineris futbolininkai = new ZaidejuKonteineris(50);
            string[] eilutes = File.ReadAllLines(Failas);
            foreach(var eilute in eilutes)
            {
                Futbolininkas futbolininkas = new Futbolininkas(eilute);
                futbolininkai.PridedaZaideja(futbolininkas);
            }
            return futbolininkai;
        }
        void SpausdinaDuomenis(ZaidejuKonteineris zaidejai)
        {
            for (int i = 0; i < zaidejai.Skaicius; i++)
            {
                Console.WriteLine("{0}", zaidejai.PaimaZaideja(i).ToString());
            }
        }
        //Metodas spausdinantis komandų duomenis į konsolę
        void SpausdinaKomanduDuomenis(KomanduKonteineris komandos)
        {
            for (int i = 0; i < komandos.KomanduSkaicius; i++)
            {
                Console.WriteLine("{0}", komandos.PaimaKomanda(i).ToString());
            }
        }
        //Metodas atrenkantis komandas pagal pasirinktą miestą
        KomanduKonteineris AtrenkaKomandas(string pasirinktasMiestas, KomanduKonteineris komandos)
        {
            KomanduKonteineris AtrinktosKomandos = new KomanduKonteineris(50);
            for (int i = 0; i < komandos.KomanduSkaicius; i++)
            {
                // Console.WriteLine("{0}", komandos.PaimaKomanda(i).ToString());
                if (pasirinktasMiestas == komandos.PaimaKomanda(i))
                {
                    AtrinktosKomandos.PridedaKomanda(komandos.PaimaKomanda(i));
                }
            }
            return AtrinktosKomandos;
        }
        ZaidejuKonteineris AtrenkaZaidejus(KomanduKonteineris AtrinktosKomandos, ZaidejuKonteineris zaidejai)
        {
            ZaidejuKonteineris AtrinktiZaidejai = new ZaidejuKonteineris(50);
            for (int i = 0; i < zaidejai.Skaicius; i++)
            {
                for (int j = 0; j < AtrinktosKomandos.KomanduSkaicius; j++)
                {
                    if (zaidejai.PaimaZaideja(i) == AtrinktosKomandos.PaimaKomanda(j))
                    {
                        if (zaidejai.PaimaZaideja(i).TaskuSkaicius >= SkaiciuojaTaskuVidurkius(AtrinktosKomandos.PaimaKomanda(j), zaidejai))
                        {
                            if (zaidejai.PaimaZaideja(i) is Krepšininkas && ((Krepšininkas)zaidejai.PaimaZaideja(i)).AtkovotuKamuoliuSkaicius >=SkaiciuojaVidurkius(AtrinktosKomandos.PaimaKomanda(j), zaidejai))
                            {
                                AtrinktiZaidejai.PridedaZaideja(zaidejai.PaimaZaideja(i));
                            }
                            if (zaidejai.PaimaZaideja(i) is Futbolininkas && ((Futbolininkas)zaidejai.PaimaZaideja(i)).SurinktuKorteliuSkaicius >= SkaiciuojaVidurkius(AtrinktosKomandos.PaimaKomanda(j), zaidejai))
                            {
                                AtrinktiZaidejai.PridedaZaideja(zaidejai.PaimaZaideja(i));
                            }
                        }
                    }
                }
            }
            return AtrinktiZaidejai;
        }
        public double SkaiciuojaTaskuVidurkius(Komanda AtrinktaKomanda, ZaidejuKonteineris Zaidejai)
        {
            double Vidurkis = 0;
            int ZaidejuSkaicius = 0;
            for (int i = 0; i < Zaidejai.Skaicius; i++)
            {
                if (AtrinktaKomanda != null)
                {
                    if (AtrinktaKomanda.KomandosPavadinimas == Zaidejai.PaimaZaideja(i).KomandosPavadinimas)
                    {
                        Vidurkis = Vidurkis + Zaidejai.PaimaZaideja(i).TaskuSkaicius;
                        ZaidejuSkaicius++;
                    }
                }
            }
            Vidurkis = Vidurkis / ZaidejuSkaicius;
            return Vidurkis;
        }
        public double SkaiciuojaVidurkius(Komanda AtrinktaKomanda, ZaidejuKonteineris Zaidejai)
        {
            double Vidurkis = 0;
            int ZaidejuSkaicius = 0;
            for (int i = 0; i < Zaidejai.Skaicius; i++)
            {
                if (AtrinktaKomanda != null)
                {
                    if (AtrinktaKomanda.KomandosPavadinimas == Zaidejai.PaimaZaideja(i).KomandosPavadinimas)
                    {
                        if (Zaidejai.PaimaZaideja(i) is Krepšininkas)
                        {
                            Vidurkis = Vidurkis + ((Krepšininkas)Zaidejai.PaimaZaideja(i)).AtkovotuKamuoliuSkaicius;
                            ZaidejuSkaicius++;
                        }
                        if(Zaidejai.PaimaZaideja(i) is Futbolininkas)
                        {
                            Vidurkis = Vidurkis + ((Futbolininkas)Zaidejai.PaimaZaideja(i)).SurinktuKorteliuSkaicius;
                            ZaidejuSkaicius++;
                        }
                    }
                }
            }
            Vidurkis = Vidurkis / ZaidejuSkaicius;
            return Vidurkis;
        }



    }
}
