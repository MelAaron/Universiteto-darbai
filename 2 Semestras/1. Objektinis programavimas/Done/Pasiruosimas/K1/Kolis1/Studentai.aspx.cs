using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Kolis1
{
    public partial class Studentai : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            File.Delete(Server.MapPath("Ats.txt"));

            string file1 = "App_Data/Info.txt";
            string file2 = "App_Data/Info2.txt";
            string atsf = "Ats.txt";

            Fakultetas Fakas1 = new Fakultetas(15);
            Fakultetas Fakas2 = new Fakultetas(15);

            DuomSkaitymas(Fakas1, file1);
            DuomSkaitymas(Fakas2, file2);

            Spausdinimas(Fakas1, atsf);
            Spausdinimas(Fakas2, atsf);

            var Geriausi1 = Geriausi(Fakas1);
            var Geriausi2 = Geriausi(Fakas2);

            Lyginimas(Geriausi1, Geriausi2, atsf);
            
            Spausdinimas(Geriausi1, atsf);
            Spausdinimas(Geriausi2, atsf);
            
            Label1.Text = "lmao";
        }

        private void DuomSkaitymas(Fakultetas fakas, string file)
        {
            using (StreamReader sr = new StreamReader(Server.MapPath(file)))
            {
                string line;
                line = sr.ReadLine();
                string[] values = line.Split(';');
                 fakas.FakultetoPav = values[0];
                 fakas.Kreditai = int.Parse(values[1]);
                 fakas.Moduliai = int.Parse(values[2]);
                while((line = sr.ReadLine()) != null )
                {
                    string[] valuess = line.Split(';');
                    string pavarde = valuess[0];
                    string vardas = valuess[1];
                    string grupe = valuess[2];
                    int[] kreditai = new int[15];
                    int j = 0;
                    for (int i = 3; i < valuess.Count(); i++)
                    {
                        kreditai[j] = int.Parse(valuess[i]);
                        j++;
                    }
                    Studentas studentas = new Studentas(pavarde, vardas, grupe, kreditai);
                    fakas.PridetiStudenta(studentas);
                    
                }
            }
        }

        private Fakultetas Geriausi (Fakultetas fakas)
        {
            Fakultetas geri = new Fakultetas(15);
            geri.FakultetoPav = fakas.FakultetoPav;
            geri.Kreditai = fakas.Kreditai;
            geri.Moduliai = fakas.Moduliai;
            for (int i = 0; i < fakas.Count; i++)
            {
                fakas.GautiStudenta(i).KredituSuma(0);
                if(fakas.GautiStudenta(i).Suma > fakas.Kreditai)
                {
                    geri.PridetiStudenta(fakas.GautiStudenta(i));
                }
            }
            return geri;
        }

        private void Lyginimas (Fakultetas f1, Fakultetas f2, string file)
        {
            if (f1 > f2)
                Daugiau(file, f1);
            else
                Daugiau(file, f2);
        }

        private void Daugiau(string file, Fakultetas f)
        {
            using (StreamWriter sw = new StreamWriter(Server.MapPath(file), true))
            {
                sw.WriteLine("Daugiau geru studentu turi " + f.FakultetoPav);
                sw.WriteLine();
            }
        }

        private void Spausdinimas (Fakultetas fakas, string file)
        {
            using (StreamWriter sw = new StreamWriter(Server.MapPath(file), true))
            {
                sw.WriteLine(fakas.FakultetoPav + " " + fakas.Kreditai + " " + fakas.Moduliai);
                for (int i = 0; i < fakas.Count; i++)
                {
                    if (fakas.GautiStudenta(i) == null)
                        continue;
                    sw.WriteLine(fakas.GautiStudenta(i).ToString());
                    string line = new string('-', fakas.GautiStudenta(i).ToString().Length);
                    sw.WriteLine(line);
                }
                sw.WriteLine();
            }
        }

        private void Skait (Fakultetas f, string file)
        {
            using (StreamReader sw = new StreamReader(file))
            {
                string line;
                line = sw.ReadLine();
                string[] values = line.Split(';');
                f.FakultetoPav = values[0];
                f.Kreditai = int.Parse(values[1]);
                f.Moduliai = int.Parse(values[2]);
                while((line = sw.ReadLine()) != null)
                {
                    string[] svalues = line.Split(';');
                    string pavarde = svalues[0];
                    string vardas = svalues[1];
                    string grupe = svalues[2];
                    int j = 0;
                    int[] kreditai = new int[15];
                    for (int i = 3; i < svalues.Length; i++)
                    {
                        kreditai[j++] = int.Parse(svalues[i]);
                    }
                    Studentas studentas = new Studentas(pavarde, vardas, grupe, kreditai);
                    f.PridetiStudenta(studentas);
                }
            }
        }

        private void S(Fakultetas f, string file)
        {
            using (StreamReader sr = new StreamReader(file))
            {
                string line;
                line = sr.ReadLine();
                string[] val = line.Split(';');
                f.FakultetoPav = val[0];
                f.Kreditai = int.Parse(val[1]);
                f.Moduliai = int.Parse(val[2]);
                while((line = sr.ReadLine()) != null)
                {
                    string[] values = line.Split(';');
                    string pav = values[0];
                    string var = values[1];
                    string gru = values[2];
                    int j = 0;
                    int[] kre = new int[15];
                    for (int i = 3; i < values.Length; i++)
                        kre[j++] = int.Parse(values[i]);
                    Studentas stud = new Studentas(pav, var, gru, kre);
                    f.PridetiStudenta(stud);
                }
            }
        }
    }
}