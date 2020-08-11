/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package edu.ktu.ds.lab3.svencionis;

//import edu.ktu.ds.lab3.utils.HashMapOa;
import edu.ktu.ds.lab3.utils.EvaluableMap;
//import edu.ktu.ds.lab3.utils.HashMap;
import edu.ktu.ds.lab3.utils.ParsableMap;
import edu.ktu.ds.lab3.utils.HashType;
import edu.ktu.ds.lab3.utils.Ks;
import edu.ktu.ds.lab3.utils.Map;
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
 *
 * @author PC
 */
public class HashMapOa<K, V> implements EvaluableMap<K, V> {
//    Map<int, String> a = new Map<int, String>();
//    Map<int, string> myMap = new Map<int, string>();
    
    public static final int DEFAULT_INITIAL_CAPACITY = 16;
    public static final float DEFAULT_LOAD_FACTOR = 0.75f;
    public static final HashType DEFAULT_HASH_TYPE = HashType.DIVISION;
    
//    private final Function<String, K> keyCreateFunction;   // funkcija bazinio rakto objekto kūrimui
//    private final Function<String, V> valueCreateFunction; // funkcija bazinio reikšmės objekto kūrimui
    
    //protected Map<int, Node<K, V>> temm; //ar Node<K, V> turi but Map Key ar Value????

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
    

    /* Klasėje sukurti 4 perkloti konstruktoriai, nustatantys atskirus maišos 
     * lentelės parametrus. Jei kuris nors parametras nėra nustatomas - 
     * priskiriama standartinė reikšmė.
     */
    public HashMapOa() {
        this(DEFAULT_HASH_TYPE);
    }

    public HashMapOa(HashType ht) {
        this(DEFAULT_INITIAL_CAPACITY, ht);
    }

    public HashMapOa(int initialCapacity, HashType ht) {
        this(initialCapacity, DEFAULT_LOAD_FACTOR, ht);
    }

    public HashMapOa(float loadFactor, HashType ht) {
        this(DEFAULT_INITIAL_CAPACITY, loadFactor, ht);
    }

