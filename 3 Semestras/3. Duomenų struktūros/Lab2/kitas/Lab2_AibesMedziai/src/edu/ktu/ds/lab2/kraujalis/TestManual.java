/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package edu.ktu.ds.lab2.kraujalis;

import edu.ktu.ds.lab2.utils.BstSet;
import edu.ktu.ds.lab2.utils.Ks;
import edu.ktu.ds.lab2.utils.ParsableAvlSet;
import edu.ktu.ds.lab2.utils.ParsableBstSet;
import edu.ktu.ds.lab2.utils.ParsableSortedSet;
import edu.ktu.ds.lab2.utils.Set;
import java.util.Arrays;
import java.util.Collections;
import java.util.Iterator;
import java.util.Locale;

import edu.ktu.ds.lab2.utils.*;

import java.util.Arrays;
import java.util.Collections;
import java.util.Iterator;
import java.util.Locale;

/**
 *
 * @author Gvidas Kraujalis
 */
public class TestManual {

    static Account[] accounts;
    static ParsableSortedSet<Account> cSeries = new ParsableBstSet<>(Account::new, Account.byPrice);

    public static void main(String[] args) throws CloneNotSupportedException {
        Locale.setDefault(Locale.US); // Suvienodiname skaičių formatus
        executeTest();
    }

