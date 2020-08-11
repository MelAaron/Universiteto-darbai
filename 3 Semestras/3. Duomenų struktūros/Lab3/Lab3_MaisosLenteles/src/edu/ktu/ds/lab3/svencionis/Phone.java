package edu.ktu.ds.lab3.svencionis;

import edu.ktu.ds.lab3.utils.Ks;
import edu.ktu.ds.lab3.utils.Parsable;

import java.time.LocalDate;
import java.util.*;

/**
 * @author EK
 */
public final class Phone implements Parsable<Phone> {

    // Bendri duomenys visiems automobiliams (visai klasei)
    private static final int minYear = 1990;
    private static final int currentYear = LocalDate.now().getYear();
    private static final double minPrice = 100.0;
    private static final double maxPrice = 333000.0;

    private String compay = "";
    private String model = "";
    private int year = -1;
    private int memory = -1;
    private double price = -1.0;

    public Phone() {
    }

    public Phone(String compay, String model, int year, int memory, double price) {
        this.compay = compay;
        this.model = model;
        this.year = year;
        this.memory = memory;
        this.price = price;
    }

    public Phone(String dataString) {
        this.parse(dataString);
    }

    public Phone(Builder builder) {
        this.compay = builder.compay;
        this.model = builder.model;
        this.year = builder.year;
        this.memory = builder.memory;
        this.price = builder.price;
    }
    
    @Override
    public void parse(String dataString) {
        try {   // duomenys, atskirti tarpais
            Scanner scanner = new Scanner(dataString);
            compay = scanner.next();
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
    public String toString() {
        return compay + "_" + model + ":" + year + " " + getMemory() + " "
                + String.format("%4.1f", price);
    }

    public String getCompany() {
        return compay;
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

    public double getPrice() {
        return price;
    }

    public void setPrice(double price) {
        this.price = price;
    }

    public void setMemory(int memory) {
        this.memory = memory;
    }

    @Override
    public int hashCode() {
        int hash = 5;
        hash = 29 * hash + Objects.hashCode(this.compay);
        hash = 29 * hash + Objects.hashCode(this.model);
        hash = 29 * hash + this.year;
        hash = 29 * hash + this.memory;
        hash = 29 * hash + (int) (Double.doubleToLongBits(this.price) ^ (Double.doubleToLongBits(this.price) >>> 32));
        return hash;
    }

    @Override
    public boolean equals(Object obj) {
        if (this == obj) {
            return true;
        }
        if (obj == null) {
            return false;
        }
        if (getClass() != obj.getClass()) {
            return false;
        }
        final Phone other = (Phone) obj;
        if (this.year != other.year) {
            return false;
        }
        if (this.memory != other.memory) {
            return false;
        }
        if (Double.doubleToLongBits(this.price) != Double.doubleToLongBits(other.price)) {
            return false;
        }
        if (!Objects.equals(this.compay, other.compay)) {
            return false;
        }
        if (!Objects.equals(this.model, other.model)) {
            return false;
        }
        return true;
    }

    // Phone klases objektų gamintojas
    public static class Builder {

        private final static Random RANDOM = new Random(1949);  // Atsitiktinių generatorius
        private final static String[][] MODELS = { // galimų automobilių markių ir jų modelių masyvas
            {"Nokia", "3", "6", "CX-3", "MX-5"},
            {"Samsung", "0F21", "Kuga", "Forc", "Galaxy", "Mania"},
            {"Huawei", "Fana", "Jetta", "Pint", "A8"},
            {"Samsung", "HR-V", "CR-V", "Civic", "Jazz"},
            {"Apple", "Clio", "Galaxy", "Max", "Cam"},
            {"Motorola", "208", "308", "508", "Partner"},
            {"Nokia", "3310", "A4", "A6", "A8", "Q3", "Q5"}
        };

        private String compay = "";
        private String model = "";
        private int year = -1;
        private int memory = -1;
        private double price = -1.0;

        public Phone build() {
            return new Phone(this);
        }

        public Phone buildRandom() {
            int ma = RANDOM.nextInt(MODELS.length);        // markės indeksas  0..
            int mo = RANDOM.nextInt(MODELS[ma].length - 1) + 1;// modelio indeksas 1..
            return new Phone(MODELS[ma][0],
                    MODELS[ma][mo],
                    1990 + RANDOM.nextInt(20),// metai tarp 1990 ir 2009
                    6000 + RANDOM.nextInt(222000),// rida tarp 6000 ir 228000
                    800 + RANDOM.nextDouble() * 88000);// kaina tarp 800 ir 88800
        }

        public Builder year(int year) {
            this.year = year;
            return this;
        }

        public Builder compay(String compay) {
            this.compay = compay;
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
