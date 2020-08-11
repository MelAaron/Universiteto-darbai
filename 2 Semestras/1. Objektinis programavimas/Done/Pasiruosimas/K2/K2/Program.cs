using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;

namespace K2
{
    class Program
    {
        static void Main(string[] args)
        {
            string file = "file.txt";
            string answerFile = "answers.txt";
            File.Delete(answerFile);
            var A = new Modeliai<Auto>();
            ReadData(A, file);
            Spausdinti(answerFile, A);
            Auto BrangiausiasAuto = Brangiausias(A);
            var B = Atrinkti(A, BrangiausiasAuto);
            Spausdinti(answerFile, B);
            B.RikiuotiBurbulu();
            Spausdinti(answerFile, B);
        }
        private static void ReadData(Modeliai<Auto> list, string file)
        {
            using (StreamReader sr = new StreamReader(file, Encoding.GetEncoding(1257)))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] val = line.Split(';');
                    var automobilis = new Auto(val[0], val[1], double.Parse(val[2]));
                    list.Prideti(automobilis);
                }
            }
        }
        private static Auto Brangiausias(Modeliai<Auto> list)
        {
            list.Pirmas();
            Auto brangiausias = list.GautiData();
            for (list.Pirmas(); !list.Pabaiga(); list.Kitas())
            {
                if (list.GautiData().Kaina > brangiausias.Kaina)
                    brangiausias = list.GautiData();
            }
            return brangiausias;
        }
        private static Modeliai<Auto> Atrinkti(Modeliai<Auto> A, Auto brangiausias)
        {
            var B = new Modeliai<Auto>();
            for (A.Pirmas(); !A.Pabaiga(); A.Kitas())
            {
                if ((A.GautiData().Kaina * 100) / brangiausias.Kaina > 75 && (A.GautiData().Kaina * 100) / brangiausias.Kaina < 125)
                {
                    B.Prideti(A.GautiData());
                }
            }
            return B;
        }
        private static void Spausdinti(string answerfile, Modeliai<Auto> list)
        {
            using (StreamWriter sw = new StreamWriter(answerfile, true))
            {
                list.Pirmas();
                string bruksnys = new string('-', list.GautiData().ToString().Length);
                for (list.Pirmas(); !list.Pabaiga(); list.Kitas())
                {
                    sw.WriteLine(list.GautiData().ToString());
                    sw.WriteLine(bruksnys);
                }
                sw.WriteLine();
            }
        }
    }
    //------------------------------------------------------------------------------------------------------------------------
    class Auto : IComparable<Auto>, IEquatable<Auto>
    {
        public string Pavadinimas { get; set; }
        public string Modelis { get; set; }
        public double Kaina { get; set; }
        public Auto(string pavadinimas, string modelis, double kaina)
        {
            Pavadinimas = pavadinimas;
            Modelis = modelis;
            Kaina = kaina;
        }
        public int CompareTo(Auto other)
        {
            if (other == null)
                return 1;
            if (Kaina.CompareTo(other.Kaina) == 0)
            {
                return Pavadinimas.CompareTo(other.Pavadinimas);
            }
            else return (Kaina.CompareTo(other.Kaina));
        }
        public bool Equals(Auto other)
        {
            if (other == null)
                return false;
            if (Pavadinimas == other.Pavadinimas && Modelis == other.Modelis)
                return true;
            else
                return false;
        }
        public override string ToString()
        {
            return String.Format("{0, 20} | {1, 10} | {2, 10} |", Pavadinimas, Modelis, Kaina);
        }
    }
    //------------------------------------------------------------------------------------------------------------------------
    class Modeliai<tipas> : IEnumerable<tipas> where tipas : IComparable<tipas>, IEquatable<tipas>
    {
        private Mazgas<tipas> pr;
        private Mazgas<tipas> dd;
        private Mazgas<tipas> pb;

        private sealed class Mazgas<tipas>
        {
            public tipas data { get; set; }
            public Mazgas<tipas> kitas { get; set; }
            public Mazgas<tipas> ankstesnis { get; set; }
            public Mazgas(tipas input, Mazgas<tipas> adrA, Mazgas<tipas> adrK)
            {
                data = input;
                kitas = adrK;
                ankstesnis = adrA;
            }
        }
        public void Prideti(tipas pridedamas)
        {
            Mazgas<tipas> temp = new Mazgas<tipas>(pridedamas, pb, null);
            if (pr != null)
                pb.kitas = temp;
            else
                pr = temp;
            pb = temp;
        }
        public void NaikintiSarasa()
        {
            while (pr != null)
            {
                dd = pr;
                pr = pr.kitas;
                dd.kitas = null;
            }
            pb = dd = pr;
        }
        public void SalintiDuomenis()
        {
            if (dd == pr) pr = pr.kitas;
            if (dd == pb) pb = pb.ankstesnis;
            if (dd.ankstesnis != null)
                dd.ankstesnis.kitas = dd.kitas;
            if (dd.kitas != null)
                dd.kitas.ankstesnis = dd.ankstesnis;
            dd = null;
        }
        public void RikiuotiBurbulu()
        {
            bool bk = true;
            while (bk)
            {
                bk = false;
                for (dd = pr; dd != null; dd = dd.kitas)
                {
                    if (dd.kitas != null && dd.data.CompareTo(dd.kitas.data) > 0)
                    {
                        bk = true;
                        tipas temp = dd.data;
                        dd.data = dd.kitas.data;
                        dd.kitas.data = temp;
                    }
                }
            }
        }
        public void RusiuotiIsrinkimu()
        {
            for (Mazgas<tipas> d1 = pr; d1 != null; d1 = d1.kitas)
            {
                Mazgas<tipas> maxv = d1;
                for (Mazgas<tipas> d2 = d1; d2 != null; d2 = d2.kitas)
                    if (d2.data.CompareTo(maxv.data) < 0)
                        maxv = d2;
                tipas St = d1.data;
                d1.data = maxv.data;
                maxv.data = St;
            }
        }
        public IEnumerator<tipas> GetEnumerator()
        {
            for (Mazgas<tipas> dd = pr; dd != null; dd = dd.kitas)
            {
                yield return dd.data;
            }
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
        public Modeliai()
        {
            pr = pb = dd = null;
        }
        public tipas GautiData()
        {
            return dd.data;
        }
        public void Pirmas()
        {
            dd = pr;
        }
        public void Kitas()
        {
            dd = dd.kitas;
        }
        public void Ankstesnis()
        {
            dd = dd.ankstesnis;
        }
        public bool Pabaiga()
        {
            return dd == null;
        }
        public void Paskutinis()
        {
            dd = pb;
        }
        //public void RusiuotiBurbulu()
        //{
        //    bool bc = true;
        //    Mazgas<tipas> d0, d1, r1;
        //    while (bc)
        //    {
        //        bc = false;
        //        d0 = d1 = r1 = pr;
        //        while (d1 != null)
        //        {
        //            if (d0.data.CompareTo(d1.data) > 0)
        //            {
        //                bc = true;
        //                if (d0 == pr)
        //                {
        //                    pr = pr.kitas;
        //                    d0.kitas = d1.kitas;
        //                    d1.kitas = d0;
        //                }
        //                else
        //                {
        //                    d0.kitas = d1.kitas;
        //                    d1.kitas = d0;
        //                    r1.kitas = d1;
        //                }
        //            }
        //            r1 = d0;
        //            d0 = d1;
        //            d1 = d1.kitas;
        //        }
        //    }
        //}
        //public void Pasalinti(tipas duom)
        //{
        //    for(Mazgas<tipas> temp = pr; temp != null; temp = temp.kitas)
        //    {
        //        if(duom.Equals(temp))
        //        {
        //            temp.ankstesnis.kitas = temp.kitas;
        //            temp = null;
        //            return;
        //        }
        //    }
        //}

    }
    //public class ModeliaiA<tipas> where tipas : IComparable<tipas>
    //{
    //    private Mazgas<tipas> dd;
    //    private Mazgas<tipas> pr;
    //    private Mazgas<tipas> pb;
    //    private sealed class Mazgas<tipas>
    //    {
    //        public tipas data { get; set; }
    //        public Mazgas<tipas> kitas { get; set; }
    //        public Mazgas<tipas> ankstesnis { get; set; }
    //        public Mazgas(tipas naujas, Mazgas<tipas> adrN, Mazgas<tipas> adrP)
    //        {
    //            data = naujas;
    //            kitas = adrN;
    //            ankstesnis = adrP;
    //        }
    //    }
    //    public ModeliaiA()
    //    {
    //        dd = pr = pb = null;
    //    }
    //    public void Prideti(tipas naujas)
    //    {
    //        Mazgas<tipas> t = new Mazgas<tipas>(naujas, null, pb);
    //        if (pr != null)
    //            pb.kitas = t;
    //        else
    //            pr = t;
    //        pb = t;
    //    }
    //    public void Kitas()
    //    {
    //        dd = dd.kitas;
    //    }
    //    public void Ankstesnis()
    //    {
    //        dd = dd.ankstesnis;
    //    }
    //    public tipas GautiData()
    //    {
    //        return dd.data;
    //    }
    //    public void Pirmas()
    //    {
    //        dd = pr;
    //    }
    //    public bool Pabaiga()
    //    {
    //        return dd == null;
    //    }
    //    public void Paskutinis()
    //    {
    //        dd = pb;
    //    }
    //    public void RikiuotiBurbulu()
    //    {
    //        bool bk = true;
    //        while(bk)
    //        {
    //            bk = false;
    //            for(Mazgas<tipas> d = pr; d != null; d = d.kitas)
    //            {
    //                if(d.kitas != null && d.data.CompareTo(d.kitas.data) > 0)
    //                {
    //                    tipas t = d.data;
    //                    d.data = d.kitas.data;
    //                    d.kitas.data = t;
    //                    bk = true;
    //                }
    //            }
    //        }
    //    }
    //    public void RikiuotiIsrinkimu()
    //    {
    //        for(Mazgas<tipas> d1 = pr; d1 != null; d1 = d1.kitas)
    //        {
    //            Mazgas<tipas> maxv = d1;
    //            for (Mazgas<tipas> d2 = d1; d2 != null; d2 = d2.kitas)
    //                if (d1.data.CompareTo(d2.data) > 0)
    //                    maxv = d2;
    //            tipas t = d1.data;
    //            d1.data = maxv.data;
    //            maxv.data = t;
    //        }
    //    }
    //    public void PasalintiElementa()
    //    {
    //        if (dd == pr) pr = pr.kitas;
    //        if (dd == pb) pb = pb.ankstesnis;
    //        if (dd.kitas != null)
    //            dd.kitas.ankstesnis = dd.ankstesnis;
    //        if (dd.ankstesnis != null)
    //            dd.ankstesnis.kitas = dd.kitas;
    //        dd.kitas = null;
    //        dd.ankstesnis = null;
    //    }
    //}
    //public class Modeliai2<tipas> where tipas : IComparable<tipas>
    //{
    //    private Mazgas<tipas> pr;
    //    private Mazgas<tipas> pb;
    //    private Mazgas<tipas> dd;
    //    private class Mazgas<tipas>
    //    {
    //        public tipas data { get; set; }
    //        public Mazgas<tipas> Kitas { get; set; }
    //        public Mazgas<tipas> Ankstesnis { get; set; }
    //        public Mazgas(tipas input, Mazgas<tipas> adrN, Mazgas<tipas> adrP)
    //        {
    //            data = input;
    //            Kitas = adrN;
    //            Ankstesnis = adrP;
    //        }
    //    }
    //    public Modeliai2()
    //    {
    //        pr = pb = dd = null;
    //    }
    //    public void PridetiIGala(tipas pridedamas)
    //    {
    //        Mazgas<tipas> a = new Mazgas<tipas>(pridedamas, null, pb);
    //        if (pr != null)
    //            pb.Kitas = a;
    //        else
    //            pr = a;
    //        pb = a;
    //    }
    //    public tipas GautiData()
    //    {
    //        return dd.data;
    //    }
    //    public void Kitas()
    //    {
    //        dd = dd.Kitas;
    //    }
    //    public void Ankstesnis()
    //    {
    //        dd = dd.Ankstesnis;
    //    }
    //    public bool Pabaiga()
    //    {
    //        return dd == null;
    //    }
    //    public void Pirmas()
    //    {
    //        dd = pr;
    //    }
    //    public void Paskutinis()
    //    {
    //        dd = pb;
    //    }
    //    public void RikiuotiBurbulu()
    //    {
    //        bool bk = true;
    //        while (bk)
    //        {
    //            bk = false;
    //            for (Mazgas<tipas> a = pr; a != null; a = a.Kitas)
    //                if (a.Kitas != null && a.data.CompareTo(a.Kitas.data) > 0)
    //                {
    //                    tipas t = a.data;
    //                    a.data = a.Kitas.data;
    //                    a.Kitas.data = t;
    //                    bk = true;
    //                }
    //        }
    //    }
    //    public void RusiuotiIsrinkimu()
    //    {
    //        for(Mazgas<tipas> d1 = pr; d1 != null; d1 = d1.Kitas)
    //        {
    //            Mazgas<tipas> maxv = d1;
    //            for(Mazgas<tipas> d2 = d1; d2 != null; d2 = d2.Kitas)
    //                if (d2.data.CompareTo(d1.data) < 0)
    //                    maxv = d2;
    //            tipas t = d1.data;
    //            d1.data = maxv.data;
    //            maxv.data = t;
    //        }
    //    }
    //}
    //public class Automobiliai<type>
    //{
    //    private Mazgas<type> dd;
    //    private Mazgas<type> pr;
    //    private Mazgas<type> pb;
    //    private sealed class Mazgas<type>
    //    {
    //        public type data { get; set; }
    //        public Mazgas<type> kitas { get; set; }
    //        public Mazgas<type> ankstestnis { get; set; }
    //        public Mazgas(type input, Mazgas<type> adrA, Mazgas<type> adrK)
    //        {
    //            data = input;
    //            kitas = adrK;
    //            ankstestnis = adrA;
    //        }
    //    }
    //    public void Prideti(type idedamas)
    //    {
    //        Mazgas<type> a = new Mazgas<type>(idedamas, pb, null);
    //        if (pr != null)
    //            pb.kitas = a;
    //        else
    //            pr = a;
    //        pb = a;
    //    }
    //    public void Kitas()
    //    {
    //        dd = dd.kitas;
    //    }
    //    public void Paskutinis()
    //    {
    //        dd = pb;
    //    }
    //    public void Pirmas()
    //    {
    //        dd = pr;
    //    }
    //    public type GautiInfo()
    //    {
    //        return dd.data;
    //    }
    //    public void Ankstesnis()
    //    {
    //        dd = dd.ankstestnis;
    //    }
    //    public bool Pabaiga()
    //    {
    //        return dd == null;
    //    }
    //    public Automobiliai()
    //    {
    //        pr = pb = dd = null;
    //    }
    //}
    //public class Konteineris<type>
    //{
    //    private Mazgas<type> dd;
    //    private Mazgas<type> pr;
    //    private Mazgas<type> pb;

    //    private sealed class Mazgas<type>
    //    {
    //        public type data { get; set; }
    //        public Mazgas<type> kitas { get; set; }
    //        public Mazgas<type> ankstesnis { get; set; }
    //        public Mazgas(type input, Mazgas<type> adrN, Mazgas<type> adrP)
    //        {
    //            data = input;
    //            kitas = adrN;
    //            ankstesnis = adrP;
    //        }
    //    }
    //    public Konteineris()
    //    {
    //        dd = pr = pb = null;
    //    }
    //    public void Pirmas()
    //    {
    //        dd = pr;
    //    }
    //    public void Paskutinis()
    //    {
    //        dd = pb;
    //    }
    //    public void Kitas()
    //    {
    //        dd = dd.kitas;
    //    }
    //    public void Ankstesnis()
    //    {
    //        dd = dd.ankstesnis;
    //    }
    //    public type GautiData()
    //    {
    //        return dd.data;
    //    }
    //    public void Prideti(type objektas)
    //    {
    //        var a = new Mazgas<type>(objektas, null, pb);
    //        if (pr != null)
    //            pb.kitas = a;
    //        else
    //            pr = a;
    //        pb = a;
    //    }
    //    public void Salinti()
    //    {
    //        if (dd == pr)
    //            pr = pr.kitas;
    //        if (dd == pb)
    //            pb = pb.ankstesnis;
    //        if (dd.ankstesnis != null)
    //            dd.ankstesnis.kitas = dd.kitas;
    //        if (dd.kitas != null)
    //            dd.kitas.ankstesnis = dd.ankstesnis;
    //    }
    //}
    //public class Vienkryptis<tipas>
    //{
    //    private Mazgas<tipas> dd;
    //    private Mazgas<tipas> pr;
    //    private Mazgas<tipas> pb;
    //    private sealed class Mazgas<tipas>
    //    {
    //        public tipas data { get; set; }
    //        public Mazgas<tipas> kitas { get; set; }
    //        public Mazgas(tipas input, Mazgas<tipas> adr)
    //        {
    //            data = input;
    //            kitas = adr;
    //        }
    //    }
    //    public Vienkryptis()
    //    {
    //        dd = pr = pb = null;
    //    }
    //    public void Prideti(tipas input)
    //    {
    //        Mazgas<tipas> a = new Mazgas<tipas>(input, null);
    //        if (pr != null)
    //        {
    //            pb.kitas = a;
    //            pb = a;
    //        }
    //        else
    //            pr = pb = a;
    //    }
    //    public void Pirmas()
    //    {
    //        dd = pr;
    //    }
    //    public void Paskutinis()
    //    {
    //        dd = pb;
    //    }
    //    public void Kitas()
    //    {
    //        dd = dd.kitas;
    //    }
    //    public tipas GautiData()
    //    {
    //        return dd.data;
    //    }
    //    public bool Pabaiga()
    //    {
    //        return dd == null;
    //    }
    //}
    //public class sarasas<tipas> : IEnumerable<tipas> where tipas : IComparable<tipas>, IEquatable<tipas>
    //{
    //    private Mazgas<tipas> dd;
    //    private Mazgas<tipas> pr;
    //    private Mazgas<tipas> pb;
    //    private sealed class Mazgas<tipas>
    //    {
    //        public tipas data { get; set; }
    //        public Mazgas<tipas> kitas { get; set; }
    //        public Mazgas<tipas> ankstesnis { get; set; }
    //        public Mazgas(tipas input, Mazgas<tipas> adrN, Mazgas<tipas> adrP)
    //        {
    //            data = input;
    //            kitas = adrN;
    //            ankstesnis = adrP;
    //        }
    //    }
    //    public sarasas()
    //    {
    //        pr = pb = dd = null;
    //    }
    //    public void Prideti(tipas input)
    //    {
    //        Mazgas<tipas> a = new Mazgas<tipas>(input, null, pb);
    //        if (pr != null)
    //            pb.kitas = a;
    //        else
    //            pr = a;
    //        pb = a;
    //    }
    //    public void Pirmas()
    //    {
    //        dd = pr;
    //    }
    //    public void Paskutinis()
    //    {
    //        dd = pb;
    //    }
    //    public void Kitas()
    //    {
    //        dd = dd.kitas;
    //    }
    //    public bool Pabaiga()
    //    {
    //        return dd == null;
    //    }
    //    public void Ankstesnis()
    //    {
    //        dd = dd.ankstesnis;
    //    }
    //    public tipas GautiData()
    //    {
    //        return dd.data;
    //    }
    //    public void SortB()
    //    {
    //        bool bk = true;
    //        while (bk)
    //        {
    //            bk = false;
    //            for (Mazgas<tipas> d = pr; d != null; d = d.kitas)
    //            {
    //                if (dd.kitas != null && d.data.CompareTo(d.kitas.data) > 0)
    //                {
    //                    bk = true;
    //                    tipas t = dd.data;
    //                    dd.data = dd.kitas.data;
    //                    dd.kitas.data = t;
    //                }
    //            }
    //        }
    //    }
    //    public void SortI()
    //    {
    //        for (Mazgas<tipas> d1 = pr; d1 != null; d1 = d1.kitas)
    //        {
    //            Mazgas<tipas> maxv = d1;
    //            for (Mazgas<tipas> d2 = d1; d2 != null; d2 = d2.kitas)
    //            {
    //                if (d1.data.CompareTo(d2.data) > 0)
    //                    maxv = d2;
    //                tipas t = d1.data;
    //                d1.data = maxv.data;
    //                maxv.data = t;
    //            }
    //        }
    //    }

    //    public IEnumerator<tipas> GetEnumerator()
    //    {
    //        for (Mazgas<tipas> d = pr; d != null; d = d.kitas)
    //        {
    //            yield return d.data;
    //        }
    //    }

    //    IEnumerator IEnumerable.GetEnumerator()
    //    {
    //        throw new NotImplementedException();
    //    }
    //    public void PRIDET(tipas pridedamas)
    //    {
    //        Mazgas<tipas> a = new Mazgas<tipas>(pridedamas, null, pb);
    //        if (pr != null)
    //            pb.kitas = a;
    //        else
    //            pr = a;
    //        pb = a;
    //    }
    //    public void Burb()
    //    {
    //        bool bk = true;
    //        while(bk)
    //        {
    //            bk = false;
    //            for(Mazgas<tipas> d = pr; d != null; d = d.kitas)
    //            {
    //                if(d.kitas != null && d.data.CompareTo(d.kitas.data) > 0)
    //                {
    //                    tipas t = d.data;
    //                    d.data = d.kitas.data;
    //                    d.kitas.data = t;
    //                    bk = true;
    //                }
    //            }
    //        }
    //    }
    //    public void Isrink()
    //    {
    //        for(Mazgas<tipas> d1 = pr; d1 != null; d1 = d1.kitas)
    //        {
    //            Mazgas<tipas> maxv = d1;
    //            for(Mazgas<tipas> d2 = d1; d2 != null; d2 = d2.kitas)
    //                if (d2.data.CompareTo(d1.data) > 0)
    //                    maxv = d2;
    //            tipas t = d1.data;
    //            d1.data = maxv.data;
    //            maxv.data = t;
    //        }
    //    }
    //    public void IstrintiElementa()
    //    {
    //        if (dd == pr) pr = pr.kitas;
    //        if (dd == pb) pb = pb.ankstesnis;
    //        if (dd.kitas != null)
    //            dd.kitas.ankstesnis = dd.ankstesnis;
    //        if (dd.ankstesnis != null)
    //            dd.ankstesnis.kitas = dd.kitas;
    //    }
    //}
    //public class Daiktas: IComparable<Daiktas> , IEquatable<Daiktas>
    //{
    //    public string Pavadinimas { get; set; }
    //    public string Modelis { get; set; }
    //    public double Kaina { get; set; }
    //    public Daiktas(string pavadinimas, string modelis, double kaina)
    //    {
    //        Pavadinimas = pavadinimas;
    //        Modelis = modelis;
    //        Kaina = kaina;
    //    }

    //    public int CompareTo(Daiktas other)
    //    {
    //        if (other == null)
    //            return 0;
    //        if(Pavadinimas.CompareTo(other.Pavadinimas) == 0)
    //        {
    //            return Modelis.CompareTo(other.Modelis);
    //        }
    //        return Pavadinimas.CompareTo(other.Pavadinimas);
    //    }

    //    public bool Equals(Daiktas other)
    //    {
    //        if (other == null)
    //            return false;
    //        if (Pavadinimas.CompareTo(other.Pavadinimas) == 0 && Modelis.CompareTo(other.Modelis) == 0)
    //            return true;
    //        else
    //            return false;

    //    }
    //}
}
