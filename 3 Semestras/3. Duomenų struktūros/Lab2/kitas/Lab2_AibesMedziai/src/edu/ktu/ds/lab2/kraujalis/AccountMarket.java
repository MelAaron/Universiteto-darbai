/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package edu.ktu.ds.lab2.kraujalis;

import edu.ktu.ds.lab2.utils.BstSet;
import edu.ktu.ds.lab2.utils.Set;

/**
 *
 * @author Gvidas Kraujalis
 */
public class AccountMarket {

    public static Set<String> duplicateAccountType(Account[] accounts) {
        
        Set<Account> uni = new BstSet<>(Account.byBrand);
        Set<String> duplicates = new BstSet<>();
        
        for (Account account : accounts) {
            int sizeBefore = uni.size();
            uni.add(account);

            if (sizeBefore == uni.size()) {
                duplicates.add(account.getAccountType());
            }
        }
        return duplicates;
    }

    public static Set<String> uniqueProccesorModels(Account[] accounts) {
        Set<String> unikalusSSN = new BstSet<>();
        for (Account account : accounts) {
            unikalusSSN.add(account.getSSN());
        }
        return unikalusSSN;
    }
}
