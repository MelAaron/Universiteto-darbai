package proj;

import java.io.*;
import java.nio.Buffer;
import java.util.*;

public class Program {

    public static double warehouseCost, variableWarehouseConstructionCost, fixedWarehouseManagementCost, variableWarehouseManagements, truckDeliveryCost, railDeliveryCost, truckEmissionLevel, railwayEmissionLevel;
    public static int maxWarehouseCount = 271; //ne maziau uz 0 ir ne daugiau 271(distances key count)
    public static int iterations = 1000;
    public static void main(String args[]) {
        long t0 = System.nanoTime();
//        List<String> uniquePointAF = uniquePoints("C:\\Users\\PC\\Documents\\1. Stuff\\2. My stuff\\DiskrProj\\Data\\All flows.csv", 0);
//        List<String> uniquePointD = uniquePoints("C:\\Users\\PC\\Documents\\1. Stuff\\2. My stuff\\DiskrProj\\Data\\Distances NUTS2-NUTS2.csv", 1);
        //Skaitymas
        Map<String, List<PointD>> distances = readDistances();
        distances = readAllFlows(distances);
        readCalcData();

//        long t2 = System.nanoTime();
//        Set<String> ar = distances.keySet();
//        long t3 = System.nanoTime();
//        double time2 = (t3-t2)/ 1e9;
//        System.out.println(String.format("Laikas to array %.5f", time2));
        //Skaiciavimai
//        String[] S = { "BE21", "AT31", "DEA1", "DE21", "FR30", "FR10", "ES51", "PL22", "PL12", "BG41", "RO42" };
//        List<String> Sa = new ArrayList<>();
//        for(String a : S) Sa.add(a);
//        Map<String, Integer> warehouses = wareHousePoints(distances, Sa);
//        List<PointD> warehouseFlow = warehouseFlowSetup(distances);
//        warehouseFlow = warehouseFlowFill(distances, warehouseFlow);
//        System.out.println("TK " + String.format("%.2f", TF(distances, Sa, warehouseFlow, warehouses)));

//        System.out.println("SSK " + String.format("TK %.2f", SSK(warehouses, warehouseFlow)));
//        System.out.println("SVK " + String.format("TK %.2f", SVK(warehouses, warehouseFlow)));

//        List<PointD> temp = warehousePoints(distances, Sa, 3); //0 - abu neturi 1 - from turi, 2 - to turi, 3-abu turi

//        System.out.println(String.format("PKK %.2f", PKK(distances, Sa)));
        File file = new File("C:\\Users\\PC\\Documents\\1. Stuff\\2. My stuff\\DiskrProj\\Data\\data.csv");
        if(file.exists() && file.isFile()) file.delete();
        efficiency(distances);
        long t1 = System.nanoTime();
        double time = (t1-t0)/ 1e9;
        System.out.println(String.format("Laikas %.5f", time));
//        System.out.println(distances.get("AT12").toString());
    }

    public static void efficiency(Map<String, List<PointD>> dis){
        double bestCost = 0;
        double currentCost = 0;
        Random rand = new Random();
        double cnt = iterations;
        String[] uniqP = dis.keySet().toArray(new String[dis.size()]);
        while (cnt > 0){
//            String[] warehouses = new String[rand.nextInt(maxWarehouseCount)]; //sukuria random dydzio sandeliu masyva iki maxWarehouseCount
            List<String> Sa = new ArrayList<>();
            int kiek = rand.nextInt(maxWarehouseCount);
            while(kiek == 0) kiek = rand.nextInt(maxWarehouseCount);
            for(int i = 0; i < kiek; i++){
                int temp = rand.nextInt(270);
                while(Sa.contains(uniqP[temp]))
                    temp = rand.nextInt(270);
                Sa.add(uniqP[temp]);
            }
            Map<String, Integer> warehouses = wareHousePoints(dis, Sa);
            List<PointD> warehouseFlow = warehouseFlowSetup(dis);
            warehouseFlow = warehouseFlowFill(dis, warehouseFlow);
            currentCost = TF(dis, Sa, warehouseFlow, warehouses);
            System.out.println(kiek + " " + cnt);

//            Sa.clear();
//            Sa.add("UKI7");
//            Map<String, Double> temp = warehousesFlows(Sa, dis);

            if(bestCost == 0 || currentCost < bestCost){
                bestCost = currentCost;

//                long t2 = System.nanoTime();
                printToCsv(bestCost, Sa);
//                long t3 = System.nanoTime();
//                double time2 = (t3-t2)/ 1e9;
//                System.out.println(String.format("Laikas to array %.5f", time2));
                System.out.println(String.format(kiek + " Kainu improvement %.5f", bestCost));
            }
            cnt--;
        }
    }

