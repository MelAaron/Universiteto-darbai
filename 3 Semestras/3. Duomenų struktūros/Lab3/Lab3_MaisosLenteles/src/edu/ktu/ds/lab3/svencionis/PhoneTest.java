package edu.ktu.ds.lab3.svencionis;

import edu.ktu.ds.lab3.utils.HashType;
import edu.ktu.ds.lab3.utils.Ks;
import edu.ktu.ds.lab3.utils.ParsableHashMap;
import edu.ktu.ds.lab3.utils.ParsableMap;
import edu.ktu.ds.lab3.utils.HashMap;

import java.util.Locale;

public class PhoneTest {

    public static void main(String[] args) {
        Locale.setDefault(Locale.US); // suvienodiname skaičių formatus
        executeTest();
    }

    public static void executeTest() {
        Phone c1 = new Phone("Nokia", "3310", 1997, 50000, 1700);
        Phone c2 = new Phone("Samsung", "Galaxy", 2001, 20000, 3500);
        Phone c3 = new Phone("Iphone", "Max10", 2001, 20000, 8500.8);
        Phone c4 = new Phone("Motorola Simple 2001 115900 7500");
        Phone c5 = new Phone.Builder().buildRandom();
        Phone c6 = new Phone("Xiaomi   Guids  2007  36400 8500.3");
        Phone c7 = new Phone("OnePlus SIX 2001 115900 7500");
        Phone c8 = new Phone.Builder().buildRandom();
        Phone c9 = new Phone("Meskofonas 312 2005 100 50.2");
        Phone c10 = new Phone("TeslaPhone Ele 2020 3000 6969");

        // Raktų masyvas
        String[] phonesIds = {"TA156", "TA102", "TA178", "TA171", "TA105", "TA106", "TA107", "TA108"};
        int id = 0;
//        ParsableMap<String, Phone> phonesMap
//                = new ParsableHashMap<>(String::new, Phone::new, HashType.DIVISION);
        
        HashMap<String, Phone> phonesMap
                = new HashMap<>();

        // Reikšmių masyvas
        Phone[] phones = {c1, c2, c3, c4, c5, c6, c7};
        for (Phone c : phones) {
            phonesMap.put(phonesIds[id++], c);
        }
        //phonesMap.println("Porų išsidėstymas atvaizdyje pagal raktus");
        Ks.oun("Ar egzistuoja pora atvaizdyje?");
        Ks.oun(phonesMap.contains(phonesIds[6]));
        Ks.oun(phonesMap.contains(phonesIds[7]));
        Ks.oun("Pašalinamos poros iš atvaizdžio:");
        Ks.oun(phonesMap.remove(phonesIds[1]));
        Ks.oun(phonesMap.remove(phonesIds[7]));
        //phonesMap.println("Porų išsidėstymas atvaizdyje pagal raktus");
        Ks.oun("Atliekame porų paiešką atvaizdyje:");
        Ks.oun(phonesMap.get(phonesIds[2]));
        Ks.oun(phonesMap.get(phonesIds[7]));
        Ks.oun("Išspausdiname atvaizdžio poras String eilute:");
        Ks.ounn(phonesMap);
        
        Ks.oun("Mano testai:");
        Ks.oun("1. containsValue(Object value):");
        Ks.oun(phonesMap.containsValue(c7));
        Ks.oun("4. putIfAbsent(K key, V value):");
        Ks.oun(phonesMap.putIfAbsent(phonesIds[2], c9));
        Ks.oun("6. boolean replace(K key, V oldValue, V newValue):");
        Ks.oun(phonesMap.replace(phonesIds[0], c1, c9));
        Ks.oun("Map po replace:");
        Ks.ounn(phonesMap);
        Ks.oun("7. void replaceAll(V oldValue, V newValue):");
        //phonesMap.replace(phonesIds[3], c4, c9);
        phonesMap.replaceAll(c4, c10);
        Ks.oun(phonesMap);
        Ks.oun("numberOfEmpties");
        Ks.oun(phonesMap.numberOfEmpties());
        
        Ks.oun("values()");
        Ks.oun(phonesMap.values());
        
        
        
//        Ks.oun("");
//        Ks.oun("HashMapOa");
//        HashMapOa<String, Phone> phonesMapOa = new HashMapOa<>();
//        for (Phone c : phones) {
//            phonesMapOa.put(phonesIds[id++], c);
//        }
        
    }
}