    public HashMapOa(int initialCapacity, float loadFactor, HashType ht) {
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
    
//    public HashMapOa(Function<String, K> keyCreateFunction,
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

        //if((index = findIndex(key)) == -1) return null;//hash(key, ht);
        index = hash(key,ht);
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
        HashMapOa<K, V> newMap = new HashMapOa<>(table.length * 2, loadFactor, ht);
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
    
    private int hash(K key, HashType hashType) {
        int h = key.hashCode();
        int returnas = -1;
        switch (hashType) {
            case DIVISION:
                returnas = Math.abs(h) % table.length;
                break;
            case MULTIPLICATION:
                double k = (Math.sqrt(5) - 1) / 2;
                returnas = (int) (((k * Math.abs(h)) % 1) * table.length);
                break;
            case JCF7:
                h ^= (h >>> 20) ^ (h >>> 12);
                h = h ^ (h >>> 7) ^ (h >>> 4);
                returnas = h & (table.length - 1);
                break;
            case JCF8:
                h = h ^ (h >>> 16);
                returnas = h & (table.length - 1);
                break;
            default:
                returnas = Math.abs(h) % table.length;
        }
        if(table[returnas]!= null){
            for(int i = 0; i < table.length;i++){
                int ind = returnas + (i*i);//%table.length;
                while(ind >= table.length){
                    ind -=table.length;
                }
                //if(ind >= table.length) ind -=table.length;
                if(table[ind] == null){
                    returnas = ind;
                    break;
                }
            }
//            int ind = returnas;
//            int i = 0;
//            while(table[ind] != null) {
//                ind = returnas + (i * i);//%table.length;
//                int k = ind/table.length;
//                ind -= table.length*k;
////                while (ind >= table.length) {
////                    ind -= table.length;
////                }
//                i++;
//                if (table[ind] == null) {
//                    returnas = ind;
//                    break;
//                }
//                //if(ind >= table.length) ind -=table.length;
//            }
            
            
//            int ind = 0;
//            int i = 0;
//            while(table[ind] != null){
//                ind = returnas + (i*i);
////                while(ind >= table.length)
////                    ind -= table.length;
//                if(ind >= table.length){
//                    ind = ind - table.length*(ind / table.length);
//                }
//                    
//                
//                if(table[ind] == null){
//                    returnas = ind;
//                    break;
//                }
//                i++;
//            }
        }
//            for(int i = 0; i < table.length;i++){
//                int ind = returnas + (i*i);//%table.length;
//                while(ind >= table.length){
//                    ind -=table.length;
//                }
//                //if(ind >= table.length) ind -=table.length;
//                if(table[ind] == null){
//                    returnas = ind;
//                    break;
//                }
//            }
        if(returnas == -1){
            rehash(table[0]);
            returnas = lastUpdatedChain;
        }
        return returnas;
    }
    int findIndex(K key) {
        if (key == null) {
            return -1;
        }
        int i = 0;
        for (Node<K, V> node : table) {
            if (node != null) {
                if (key.equals(node.key)) {
                    return i;
                }
            }
            i++;
        }
        return -1;
    }
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

//    private void rehash(Node<K, V> node) {
////        Node<K,V>[] oldArray = new Node<K, V>[table.length * 2];
////        for(int i = 0; i < table.length; i++)
////            oldArray[i] = table[i];
//        HashMapOa<K, V> newMap = new HashMapOa<>(table.length * 2, loadFactor, ht);
//        for(int i = 0; i < table.length; i++){
//            int ind = hash(table[i].key, ht);
//            int ha = 0;
//            while(newMap.table[ind] != null) //jei netuscia
//                ha = (ind + (int)Math.pow(i, 2)) % (newMap.size); //kitas yra (hash(key)+i^2) % size
//            newMap.table[ha].key = node.key;
//            newMap.table[ha].value = node.value;
//            size++;
//        }
//        table = newMap.table;
//        rehashesCounter++;
//
////        // Create a new double-sized, empty table
////        
////        //allocateArray(nextPrime(2 * oldArray.length));
////        size = 0;
////
////        // Copy table over
////        for (int i = 0; i < oldArray.length; i++) {
////            if (oldArray[i] != null) {
////                oldArray[i] = node;
////            }
////        }
//    }

    /**
     * Maišos funkcijos skaičiavimas: pagal rakto maišos kodą apskaičiuojamas
     * atvaizdžio poros indeksas maišos lentelės masyve
     *
     * @param key
     * @param hashType
     * @return
     */
//    private int hash(K key, HashType hashType) {
//        int h = key.hashCode();
//        switch (hashType) {
//            case DIVISION:
//                //double t = (double)h;
//                
//                //return (Math.abs(h) + Math.abs(h)*Math.abs(h)) % table.length;
//                return (Math.abs(h) % table.length + (Math.abs(h) % table.length * Math.abs(h) % table.length)) % table.length;
//            case MULTIPLICATION:
//                double k = (Math.sqrt(5) - 1) / 2;
//                //return (int)  ()
//                return (int) ((((k * Math.abs(h)) % 1) * table.length) + Math.pow((((k * Math.abs(h)) % 1) * table.length), 2)) % table.length;
//            case JCF7:
//                h ^= (h >>> 20) ^ (h >>> 12);
//                h = h ^ (h >>> 7) ^ (h >>> 4);
//                return ((h & (table.length - 1)) + (h & (table.length - 1)) * (h & (table.length - 1))) % table.length;
//            case JCF8:
//                h = h ^ (h >>> 16);
//                return ((h & (table.length - 1)) + (h & (table.length - 1))*(h & (table.length - 1))) % table.length;
//            default:
//                return ((Math.abs(h) % table.length) + (Math.abs(h) % table.length)*(Math.abs(h) % table.length)) % table.length;
//        }
//    }
    
//        private int hash(K key, HashType hashType) {
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
    
//    private int hash(K key, HashType hashType) {
//        int h = key.hashCode();
//        switch (hashType) {
//            case DIVISION:
//                //double t = (double)h;
//
//                //return (Math.abs(h) + Math.abs(h)*Math.abs(h)) % table.length;
//                //return ((Math.abs(h) % table.length) + ((Math.abs(h) % table.length) * (Math.abs(h) % table.length))) % table.length;
//                int ats = Math.abs(h) % table.length;
//                return (int) (ats + Math.pow(ats, 1)) % table.length;
//            case MULTIPLICATION:
//                double k = (Math.sqrt(5) - 1) / 2;
//                //return (int)  ()
//                ats = (int) (((k * Math.abs(h)) % 1) * table.length);
//                return (int) (ats + Math.pow(ats, 1)) % table.length;
//            //return (int) ((((k * Math.abs(h)) % 1) * table.length) + Math.pow((((k * Math.abs(h)) % 1) * table.length), 2)) % table.length;
//            case JCF7:
//                h ^= (h >>> 20) ^ (h >>> 12);
//                h = h ^ (h >>> 7) ^ (h >>> 4);
//                ats = ((h & (table.length - 1)) + (h & (table.length - 1)) * (h & (table.length - 1))) % table.length;
//                return (int) (ats + Math.pow(ats, 1)) % table.length;
//            case JCF8:
//                h = h ^ (h >>> 16);
//                ats = ((h & (table.length - 1)) + (h & (table.length - 1)) * (h & (table.length - 1))) % table.length;
//                return (int) (ats + Math.pow(ats, 1)) % table.length;
//            default:
//                ats = ((Math.abs(h) % table.length) + (Math.abs(h) % table.length) * (Math.abs(h) % table.length)) % table.length;
//                return (int) (ats + Math.pow(ats, 1)) % table.length;
//        }
//    }
    
//    @Override
//    public String[][] getModelList(String delimiter) {
//        String[][] result = new String[table.length][];
//        int count = 0;
//        for (Node<K, V> n : table) {
//            List<String> list = new ArrayList<>();
//            list.add("[ " + count + " ]");
//            while (n != null) {
//                list.add("-->");
//                list.add(split(n.toString(), delimiter));
//                n = n.next;
//            }
//            result[count] = list.toArray(new String[0]);
//            count++;
//        }
//        return result;
//    }
//    
//    private String split(String s, String delimiter) {
//        int k = s.indexOf(delimiter);
//        if (k <= 0) {
//            return s;
//        }
//        return s.substring(0, k);
//    }
//    
//    @Override
//    public void println(String title) {
//        Ks.ounn("========" + title + "=======");
//        println();
//        Ks.ounn("======== Atvaizdžio pabaiga =======");
//    }
//    
//    @Override
//    public void println() {
//        if (isEmpty()) {
//            Ks.oun("Atvaizdis yra tuščias");
//        } else {
//            String[][] data = getModelList("=");
//            for (int i = 0; i < data.length; i++) {
//                for (int j = 0; j < data[i].length; j++) {
//                    String format = (j == 0 | j % 2 == 1) ? "%7s" : "%15s";
//                    Object value = data[i][j];
//                    Ks.ouf(format, (value == null ? "" : value));
//                }
//                Ks.oufln("");
//            }
//        }
//
//        Ks.oufln("****** Bendras porų kiekis yra " + size());
//    }
//    
//    @Override
//    public void save(String filePath) {
//        throw new UnsupportedOperationException("Saugojimas.. nepalaikomas");
//    }
//    
//    @Override
//    public void load(String filePath) {
//        if (filePath == null || filePath.length() == 0) {
//            return;
//        }
//        clear();
//        try (BufferedReader fReader = Files.newBufferedReader(Paths.get(filePath), Charset.defaultCharset())) {
//            fReader.lines()
//                    .map(String::trim)
//                    .filter(line -> !line.isEmpty())
//                    .forEach(this::put);
//        } catch (FileNotFoundException e) {
//            Ks.ern("Tinkamas duomenų failas nerastas: " + e.getLocalizedMessage());
//        } catch (IOException | UncheckedIOException e) {
//            Ks.ern("Failo skaitymo klaida: " + e.getLocalizedMessage());
//        }
//    }
//    
//    @Override
//    public V put(String dataString) {
//        return put(
//                create(keyCreateFunction, dataString, "Nenustatyta raktų kūrimo funkcija"),
//                create(valueCreateFunction, dataString, "Nenustatyta reikšmių kūrimo funkcija")
//        );
//    }
//    
//    private static <T, R> R create(Function<T, R> function, T data, String errorMessage) {
//        return Optional.ofNullable(function)
//                .map(f -> f.apply(data))
//                .orElseThrow(() -> new IllegalStateException(errorMessage));
//    }

//    @Override
//    public V put(K key, V value) {
//        if (key == null || value == null) {
//            throw new IllegalArgumentException("Key or value is null in put(Key key, Value value)");
//        }
//        index = hash(key, ht);
//        int i = index;
//        while(table[i] != null){
//            i = i+i++;
//        }
//        chainsCounter++;
//        index = i % table.length;
//        Node<K,V> node = new Node<>(key,value,table[index]);
//        table[index] = node;
////        if (table[index] == null) {
////            chainsCounter++;
////        }
////        else{
////            index = hash(key,ht) +
////        }
//
////        Node<K, V> node = getInChain(key, table[index]);
////        if (node == null) { //jei nera node su tokiu raktu
////            table[index] = new Node<>(key, value, table[index]);
////            size++;
////
////            if (size > table.length * loadFactor) {
////                rehash(table[index]);
////            } else {
////                lastUpdatedChain = index;
////            }
////        } else { //jei jau yra node su tokiu raktu
////            node.value = value;
////            lastUpdatedChain = index;
////        }
//
//        return value;
//    }