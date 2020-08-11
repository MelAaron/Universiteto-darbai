package proj;

import javafx.application.Application;
import javafx.fxml.FXMLLoader;
import javafx.scene.Parent;
import javafx.scene.Scene;
import javafx.stage.Stage;
import sun.rmi.server.InactiveGroupException;
import sun.rmi.server.Util;

import java.io.BufferedReader;
import java.io.File;
import java.io.FileReader;
import java.io.IOException;
import java.util.*;
import java.util.stream.Collectors;

public class Main {

    public static Random rnd = new Random();
    // kainos
    public static double warehouseConstructionCost = 308525.05;
    public static double variableWarehouseConstructionCost = 539.91;
    public static double fixedWarehouseManagementCost = 8513.26;
    public static double variableWarehouseManagementCost = 6.31;
    public static double truckDeliveryCosts = 16.54;
    public static double railwayDeliveryCosts = 3.95;
    public static double truckEmission = 0.062;
    public static double railwayEmission = 0.022;

    public static int iterations = 20;

    public static int[] maxS = new int[271];
    public static double minPrice = Double.MAX_VALUE;
    public static String finalStartingPoint = "";

    public static void readFlows(HashMap flows) {
        //File file = new File("C:\\Users\\pc\\Desktop\\ClusterProject\\src\\Project\\All flows.csv");
        File file = new File("Data/All flows.csv");
        BufferedReader br = null;
        try {
            br = new BufferedReader(new FileReader(file));
            String line;
            br.readLine();

            while ((line = br.readLine()) != null) {
                String[] values = line.split(",");
                String key = values[0] + "-" + values[1];
                if(flows.containsKey(key)) {
                    int newValue = Integer.parseInt(flows.get(key).toString()) + Integer.parseInt(values[3]);
                    flows.replace(key, newValue);
                }
                else
                {
                    flows.put(key, Integer.parseInt(values[3]));
                }
            }

        } catch (IOException e) {
            e.printStackTrace();
        }
    }

    public static void readDistances(HashMap distances) {
        //File file = new File("C:\\Users\\pc\\Desktop\\ClusterProject\\src\\Project\\Distances NUTS2-NUTS2.csv");
        File file = new File("Data/Distances NUTS2-NUTS2.csv");
        BufferedReader br = null;
        try {
            br = new BufferedReader(new FileReader(file));
            String line;
            br.readLine();

            while ((line = br.readLine()) != null) {
                String[] values = line.split(",");
                distances.put(values[0], values[3]);
            }

        } catch (IOException e) {
            e.printStackTrace();
        }
    }

    public static double target(int[] S, String startPoint, List<String> uniqueLocations, HashMap flows, HashMap distances)
    {
        double price = 0;
        int warehouseBuiltCounter = 0;
        for (int i = 0; i < S.length; i++)
        {
            if (S[i] == 1)
            {
                warehouseBuiltCounter++;
            }
        }

        // Tikslo funkcija: SSK + SVK + TRK + NKA + COD

        for (int i = 0; i < 271; i++)
        {
            String route = startPoint + '-' + uniqueLocations.get(i);
            try
            {
                double SSK = S[i] * ((int) flows.get(route) * variableWarehouseConstructionCost * warehouseConstructionCost);
                double SVK = S[i] * (((int) flows.get(route) * variableWarehouseManagementCost * 365) + (fixedWarehouseManagementCost * 12));
                double TRK = 0;
                double RTRK = 0;
                double COD = 0;
                double RCOD = 0;
                if (S[i] == 1)
                {
                    RTRK = truckDeliveryCosts * Double.parseDouble(distances.get(route).toString()) * (int) flows.get(route);
                    RCOD = truckEmission * Double.parseDouble(distances.get(route).toString()) * (int) flows.get(route);
                    TRK = railwayDeliveryCosts * Double.parseDouble(distances.get(route).toString()) * (int) flows.get(route);
                    COD = railwayEmission * Double.parseDouble(distances.get(route).toString()) * (int) flows.get(route);
                }
                else
                {
                    TRK = truckDeliveryCosts * Double.parseDouble(distances.get(route).toString()) * (int) flows.get(route);
                    COD = truckEmission * Double.parseDouble(distances.get(route).toString()) * (int) flows.get(route);
                }
                double NKA = Double.parseDouble(distances.get(route).toString()) * (int) flows.get(route);

                if (SVK + SSK + TRK + COD < RTRK + RCOD)
                {
                    price += SSK + SVK + TRK + NKA + COD;
                }
                else
                {
                    S[i] = 0;
                    price += RTRK + RCOD + NKA;
                }
            }
            catch (NullPointerException e)
            {
                //System.out.println(route);
            }
        }
        return price;
    }

    public static int[] getS(int size)
    {
        int[] S = new int[size];
        Random rnd = new Random();
        for(int i = 0; i < size; i++)
        {
            S[i] = rnd.nextInt(2);
        }
        return S;
    }


    public static void main(String[] args) {
        // pradiniai duomenys
        HashMap flows = new HashMap();
        HashMap distances = new HashMap();
        readFlows(flows);
        readDistances(distances);


        // visi marsrutai sorted
        Set<String> locations = distances.keySet();
        ArrayList<String> sortedLocations = new ArrayList<>(new TreeSet<>(locations));

        List<String> uniqueLocations = new LinkedList<>();

        for(int i = 0; i < distances.size(); i += 271)
        {
            uniqueLocations.add(sortedLocations.get(i).substring(0, 4));
        }

        //pagrindine funkcija
        //---------------------------------------------------------------------------
        for(int i = 0; i < iterations; i++)
        {
            // sugeneruoja random S
            int[] S = getS(271);

            String startPoint = uniqueLocations.get(rnd.nextInt(271));

            // gauti kazkokia kaina ir jei kaina mazesne uz dabartine, perrasyti
            double price = target(S, startPoint, uniqueLocations, flows, distances);
            if (price < minPrice)
            {
                maxS = S;
                minPrice = price;
                finalStartingPoint = startPoint;
            }
        }
        //---------------------------------------------------------------------------

        int z = 1;
        for(int i = 0; i < maxS.length; i++)
        {
            if(maxS[i] == 1)
            {
                String s = finalStartingPoint + "-" + uniqueLocations.get(i);
                //String s = uniqueLocations.get(i);
                System.out.println(String.format("%d: %s", z, s));
                z++;
            }
        }
        System.out.println(minPrice);
    }
}

