/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package edu.ktu.ds.lab1b.svencionis;

import edu.ktu.ds.lab1b.util.Ks;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.Collections;
import java.util.Locale;
import java.util.Random;

/**
 *
 * @author PC
 */
public class Greitaveika {
    
    ArrayList<Integer> intsList = new ArrayList<Integer>();
    Integer[] ints;
    Random rg = new Random();
    //int[] counts = {2_000, 4_000, 8_000, 16_000};
    int[] counts = {10_000, 20_000, 40_000, 80_000};
    void generateInts(int count){
        
        ints = new Integer[count];
        for (int i = 0; i < count; i++){
            ints[i] = rg.nextInt(100);
        }
        Collections.shuffle(Arrays.asList(ints));
        intsList.clear();
        for (Integer c : ints) {
            intsList.add(c);
        }
    }
    void instructions(){
        long memTotal = Runtime.getRuntime().totalMemory();
        long memMax = Runtime.getRuntime().maxMemory();
        Ks.oun("memTotal= " + memTotal);
        Ks.oun("memMax= " + memMax);
        
        Ks.oun("0 - Elementų kiekis ArrayList<Integer> sąraše");
        Ks.oun("1 - Pasiruošimas tyrimui - x sukurimas");
        Ks.oun("2 - Math.pow(x, 1.0/3)");
        Ks.oun("3 - Math.cbrt(x)");
        Ks.oun("4 - ArrayList<Integer> sugeneravimas");
        Ks.oun("5 - indexOf(Object o)");
        Ks.oun("6 - lastIndexOf(Object o)");
        Ks.ouf("%6d %7d %7d %7d %7d %7d %7d \n", 0, 1, 2, 3, 4, 5, 6);
        
    }
    
    void execute2(int elementCount){
        
        generateInts(elementCount);
        
        long t0 = System.nanoTime();
        int x = rg.nextInt(1000);
        long t1 = System.nanoTime();
        for(int i = 0; i < elementCount; i++)
        Math.pow(intsList.get(i), 1.0/3);
        //Math.pow(x, 1.0/3);
        long t2 = System.nanoTime();
        for(int i = 0; i < elementCount; i++)
        Math.cbrt(intsList.get(i));
        //Math.cbrt(x);
        long t3 = System.nanoTime();
        generateInts(elementCount);
        long t4 = System.nanoTime();
        intsList.indexOf(rg.nextInt(elementCount));
        long t5 = System.nanoTime();
        intsList.lastIndexOf(rg.nextInt(elementCount));
        long t6 = System.nanoTime();
        
        Ks.ouf("%7d %7.5f %7.5f %7.5f %7.5f %7.5f %7.5f \n", elementCount,
                (t1 - t0) / 1e9, (t2 - t1) / 1e9, (t3 - t2) / 1e9,
                (t4 - t3) / 1e9, (t5 - t4) / 1e9, (t6 - t5) / 1e9);
    }
    void execute(){
        instructions();
        for(int i = 0; i < counts.length; i++){
            new Greitaveika().execute2(counts[i]);
        }
    }

    public static void main(String[] args) {
        // suvienodiname skaičių formatus pagal LT lokalę (10-ainis kablelis)
        Locale.setDefault(new Locale("LT"));
            new Greitaveika().execute();
    }
}
