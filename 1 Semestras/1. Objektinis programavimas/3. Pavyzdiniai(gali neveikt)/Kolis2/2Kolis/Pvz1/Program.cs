using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;


namespace Pvz1
{
    class Program
    {
        static void Main(string[] args)
        {
            const string fv = "..\\..\\Duom.txt";
            const string fr = "..\\..\\Rez.txt";
            char[] skyrikliaich = { ' ', '.', ',', '!', '?', ':', ';', '(', ')', '\t' };
            string skyrikliai = "[\\s,.;:!?()\\-]+";
            Read(fv, fr, skyrikliai, skyrikliaich);
            //AtliktiUzduoti(fv, fr, skyrikliai);
            //Sk(fv);
            string lalala = "kaka sysi ay lmao boi whatthefuck";
            Zodisss(lalala, "sysi", "boi");

            Program p = new Program();
            int a;
            Console.WriteLine(a = p.RastiKiek(fv, skyrikliai, "kasjka"));
        }

        static void Sk(string fv)
        {
            using (StreamReader sr = new StreamReader(fv, Encoding.GetEncoding(1257)))
            {
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    Console.WriteLine(line);
                }
            }
        }

        static void Read(string fd, string fr, string skyr, char[] skyrikliai)
        {
            using (var frr = File.CreateText(fr))
            {
                using (StreamReader sr = new StreamReader(fd, Encoding.GetEncoding(1257)))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        //Cia daryt veiksmus
                        
                        frr.WriteLine(line);
                    }
                }
            }
            //arba
            string[] eilutes = File.ReadAllLines(fd, Encoding.GetEncoding(1257));
            for (int i = 0; i < eilutes.Length; i++)
            {
                string[] zodziai = eilutes[i].Split(skyrikliai, StringSplitOptions.RemoveEmptyEntries);
                //using System.Text.RegularExpressions;
                string[] parts = Regex.Split(eilutes[i], skyr);
            }
        }

        static void AtliktiUzduoti(string fd, string fr, string skyr)
        {
            var nr = 0;
            RastiEilute(fd, out nr);
            Console.WriteLine("Ilgiausios eil nr: " + nr);
            Console.WriteLine();
            string[] eilutes = File.ReadAllLines(fd, Encoding.GetEncoding(1257));

            using (var ct = File.CreateText(fr))
            {
                for (int e = 0; e < eilutes.Length; e++)
                {
                    var zod = "";
                    var pr = -1;
                    var uniquebalses = EilutesSkirtBalsiuSkaicius(eilutes[e]);
                    RastiZodiEil(eilutes[e], skyr, out zod, out pr);
                    //ct.WriteLine(zod + " " + pr);

                    if (pr != -1)
                    {
                        PerkeltiZodiEil(ref eilutes[e], skyr, zod, pr);
                        ct.WriteLine(eilutes[e]);
                    }
                    //viskas veikia tik kazkodel crashina 6 eilutej perkelime
                    
                }
            }

                //for (int e = 0; e < eilutes.Length; e++)
                //{
                //    var zod = "";
                //    var pr = -1;
                //    var uniquebalses = EilutesSkirtBalsiuSkaicius(eilutes[e]);
                //    RastiZodiEil(eilutes[e], skyr, out zod, out pr);
                //    Console.WriteLine(zod + " " + pr);
                //    if (pr != -1)
                //        PerkeltiZodiEil(ref eilutes[e], skyr, zod, pr);
                //    Console.WriteLine(eilutes[e]);
                //    //viskas veikia tik kazkodel crashina 6 eilutej perkelime

                //    Console.WriteLine();
                //}
        }

        static void PerkeltiZodiEil(ref string eil, string skyr, string zod, int pr)
        {
            var upEil = eil.Remove(pr, zod.Length + 1);
            eil = zod + " " + upEil;
        }

        static void RastiZodiEil(string eil, string skyr, out string zod, out int pr)
        {
            zod = "";
            pr = -1;
            char[] balse = { 'a', 'e', 'i', 'y', 'o', 'u', 'A', 'E', 'I', 'Y', 'O', 'U' };
            string balses = "aeiyouAEIYOU";

            var maxIlgis = 0;
            //string[] zodziai = eil.Split(skyrikliai, StringSplitOptions.RemoveEmptyEntries);
            string[] zodziai = Regex.Split(eil, skyr);
            for (int i = 0; i < zodziai.Length; i++)
            {
                var k = 0;
                var zodis = zodziai[i];
                for (int j = 0; j < zodis.Length; j++)
                {
                    var ch = zodis[j];
                    if ((balses.Contains(ch)) || (balses.Contains(Char.ToUpper(ch))))
                    {
                        k++;
                    }
                    if ((k >= 3) && (zodziai[i].Length > maxIlgis))
                    {
                        maxIlgis = zodis.Length;
                        pr = eil.IndexOf(zodis);
                        zod = zodis;
                    }
                }

            }
        }

        static void RastiEilute(string fv, out int nr)
        {
            nr = 0;
            string[] eilutes = File.ReadAllLines(fv, Encoding.GetEncoding(1257));
            var ilgiausiaE = eilutes[0];
            var maxIlgis = 0;
            for (int i = 0; i < eilutes.Length; i++)
            {
                var eilute = eilutes[i];
                if (eilute.Length > maxIlgis)
                {
                    nr = i + 1;
                    ilgiausiaE = eilute;
                    maxIlgis = eilute.Length;
                }
            }

            //char[] skyrikliai = { ' ', '.', ',', '!', '?', ':', ';', '(', ')', '\t' };
            //string[] eilutes = File.ReadAllLines(fv, Encoding.GetEncoding(1257));
            //for (int i = 0; i < eilutes.Length; i++)
            //{
            //    var eilute = eilutes[i];
            //    string[] zodziai = eilute.Split(skyrikliai, StringSplitOptions.RemoveEmptyEntries);
            //    for (int j = 0; j < zodziai.Length; j++)
            //    {
            //        var zodis = zodziai[i];

            //    }
            //}
        }

        static int EilutesSkirtBalsiuSkaicius(string eil)
        {
            int balkiek = 0;
            int j = 0;
            char[] skyrikliai = { ' ', '.', ',', '!', '?', ':', ';', '(', ')', '\t' };
            char[] balses = { 'a', 'e', 'i', 'y', 'o', 'u', 'A', 'E', 'I', 'Y', 'O', 'U' };
            var balsesv = new char[12];
            for (int i = 0; i < eil.Length; i++)
            {
                if ((balses.Contains(eil[i])) && (!balsesv.Contains(eil[i])))
                {
                    balkiek++;
                    balsesv[j] = eil[i];
                    j++;
                }
            }
            return balkiek;
        }

        static void Zodisss (string line, string zodis, string prideti)
        {
            var nr = line.IndexOf(zodis);
            StringBuilder k = new StringBuilder();
            string b = "";
            //b = line.Substring(0, nr) + " " + prideti + line.Substring(line.Length - );
        }

        int RastiKiek (string failas, string skyrikliai, string zodis)
        {
            int k = 0;
            using (StreamReader sr = new StreamReader(@failas, Encoding.GetEncoding(1257)))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] zodziai = Regex.Split(line, skyrikliai);
                    for (int i = 0; i < zodziai.Length; i++)
                    {
                        if (zodziai[i] == zodis)
                            k++;
                    }
                }
            }
            return k;
        }
    }
}