    public static void printToCsv(double cost, List<String> Sa){
        try{
            FileWriter fw = new FileWriter("C:\\Users\\PC\\Documents\\1. Stuff\\2. My stuff\\DiskrProj\\Data\\data.csv", true);
            for(String s : Sa){
                fw.append(s);
                fw.append(",");
            }
            fw.append("\n" + cost);
//            fw.write(cost + "");
            fw.append("\n");
            fw.close();
        }catch (FileNotFoundException e) {
            e.printStackTrace();
        } catch (IOException e) {
            e.printStackTrace();
        }
    }

    public static double TF(Map<String, List<PointD>> dis, List<String> pointsWithWarehouses, List<PointD> warehouseFlow, Map<String, Integer> warehouses){
        double PKK = PKK(dis, pointsWithWarehouses);
        double SSK = SSK(warehouses, warehouseFlow);
        double SVK = SVK(warehouses, warehouseFlow);
        return PKK + SSK + SVK;
    }

    public static double SSK(Map<String, Integer> warehouses, List<PointD> flows){
        double cost = 0;
        for(PointD item : flows)
            for(String warehouse : warehouses.keySet())
                if(warehouses.get(warehouse) == 1 && warehouse.equals(item.from)){
                    cost += 0.05 * (warehouseCost + variableWarehouseConstructionCost) * item.flowTons;
//                    return cost;
                }

        return cost;
    }

    public static double SVK(Map<String, Integer> warehouses, List<PointD> flows){
        double cost = 0;
        for(PointD flow : flows)
            for(String warehouse : warehouses.keySet())
                if(warehouses.get(warehouse) == 1 && warehouse.equals(flow.from)){
                    cost += fixedWarehouseManagementCost * 12 + variableWarehouseManagements * flow.flowTons * 365;
//                    return cost;
                }
        return cost;
    }

    public static List<String> uniquePoints(String path, int number){//all flows - 0, distances - 1
        try{
            List<String> ppp = new ArrayList<>();
            BufferedReader r = new BufferedReader(new FileReader(path));
            String line = r.readLine(); //atsikratom header
            while((line = r.readLine()) != null){
                String[] dataDistance = line.split(",");
                if(!ppp.contains(dataDistance[number]))
                    ppp.add(dataDistance[number]);
            }
            return ppp;
        } catch (FileNotFoundException e) {
            e.printStackTrace();
        } catch (IOException e) {
            e.printStackTrace();
        }
        return null;
    }

    public static Map<String, List<PointD>> readDistances(){
        Map<String, List<PointD>> dist = new HashMap<>();
        try{
            List<PointD> temp = new ArrayList<>();
            BufferedReader r = new BufferedReader(new FileReader("C:\\Users\\PC\\Documents\\1. Stuff\\2. My stuff\\DiskrProj\\Data\\Distances NUTS2-NUTS2.csv"));
//            int i = 0;
            String origin = null;
            String line = r.readLine(); //atsikratom header
            while((line = r.readLine()) != null){
                String[] dataDistance = line.split(",");
                origin = dataDistance[1];
                if(!dist.containsKey(origin)/* && origins.get(i) != origin*/){
                    dist.put(origin/*origins.get(i)*/, temp);
                    temp = new ArrayList<>();
//                    i++;
                }
                PointD pointD = new PointD(origin, dataDistance[2], Double.parseDouble(dataDistance[3]));
                if(pointD.distance != 0) temp.add(pointD); //Ifa palikt jei nenori kad butu is saves i save(distance 0)
                dist.put(origin, temp);
            }

        }  catch (FileNotFoundException e) {
            e.printStackTrace();
        } catch (IOException e) {
            e.printStackTrace();
        }
        return dist;
    }

