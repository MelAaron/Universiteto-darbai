/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package edu.ktu.ds.lab2.svencionis;


import edu.ktu.ds.lab2.utils.Ks;
import edu.ktu.ds.lab2.utils.Parsable;
import java.util.*;

/**
 *
 * @author PC
 */
public final class Microcontroller implements Parsable<Microcontroller> {
    
    //private static final int memory =
    
    private static final String idCode = "TA";   //  ***** nauja
    private static int serNr = 100;               //  ***** nauja
    
    private final String mCNr;

    private String name = "";
    private String model = "";
    private int year = -1;
    private int memory = -1;
    private double price = -1.0;
    
    public Microcontroller() {
        mCNr = idCode + (serNr++);    // suteikiamas originalus mCNr
    }

    public Microcontroller(String name, String model, int year, int memory, double price) {
        mCNr = idCode + (serNr++);    // suteikiamas originalus mCNr
        this.name = name;
        this.model = model;
        this.year = year;
        this.memory = memory;
        this.price = price;
    }
    
    public Microcontroller(String dataString) {
        mCNr = idCode + (serNr++);    // suteikiamas originalus mCNr
        this.parse(dataString);
    }

    public Microcontroller(Builder builder) {
        mCNr = idCode + (serNr++);    // suteikiamas originalus mCNr
        this.name = builder.name;
        this.model = builder.model;
        this.year = builder.year;
        this.memory = builder.memory;
        this.price = builder.price;
    }

    public Microcontroller create(String dataString) {
        return new Microcontroller(dataString);
    }
    
    @Override
    public void parse(String dataString) {
        try {   // duomenys, atskirti tarpais
            Scanner scanner = new Scanner(dataString);
            name = scanner.next();
            model = scanner.next();
            year = scanner.nextInt();
            memory = scanner.nextInt();
            price = scanner.nextDouble();
        } catch (InputMismatchException e) {
            Ks.ern("Blogas duomenų formatas -> " + dataString);
        } catch (NoSuchElementException e) {
            Ks.ern("Trūksta duomenų -> " + dataString);
        }
    }
    
    @Override
    public String toString() {  // papildyta su mCNr
        return getMicrocontrollerRegNr() + "=" + name + "_" + model + ":" + year + " " + getMemory() + " " + String.format("%4.1f", price);
    }

    public String getName() {
        return name;
    }

    public String getModel() {
        return model;
    }

    public int getYear() {
        return year;
    }

    public int getMemory() {
        return memory;
    }

    public void setMemory(int memory) {
        this.memory = memory;
    }

    public double getPrice() {
        return price;
    }

    public void setPrice(double price) {
        this.price = price;
    }
    
    public String getMicrocontrollerRegNr() {  //** nauja.
        return mCNr;
    }
    
    @Override
    public int compareTo(Microcontroller mc) {
        return getMicrocontrollerRegNr().compareTo(mc.getMicrocontrollerRegNr());
    }

    public static Comparator<Microcontroller> byMake = (Microcontroller c1, Microcontroller c2) -> c1.name.compareTo(c2.name); // pradžioje pagal markes, o po to pagal modelius

    public static Comparator<Microcontroller> byPrice = (Microcontroller c1, Microcontroller c2) -> {
        // didėjanti tvarka, pradedant nuo mažiausios
        if (c1.price < c2.price) {
            return -1;
        }
        if (c1.price > c2.price) {
            return +1;
        }
        return 0;
    };

    public static Comparator<Microcontroller> byYearPrice = (Microcontroller c1, Microcontroller c2) -> {
        // metai mažėjančia tvarka, esant vienodiems lyginama kaina
        if (c1.year > c2.year) {
            return +1;
        }
        if (c1.year < c2.year) {
            return -1;
        }
        if (c1.price > c2.price) {
            return +1;
        }
        if (c1.price < c2.price) {
            return -1;
        }
        return 0;
    };
    
    public static class Builder {

        private final static Random RANDOM = new Random(1949);  // Atsitiktinių generatorius
        private final static String[][] MODELS = { // galimų automobilių markių ir jų modelių masyvas
                {"Arduino", "121", "323", "626", "MX6"},
                {"RaspberryPi", "Three", "Nano", "v3", "412A", "12-31KL"},
                {"Intel", "92", "96"},
                {"ATmega", "ICS51", "Uno", "81_C"},
                {"Sony", "Nanov2", "Megane41", "TW14", "SCC"},
                {"Altera", "206", "207", "307"}
        };

        private String name = "";
        private String model = "";
        private int year = -1;
        private int memory = -1;
        private double price = -1.0;

        public Microcontroller build() {
            return new Microcontroller(this);
        }

        public Microcontroller buildRandom() {
            int ma = RANDOM.nextInt(MODELS.length);        // markės indeksas  0..
            int mo = RANDOM.nextInt(MODELS[ma].length - 1) + 1;// modelio indeksas 1..
            return new Microcontroller(MODELS[ma][0],
                    MODELS[ma][mo],
                    1990 + RANDOM.nextInt(20),// metai tarp 1990 ir 2009
                    6000 + RANDOM.nextInt(222000),// rida tarp 6000 ir 228000
                    800 + RANDOM.nextDouble() * 88000);// kaina tarp 800 ir 88800
        }

        public Builder year(int year) {
            this.year = year;
            return this;
        }

        public Builder name(String name) {
            this.name = name;
            return this;
        }

        public Builder model(String model) {
            this.model = model;
            return this;
        }

        public Builder memory(int memory) {
            this.memory = memory;
            return this;
        }

        public Builder price(double price) {
            this.price = price;
            return this;
        }
    }
}
