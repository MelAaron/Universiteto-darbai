/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Multiset;

import java.io.BufferedReader;
import java.io.FileNotFoundException;
import java.io.IOException;
import java.io.UncheckedIOException;
import java.nio.charset.Charset;
import java.nio.file.Files;
import java.nio.file.Paths;
import java.util.Optional;
import java.util.Random;
import java.util.function.Function;
import projektas.Ks;

/**
 *
 * @author PC
 */
public class ExtendedMultiset<E> extends Multiset<E> {
    ExtendedMultiset<String> a;
    public ExtendedMultiset(){
//        a = new Multiset<>();
    }
    
//    private final Function<String, E> keyCreateFunction;   // funkcija bazinio rakto objekto kūrimui
//    @Override
    public ExtendedMultiset<String> load(String filePath) {
        a = new ExtendedMultiset<>();
        if (filePath == null || filePath.length() == 0) {
            return a;
        }
        a.clear();
        try (BufferedReader fReader = Files.newBufferedReader(Paths.get(filePath), Charset.defaultCharset())) {
            fReader.lines()
                    .map(String::trim)
                    .filter(line -> !line.isEmpty())
                    .forEach(a::add);
        } catch (FileNotFoundException e) {
            Ks.ern("Tinkamas duomenų failas nerastas: " + e.getLocalizedMessage());
        } catch (IOException | UncheckedIOException e) {
            Ks.ern("Failo skaitymo klaida: " + e.getLocalizedMessage());
        }
        return a;
    }
    
//    public ExtendedMultiset<String> randomStringSet(int count) {
//        Random rn = new Random();
//        char[] chars = {'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k',
//            'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x',
//            'y', 'z', '0', '1', '2', '3', '4', '5', '6', '7', '8', '9'};
//        a = new ExtendedMultiset<>();
//        int b = rn.nextInt(20);
//        String temp;
//        StringBuilder sb = new StringBuilder();
//        for (int i = 0; i < count; i++) { //set ilgis
//            sb.delete(0, sb.length());
////            while(a == 0)
////                a = rn.nextInt(20);
//            for (int j = 0; j < b; j++) { //zodzio ilgis
//                sb.append(chars[rn.nextInt(chars.length)]);
////                temp += chars[rn.nextInt(chars.length)];
//            }
//            a.add(sb.toString());
//        }
//        return a;
//    }
    
    public String[] randomStringArray(int count) {
        Random rn = new Random();
        char[] chars = {'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k',
            'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x',
            'y', 'z', '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', ' '};
        String[] ret = new String[count];
//        Multiset<String> ret = new Multiset<>();
//        int a = rn.nextInt(20);
        String temp;
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < count; i++) { //set ilgis
            sb.delete(0, sb.length());
            int a = rn.nextInt(20);
            while(a == 0)
                a = rn.nextInt(20);
            for (int j = 0; j < a; j++) { //zodzio ilgis
                sb.append(chars[rn.nextInt(chars.length)]);
                a = rn.nextInt();
            }
            ret[i] = sb.toString();
        }
        return ret;
    }

    public ExtendedMultiset<String> randomStringSet(int count) {
        ExtendedMultiset<String> ret = new ExtendedMultiset<>();
        ret.addAll(randomStringArray(count));
        return ret;
    }
//    
////    @Override
//    public String put(String dataString) {
////        return super.add(dataString);
//        return super.add(
//                create(keyCreateFunction, dataString, "Nenustatyta raktų kūrimo funkcija")
////                create(valueCreateFunction, dataString, "Nenustatyta reikšmių kūrimo funkcija")
//        );
//    }
//    
//    private static <T, R> R create(Function<T, R> function, T data, String errorMessage) {
//        return Optional.ofNullable(function)
//                .map(f -> f.apply(data))
//                .orElseThrow(() -> new IllegalStateException(errorMessage));
//    }
    
}