    public static void executeTest() throws CloneNotSupportedException {
        Account c1 = new Account("Darnell_Goodman", "Savings", "469426397", 15000, 12093);
        Account c2 = new Account.Builder()
                .name("Luella_Bradbury")
                .accountType("Savings")
                .sSN("217512645")
                .initDeposit(1500)
                .balance(499)
                .build();
        Account c3 = new Account.Builder().buildRandom();
        Account c4 = new Account("Eliseo_Waller", "Savings", "395157182", 12500, 500);
        Account c5 = new Account("Fredia_Hastings", "Checking", "208728517", 6500, 12);
        Account c6 = new Account("Frankie_Davidson", "Checking", "2607927", 10000, 979);
        Account c7 = new Account("Melody_Potts Savings 687057316 1500 465");
        Account c8 = new Account("Deadra_Power Checking 9545701 4500 798");
        Account c9 = new Account("Shila_Obrien Savings 233479044 2200 9887");

        Account[] AccountArray = {c9, c7, c8, c5, c1, c6};

        Ks.oun("Accountų Aibė:");
        ParsableSortedSet<Account> AccountSet = new ParsableBstSet<>(Account::new);

        for (Account c : AccountArray) {
            AccountSet.add(c);
            Ks.oun("Aibė papildoma: " + c + ". Jos dydis: " + AccountSet.size());
        }
        Ks.oun("");
        Ks.oun(AccountSet.toVisualizedString(""));
//-------------------------------------------------------------------------------------------------------------
        BstSet<Account> beginer;
        beginer = new BstSet<>();
        beginer.add(new Account("Marybeth_Sanders Checking 431551383 2500 654"));
        beginer.add(new Account("Hattie_Storey Checking 476687875 3500 798",false));
        beginer.add(new Account("Florinda_Goulding Checking 233025468 25000 132",false));
        //beginer.add(new Account(" GPU testing vega_64 2017 579",false));!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        ParsableBstSet<Account> testing;
        testing = (ParsableBstSet<Account>) AccountSet;
        testing.addAll(beginer);

        //Ks.oun("addall");
        Ks.oun(AccountSet.toVisualizedString(""));
        
        AccountSet.headSet(new Account("Hattie_Storey Checking 476687875 3500 798",false));
        
        //Ks.oun("headset TA222");
        Ks.oun(AccountSet.toVisualizedString(""));
        
//-------------------------------------------------------------------------------------------------------------
        ParsableSortedSet<Account> AccountSetCopy = (ParsableSortedSet<Account>) AccountSet.clone();

        AccountSetCopy.add(c2);
        AccountSetCopy.add(c3);
        AccountSetCopy.add(c4);
        Ks.oun("Papildyta Account kopija:");
        Ks.oun(AccountSetCopy.toVisualizedString(""));

        c9.setPrice(420);

        Ks.oun("Originalas:");
        Ks.ounn(AccountSet.toVisualizedString(""));

        Ks.oun("Ar elementai egzistuoja aibėje?");
        for (Account c : AccountArray) {
            Ks.oun(c + ": " + AccountSet.contains(c));
        }
        Ks.oun(c2 + ": " + AccountSet.contains(c2));
        Ks.oun(c3 + ": " + AccountSet.contains(c3));
        Ks.oun(c4 + ": " + AccountSet.contains(c4));
        Ks.oun("");

        Ks.oun("Ar elementai egzistuoja aibės kopijoje?");
        for (Account c : AccountArray) {
            Ks.oun(c + ": " + AccountSetCopy.contains(c));
        }
        Ks.oun(c2 + ": " + AccountSetCopy.contains(c2));
        Ks.oun(c3 + ": " + AccountSetCopy.contains(c3));
        Ks.oun(c4 + ": " + AccountSetCopy.contains(c4));
        Ks.oun("");

        Ks.oun("Elementų šalinimas iš kopijos. Aibės dydis prieš šalinimą:  " + AccountSetCopy.size());
        for (Account c : new Account[]{c2, c1, c9, c8, c5, c3, c4, c2, c7, c6, c7, c9}) {
            AccountSetCopy.remove(c);
            Ks.oun("Iš autoaibės kopijos pašalinama: " + c + ". Jos dydis: " + AccountSetCopy.size());
        }
        Ks.oun("");

        Ks.oun("Accountų aibė su iteratoriumi:");
        Ks.oun("");
        for (Account c : AccountSet) {
            Ks.oun(c);
        }
        Ks.oun("");
        Ks.oun("Accountų aibė AVL-medyje:");
        ParsableSortedSet<Account> AccountSetAvl = new ParsableAvlSet<>(Account::new);
        for (Account c : AccountArray) {
            AccountSetAvl.add(c);
        }
        Ks.ounn(AccountSetAvl.toVisualizedString(""));

        Ks.oun("Accountų aibė su iteratoriumi:");
        Ks.oun("");
        for (Account c : AccountSetAvl) {
            Ks.oun(c);
        }

        Ks.oun("");
        Ks.oun("Accountų aibė su atvirkštiniu iteratoriumi:");
        Ks.oun("");
        Iterator iter = AccountSetAvl.descendingIterator();
        while (iter.hasNext()) {
            Ks.oun(iter.next());
        }

        Ks.oun("");
        Ks.oun("Accountų aibės toString() metodas:");
        Ks.ounn(AccountSetAvl);

        // Išvalome ir suformuojame aibes skaitydami iš failo
        AccountSet.clear();
        AccountSetAvl.clear();

        Ks.oun("");
        Ks.oun("Accountų aibė DP-medyje:");
        AccountSet.load("data\\ban3.txt");//!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        Ks.ounn(AccountSet.toVisualizedString(""));
        Ks.oun("Išsiaiškinkite, kodėl medis augo tik į vieną pusę.");

        Ks.oun("");
        Ks.oun("Accountų aibė AVL-medyje:");//!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        AccountSetAvl.load("data\\ban3.txt");
        Ks.ounn(AccountSetAvl.toVisualizedString(""));

        Set<String> carsSet4 = AccountMarket.duplicateAccountType(AccountArray);
        Ks.oun("Pasikartojantys Accountų tipai is avl:\n" + carsSet4.toString());

        Set<String> carsSet5 = AccountMarket.uniqueProccesorModels(AccountArray);
        Ks.oun("Unikalūs Accountų tipai is avl:\n" + carsSet5.toString());
    }

    static ParsableSortedSet generateSet(int kiekis, int generN) {
        accounts = new Account[generN];
        for (int i = 0; i < generN; i++) {
            accounts[i] = new Account.Builder().buildRandom();
        }
        Collections.shuffle(Arrays.asList(accounts));

        cSeries.clear();
        Arrays.stream(accounts).limit(kiekis).forEach(cSeries::add);
        return cSeries;
    }
}
