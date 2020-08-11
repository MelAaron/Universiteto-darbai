using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cluster
{
    class Distance
    {
        public string Key { get; set; }
        public string Destination { get; set; }
        public double Time { get; set; }
        public double WayLenght { get; set; }

        public Distance()
        {

        }
        public Distance(string key, string destination, double wayLenght, double time)
        {
            Key = key;

            Destination = destination;
            Time = time;
            WayLenght = wayLenght;
        }
        public override string ToString()
        {
            return string.Format(Key +  " " + Destination + " " + Time.ToString() + " " + WayLenght.ToString());
        }


    }
}
