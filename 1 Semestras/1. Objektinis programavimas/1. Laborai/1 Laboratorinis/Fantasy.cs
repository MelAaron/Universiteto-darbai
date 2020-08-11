using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_Laboratorinis
{
    class Fantasy
    {
        public string Vardas { get; set; }
        public string Rase { get; set; }
        public string Klase { get; set; }
        public int GyvybesTaskai { get; set; }
        public int Mana { get; set; }
        public int ZalosTaskai { get; set; }
        public int GynybosTaskai { get; set; }
        public int Jega { get; set; }
        public int Vikrumas { get; set; }
        public int Intelektas { get; set; }
        public string YpatingaGalia { get; set; }

        public int Skaitkliukas { get; set; } // tarnybinis kintamasis

        /// <summary>
        /// rasiu pasikartojimo kiekiui skaiciuoti
        /// </summary>
        /// <param name="rase">rases pavadinimas</param>
        public Fantasy(string rase)
        {
            Rase = rase;
            Skaitkliukas = 0;
        }
        /// <summary>
        /// Duomenu priskyrimas
        /// </summary>
        /// <param name="vardas">herojaus vardas</param>
        /// <param name="rase">herojaus rase</param>
        /// <param name="klase">herojaus klase</param>
        /// <param name="gyvybestaskai">herojaus gyvybes taskai</param>
        /// <param name="mana">herojaus mana</param>
        /// <param name="zalostaskai">herojaus zalos taskai</param>
        /// <param name="gynybostaskai">herojaus gynybos taskai</param>
        /// <param name="jega">herojaus jega</param>
        /// <param name="vikrumas">herojaus vikrumas</param>
        /// <param name="intelektas">herojaus intelektas</param>
        /// <param name="ypatingagalia">herojaus ypatinga galia</param>
        public Fantasy(string vardas, string rase, string klase, int gyvybestaskai,
            int mana, int zalostaskai, int gynybostaskai, int jega,
            int vikrumas, int intelektas, string ypatingagalia )
        {
            Vardas = vardas;
            Rase = rase;
            Klase = klase;
            GyvybesTaskai = gyvybestaskai;
            Mana = mana;
            ZalosTaskai = zalostaskai;
            GynybosTaskai = gynybostaskai;
            Jega = jega;
            Vikrumas = vikrumas;
            Intelektas = intelektas;
            YpatingaGalia = ypatingagalia;

            Skaitkliukas = 0;
        }

    }
}
