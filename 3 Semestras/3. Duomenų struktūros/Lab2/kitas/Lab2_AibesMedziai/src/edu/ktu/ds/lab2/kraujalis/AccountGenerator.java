/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package edu.ktu.ds.lab2.kraujalis;

import edu.ktu.ds.lab2.gui.ValidationException;
import java.util.Arrays;
import java.util.Collections;
import java.util.stream.IntStream;
import java.util.stream.Stream;

/**
 *
 * @author Gvidas Kraujalis
 */
public class AccountGenerator {

    private int startIndex = 0, lastIndex = 0;
    private boolean isStart = true;

    private Account[] accounts;

    public Account[] generateShuffle(int setSize,
                                 double shuffleCoef) throws ValidationException {

        return generateShuffle(setSize, setSize, shuffleCoef);
    }

    /**
     * @param setSize
     * @param setTake
     * @param shuffleCoef
     * @return Gražinamas aibesImtis ilgio masyvas
     * @throws ValidationException
     */
    public Account[] generateShuffle(int setSize, int setTake, double shuffleCoef) throws ValidationException {

        Account[] account = IntStream.range(0, setSize)
                .mapToObj(i -> new Account.Builder().buildRandom())
                .toArray(Account[]::new);
        return shuffle(account, setTake, shuffleCoef);
    }

    public Account takeCar() throws ValidationException {
        if (lastIndex < startIndex) {
            throw new ValidationException(String.valueOf(lastIndex - startIndex), 4);
        }
        // Vieną kartą Automobilis imamas iš masyvo pradžios, kitą kartą - iš galo.
        isStart = !isStart;
        return accounts[isStart ? startIndex++ : lastIndex--];
    }

    private Account[] shuffle(Account[] account, int amountToReturn, double shuffleCoef) throws ValidationException {
        if (account == null) {
            throw new IllegalArgumentException("Banko sąskaitų nėra (null)");
        }
        if (amountToReturn <= 0) {
            throw new ValidationException(String.valueOf(amountToReturn), 1);
        }
        if (account.length < amountToReturn) {
            throw new ValidationException(account.length + " >= " + amountToReturn, 2);
        }
        if ((shuffleCoef < 0) || (shuffleCoef > 1)) {
            throw new ValidationException(String.valueOf(shuffleCoef), 3);
        }

        int amountToLeave = account.length - amountToReturn;
        int startIndex = (int) (amountToLeave * shuffleCoef / 2);

        Account[] takeToReturn = Arrays.copyOfRange(account, startIndex, startIndex + amountToReturn);
        Account[] takeToLeave = Stream
                .concat(Arrays.stream(Arrays.copyOfRange(account, 0, startIndex)),
                        Arrays.stream(Arrays.copyOfRange(account, startIndex + amountToReturn, account.length)))
                .toArray(Account[]::new);

        Collections.shuffle(Arrays.asList(takeToReturn)
                .subList(0, (int) (takeToReturn.length * shuffleCoef)));
        Collections.shuffle(Arrays.asList(takeToLeave)
                .subList(0, (int) (takeToLeave.length * shuffleCoef)));

        this.startIndex = 0;
        this.lastIndex = takeToLeave.length - 1;
        this.accounts = takeToLeave;
        return takeToReturn;
    }
}
