package edu.ktu.ds.lab2.svencionis;

import edu.ktu.ds.lab2.gui.ValidationException;

import java.util.Arrays;
import java.util.Collections;
import java.util.Random;
import java.util.stream.IntStream;
import java.util.stream.Stream;

public class MCGenerator {

    private int startIndex = 0, lastIndex = 0;
    private boolean isStart = true;

    private Microcontroller[] mcs;

    public Microcontroller[] generateShuffle(int setSize,
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
    public Microcontroller[] generateShuffle(int setSize,
                                 int setTake,
                                 double shuffleCoef) throws ValidationException {

        //Microcontroller[] mcs = generateInts(setSize);
        Microcontroller[] mcs = IntStream.range(0, setSize)
                .mapToObj(i -> new Microcontroller.Builder().buildRandom())
                .toArray(Microcontroller[]::new);
        return shuffle(mcs, setTake, shuffleCoef);
    }

    public Microcontroller takeMicrocontroller() throws ValidationException {
        if (lastIndex < startIndex) {
            throw new ValidationException(String.valueOf(lastIndex - startIndex), 4);
        }
        // Vieną kartą Automobilis imamas iš masyvo pradžios, kitą kartą - iš galo.
        isStart = !isStart;
        return mcs[isStart ? startIndex++ : lastIndex--];
    }
    private Integer[] ints;
    Random rg = new Random();
    public Integer[] generateInts(int count) {
        ints = new Integer[count];
        
        for (int i = 0; i < count; i++) {
            ints[i] = rg.nextInt(count);
        }
        Collections.shuffle(Arrays.asList(ints));
        return ints;
//        intsList.clear();
//        for (Integer c : ints) {
//            intsList.add(c);
//        }
    }

    private Microcontroller[] shuffle(Microcontroller[] mcs, int amountToReturn, double shuffleCoef) throws ValidationException {
        if (mcs == null) {
            throw new IllegalArgumentException("Mikrovaldikliu nėra (null)");
        }
        if (amountToReturn <= 0) {
            throw new ValidationException(String.valueOf(amountToReturn), 1);
        }
        if (mcs.length < amountToReturn) {
            throw new ValidationException(mcs.length + " >= " + amountToReturn, 2);
        }
        if ((shuffleCoef < 0) || (shuffleCoef > 1)) {
            throw new ValidationException(String.valueOf(shuffleCoef), 3);
        }

        int amountToLeave = mcs.length - amountToReturn;
        int startIndex = (int) (amountToLeave * shuffleCoef / 2);

        Microcontroller[] takeToReturn = Arrays.copyOfRange(mcs, startIndex, startIndex + amountToReturn);
        Microcontroller[] takeToLeave = Stream
                .concat(Arrays.stream(Arrays.copyOfRange(mcs, 0, startIndex)),
                        Arrays.stream(Arrays.copyOfRange(mcs, startIndex + amountToReturn, mcs.length)))
                .toArray(Microcontroller[]::new);

        Collections.shuffle(Arrays.asList(takeToReturn)
                .subList(0, (int) (takeToReturn.length * shuffleCoef)));
        Collections.shuffle(Arrays.asList(takeToLeave)
                .subList(0, (int) (takeToLeave.length * shuffleCoef)));

        this.startIndex = 0;
        this.lastIndex = takeToLeave.length - 1;
        this.mcs = takeToLeave;
        return takeToReturn;
    }
}