    public static Map<String, List<PointD>> readAllFlows(Map<String, List<PointD>> addTo){
        try{
            BufferedReader r = new BufferedReader(new FileReader("C:\\Users\\PC\\Documents\\1. Stuff\\2. My stuff\\DiskrProj\\Data\\All flows.csv"));
            String line = r.readLine(); //atsikratom header
            while((line = r.readLine()) != null){
                String[] dataDistance = line.split(",");
                if(addTo.containsKey(dataDistance[0])){
                    List<PointD> temp = addTo.get(dataDistance[0]);//-----------------
                    int cnt = 0;
                    for(PointD p : temp) {
                        p.addflowTonsIfEquals(dataDistance[0], dataDistance[1], Double.parseDouble(dataDistance[3]));
                        cnt++;
                        if(cnt == 2)continue;
                    }
                    addTo.put(dataDistance[0], temp);
                }
            }
        }  catch (FileNotFoundException e) {
            e.printStackTrace();
        } catch (IOException e) {
            e.printStackTrace();
        }
        return addTo;
    }

    public static void readCalcData(){
        try{
            BufferedReader r = new BufferedReader(new FileReader("C:\\Users\\PC\\Documents\\1. Stuff\\2. My stuff\\DiskrProj\\Data\\Data for calculations.csv"));
            int i = 0;
            String line = r.readLine(); //atsikratom header
            while((line = r.readLine()) != null){
                String[] dataDistance = line.split(",");
                switch (i){
                    case 0: warehouseCost = Double.parseDouble(dataDistance[2]);
                    break;
                    case 1: variableWarehouseConstructionCost = Double.parseDouble(dataDistance[2]);
                    break;
                    case 2: fixedWarehouseManagementCost = Double.parseDouble(dataDistance[2]);
                    break;
                    case 3: variableWarehouseManagements = Double.parseDouble(dataDistance[2]);
                    break;
                    case 4: truckDeliveryCost = Double.parseDouble(dataDistance[2]);
                    break;
                    case 5: railDeliveryCost = Double.parseDouble(dataDistance[2]);
                    break;
                    case 6: truckEmissionLevel = Double.parseDouble(dataDistance[2]);
                    break;
                    case 7: railwayEmissionLevel = Double.parseDouble(dataDistance[2]);
                    break;
                    default:
                        return;
                }
                i++;
            }
        }  catch (FileNotFoundException e) {
            e.printStackTrace();
        } catch (IOException e) {
            e.printStackTrace();
        }
    }

    public static double PKK(Map<String, List<PointD>> dis, List<String> pointsWithWarehouses){
        double cost = 0;
        List<PointD> list = warehousePoints(dis, pointsWithWarehouses, 3);//visi turi sandelius
        for(PointD point : list) cost += point.flowTons * (point.distance * railDeliveryCost + point.distance * railwayEmissionLevel);
        list = warehousePoints(dis, pointsWithWarehouses, 1);//from turi sandeli
        for(PointD point : list) cost += point.flowTons * getOptimalPathTo(dis, point, pointsWithWarehouses, point.distance * truckDeliveryCost + point.distance * truckEmissionLevel);
        list = warehousePoints(dis, pointsWithWarehouses, 2);//to turi sandeli
        for(PointD point : list) cost += point.flowTons * getOptimalPathFrom(dis, point, pointsWithWarehouses, point.distance * truckDeliveryCost + point.distance * truckEmissionLevel);
        list = warehousePoints(dis, pointsWithWarehouses, 0);//nei vienas neturi sandeli
        for(PointD point : list)  cost += point.flowTons * getOptimalPathBoth(dis, point, pointsWithWarehouses, point.distance * truckDeliveryCost + point.distance * truckEmissionLevel);

        return cost;
    }

