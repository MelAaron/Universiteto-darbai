using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;





namespace Egzui_S2
{
    class Sarasas<type> where type : IComparable<type> //sito reikes rikiavimo burbuliuku metodui, nerasyt jei nereik rikiuot burbuliuku
    {

        //Sukurkite ir užrašykite vienkrypčio sąrašo
        //duomenų tipus su komentarais.
        #region duomenu tipas
        private sealed class Mazgas<type> where type : IComparable<type> //sito reikes rikiavimo burbuliuku metodui, nerasyt jei nereik rikiuot burbuliuku
        {
            public type duomenuKlase { get; set; }
            public Mazgas<type> kitas { get; set; }
            public Mazgas(type duomenys, Mazgas<type> nuoroda)
            {
                duomenuKlase = duomenys;
                kitas = nuoroda;
            }
            //galbut dar uzkloti equals ir compare metodai
        }
        #endregion

        #region baziniai kintamieji
        private Mazgas<type> pirmas { get; set; }
        private Mazgas<type> paskutinis { get; set; }
        private Mazgas<type> dabartinis { get; set; }
        #endregion

        #region bazines operacijos
        public Sarasas()
        {
            pirmas = paskutinis = null;
        }

       public void PridetIGala(type pridedamasis)
        {
            Mazgas<type> laikinas = new Mazgas<type>(pridedamasis, null);
            if (pirmas == null)
                pirmas = laikinas;
            else
                paskutinis.kitas = laikinas;
            paskutinis = laikinas;
        }

        public void PridetIPrieki(type pridedamasis)
        {
            Mazgas<type> laikinas = new Mazgas<type>(pridedamasis, pirmas);
            if (pirmas == null)
                paskutinis = laikinas;
            pirmas = laikinas;
        }

        public void Pradzia()
        {
            dabartinis = pirmas;
        }
        public void Kitas()
        {
            dabartinis = dabartinis.kitas;
        }
        public bool Pasibaige()
        {
            return dabartinis == null;
        }
        public type Grazinti()
        {
            return dabartinis.duomenuKlase;
        }


        #endregion

        //Parašykite klasės metodą elemento šalinimui iš
        //to sąrašo.Elementas nurodomas metodo
        //parametru.
        #region salinimas
        public void Pasalinti(type pasalinamasis)
        {
            Mazgas<type> nuoroda = pirmas;
            for(Mazgas<type> laikinas = pirmas; laikinas != null; laikinas = laikinas.kitas)
            {
                if (laikinas.duomenuKlase.Equals(pasalinamasis))
                {
                    nuoroda.kitas = laikinas.kitas;
                    laikinas = null;
                }
                else nuoroda = laikinas;
            }
        }
        #endregion


        //Sąrašo rikiavimas išrinkimo ar burbuliuko metodai, sicia reikia mazgo ir konteinerio klaseje deklaruot IComparable<type>
        #region rikiavimas
        public void RikiavimasBurbuliuku() 
        {
            if (pirmas == null) return; //del viso pikto
            for(Mazgas<type> burbulas = pirmas; burbulas != null; burbulas = burbulas.kitas)
            {
                if(burbulas.duomenuKlase.CompareTo(burbulas.kitas.duomenuKlase) > 0)
                {
                    type laikinas = burbulas.duomenuKlase;
                    burbulas.duomenuKlase = burbulas.kitas.duomenuKlase;
                    burbulas.kitas.duomenuKlase = laikinas;
                }
            }
        }

        public void RikiavimasIsrinkimu()
        {
            if (pirmas == null) return;
            for (Mazgas<type> dabartinis = pirmas; dabartinis != null; dabartinis = dabartinis.kitas)
            {
                Mazgas<type> didziausias = dabartinis;
                for (Mazgas<type> paieska = dabartinis; paieska != null; paieska = paieska.kitas)
                    if (paieska.duomenuKlase.CompareTo(didziausias.duomenuKlase) < 0)
                        didziausias = paieska;
                type laikinas = dabartinis.duomenuKlase;
                dabartinis.duomenuKlase = didziausias.duomenuKlase;
                didziausias.duomenuKlase = laikinas;
            }
        }
        #endregion
    }
    class Sarasas
    {
        Mazgas pirmas;
        Mazgas paskutinis;
        Mazgas dabartinis;
        private sealed class Mazgas
        {
            public Player data { get; set; }
            public Mazgas kitas { get; set; }
            public Mazgas(Player input, Mazgas adr)
            {
                data = input;
                kitas = adr;
            }
        }
        public void Prideti(Player data)
        {
            Mazgas temp = new Mazgas(data, null);
            if (pirmas == null)
            {
                pirmas = paskutinis = temp;
            }
            else
            {
                paskutinis.kitas = temp;
                paskutinis = temp;
            }
        }
        public void RikiuotiBurbulu()
        {
            bool bk = true;
            while (bk)
            {
                bk = false;
                for (dabartinis = pirmas; dabartinis != null; dabartinis = dabartinis.kitas)
                {
                    if (dabartinis.kitas != null && dabartinis.data.inches > dabartinis.kitas.data.inches)
                    {
                        bk = true;
                        tipas temp = dd.data;
                        dd.data = dd.kitas.data;
                        dd.kitas.data = temp;
                    }
                }
            }
        }
        public Sarasas()
        {
            pirmas = paskutinis = dabartinis = null;
        }
        public void Kitas()
        {
            dabartinis = dabartinis.kitas;
        }
        public void Pirmas()
        {
            dabartinis = pirmas;
        }
        public void Paskutinis()
        {
            dabartinis = paskutinis;
        }
        public Player Data()
        {
            return dabartinis.data;
        }
        public bool Pabaiga()
        {
            return dabartinis == null;
        }
    }
}
