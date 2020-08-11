using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EgzoTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Player p1 = new Player("10", "Sarauskas", "Mindaugas", 100);
            Player p2 = new Player("5", "Drapas", "Kolbis", 90);
            Player p3 = new Player("3", "Juokniskauszius", "Arnoskas", 115);
            ProtocolLine pl1 = new ProtocolLine("10", 3, 5, 10);
            ProtocolLine pl2 = new ProtocolLine("5", 2, 0, 2);
            ProtocolLine pl3 = new ProtocolLine("3", 1, 6, 20);
            List<Player> players = new List<Player>();
            players.Add(p1);
            players.Add(p2);
            players.Add(p3);
            List<ProtocolLine> protocols = new List<ProtocolLine>();
            protocols.Add(pl1);
            protocols.Add(pl2);
            protocols.Add(pl3);

            int player10mins = protocols.Where(x => x.number == "10").Sum(x => x.duration); //lambda
            int a = (from ar in protocols
                     where ar.number == "10"
                     select ar.duration).Sum();//linq

            var b = protocols.Where(x => x.quarter == 1 && x.duration >= 5).OrderByDescending(x => x.duration).ToList(); //lamda
            IEnumerable<string> d = from p in players
                                    let sumA = (from pl in protocols
                                                where p.number == pl.number &&
                                                pl.quarter == 1
                                                select pl.duration).Sum()
                                    where sumA >= 5
                                    orderby p.number descending, p.surname
                                    select p.number + " " + p.surname + " " + p.name + " " + sumA;//linq


            int duration10 = (from pl in protocols
                              where pl.number == "10"
                              select pl.duration).Sum();

            IEnumerable<string> aba = from p in players
                                    let suma = (from pl in protocols
                                             where p.number == pl.number
                                             select pl.duration).Sum()
                                    where suma >= 5
                                    orderby p.number descending, p.surname
                                    select p.number + " " + p.name + " " + p.surname + " " + suma;



            List<Player> abc = (from p in players
                                where p.inches >= 120
                                select p).ToList();
            List<Player> abc2 = players.Where(x => x.inches >= 120).ToList();

            //zaidejai kurie 1 ir 3 keliniuose zaide ir ju ugiai buvo didesni nei 75, ju vardus ir ugius, pagal ugius mazejanciai
            IEnumerable<string> Justino = from p in players
                                          let amount = (from pl in protocols
                                                     where p.number == pl.number &&
                                                     p.inches > 75
                                                     select pl.quarter)
                                          where amount.Contains(3) && amount.Contains(1)
                                          orderby p.inches descending
                                          select p.name + " " + p.inches;
            //zaidejai kurie per 1 ir 3  kelinius sudejus surinko nemaziau nei 10 min, ir isrikiuoti pagal laika ir numeri
            IEnumerable<string> Justino2 = from p in players
                                           let quarters = (from pl in protocols
                                                         where p.number == pl.number &&
                                                         (pl.quarter == 1 || pl.quarter == 3)
                                                         select pl.duration).Sum()
                                           where quarters >= 10
                                           orderby quarters, p.number
                                           select quarters + " " + p.number;
        }
    }
    class Player
    {
        public string number { get; set; }
        public string surname { get; set; }
        public string name { get; set; }
        public int inches { get; set; }
        public Player(string a, string b, string c, int d)
        {
            number = a;
            surname = b;
            name = c;
            inches = d;
        }
    }
    class ProtocolLine
    {
        public string number { get; set; }
        public int quarter { get; set; }
        public int start { get; set; }
        // time to start playing
        public int duration { get; set; }
        // time of playing
        public ProtocolLine(string a, int b, int c, int d)
        {
            number = a;
            quarter = b;
            start = c;
            duration = d;
        }
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
                        Player temp = dabartinis.data;
                        dabartinis.data = dabartinis.kitas.data;
                        dabartinis.kitas.data = temp;
                    }
                }
            }
        }
        public void RusiuotiIsrinkimu()
        {
            for (Mazgas d1 = pirmas; d1 != null; d1 = d1.kitas)
            {
                Mazgas maxv = d1;
                for (Mazgas d2 = d1; d2 != null; d2 = d2.kitas)
                    if (d2.data.CompareTo(maxv.data) < 0)
                        maxv = d2;
                Player St = d1.data;
                d1.data = maxv.data;
                maxv.data = St;
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
