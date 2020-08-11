/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package edu.ktu.ds.lab1b.svencionis;

import edu.ktu.ds.lab1b.util.Ks;
import edu.ktu.ds.lab1b.util.Parsable;
import java.util.Locale;
import java.util.InputMismatchException;
import java.util.NoSuchElementException;
import java.util.Scanner;
/**
 *
 * @author PC
 */
public class Star implements Parsable<Star> {
 
    private String name;
    private int distanceLY;
    private int luminocity;
    private double weight;
    private int age;
    
    public Star(String name, int distanceLY,
            int luminocity, double weight, int age) {
        this.name = name;
        this.distanceLY = distanceLY;
        this.luminocity = luminocity;
        this.weight = weight;
        this.age = age;
    }
    
    public Star(){
    }
    
    public Star(String data) {
        parse(data);
    }
    public String getName() {
        return name;
    }

    public int getdistance() {
        return distanceLY;
    }

    public int getLuminocity() {
        return luminocity;
    }

    public double getWeight() {
        return weight;
    }

    public int getAge() {
        return age;
    }
    
    @Override
    public final void parse(String data) {
        try {   // ed - tai elementarūs duomenys, atskirti tarpais
            Scanner ed = new Scanner(data);
            name = ed.next();
            distanceLY = ed.nextInt();
            luminocity = ed.nextInt();
            weight = ed.nextDouble();
            age = ed.nextInt();
        } catch (InputMismatchException e) {
            Ks.ern("Blogas duomenų formatas apie auto -> " + data);
        } catch (NoSuchElementException e) {
            Ks.ern("Trūksta duomenų apie auto -> " + data);
        }
    }
    
    
    
    @Override
    public int compareTo(Star otherCar) {
        // lyginame pagal svarbiausią požymį - kainą
        double otherAge = otherCar.getAge();
        if (age < otherAge) {
            return -1;
        }
        if (age > otherAge) {
            return +1;
        }
        return 0;
    }
    
    @Override
    public String toString() {  // surenkama visa reikalinga informacija
        return String.format("%-8s %4d %7d %8.1f %4d",
                name, distanceLY, luminocity, weight, age);
    }
    
    
    public static void main(String... args) {
        // suvienodiname skaičių formatus pagal LT lokalę (10-ainis kablelis)
        Locale.setDefault(new Locale("LT"));
        Star a1 = new Star("MilkySat", 50, 1997, 50000, 599);
        Star a2 = new Star("Maxwell", 102, 2015, 20000, 3500);
        Star a3 = new Star();
        Star a4 = new Star();
        a3.parse("Einstein 14 2001 20000 8500");
        a4.parse("Saturdus 32 1990 20000  500");
        Ks.oun(a1);
        Ks.oun(a2);
        Ks.oun(a3);
        Ks.oun(a4);
    }
}
