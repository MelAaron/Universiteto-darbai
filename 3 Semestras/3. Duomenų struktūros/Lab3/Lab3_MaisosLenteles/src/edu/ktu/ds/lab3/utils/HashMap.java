package edu.ktu.ds.lab3.utils;

import java.io.BufferedReader;
import java.io.FileNotFoundException;
import java.io.IOException;
import java.io.UncheckedIOException;
import java.nio.charset.Charset;
import java.nio.file.Files;
import java.nio.file.Paths;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;
import java.util.Optional;
import java.util.function.Function;

/**
 * Porų ("maping'ų") raktas-reikšmė objektų kolekcijos - atvaizdžio realizacija
 * maišos lentele, kolizijas sprendžiant atskirų grandinėlių (angl. separate
 * chaining) metodu. Neužmirškite, jei poros raktas - nuosavos klasės objektas,
 * pvz. klasės Car objektas, klasėje būtina perdengti metodus equals(Object o)
 * ir hashCode().
 *
 * @param <K> atvaizdžio raktas
 * @param <V> atvaizdžio reikšmė
 *
 * @Užduotis Peržiūrėkite ir išsiaiškinkite pateiktus metodus.
 *
 * @author darius.matulis@ktu.lt
 */
public class HashMap<K, V> implements EvaluableMap<K, V> {

    public static final int DEFAULT_INITIAL_CAPACITY = 16;
    public static final float DEFAULT_LOAD_FACTOR = 0.75f;
    public static final HashType DEFAULT_HASH_TYPE = HashType.DIVISION;

    // Maišos lentelė
    protected Node<K, V>[] table;
    // Lentelėje esančių raktas-reikšmė porų kiekis
    protected int size = 0;
    // Apkrovimo faktorius
    protected float loadFactor;
    // Maišos metodas
    protected HashType ht;
    //--------------------------------------------------------------------------
    //  Maišos lentelės įvertinimo parametrai
    //--------------------------------------------------------------------------
    // Maksimalus suformuotos maišos lentelės grandinėlės ilgis
    protected int maxChainSize = 0;
    // Permaišymų kiekis
    protected int rehashesCounter = 0;
    // Paskutinės patalpintos poros grandinėlės indeksas maišos lentelėje
    protected int lastUpdatedChain = 0;
    // Lentelės grandinėlių skaičius     
    protected int chainsCounter = 0;
    // Einamas poros indeksas maišos lentelėje
    protected int index = 0;
    //tusciu elementu skaicius
    //protected int numberOfEmpties = 0;
    
//    private final Function<String, K> keyCreateFunction;   // funkcija bazinio rakto objekto kūrimui
//    private final Function<String, V> valueCreateFunction; // funkcija bazinio reikšmės objekto kūrimui
    /* Klasėje sukurti 4 perkloti konstruktoriai, nustatantys atskirus maišos 
     * lentelės parametrus. Jei kuris nors parametras nėra nustatomas - 
     * priskiriama standartinė reikšmė.
     */
    public HashMap() {
        this(DEFAULT_HASH_TYPE);
    }

    public HashMap(HashType ht) {
        this(DEFAULT_INITIAL_CAPACITY, ht);
    }

    public HashMap(int initialCapacity, HashType ht) {
        this(initialCapacity, DEFAULT_LOAD_FACTOR, ht);
    }

    public HashMap(float loadFactor, HashType ht) {
        this(DEFAULT_INITIAL_CAPACITY, loadFactor, ht);
    }

    public HashMap(int initialCapacity, float loadFactor, HashType ht) {
        if (initialCapacity <= 0) {
            throw new IllegalArgumentException("Illegal initial capacity: " + initialCapacity);
        }

        if ((loadFactor <= 0.0) || (loadFactor > 1.0)) {
            throw new IllegalArgumentException("Illegal load factor: " + loadFactor);
        }

        this.table = new Node[initialCapacity];
        this.loadFactor = loadFactor;
        this.ht = ht;
    }
    
//    public HashMap(Function<String, K> keyCreateFunction,
//            Function<String, V> valueCreateFunction,
//            int initialCapacity,
//            float loadFactor,
//            HashType ht) {
//
//        //this(DEFAULT_INITIAL_CAPACITY, ht);
//        //this.table = new Node(initialCapacity, loadFactor, ht);
//        this(initialCapacity, loadFactor, ht);
//        
//        //this.table = new Node[initialCapacity];
//        //this.loadFactor = loadFactor;
//        this.keyCreateFunction = keyCreateFunction;
//        this.valueCreateFunction = valueCreateFunction;
//    }
    
