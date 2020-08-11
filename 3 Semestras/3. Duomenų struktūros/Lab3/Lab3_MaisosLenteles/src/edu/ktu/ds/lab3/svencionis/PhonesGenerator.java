package edu.ktu.ds.lab3.svencionis;

import edu.ktu.ds.lab3.gui.ValidationException;
import java.util.Arrays;
import java.util.Collections;
import java.util.stream.IntStream;

public class PhonesGenerator {

    private static final String ID_CODE = "TA";      //  ***** Nauja
    private static int serNr = 10000;               //  ***** Nauja

    private Phone[] phones;
    private String[] keys;

    private int currentPhoneIndex = 0, currentPhoneIdIndex = 0;

    public static Phone[] generateShufflePhones(int size) {
        Phone[] phones = IntStream.range(0, size)
                .mapToObj(i -> new Phone.Builder().buildRandom())
                .toArray(Phone[]::new);
        Collections.shuffle(Arrays.asList(phones));
        return phones;
    }

    public static String[] generateShuffleIds(int size) {
        String[] keys = IntStream.range(0, size)
                .mapToObj(i -> ID_CODE + (serNr++))
                .toArray(String[]::new);
        Collections.shuffle(Arrays.asList(keys));
        return keys;
    }

    public Phone[] generateShufflePhonesAndIds(int setSize,
            int setTakeSize) throws ValidationException {

        if (setTakeSize > setSize) {
            setTakeSize = setSize;
        }
        phones = generateShufflePhones(setSize);
        keys = generateShuffleIds(setSize);
        this.currentPhoneIndex = setTakeSize;
        return Arrays.copyOf(phones, setTakeSize);
    }

    // Imamas po vienas elementas iš sugeneruoto masyvo. Kai elementai baigiasi sugeneruojama
    // nuosava situacija ir išmetamas pranešimas.
    public Phone getPhone() {
        if (phones == null) {
            throw new ValidationException("phonesNotGenerated");
        }
        if (currentPhoneIndex < phones.length) {
            return phones[currentPhoneIndex++];
        } else {
            throw new ValidationException("allSetStoredToMap");
        }
    }

    public String getPhoneId() {
        if (keys == null) {
            throw new ValidationException("phonesIdsNotGenerated");
        }
        if (currentPhoneIdIndex < keys.length) {
            return keys[currentPhoneIdIndex++];
        } else {
            throw new ValidationException("allKeysStoredToMap");
        }
    }
}
