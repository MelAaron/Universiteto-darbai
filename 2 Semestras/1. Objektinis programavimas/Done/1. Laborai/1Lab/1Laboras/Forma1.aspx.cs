using System;
using System.IO;
using System.Web.UI.WebControls;

namespace _1Laboras
{
    public partial class Forma1 : System.Web.UI.Page
    {
        const int max = 7;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            File.Delete(Server.MapPath("Ats3.txt"));
            Konteineris Kauliukai = Skaityti();
            Galimybes(Kauliukai, "");
            Tikrinimas();
        }

        /// <summary>
        /// Nuskaito duomenis is tekstinio failo
        /// </summary>
        /// <returns>sukurta duomenu konteineri</returns>
        Konteineris Skaityti()
        {
            Konteineris Kauliukai = new Konteineris();
            string line = File.ReadAllText(Server.MapPath("App_Data/Kur3.txt"));
            string[] values = line.Split(' ');
            if(values.Length != max)
            {
                PrintTable("Netinkamas kauliukų skaičius");
                PrintToFile("Netinkamas kauliukų skaičius");
                return null;
            }
            for (int i = 0; i < max; i++)
                Kauliukai.PridetiKauliuka(values[i]);
            return Kauliukai;
        }

        /// <summary>
        /// Skaiciuoja visas imanomas kauliuku sustatymo galimybes
        /// </summary>
        /// <param name="kauliukai">kauliuku rinkinys</param>
        /// <param name="rez">rezultato eilute</param>
        private void Galimybes (Konteineris kauliukai, string rez)
        {
            if (kauliukai == null)
                return;
            if (rez == "")
            {
                for (int i = 0; i < kauliukai.Count; i++)
                {
                    Konteineris naujiKauliukai = new Konteineris(kauliukai, i);
                    rez = " " + kauliukai.GautiKauliuka(i);
                    Galimybes(naujiKauliukai, rez);

                    rez = " " + kauliukai.ApverstiKauliuka(i);
                    Galimybes(naujiKauliukai, rez);
                }
            }
            else if(kauliukai.Count > 0)
            {
                for (int i = 0; i < kauliukai.Count; i++)
                {
                    if(kauliukai.GautiKauliuka(i)[0] == rez[rez.Length - 1])
                    {
                        Konteineris naujiKauliukai = new Konteineris(kauliukai, i);
                        rez += " " + kauliukai.GautiKauliuka(i);
                        Galimybes(naujiKauliukai, rez);
                        rez = rez.Remove(rez.Length - 3, 3);
                    }
                    if(kauliukai.ApverstiKauliuka(i)[0] == rez[rez.Length - 1])
                    {
                        Konteineris naujiKauliukai = new Konteineris(kauliukai, i);
                        rez += " " + kauliukai.ApverstiKauliuka(i);
                        Galimybes(naujiKauliukai, rez);
                        rez = rez.Remove(rez.Length - 3, 3);
                    }
                }
            }
            else
            {
                PrintTable(rez);
                PrintToFile(rez);
            }
        }
        
        /// <summary>
        /// Atspausdina gautus atsakymus lentele
        /// </summary>
        /// <param name="rez">vienas atsakymas</param>
        private void PrintTable (string rez)
        {
            TableCell cell = new TableCell();
            cell.Text = rez;

            TableRow row = new TableRow();
            row.Cells.Add(cell);

            Table1.Rows.Add(row);
        }

        /// <summary>
        /// Spausdina gautus atsakymus i txt faila
        /// </summary>
        /// <param name="rez">vienas atsakymas</param>
        private void PrintToFile (string rez)
        {
            using (StreamWriter writer = new StreamWriter(Server.MapPath(@"Ats3.txt"), true))
            {
                writer.WriteLine("{0}", rez);
            }
        }

        /// <summary>
        /// Skaiciavimu gale patikrina kiek gauta atsakymu
        /// Jei atsakymu negauta, pranesa
        /// </summary>
        private void Tikrinimas()
        {
            if (Table1.Rows.Count == 0)
            {
                PrintTable("Nėra galimų grandinių.");
                PrintToFile("Nėra galimų grandinių.");
            }
        }
    }
}