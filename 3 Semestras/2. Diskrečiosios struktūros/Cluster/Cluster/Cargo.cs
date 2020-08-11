using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cluster
{
    class Cargo
    {
        public string Load { get; set; }
        public string Unload { get; set; }
        public string Type { get; set; }
        public double FlowTons { get; set; }
        public double FlowTonKms { get; set; }
        public int warehouses { get; set; }


        public Cargo()
        {

        }
        public Cargo(string load, string unload, string type, double flowTons, double flowTonKms)
        {
            Load = load;
            Unload = unload;
            Type = type;
            FlowTons = flowTons;
            FlowTonKms = flowTonKms;
        }
                public Cargo(string unload, double flowTons)
        {
           // Load = load;
            Unload = unload;
           // Type = type;
            FlowTons = flowTons;
           // FlowTonKms = flowTonKms;
        }
        public override string ToString()
        {
            return string.Format(Unload + " " + FlowTons.ToString() + " " + FlowTonKms.ToString());
        }

    }
}
