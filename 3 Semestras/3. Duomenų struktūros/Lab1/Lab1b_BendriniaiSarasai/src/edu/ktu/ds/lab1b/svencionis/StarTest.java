/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package edu.ktu.ds.lab1b.svencionis;


import edu.ktu.ds.lab1b.util.Ks;
import edu.ktu.ds.lab1b.util.LinkedList;
import java.util.Locale;
import java.util.Random;
/**
 *
 * @author PC
 */
public class StarTest {
    
    public StarList stars = new StarList();
    
    void createStars() {
        Star a1 = new Star("MilkySat", 50, 1997, 50000, 599);
        Star a2 = new Star("Maxwell", 102, 2015, 20000, 3500);
        Star a3 = new Star();
        Star a4 = new Star();
        a3.parse("Einstein 14 2001 20000 8500");
        a4.parse("Saturdus 32 1990 20000  500");
        
        Ks.oun(a1);
        Ks.oun(a2);
        
        Ks.oun("Pirmų 2 zvaigzdziu svorio vidurkis= "
                + (a1.getWeight()+ a2.getWeight()) / 2);
        Ks.oun(a3);
        Ks.oun(a4);
        Ks.oun("Kitų 2 auto atstumu suma= "
                + (a3.getdistance() + a4.getdistance()));
    }
    void createStarList() {
        Star c1 = new Star("Renault", 14, 1997, 50000, 1700);
        Star c2 = new Star("Renault", 24, 2001, 20000, 3500);
        Star c3 = new Star("Toyota", 26, 2001, 20000, 8500);
        stars.add(c1);
        stars.add(c2);
        stars.add(c3);
        stars.println("Pirmi 3 auto");
        stars.add("Renault 24 2001 115900 7500");
        stars.add("Renault 11 1946 365100 9500");
        stars.add("Honda   55  2007  36400 8500");

        stars.println("Visi 6 auto");
        stars.forEach(System.out::println);
        
        Ks.oun("Pirmų 3 zvaigzdziu svorio vidurkis= "
                + (stars.get(0).getWeight()+ stars.get(1).getWeight()+ stars.get(2).getWeight()) / 3);
        Ks.oun("Kitų 3 auto atstumu suma= "
                + (stars.get(3).getdistance() + stars.get(4).getdistance()+ stars.get(5).getdistance()));
    }
    void checkStarSearchFilters() {
        StarSearch search = new StarSearch();

        search.allStars.load("ban.txt");
        search.allStars.println("Bandomasis rinkinys");

        stars = search.getYoungerStars(600);
        stars.println("Pradedant nuo 600 mln. metų");

        stars = search.getByDistance(20, 100);
        stars.println("Atstumas tarp 20 ir 100 šveismečių");

        stars = search.getBrightestStars();
        stars.println("Ryškiausios zvaigzdės");

        stars = search.getByName("M");
        stars.println("Žvaigždės, kurių pavadinimai prasideda M raide");
        
        int n = 0;
        for (Star c : stars) {
            n++;    // testuojame ciklo veikimą
        }
        Ks.oun("Žvaigždžių, pasidedančių M raide, kiekis = " + n);
    }
    void appendStarList() {
        Random rnd = new Random();
        for (int i = 0; i < 8; i++) {
            stars.add(new Star("Malinus", 30 + i * rnd.nextInt(15),
                    2000 - i * rnd.nextInt(500), 40000 + i * rnd.nextInt(2000), 36000 - i * 2000));
        }
        stars.add("Mondeo  19 37000 36000 500");
        stars.add("Bravo   11 27000 32500 32");
        stars.add("Miesta  65 31200 16000 5901");
        stars.add("Bethoven      2006 87000 36000 124");
        stars.println("Testuojamų žvaigždžių sąrašas");
        stars.save("ban.txt");
    }
    public void execute(){
//        createStars();
//        createStarList();
//        appendStarList();
//        checkStarSearchFilters();
        
        Star c1 = new Star("Malarija", 13, 3021, 505111.1, 1700);
        Star c2 = new Star("Zvaigziu", 45, 1251, 2523.1, 3500);
        Star c3 = new Star("Lapignas", 25, 1512, 125125.0, 8500);
        Star c4 = new Star("Salamina", 74, 12516, 20569.8, 8500);
        Star c5 = new Star("Naujorita", 13, 3021, 5011.1, 1700);
        Star c6 = new Star("Akaulosjus", 45, 1251, 2523.1, 3500);
        Star c7 = new Star("Lausogis", 25, 1512, 125125.0, 8500);
        Star c8 = new Star("Midrakadis", 74, 12516, 20569.8, 8500);
        Star c9 = new Star("Puikioji", 255, 20021, 20212.1, 3500);
        LinkedList<Star> list = new LinkedList();
        list.add(c1);
        list.add(c3);
        list.add(c4);
        list.add(c5);
        list.add(c6);
        list.add(c7);
        list.add(c8);
        

        
        Star c10 = new Star("Loyalitas", 212, 12155, 20000.21, 8500);
        Star c11 = new Star("Kazanopolis", 1003, 6541, 9125.31, 8500);
        LinkedList<Star> newList = new LinkedList();
        newList.add(c9);
        newList.add(c10);
        newList.add(c11);
        
        int ind = list.lastIndexOf(c2);
        Ks.ouf("Grazinamas int " + ind + " \n");

//        list.addAll(5, newList);
//        list.add(0, c6);
//        list.remove(7);
//        list.removeFirst();
//        list.set(0, c9);
        //list.RemoveFirstOccurrence(c2);
        
        for(int i = 0; i < list.size(); i++){
            Ks.oun(list.get(i));
        }
        Ks.ou(ind);
    }
    public static void main(String... args) {
        // suvienodiname skaičių formatus pagal LT lokalę (10-ainis kablelis)
        Locale.setDefault(new Locale("LT"));
        new StarTest().execute();
    }
}