    public static double getOptimalPathBoth(Map<String, List<PointD>> dis, PointD marsrutas, List<String> pointsWithWarehouses, double maxCost){
        PointD minP1 = marsrutas;
        double minDist = marsrutas.distance;
        for(PointD toPoint: dis.get(marsrutas.from)){ //eina per taskus, is tasko be sandelio ir iesko artimiausio sandelio
            if(pointsWithWarehouses.contains(toPoint.to)) //jei randa su sandeliu
                if(toPoint.distance < minDist){ //jei atstumas mazenis uz orignalu
                    minDist = toPoint.distance;
                    minP1 = toPoint;
                }
        }

        PointD minP2 = marsrutas;
        minDist = marsrutas.distance;
        for(PointD toPoint: dis.get(marsrutas.to)){ //eina per taskus, is tasko be sandelio ir iesko artimiausio sandelio
            if(pointsWithWarehouses.contains(toPoint.to)) //jei randa su sandeliu
                if(toPoint.distance < minDist){ //jei atstumas mazenis uz orignalu
                    minDist = toPoint.distance;
                    minP2 = toPoint;
                }
        }
        PointD marsTarpSan = null;
        for(PointD mars : dis.get(minP1.to))
            if(mars.to.equals(minP2.to)) {
                marsTarpSan = mars;
                break;
            }

        if (marsTarpSan == null) return maxCost;
        double ret = ((minP1.distance * truckDeliveryCost + minP1.distance * truckEmissionLevel) +
                (minP2.distance * truckDeliveryCost + minP2.distance * truckEmissionLevel) +
                (marsTarpSan.distance * railDeliveryCost + marsTarpSan.distance * railwayEmissionLevel));
        if(ret < maxCost)
            return ret;
        else return maxCost;
    }

    public static double getOptimalPathTo(Map<String, List<PointD>> dis, PointD marsrutas, List<String> pointsWithWarehouses, double maxCost){
        PointD minP = marsrutas;
        double minDist = marsrutas.distance;
        for(PointD toPoint: dis.get(marsrutas.to)){ //eina per taskus, is tasko be sandelio ir iesko artimiausio sandelio
            if(pointsWithWarehouses.contains(toPoint.to)) //jei randa su sandeliu
                if(toPoint.distance < minDist){ //jei atstumas mazenis uz orignalu
                    minDist = toPoint.distance;
                    minP = toPoint;
                }
        }
        PointD marsrutasIkiSan = null;
        for(PointD OGtoNew : dis.get(marsrutas.from))
            if(OGtoNew.to.equals(minP.to)) {
                marsrutasIkiSan = OGtoNew;
                break;
            }

        if (marsrutasIkiSan == null) return maxCost;
        double ret = (truckDeliveryCost * minP.distance + truckEmissionLevel * minP.distance) +
                (railDeliveryCost * marsrutasIkiSan.distance + railwayEmissionLevel * marsrutasIkiSan.distance);
        if(ret < maxCost)
            return ret;
        else return maxCost;
    }

    public static double getOptimalPathFrom(Map<String, List<PointD>> dis, PointD marsrutas, List<String> pointsWithWarehouses, double maxCost){
        PointD minP = marsrutas;
        double minDist = marsrutas.distance;
        for(PointD toPoint: dis.get(marsrutas.from)){ //eina per taskus, is tasko be sandelio ir iesko artimiausio sandelio
            if(pointsWithWarehouses.contains(toPoint.to)) //jei randa su sandeliu
                if(toPoint.distance < minDist){ //jei atstumas mazenis uz orignalu
                    minDist = toPoint.distance;
                    minP = toPoint;
                }
        }
        PointD marsrutasIkiSan = null;
        for(PointD OGtoNew : dis.get(minP.from))
            if(OGtoNew.to.equals(marsrutas.to)) {
                marsrutasIkiSan = OGtoNew;
                break;
            }

        if(marsrutasIkiSan == null) return maxCost;
        double ret = (truckDeliveryCost * minP.distance + truckEmissionLevel * minP.distance) +
                (railDeliveryCost * marsrutasIkiSan.distance + railwayEmissionLevel * marsrutasIkiSan.distance);
        if(ret < maxCost)
            return ret;
        else return maxCost;
    }

