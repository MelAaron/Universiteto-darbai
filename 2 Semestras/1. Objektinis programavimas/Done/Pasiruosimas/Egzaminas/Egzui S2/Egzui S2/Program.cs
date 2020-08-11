using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Egzui_S2
{
    class Program
    {
        static void Main(string[] args)
        {
            Sarasas<int> naujas = new Sarasas<int>();
            naujas.PridetIGala(0);
            naujas.PridetIGala(3);
            naujas.PridetIGala(2);
            naujas.PridetIGala(1);
            naujas.Pasalinti(2);
            naujas.RikiavimasBurbuliuku();
        }
    }
}
