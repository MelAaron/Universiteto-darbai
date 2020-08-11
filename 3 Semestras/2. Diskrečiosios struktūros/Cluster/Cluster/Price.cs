using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cluster
{
    class Price
    {
          
        public string Type { get; set; }
        public double Cost { get; set; }

        public Price()
        {

        }
        public Price(string type, double cost)
        {
            Type = type;
            Cost = cost;
        }
        public override string ToString()
        {
            return string.Format(Type + " " + Cost.ToString());
        }


    }
}

