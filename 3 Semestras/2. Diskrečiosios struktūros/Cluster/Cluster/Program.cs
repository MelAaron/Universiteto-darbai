using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Microsoft.Office.Interop.Excel;
using System.Data;


namespace Cluster
{
    class Program
    {
        static void Main(string[] args)
        {
            Program p = new Program();
            double ConBuildingCost = 0;
            double NotConBuildingCost = 0;
            double ConstManagementCost = 0;
            double NotConstManagementCost = 0;
            double TruckDeliveryCost = 0;
            double TrainDeliveryCost = 0;
            double TruckCO2 = 0;
            double TrainCO2 = 0;

            string[] distinctRegions = p.DistinctNameslist(@"C:\Users\Lenovo\Desktop\cluster 2.0\Cluster\Cluster\bin\Debug\All flows.xlsx", 0); //All flows
            Console.WriteLine("1");
            string[] distinctRegions2 = p.DistinctNameslist(@"C:\Users\Lenovo\Desktop\cluster 2.0\Cluster\Cluster\bin\Debug\D.xlsx", 1);       //distances
            Console.WriteLine("2");
            string[] S = { "BE21", "AT31", "DEA1", "DE21", "FR30", "FR10", "ES51", "PL22", "PL12", "BG41", "RO42" };
            List<Price> Prices = new List<Price>();
            Dictionary<string, List<Distance>> distanc = p.ReadAnExcelFile(distinctRegions2);
            Console.WriteLine("3");
            Dictionary<string, List<Cargo>> cargo = p.ReadAnExcelFileAllFlows(distinctRegions);
            Console.WriteLine("4");
            p.ReadAnExcelFileDataForPrices(ref  ConBuildingCost, ref  NotConBuildingCost, ref  ConstManagementCost,
            ref  NotConstManagementCost, ref  TruckDeliveryCost, ref  TrainDeliveryCost, ref  TruckCO2, ref  TrainCO2);
            Console.WriteLine("5");


            int[] WarehousesBuilt = new int[300];
            int[] NoWarehouses = new int[300];

            Dictionary<string, int> warehouses = p.WareHouses(distanc, S);
            List<Flows> warehousesFlow = p.WareHousesFlow(distanc, S);
            Console.WriteLine("6");
            p.SSK( ConBuildingCost,  NotConBuildingCost, warehouses, warehousesFlow);
            p.SVK(ConstManagementCost, NotConstManagementCost, warehouses, warehousesFlow);
            Console.WriteLine("7");
            p.Paklausa(cargo, ref warehousesFlow);
            Console.ReadKey();



            // Go to http://aka.ms/dotnet-get-started-console to continue learning how to build a console app! 

        }
        #region skaitymas
        private void ReadAnExcelFileDataForPrices(ref double ConBuildingCost, ref double NotConBuildingCost, ref double ConstManagementCost,
            ref double NotConstManagementCost, ref double TruckDeliveryCost, ref double TrainDeliveryCost, ref double TruckCO2, ref double TrainCO2)
        {
            List<Price> Data = new List<Price>();
            using (var stream = File.Open(@"C:\Users\Lenovo\Desktop\cluster 2.0\Cluster\Cluster\bin\Debug\Data for calculations.xlsx", FileMode.Open, FileAccess.Read))
            {
                using (var reader = ExcelDataReader.ExcelReaderFactory.CreateReader(stream))
                {

                  
                    if (reader.Read())
                    {
                        double[] d = new double[8];
                        int i = 0;
                        reader.GetString(2);

                        while (reader.Read()&&i<8)
                        {

                            double dd = reader.GetDouble(2);
                            d[i] = dd;
                            i++;
                        }
                        ConBuildingCost = d[0];
                        NotConBuildingCost = d[1];
                        ConstManagementCost = d[2];
                        NotConstManagementCost = d[3];
                        TruckDeliveryCost = d[4];
                        TrainDeliveryCost = d[5];
                        TruckCO2 = d[6];
                        TrainCO2 = d[7];

                    }

                }
            }
        }
        public Dictionary<string, List<Distance>> ReadAnExcelFile(string[] origins)
        {
            List<Distance> Data = new List<Distance>();
            Dictionary<string, List<Distance>> distances = new Dictionary<string, List<Distance>>();
            using (var stream = File.Open(@"C:\Users\Lenovo\Desktop\cluster 2.0\Cluster\Cluster\bin\Debug\D.xlsx", FileMode.Open, FileAccess.Read))
            {
                using (var reader = ExcelDataReader.ExcelReaderFactory.CreateReader(stream))
                {
                    // Choose one of either 1 or 2:

                    // 1. Use the reader methods
                    int i = 0;
                    if (reader.Read())
                    {
                        reader.GetString(0);
                        reader.GetString(1);
                        reader.GetString(2);
                        reader.GetString(3);
                        reader.GetString(4);
                        //   reader.GetString(0);
                        string origin = null;
                        while (reader.Read())
                        {
                            origin = reader.GetString(1);
                            // Distance distance = new Distance(reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetDouble(3), reader.GetDouble(4));
                            if (origin != null)
                            {
                                if (!distances.ContainsKey(origin)&&origins[i]!=origin)
                                {
                                    distances.Add(origins[i], Data);
                                    Data = new List<Distance>();
                                    i++;
                                }
                            }
                            Distance distance = new Distance(reader.GetString(0), reader.GetString(2), reader.GetDouble(3), reader.GetDouble(4));

                            if (origin != distance.Destination)
                            {
                                Data.Add(distance);
                            }

  
                        }
                        distances.Add(origin, Data);

                    }
                }
                //foreach (Distance d in Data)
                //{
                //    Console.WriteLine(d.ToString());
                //}
                return distances;
            }
        }
        public string[] DistinctNameslist(string path, int number)
        {
            string[] origins = new string[300];
            using (var stream = File.Open(path, FileMode.Open, FileAccess.Read))
            {
                //Console.WriteLine(path);
                using (var reader = ExcelDataReader.ExcelReaderFactory.CreateReader(stream))
                {
                    // Choose one of either 1 or 2:

                    // 1. Use the reader methods
                    int i = 0;
                    if (reader.Read())
                    {
                        reader.GetString(number);
                        //   reader.GetString(0);
                        while (reader.Read())
                        {
                            string origin = reader.GetString(number);
                            if (!origins.Contains(origin))
                            {
                                origins[i] = origin;
                                i++;
                            }
                        }
                    }
                    //reader.Reset();
                    for (int j = 0; j < 300; j++)
                    {
                      //  Console.WriteLine(j);
                        if (origins[j] != null)
                        {
                       //   Console.WriteLine(j + " " + origins[j]);
                        }
                    }
                }
                return origins;
            }
        }
        public Dictionary<string, List<Cargo>> ReadAnExcelFileAllFlows(string[] origins)
        {
            Dictionary<string, List<Cargo>> dic = new Dictionary<string, List<Cargo>>();
            List<Cargo> Data = new List<Cargo>();
            using (var stream = File.Open(@"C:\Users\Lenovo\Desktop\cluster 2.0\Cluster\Cluster\bin\Debug\All flows.xlsx", FileMode.Open, FileAccess.Read))
            {
                using (var reader = ExcelDataReader.ExcelReaderFactory.CreateReader(stream))
                {
                    // Choose one of either 1 or 2:

                    // 1. Use the reader methods
                    if (reader.Read())
                    {
                        reader.GetString(0);
                        reader.GetString(1);
                        reader.GetString(2);
                        reader.GetString(3);
                        reader.GetString(4);
                        //   reader.GetString(0);
                    }
                    int i = 0;
                    string origin = null;
                    while (reader.Read())
                    {
                        origin = reader.GetString(0);
                        if (origin != null)
                        {
                            if (!dic.ContainsKey(origin) && origins[i] != origin)
                            {
                                dic.Add(origins[i], Data);
                                Data = new List<Cargo>();
                                i++;
                            }
                        }
                        Cargo cargo = new Cargo(reader.GetString(1), reader.GetDouble(3));
                        bool found = false;
                        foreach (Cargo c in Data)
                        {
                            if (c.Unload == cargo.Unload)
                            {
                                c.FlowTons = cargo.FlowTons + c.FlowTons;
                                found = true;
                            }
                        }
                        if (found == false && origins[i] != cargo.Unload)
                        {
                            Data.Add(cargo);
                        }
                    }
                }
            }

            return dic;
        }
        #endregion

