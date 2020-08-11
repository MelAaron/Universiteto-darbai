using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3_Laboras
{
    class Branch
    {
        public string Pavadinimas { get; set; }
        public string Adresas { get; set; }
        public string Telefonas { get; set; }
        public PrietaisuKonteineris Saldytuvai { get; set; }
        public PrietaisuKonteineris MikrobanguKrosneles { get; set; }
        public PrietaisuKonteineris ElektriniaiViduliai { get; set; }

        /// <summary>
        /// naujas issisakojimas
        /// </summary>
        /// <param name="pavadinimas">parduouves pavadinimas</param>
        /// <param name="adresas">parduotuves adresas</param>
        /// <param name="telefonas">parduotuves telefono nr</param>
        public Branch (string pavadinimas, string adresas, string telefonas)
        {
            Pavadinimas = pavadinimas;
            Adresas = adresas;
            Telefonas = telefonas;
            Saldytuvai = new PrietaisuKonteineris();
            MikrobanguKrosneles = new PrietaisuKonteineris();
            ElektriniaiViduliai = new PrietaisuKonteineris();
        }

        /// <summary>
        /// prideda saldytuva i prietaisu konteineri
        /// </summary>
        /// <param name="saldytuvas">saldytuvo info</param>
        public void PridetiSaldytuva (Saldytuvas saldytuvas)
        {
            Saldytuvai.PridetiPrietaisa(saldytuvas);
        }

        /// <summary>
        /// prideda mikrobangu krosnele i prietaisu konteineri
        /// </summary>
        /// <param name="krosnele">mikrobangu k. info</param>
        public void PridetiMikrobanguKr (MikrobanguKrosnele krosnele)
        {
            MikrobanguKrosneles.PridetiPrietaisa(krosnele);
        }

        /// <summary>
        /// prideda elektrini virduli i prietaisu konteineri
        /// </summary>
        /// <param name="virdulys">elektrinio virdulio info</param>
        public void PridetiElektriniVir (ElektrinisVidrulys virdulys)
        {
            ElektriniaiViduliai.PridetiPrietaisa(virdulys);
        }
    }
}
