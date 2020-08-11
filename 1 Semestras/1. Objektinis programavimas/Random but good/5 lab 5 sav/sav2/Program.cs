using System;
using System.IO;
using System.Linq;

namespace sav2
{
    class Program
    {
        const int maxkomandos = 20;
        const int maxzaidejai = 100;
        static void Main(string[] args)
        {
            KomanduKonteineris komandos = new KomanduKonteineris(maxkomandos);
            SudarytiKomandas(komandos);
            Atrinkimas(komandos);
            Console.ReadKey();
        }
        static void Atrinkimas(KomanduKonteineris komandos)
        {
            ZaidejuKonteineris gerizaidejai = filtruoti(komandos);
            SpausdinimasIEkrana(gerizaidejai);
        }
        static void SpausdinimasIEkrana(ZaidejuKonteineris zaidejai)
        {
            for (int i = 0; i < zaidejai.Count; i++)
                Console.WriteLine(zaidejai.GetZaidejas(i));
        }
        static ZaidejuKonteineris filtruoti(KomanduKonteineris komandos)
        {
            ZaidejuKonteineris filtruotiZaidejai = new ZaidejuKonteineris(maxzaidejai);
            for (int i = 0; i < komandos.Count; i++)
                for (int j = 0; j < komandos.ZaidejuCount(i); j++)
                    if (TikrinaZaidejus(komandos.GetZaidejas(j, i), komandos.GetKomanda(i)))
                        filtruotiZaidejai += komandos.GetZaidejas(j, i);
            return filtruotiZaidejai;
        }
        static bool TikrinaZaidejus(Zaidejas zaidejas, Komanda komanda)
        {
            if(zaidejas is Krepsininkas)
            {
                Krepsininkas a = zaidejas as Krepsininkas;
                return a >= komanda;
            }
            else if (zaidejas is Futbolininkas)
            {
                Futbolininkas a = zaidejas as Futbolininkas;
                return a >= komanda;
            }
            return false;
        }
       
        static void SudarytiKomandas(KomanduKonteineris komandos)
        {
            ZaidejuKonteineris visiZaidejai = new ZaidejuKonteineris(maxzaidejai);
            SkaitytiZaidejusIsFailo(visiZaidejai);
            SkaitytiKomandasIsFailo(komandos, visiZaidejai);
        }
        static void SkaitytiZaidejusIsFailo(ZaidejuKonteineris visiZaidejai)
        {
            using (StreamReader reader = new StreamReader(@"..\..\Zaidejai.txt"))
            {
                string line = "";
                while (null != (line = reader.ReadLine()))
                {
                    switch (line[0])
                    {
                        case 'K':
                            visiZaidejai.PridetiZaideja(new Krepsininkas(line));
                            break;
                        case 'F':
                            visiZaidejai.PridetiZaideja(new Futbolininkas(line));
                            break;
                    }
                }
            }
        }

        static void SkaitytiKomandasIsFailo(KomanduKonteineris komandos, ZaidejuKonteineris visiZaidejai)
        {
            using (StreamReader reader = new StreamReader(@"..\..\Komandos.txt"))
            {
                string line = null;

                while ((line = reader.ReadLine()) != null)
                {
                    string[] values = line.Split(';');
                    string komandosPavadinimas = values[0];
                    string miestas = values[1];
                    string komandosTreneris = values[2];
                    int zaistiosRungtynes = int.Parse(values[3]);
                    Komanda naujakomanda = new Komanda(komandosPavadinimas, miestas, komandosTreneris, zaistiosRungtynes, KomandosZaidejai(komandosPavadinimas, visiZaidejai));
                    komandos.PridetiKomanda(naujakomanda);
                }
            }
        }
        static ZaidejuKonteineris KomandosZaidejai(string komandospavadinimas, ZaidejuKonteineris visiZaidejai)
        {
            ZaidejuKonteineris komandosZaidejai = new ZaidejuKonteineris(visiZaidejai.Count);
            for (int i = 0; i < visiZaidejai.Count; i++)
            {
                if (visiZaidejai.GetZaidejas(i).KomandosPavadinimas == komandospavadinimas)
                {
                    komandosZaidejai.PridetiZaideja(visiZaidejai.GetZaidejas(i));
                }
            }

            return komandosZaidejai;
        }
    }
}
