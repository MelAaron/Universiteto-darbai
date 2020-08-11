/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package edu.ktu.ds.lab2.svencionis;

import edu.ktu.ds.lab2.utils.*;

import java.util.Arrays;
import java.util.Collections;
import java.util.Iterator;
import java.util.Locale;


/**
 *
 * @author PC
 */
public class MCTest {
    
    static Microcontroller[] mCs;
    static ParsableSortedSet<Microcontroller> cSeries = new ParsableBstSet<>(Microcontroller::new, Microcontroller.byPrice);

    public static void main(String[] args) throws CloneNotSupportedException {
        Locale.setDefault(Locale.US); // Suvienodiname skaičių formatus
        executeTest();
    }

    public static void executeTest() throws CloneNotSupportedException {
        Microcontroller c1 = new Microcontroller("C1ATmega", "315M", 1997, 50000, 1700);
        Microcontroller c2 = new Microcontroller.Builder()
                .name("Renault")
                .model("Megane")
                .year(2001)
                .memory(20000)
                .price(3500)
                .build();
        Microcontroller c3 = new Microcontroller.Builder().buildRandom();
        Microcontroller c4 = new Microcontroller("C4Arduino Mega 2001 115900 700");
        Microcontroller c5 = new Microcontroller("C5Arguino Nano 1946 365100 9500");
        Microcontroller c6 = new Microcontroller("C6Arguino   Uno  2001  36400 80.3");
        Microcontroller c7 = new Microcontroller("C7RaspberryPi Three 2001 115900 7500");
        Microcontroller c8 = new Microcontroller("C8RaspberryPi Four 1946 365100 950");
        Microcontroller c9 = new Microcontroller("C9RaspberryPi   Two  2007  36400 850.3");
        Microcontroller c10 = new Microcontroller("Intel MCS-51 1999 1222 900");

        Microcontroller[] mCsArray = {c9, c7, c8, c5, c1, c6};

        long t0 = System.nanoTime();
        
        Ks.oun("Auto Aibė:");
        ParsableSortedSet<Microcontroller> mCsSet = new ParsableBstSet<>(Microcontroller::new);

        for (Microcontroller c : mCsArray) {
            mCsSet.add(c);
            Ks.oun("Aibė papildoma: " + c + ". Jos dydis: " + mCsSet.size());
        }
        Ks.oun("");
        Ks.oun(mCsSet.toVisualizedString(""));
        
        //-------------------------------------------------------------------
        BstSet<Microcontroller> test = new BstSet<>();
        for (Microcontroller c : mCsArray) test.add(c);
        Microcontroller ct = test.ceiling(c7);
        if(ct != null)
        Ks.oun(ct);
        else Ks.oun("Null");
        
        ////treeHeight
//        BstSet<Microcontroller> test = new BstSet<>();
//        for (Microcontroller c : mCsArray) test.add(c);
//        int h = test.getTreeHeight();
//        Ks.oun(h);
        ////subSet
//        BstSet<Microcontroller> test = new BstSet<>();
//        for (Microcontroller c : mCsArray) test.add(c);
//        Set<Microcontroller> n = test.subSet(c7, c1);
//        Ks.oun(n.toVisualizedString(""));
        ////headSet
//        BstSet<Microcontroller> test = new BstSet<>();
//        for (Microcontroller c : mCsArray) test.add(c);
//        Set<Microcontroller> n = test.headSet(c1);
//        Ks.oun(n.toVisualizedString(""));
        ////tailSet(individualus)
//        BstSet<Microcontroller> test = new BstSet<>();
//        for (Microcontroller c : mCsArray) test.add(c);
//        Set<Microcontroller> n = test.tailSetI(c7);
//        Ks.oun(n.toVisualizedString(""));
        ////tailSet
//        BstSet<Microcontroller> test = new BstSet<>();
//        for (Microcontroller c : mCsArray) test.add(c);
//        Set<Microcontroller> n = test.tailSet(c7);
//        Ks.oun(n.toVisualizedString(""));
        ////floor(individualus)
        ////BstSet<Microcontroller> n = test.floor(c7);
        ////Ks.oun(n.toVisualizedString(""));
        //Microcontroller ct = test.floor(c7);
        //if(ct != null)
        //Ks.oun(ct);
        //else Ks.oun("Null");
        ////addAll(individualus)
//        BstSet<Microcontroller> test = new BstSet<>();
//        for (Microcontroller c : mCsArray) test.add(c);
//        Microcontroller[] pridejimoArray = {c2, c3, c4, c10};
//        BstSet<Microcontroller> pridejimas = new BstSet<>();
//        for (Microcontroller c : pridejimoArray) pridejimas.add(c);
//        Ks.oun(test.size());
//        test.addAll(pridejimas);
//        Ks.oun(test.toVisualizedString(""));
//        Ks.oun(test.size());
        //-------------------------------------------------------------------

        ParsableSortedSet<Microcontroller> mCsSetCopy = (ParsableSortedSet<Microcontroller>) mCsSet.clone();

        mCsSetCopy.add(c2);
        mCsSetCopy.add(c3);
        mCsSetCopy.add(c4);
        Ks.oun("Papildyta autoaibės kopija:");
        Ks.oun(mCsSetCopy.toVisualizedString(""));

        c9.setMemory(10000);

        Ks.oun("Originalas:");
        Ks.ounn(mCsSet.toVisualizedString(""));

        Ks.oun("Ar elementai egzistuoja aibėje?");
        for (Microcontroller c : mCsArray) {
            Ks.oun(c + ": " + mCsSet.contains(c));
        }
        Ks.oun(c2 + ": " + mCsSet.contains(c2));
        Ks.oun(c3 + ": " + mCsSet.contains(c3));
        Ks.oun(c4 + ": " + mCsSet.contains(c4));
        Ks.oun("");

        Ks.oun("Ar elementai egzistuoja aibės kopijoje?");
        for (Microcontroller c : mCsArray) {
            Ks.oun(c + ": " + mCsSetCopy.contains(c));
        }
        Ks.oun(c2 + ": " + mCsSetCopy.contains(c2));
        Ks.oun(c3 + ": " + mCsSetCopy.contains(c3));
        Ks.oun(c4 + ": " + mCsSetCopy.contains(c4));
        Ks.oun("");

        Ks.oun("Elementų šalinimas iš kopijos. Aibės dydis prieš šalinimą:  " + mCsSetCopy.size());
        for (Microcontroller c : new Microcontroller[]{c2, c1, c9, c8, c5, c3, c4, c2, c7, c6, c7, c9}) {
            mCsSetCopy.remove(c);
            Ks.oun("Iš autoaibės kopijos pašalinama: " + c + ". Jos dydis: " + mCsSetCopy.size());
        }
        Ks.oun("");

        Ks.oun("Automobilių aibė su iteratoriumi:");
        Ks.oun("");
        for (Microcontroller c : mCsSet) {
            Ks.oun(c);
        }
        
        Ks.oun("");
        Ks.oun("Iteratoriaus remove");
        Iterator iter = mCsSet.iterator();
        Ks.oun("");
        Ks.oun(iter.next());
        Ks.oun(iter.next());
        //iter.next();
        iter.remove();//mCsSetAvl.remove();
        while (iter.hasNext()) {
            Ks.oun(iter.next());
        }
        Ks.oun("");
        
        long t1 = System.nanoTime();
        Ks.oun("");
        Ks.oun("Automobilių aibė AVL-medyje:");
        ParsableSortedSet<Microcontroller> mCsSetAvl = new ParsableAvlSet<>(Microcontroller::new);
        for (Microcontroller c : mCsArray) {
            mCsSetAvl.add(c);
        }
        Ks.ounn(mCsSetAvl.toVisualizedString(""));

        Ks.oun("Automobilių aibė su iteratoriumi:");
        Ks.oun("");
        for (Microcontroller c : mCsSetAvl) {
            Ks.oun(c);
        }

        Ks.oun("");
        Ks.oun("Automobilių aibė su atvirkštiniu iteratoriumi:");
        Ks.oun("");
        iter = mCsSetAvl.descendingIterator();
        while (iter.hasNext()) {
            Ks.oun(iter.next());
        }
        
//        Ks.oun("");
//        Ks.oun("Iteratoriaus remove");
//        iter = mCsSetAvl.iterator();
//        Ks.oun("");
//        Ks.oun(iter.next());
//        Ks.oun(iter.next());
//        //iter.next();
//        iter.remove();//mCsSetAvl.remove();
//        while (iter.hasNext()) {
//            Ks.oun(iter.next());
//        }
//        Ks.oun("");
        
        Ks.oun("");
        Ks.oun("Automobilių aibės toString() metodas:");
        Ks.ounn(mCsSetAvl);

        // Išvalome ir suformuojame aibes skaitydami iš failo
        mCsSet.clear();
        mCsSetAvl.clear();

//        Ks.oun("");
//        Ks.oun("Automobilių aibė DP-medyje:");
//        mCsSet.load("data\\ban.txt");
//        Ks.ounn(mCsSet.toVisualizedString(""));
//        Ks.oun("Išsiaiškinkite, kodėl medis augo tik į vieną pusę.");
//
//        Ks.oun("");
//        Ks.oun("Automobilių aibė AVL-medyje:");
//        mCsSetAvl.load("data\\ban.txt");
//        Ks.ounn(mCsSetAvl.toVisualizedString(""));
        long t2 = System.nanoTime();
    }

    static ParsableSortedSet generateSet(int kiekis, int generN) {
        mCs = new Microcontroller[generN];
        for (int i = 0; i < generN; i++) {
            mCs[i] = new Microcontroller.Builder().buildRandom();
        }
        Collections.shuffle(Arrays.asList(mCs));

        cSeries.clear();
        Arrays.stream(mCs).limit(kiekis).forEach(cSeries::add);
        return cSeries;
    }
    
}