        public Dictionary<string, int> WareHouses(Dictionary<string, List<Distance>> dis, string[]CentersWithWareHouse)
        { 
            Dictionary<string, int> dictionary = new Dictionary<string, int>();
            foreach (string name in dis.Keys)
            {
                if (dictionary.ContainsKey(name) != true && CentersWithWareHouse.Contains(name) != true) //jei neturi rakto su from ir jei nera tarp tasku su sandeliais, pridedam pavadinima ir 0
                {
                    dictionary.Add(name, 0);
                }
                else if (dictionary.ContainsKey(name) != true && CentersWithWareHouse.Contains(name) == true) //jei neturi rakto su from ir jei yra tarp tasku su sandeliais, pridedam pavadinima ir 0
                {
                    dictionary.Add(name, 1);
                }
            }
            foreach (string name in dictionary.Keys)
            {
                int i;
                dictionary.TryGetValue(name, out i);

            }


            return dictionary;
        }
        public List<Flows> WareHousesFlow(Dictionary<string, List<Distance>> dis, string[] CentersWithWareHouse)
        {
            List< Flows> flows = new List<Flows>();

            foreach (string name in dis.Keys)
            {
                Flows flow = new Flows();

                flow.ID = name;
                flow.FlowTons = 0;
                flows.Add(flow);
            }

            return flows;
        }

   