    //grazina sarasa su masrstutais, kuriuose abu taskai turi po pasirinktinai sandeliu
    public static List<PointD> warehousePoints(Map<String, List<PointD>> dis, List<String> pointsWithWarehouses, int a){
        List<PointD> list = new ArrayList<>();
        for(String name : dis.keySet()){
            for(PointD point : dis.get(name))
                switch (a){
                    case 0 : //nei vienas sandelio neturi
                        if(!pointsWithWarehouses.contains(point.from) && !pointsWithWarehouses.contains(point.to))
                            list.add(point);
                        break;
                    case 1: //from turi sandeli
                        if(pointsWithWarehouses.contains(point.from) && !pointsWithWarehouses.contains(point.to))
                            list.add(point);
                        break;
                    case 2: //to turi sandeli
                        if(!pointsWithWarehouses.contains(point.from) && pointsWithWarehouses.contains(point.to))
                            list.add(point);
                        break;
                    case 3: //abu turi sandeli
                        if(pointsWithWarehouses.contains(point.from) && pointsWithWarehouses.contains(point.to))
                            list.add(point);
                        break;
                }
        }
        return list;
    }
//
//    public static List<PointD> singleFromWarehousePoints(Map<String, List<PointD>> dis, List<String> pointsWithWarehouses){
//        List<PointD> list = new ArrayList<>();
//        for(String name : dis.keySet()){
//            for(PointD point : dis.get(name))
//                if(pointsWithWarehouses.contains(point.from) && !pointsWithWarehouses.contains(point.to))
//                    list.add(point);
//        }
//        return list;
//    }
//
//    public static List<PointD> singleToWarehousePoints(Map<String, List<PointD>> dis, List<String> pointsWithWarehouses){
//        List<PointD> list = new ArrayList<>();
//        for(String name : dis.keySet()){
//            for(PointD point : dis.get(name))
//                if(!pointsWithWarehouses.contains(point.from) && pointsWithWarehouses.contains(point.to))
//                    list.add(point);
//        }
//        return list;
//    }
//
//    public static List<PointD> neitherWarehousePoints(Map<String, List<PointD>> dis, List<String> pointsWithWarehouses){
//        List<PointD> list = new ArrayList<>();
//        for(String name : dis.keySet()){
//            for(PointD point : dis.get(name))
//                if(!pointsWithWarehouses.contains(point.from) && !pointsWithWarehouses.contains(point.to))
//                    list.add(point);
//        }
//        return list;
//    }
    //sudaro map su taskais ir su skaicium ar turi sandeli 1 - turi, 0 - neturi
    public static Map<String, Integer> wareHousePoints(Map<String, List<PointD>> dis, List<String> pointsWithWarehouses){
        Map<String, Integer> temp = new HashMap<>();
        for(String name : dis.keySet()){
            if(!temp.containsKey(name) && !pointsWithWarehouses.contains(name))
                temp.put(name, 0);
            if(!temp.containsKey(name) && pointsWithWarehouses.contains(name))
                temp.put(name, 1);
        }
        return temp;
    }

    public static List<PointD> warehouseFlowSetup(Map<String, List<PointD>> dis){
        List<PointD> temp = new ArrayList<>();
        for(String from : dis.keySet()){
            PointD flow = new PointD(from, 0);
            temp.add(flow);
        }
        return temp;
    }

    public static List<PointD> warehouseFlowFill(Map<String, List<PointD>> dist, List<PointD> warehouses){
        for(String point : dist.keySet())
            for(PointD list : dist.get(point)) //eina per visus sarasus
                for(PointD item : warehouses) //eina per
                    if(item.from.equals(list.from)/* == list.from*/ || item.from.equals(list.to) /*== list.to*/)
                        item.addflowTons(list.flowTons);
        return warehouses;
    }

//    public static Map<String, Double> warehousesFlows(List<String> pointsWithWarehouses, Map<String, List<PointD>> dis){
//        Map<String, Double> temp = new HashMap<>();
//        for(String key : dis.keySet()) //eina per raktus
//            for(String warehouse : pointsWithWarehouses) //eina per sandelius
//                for(PointD marsrutas : dis.get(key)){ //eina per rakto sarasa
//                    if(warehouse == marsrutas.from/* || warehouse == marsrutas.to*/){
//                        if(temp.containsKey(warehouse)){
//                            double a = temp.get(warehouse);
//                            a += marsrutas.flowTons;
//                            temp.put(warehouse, a);
//                        }
//                        else temp.put(warehouse, marsrutas.flowTons);
//                    }
//                    if(warehouse == marsrutas.to){
//                        if(temp.containsKey(warehouse)){
//                            double a = temp.get(warehouse);
//                            a += marsrutas.flowTons;
//                            temp.put(warehouse, a);
//                        }
//                        else temp.put(warehouse, marsrutas.flowTons);
//                    }
//                }
//
//        return temp;
//    }
}