    //-----------------------------------Privalomi-----------------------------
    public boolean containsValue(Object value){
        if(size == 0 || value == null) return false;
        for (Node<K, V> node : table) {
            if(node != null)
                for (Node<K, V> n = node; n != null; n = n.next) {
                    if(n.value.equals(value))
                return true;
                }
        }
        return false;
    }
    
    public V putIfAbsent(K key, V value){
        if(size == 0 || key == null) return null;
        if(get(key) == null){
            put(key, value);
            return null;
        }
        else return get(key);
    }
    
    public int numberOfEmpties(){
        int temp = 0;
        for(Node<K, V> node: table){
            if(node == null)
                temp++;
        }
        return temp;
    }
    //private final java.util.List<V> temp = new java.util.List<>();
    public java.util.List<V> values(){
        java.util.List<V> temp = new ArrayList<>();
        for(Node<K, V> node : table){
            if(node != null)
                for(Node<K, V> n = node; n != null; n = n.next){
                    temp.add(n.value);
                }
        }
        return temp;
    }
    //-----------------------------------Individualus--------------------------
    public boolean replace(K key, V oldValue, V newValue){
        if(size == 0 || key == null || oldValue == null || newValue == null) return false;
        if(!this.contains(key))return false;
        if(get(key).equals(oldValue)){
            put(key, newValue);
            return true;
        }
        return false;
    }
    
    public void replaceAll(V oldValue, V newValue){
        for (Node<K, V> node : table) {
            if (node != null) {
                for (Node<K, V> n = node; n != null; n = n.next) {
                    if (n.value.equals(oldValue)) {
                        put(n.key, newValue);
                    }
                }
            }
        }
    }

    /**
     * Patikrinama ar atvaizdis yra tuščias.
     *
     */
    @Override
    public boolean isEmpty() {
        return size == 0;
    }

    /**
     * Grąžinamas atvaizdyje esančių porų kiekis.
     *
     * @return Grąžinamas atvaizdyje esančių porų kiekis.
     */
    @Override
    public int size() {
        return size;
    }

    /**
     * Išvalomas atvaizdis.
     */
    @Override
    public void clear() {
        Arrays.fill(table, null);
        size = 0;
        index = 0;
        lastUpdatedChain = 0;
        maxChainSize = 0;
        rehashesCounter = 0;
        chainsCounter = 0;
    }

    /**
     * Patikrinama ar pora egzistuoja atvaizdyje.
     *
     * @param key raktas.
     * @return Patikrinama ar pora egzistuoja atvaizdyje.
     */
    @Override
    public boolean contains(K key) {
        return get(key) != null;
    }

    /**
     * Atvaizdis papildomas nauja pora.
     *
     * @param key raktas,
     * @param value reikšmė.
     * @return Atvaizdis papildomas nauja pora.
     */
    @Override
    public V put(K key, V value) {
        if (key == null || value == null) {
            throw new IllegalArgumentException("Key or value is null in put(Key key, Value value)");
        }
        index = hash(key, ht);
        if (table[index] == null) {
            chainsCounter++;
        }

        Node<K, V> node = getInChain(key, table[index]);
        if (node == null) {
            table[index] = new Node<>(key, value, table[index]);
            size++;

            if (size > table.length * loadFactor) {
                rehash(table[index]);
            } else {
                lastUpdatedChain = index;
            }
        } else {
            node.value = value;
            lastUpdatedChain = index;
        }

        return value;
    }

    /**
     * Grąžinama atvaizdžio poros reikšmė.
     *
     * @return Grąžinama atvaizdžio poros reikšmė.
     *
     * @param key raktas.
     */
    @Override
    public V get(K key) {
        if (key == null) {
            throw new IllegalArgumentException("Key is null in get(Key key)");
        }

        index = hash(key, ht);
        Node<K, V> node = getInChain(key, table[index]);
        return (node != null) ? node.value : null;
    }

