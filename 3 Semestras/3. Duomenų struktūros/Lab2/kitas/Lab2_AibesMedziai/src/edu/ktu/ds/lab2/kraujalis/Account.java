/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package edu.ktu.ds.lab2.kraujalis;

import java.util.Comparator;
import java.util.InputMismatchException;
import java.util.NoSuchElementException;
import java.util.Random;
import java.util.Scanner;

import edu.ktu.ds.lab2.utils.Ks;
import edu.ktu.ds.lab2.utils.Parsable;

import java.util.*;

/**
 *
 * @author Gvidas Kraujalis
 */
public class Account implements Parsable<Account> {

    final static private int minInitDeposit = 0;

    final static private double minBalance = 0;
    //final static private double maxBalance = 210_000;

    private static final String idCode = "TA";
    private static int serNr = 100;

    private final String RegNr;

    private String name;
    private String accountType;
    private String sSN;
    private int initDeposit;
    private double balance;

    public Account() {
        RegNr = idCode + (serNr++);    // suteikiamas originalus carRegNr
    }

    public Account(String name, String accountType, String sSN, int initDeposit, double balance) {
        RegNr = idCode + (serNr++);    // suteikiamas originalus carRegNr

        this.name = name;
        this.accountType = accountType;
        this.sSN = sSN;
        this.initDeposit = initDeposit;
        this.balance = balance;

        validate();
    }

    public Account(String dataString) {
        RegNr = idCode + (serNr++);    // suteikiamas originalus carRegNr

        this.parse(dataString);

        validate();
    }

    public Account(String dataString, boolean RandomReg) {
        if (RandomReg) {
            RegNr = idCode + (serNr++);    // suteikiamas originalus carRegNr
        } else {
            Scanner scanner = new Scanner(dataString);
            RegNr = scanner.next();
        }
        this.parseAlternative(dataString, RandomReg);

        validate();
    }

    public Account(Builder builder) {
        RegNr = idCode + (serNr++);    // suteikiamas originalus carRegNr

        this.name = builder.name;
        this.accountType = builder.accountType;
        this.sSN = builder.sSN;
        this.initDeposit = builder.initDeposit;
        this.balance = builder.balance;

        validate();
    }

    public Account create(String dataString) {
        return new Account(dataString);
    }

    private void validate() {
        String errorType = "";
        if (initDeposit < minInitDeposit) {
            errorType = "Neteisingas pradinis įnašas";
        }
        if (balance < minBalance /*|| balance > maxBalance*/) {
            errorType += "Neteisingas likutis";
        }

        if (!errorType.isEmpty()) {
            Ks.ern("Neteisingai sukonfigūruota banko sąskaita: " + errorType);
        }
    }

    @Override
    public final void parse(String data) {
        try {   // duomenys, atskirti tarpais
            Scanner scanner = new Scanner(data);
            name = scanner.next();
            accountType = scanner.next();
            sSN = scanner.next();
            initDeposit = scanner.nextInt();
            setPrice(scanner.nextDouble());

        } catch (InputMismatchException e) {
            Ks.ern("Blogas duomenų formatas -> " + data);
        } catch (NoSuchElementException e) {
            Ks.ern("Trūksta duomenų -> " + data);
        }
    }

    public final void parseAlternative(String data, boolean random) {
        try {   // duomenys, atskirti tarpais
            Scanner scanner = new Scanner(data);
            if(!random)scanner.next();
            name = scanner.next();
            accountType = scanner.next();
            sSN = scanner.next();
            initDeposit = scanner.nextInt();
            setPrice(scanner.nextDouble());

        } catch (InputMismatchException e) {
            Ks.ern("Blogas duomenų formatas -> " + data);
        } catch (NoSuchElementException e) {
            Ks.ern("Trūksta duomenų -> " + data);
        }
    }

    @Override
    public String toString() {  // papildyta su carRegNr
        return RegNr + "=" + name + "_" + accountType + ":" + sSN + " " + initDeposit + " " + String.format("%4.1f", balance);
    }

    public String ToString_data1() {  // papildyta su carRegNr
        return RegNr + " " + name + " " + accountType + " " + sSN + " " + initDeposit + " " + String.format("%4.1f", balance);
    }
    public String ToString_data2() {  // papildyta su carRegNr
        return name + " " + accountType + " " + sSN + " " + initDeposit + " " + String.format("%4.1f", balance);
    }

    public String getName() {
        return name;
    }

    public String getAccountType() {
        return accountType;
    }

    public String getSSN() {
        return sSN;
    }

    public int getInitDeposit() {
        return initDeposit;
    }

    public double getBalance() {
        return balance;
    }

    // keisti bus galima tik kainą - kiti parametrai pastovūs
    public void setPrice(double balance) {
        this.balance = balance;
    }

    public String getRegNr() {  //** nauja.
        return RegNr;
    }

    @Override
    public int compareTo(Account account) {
        return getRegNr().compareTo(account.getRegNr());
    }

    // pradžioje pagal markes, o po to pagal modelius
    public static Comparator<Account> byBrand
            = (Account c1, Account c2) -> c1.accountType.compareTo(c2.accountType);

    public static Comparator<Account> byPrice = (Account c1, Account c2) -> {
        // didėjanti tvarka, pradedant nuo mažiausios
        if (c1.balance < c2.balance) {
            return -1;
        }
        if (c1.balance > c2.balance) {
            return +1;
        }
        return 0;
    };

    // metai mažėjančia tvarka, esant vienodiems lyginama kaina
    public static Comparator<Account> byYearPrice
            = (Account c1, Account c2) -> {
                if (c1.initDeposit > c2.initDeposit) {
                    return +1;
                }
                if (c1.initDeposit < c2.initDeposit) {
                    return -1;
                }
                if (c1.balance > c2.balance) {
                    return +1;
                }
                if (c1.balance < c2.balance) {
                    return -1;
                }
                return 0;
            };

    // Car klases objektų gamintojas (builder'is)
    public static class Builder {

        private final static Random RANDOM = new Random(2017);  // Atsitiktinių generatorius
        private final static String[][] MODELS = { // galimų type/brand/model masyvas
            {"Arielle_Duncan", "Savings", "444102638", "1444102638"},
            {"Hilary_Ward", "Checking", "5965723"},
            {"Agnes_Leonard", "Savings", "3827896", "123827896"},
            {"Clyde_Higgs", "Checking", "164445329"}
        };

        private String name = "";
        private String accountType = "";
        private String sSN = "";
        private int initDeposit = -1;
        private double balance = -1.0;

        public Account build() {
            return new Account(this);
        }

        public Account buildRandom() {
            int tIndex = RANDOM.nextInt(MODELS.length);        // markės indeksas  0..
            int mIndex = RANDOM.nextInt(MODELS[tIndex].length - 2) + 2;// modelio indeksas 1..
            return new Account(
                    MODELS[tIndex][0],
                    MODELS[tIndex][1],
                    MODELS[tIndex][mIndex],
                    2000 + RANDOM.nextInt(20), // metai tarp 1999 ir 2019
                    //                    2019,
                    10 + RANDOM.nextDouble() * 200_0); // kaina tarp 10 ir 201_0
        }

        public Builder name(String name) {
            this.name = name;
            return this;
        }

        public Builder accountType(String accountType) {
            this.accountType = accountType;
            return this;
        }

        public Builder sSN(String sSN) {
            this.sSN = sSN;
            return this;
        }

        public Builder initDeposit(int initDeposit) {
            this.initDeposit = initDeposit;
            return this;
        }

        public Builder balance(double balance) {
            this.balance = balance;
            return this;
        }
    }
}
