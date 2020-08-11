using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cluster
{
    class Flows
    {
        public string ID { get; set; }

        public double FlowTons { get; set; }



        public Flows()
        {

        }
        public Flows(string load,  double flowTons)
        {
            ID = load;
            FlowTons = flowTons;
         
        }
     
        public override string ToString()
        {
            return string.Format(ID + " " + FlowTons.ToString());
        }

    }
}