    /**
     * Pora pašalinama iš atvaizdžio.
     *
     * @param key Pora pašalinama iš atvaizdžio.
     * @return key raktas.
     */
    @Override
    public V remove(K key) {
        if (key == null) {
            throw new IllegalArgumentException("Key is null in remove(Key key)");
        }

        index = hash(key, ht);
        Node<K, V> previous = null;
        for (Node<K, V> n = table[index]; n != null; n = n.next) {
            if ((n.key).equals(key)) {
                if (previous == null) {
                    table[index] = n.next;
                } else {
                    previous.next = n.next;
                }
                size--;

                if (table[index] == null) {
                    chainsCounter--;
                }
                return n.value;
            }
            previous = n;
        }
        return null;
    }

    /**
     * Permaišymas
     *
     * @param node
     */
    private void rehash(Node<K, V> node) {
        HashMap<K, V> newMap = new HashMap<>(table.length * 2, loadFactor, ht);
        for (int i = 0; i < table.length; i++) {
            while (table[i] != null) {
                if (table[i].equals(node)) {
                    lastUpdatedChain = i;
                }
                newMap.put(table[i].key, table[i].value);
                table[i] = table[i].next;
            }
        }
        table = newMap.table;
        maxChainSize = newMap.maxChainSize;
        chainsCounter = newMap.chainsCounter;
        rehashesCounter++;
        
    }

    /**
     * Maišos funkcijos skaičiavimas: pagal rakto maišos kodą apskaičiuojamas
     * atvaizdžio poros indeksas maišos lentelės masyve
     *
     * @param key
     * @param hashType
     * @return
     */
    private int hash(K key, HashType hashType) {
        int h = key.hashCode();
        switch (hashType) {
            case DIVISION:
                return Math.abs(h) % table.length;
            case MULTIPLICATION:
                double k = (Math.sqrt(5) - 1) / 2;
                return (int) (((k * Math.abs(h)) % 1) * table.length);
            case JCF7:
                h ^= (h >>> 20) ^ (h >>> 12);
                h = h ^ (h >>> 7) ^ (h >>> 4);
                return h & (table.length - 1);
            case JCF8:
                h = h ^ (h >>> 16);
                return h & (table.length - 1);
            default:
                return Math.abs(h) % table.length;
        }
    }
//    private int hash(K key, HashType hashType) {
//        int h = key.hashCode();
//        switch (hashType) {
//            case DIVISION:
//                //double t = (double)h;
//
//                //return (Math.abs(h) + Math.abs(h)*Math.abs(h)) % table.length;
//                //return ((Math.abs(h) % table.length) + ((Math.abs(h) % table.length) * (Math.abs(h) % table.length))) % table.length;
//                int ats = Math.abs(h) % table.length;
//                return (int) (ats + Math.pow(index, 2)) % table.length;
//            case MULTIPLICATION:
//                double k = (Math.sqrt(5) - 1) / 2;
//                //return (int)  ()
//                ats =(int)(((k * Math.abs(h)) % 1) * table.length);
//                return (int) (ats + Math.pow(index, 2)) % table.length;
//                //return (int) ((((k * Math.abs(h)) % 1) * table.length) + Math.pow((((k * Math.abs(h)) % 1) * table.length), 2)) % table.length;
//            case JCF7:
//                h ^= (h >>> 20) ^ (h >>> 12);
//                h = h ^ (h >>> 7) ^ (h >>> 4);
//                ats = ((h & (table.length - 1)) + (h & (table.length - 1)) * (h & (table.length - 1))) % table.length;
//                return (int) (ats + Math.pow(index, 2)) % table.length;
//            case JCF8:
//                h = h ^ (h >>> 16);
//                ats = ((h & (table.length - 1)) + (h & (table.length - 1)) * (h & (table.length - 1))) % table.length;
//                return (int) (ats + Math.pow(index, 2)) % table.length;
//            default:
//                ats = ((Math.abs(h) % table.length) + (Math.abs(h) % table.length) * (Math.abs(h) % table.length)) % table.length;
//                return (int) (ats + Math.pow(index, 2)) % table.length;
//        }
//    }

    /**
     * Paieška vienoje grandinėlėje
     *
     * @param key
     * @param node
     * @return
     */
    private Node<K, V> getInChain(K key, Node<K, V> node) {
        if (key == null) {
            throw new IllegalArgumentException("Key is null in getInChain(Key key, Node node)");
        }
        int chainSize = 0;
        for (Node<K, V> n = node; n != null; n = n.next) {
            chainSize++;
            if ((n.key).equals(key)) {
                return n;
            }
        }
        maxChainSize = Math.max(maxChainSize, chainSize + 1);
        return null;
    }