        #region tikslo funkcija
        public void Paklausa(Dictionary<string, List<Cargo>> cargo, ref List<Flows> wareHousesFlow)
        {
            foreach (string center in cargo.Keys)
            {
                List<Cargo> cargoooo;
                if (cargo.TryGetValue(center, out cargoooo) == true)
                {
                    foreach (Cargo c in cargoooo)
                    {
                        foreach (Flows item in wareHousesFlow)
                        {
                            if (item.ID == c.Unload || item.ID == c.Unload)
                            {
                                item.FlowTons += c.FlowTons;
                            }
                        }
                    }
                }
            }
            int i = 0;
            foreach (Flows item in wareHousesFlow)
            {
                i++;
                Console.WriteLine(i + " " + item.ToString());
            }
        }

        public double SSK(double ConBuildingCost, double NotConBuildingCost, Dictionary<string, int> warehouses, List<Flows> warehousesFlow)
        {
            double cost = 0;
            foreach (Flows item in warehousesFlow)
            {
                foreach (var warehouse in warehouses)
                {
                    if (warehouse.Value == 1 && warehouse.Key == item.ID)//jei turi sandeli ir
                    {
                        cost += ConBuildingCost + NotConBuildingCost * item.FlowTons;
                    }
                }
            }


            return cost;
        }
        public double SVK(double ConstManagementCost, double NotConstManagementCost, Dictionary<string, int> warehouses, List<Flows> warehousesFlow)
        {
            double cost = 0;
            double p = 1;
            foreach (Flows item in warehousesFlow)
            {
                foreach (var warehouse in warehouses)
                {
                    if (warehouse.Value == 1 && warehouse.Key == item.ID)
                    {
                        cost += ConstManagementCost * 12 + NotConstManagementCost * item.FlowTons * 365;
                    }
                }

            }
            return cost;
        }

        public double TK(string origin, string destination, double weight, Dictionary<string, List<Distance>> distance, Dictionary<string, int> WareHouses, double truckDelivery, double trainDelivery, double truckCo2, double trainCo2)
        {
            double cost = 0;
            double alternativeCost = 0;
            int warehouseOrigin = WareHouses[origin];
            int warehouseDestination = WareHouses[destination];

            if (warehouseOrigin == 1 && warehouseDestination == 1)
            {
                double metres = 0;
                foreach (Distance d in distance[origin])
                {
                    if (d.Destination == destination)
                    { metres = d.WayLenght; }
                }
                cost = metres * weight * trainDelivery + trainCo2 * metres;
            }
            else if (warehouseOrigin == 0 && warehouseDestination == 0)
            {
                double metres = 0;
                foreach (Distance d in distance[origin])
                {
                    if (d.Destination == destination)
                    { metres = d.WayLenght; }

                }
                cost = metres * weight * truckDelivery + truckCo2 * metres;
            }
            if (warehouseOrigin == 0 && warehouseOrigin == 0 && WarehouseNumber(WareHouses) >= 2)
            {
                string ClosestWarehouse1 = ClosestWareHouse(WareHouses, origin, distance);
                string ClosestWarehouse2 = ClosestWareHouse(WareHouses, destination, distance);
                foreach (Distance d in distance[origin])
                {
                    if (d.Destination == ClosestWarehouse1)
                    {
                        alternativeCost = alternativeCost + d.WayLenght * truckDelivery + d.WayLenght * truckCo2;
                    }
                }
                foreach (Distance d in distance[ClosestWarehouse1])
                {
                    if (d.Destination == ClosestWarehouse2)
                    {
                        alternativeCost = alternativeCost + d.WayLenght * trainDelivery + d.WayLenght * trainCo2;
                    }
                }
                foreach (Distance d in distance[ClosestWarehouse2])
                {
                    if (d.Destination == destination)
                    {
                        alternativeCost = alternativeCost + d.WayLenght * truckDelivery + d.WayLenght * truckCo2;
                    }
                }
            }
            return cost;
        }
        //public double DistanceBetweenC(List<string, Distance> d, string origin, string destination)
        //{
        //    double metres = 0;
        //    foreach()

        //}

        public int WarehouseNumber(Dictionary<string, int> WareHouses)
        {
            int nr = 0;
            foreach (int n in WareHouses.Values)
            {
                if (n == 1)
                    nr++;

            }
            return nr;
        }
        public string ClosestWareHouse(Dictionary<string, int> WareHouses, string Center, Dictionary<string, List<Distance>> distance)
        {
            string closestWareHouse = null;
            double shortestDistance = 0;
            foreach (var region in WareHouses.Where(x=> x.Value == 1 ))
            {
                foreach (Distance d in distance[Center])
                {
                    if (d.Destination == region.Key)
                    {
                        if (shortestDistance == 0 || shortestDistance > d.WayLenght)
                        {
                            closestWareHouse = d.Destination;
                            shortestDistance = d.WayLenght;
                        }
                    }
                }
            }
            return closestWareHouse;

        }
        #endregion
    }

}