    @Override
    public String[][] toArray() {
        String[][] result = new String[table.length][];
        int count = 0;
        for (Node<K, V> n : table) {
            String[] list = new String[getMaxChainSize()];
            int countLocal = 0;
            while (n != null) {
                list[countLocal++] = n.toString();
                n = n.next;
            }
            result[count] = list;
            count++;
        }
        return result;
    }

    @Override
    public String toString() {
        StringBuilder result = new StringBuilder();
        for (Node<K, V> node : table) {
            if (node != null) {
                for (Node<K, V> n = node; n != null; n = n.next) {
                    result.append(n.toString()).append(System.lineSeparator());
                }
            }
        }
        return result.toString();
    }

    /**
     * Grąžina maksimalų grandinėlės ilgį.
     *
     * @return Maksimalus grandinėlės ilgis.
     */
    @Override
    public int getMaxChainSize() {
        return maxChainSize;
    }

    /**
     * Grąžina formuojant maišos lentelę įvykusių permaišymų kiekį.
     *
     * @return Permaišymų kiekis.
     */
    @Override
    public int getRehashesCounter() {
        return rehashesCounter;
    }

    /**
     * Grąžina maišos lentelės talpą.
     *
     * @return Maišos lentelės talpa.
     */
    @Override
    public int getTableCapacity() {
        return table.length;
    }

    /**
     * Grąžina paskutinės papildytos grandinėlės indeksą.
     *
     * @return Paskutinės papildytos grandinėlės indeksas.
     */
    @Override
    public int getLastUpdatedChain() {
        return lastUpdatedChain;
    }

    /**
     * Grąžina grandinėlių kiekį.
     *
     * @return Grandinėlių kiekis.
     */
    @Override
    public int getChainsCounter() {
        return chainsCounter;
    }
    
    //@Override
    public String[][] getModelList(String delimiter) {
        String[][] result = new String[table.length][];
        int count = 0;
        for (Node<K, V> n : table) {
            List<String> list = new ArrayList<>();
            list.add("[ " + count + " ]");
            while (n != null) {
                list.add("-->");
                list.add(split(n.toString(), delimiter));
                n = n.next;
            }
            result[count] = list.toArray(new String[0]);
            count++;
        }
        return result;
    }

    private String split(String s, String delimiter) {
        int k = s.indexOf(delimiter);
        if (k <= 0) {
            return s;
        }
        return s.substring(0, k);
    }
//////    
////    //@Override
//    public void load(String filePath) {
//        if (filePath == null || filePath.length() == 0) {
//            return;
//        }
//        clear();
//        try (BufferedReader fReader = Files.newBufferedReader(Paths.get(filePath), Charset.defaultCharset())) {
//            fReader.lines()
//                    .map(String::trim)
//                    .filter(line -> !line.isEmpty())
//                    .forEach(this::put); //cia problema jis nori to kito put metodo
//        } catch (FileNotFoundException e) {
//            Ks.ern("Tinkamas duomenų failas nerastas: " + e.getLocalizedMessage());
//        } catch (IOException | UncheckedIOException e) {
//            Ks.ern("Failo skaitymo klaida: " + e.getLocalizedMessage());
//        }
//    }
//    
//    public V put(String dataString) {
//        return put(
//                create(keyCreateFunction, dataString, "Nenustatyta raktų kūrimo funkcija"),
//                create(valueCreateFunction, dataString, "Nenustatyta reikšmių kūrimo funkcija")
//        );
//    }
//    private static <T, R> R create(Function<T, R> function, T data, String errorMessage) {
//        return Optional.ofNullable(function)
//                .map(f -> f.apply(data))
//                .orElseThrow(() -> new IllegalStateException(errorMessage));
//    }

    protected static class Node<K, V> {

        // Raktas        
        protected K key;
        // Reikšmė
        protected V value;
        // Rodyklė į sekantį grandinėlės mazgą
        protected Node<K, V> next;

        protected Node() {
        }

        protected Node(K key, V value, Node<K, V> next) {
            this.key = key;
            this.value = value;
            this.next = next;
        }

        @Override
        public String toString() {
            return key + "=" + value;
        }
    }
}
