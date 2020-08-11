package edu.ktu.ds.lab3.svencionis;

import edu.ktu.ds.lab3.gui.ValidationException;
import edu.ktu.ds.lab3.utils.HashType;
import edu.ktu.ds.lab3.utils.Ks;
import edu.ktu.ds.lab3.utils.ParsableHashMap;
import edu.ktu.ds.lab3.utils.ParsableMap;

import java.util.*;
import java.util.concurrent.BlockingQueue;
import java.util.concurrent.Semaphore;

import java.io.*; 

/**
 * @author eimutis
 */
public class SimpleBenchmark {

    public static final String FINISH_COMMAND = "                               ";
    private static final ResourceBundle MESSAGES = ResourceBundle.getBundle("edu.ktu.ds.lab3.gui.messages");

    private final Timekeeper timekeeper;

    private final String[] BENCHMARK_NAMES = {"labHMput", "javaHMput", "HMOput", "labHMrem", "javaHMrem", "HMOrem"};
    private final int[] COUNTS = {60000, 10000, 20000, 40000, 80000};

    private final ParsableMap<String, Phone> phonesMap
            = new ParsableHashMap<>(String::new, Phone::new, 10, 0.75f, HashType.DIVISION);
    private final ParsableMap<String, Phone> phonesMap2
            = new ParsableHashMapOa<>(String::new, Phone::new, 10, 0.75f, HashType.DIVISION);
    private final edu.ktu.ds.lab3.utils.HashMap<String, String> phonesMap3 = new edu.ktu.ds.lab3.utils.HashMap<>();
    private final java.util.HashMap<String, String> phonesMap4 = new java.util.HashMap<>();
    private final HashMapOa<String, String> phonesMap5 = new HashMapOa();
    private final Queue<String> chainsSizes = new LinkedList<>();
    
    //private final Has

    /**
     * For console benchmark
     */
    public SimpleBenchmark() {
        timekeeper = new Timekeeper(COUNTS);
    }

    /**
     * For Gui benchmark
     *
     * @param resultsLogger
     * @param semaphore
     */
    public SimpleBenchmark(BlockingQueue<String> resultsLogger, Semaphore semaphore) {
        semaphore.release();
        timekeeper = new Timekeeper(COUNTS, resultsLogger, semaphore);
    }

    public static void main(String[] args) {
        executeTest();
    }

    public static void executeTest() {
        // suvienodiname skaičių formatus pagal LT lokalę (10-ainis kablelis)
        Locale.setDefault(new Locale("LT"));
        Ks.out("Greitaveikos tyrimas:\n");
        new SimpleBenchmark().startBenchmark();
    }

    public void startBenchmark() {
        try {
            benchmarkFile();
        } catch (InterruptedException e) {
            Thread.currentThread().interrupt();
        } catch (FileNotFoundException ex) {
            ex.printStackTrace(System.out);
        } catch (IOException exa){
                exa.printStackTrace();
                }
    }

    public void benchmark() throws InterruptedException {
        try {
            chainsSizes.add(MESSAGES.getString("maxChainLength"));
            chainsSizes.add("   kiekis      " + BENCHMARK_NAMES[0] + "   " + BENCHMARK_NAMES[1]);
            for (int k : COUNTS) {
                Phone[] phonesArray = PhonesGenerator.generateShufflePhones(k);
                String[] phonesIdsArray = PhonesGenerator.generateShuffleIds(k);
                
                phonesMap.clear();
                phonesMap2.clear();
                //phonesMap3.clear();
                timekeeper.startAfterPause();
                timekeeper.start();

                for (int i = 0; i < k; i++) {
                    phonesMap.put(phonesIdsArray[i], phonesArray[i]);
                }
                //phonesMap.load("C:\\Users\\PC\\Documents\\1.Stuff\\1. KTU\\3 Semestras\\Duomenu strukturos\\Lab3\\Lab3_MaisosLenteles\\data\\zodynas.txt");
                timekeeper.finish(BENCHMARK_NAMES[0]);

                String str = "   " + k + "          " + phonesMap.getMaxChainSize();
                for (int i = 0; i < k; i++) {
                    phonesMap2.put(phonesIdsArray[i], phonesArray[i]);
                }
                //phonesMap2.load("C:\\Users\\PC\\Documents\\1.Stuff\\1. KTU\\3 Semestras\\Duomenu strukturos\\Lab3\\Lab3_MaisosLenteles\\data\\zodynas.txt");
                timekeeper.finish(BENCHMARK_NAMES[1]);

                str += "         " + phonesMap2.getMaxChainSize();
                chainsSizes.add(str);

                Arrays.stream(phonesIdsArray).forEach(phonesMap::remove);
                timekeeper.finish(BENCHMARK_NAMES[2]);

                Arrays.stream(phonesIdsArray).forEach(phonesMap2::remove);
                timekeeper.finish(BENCHMARK_NAMES[3]);
                timekeeper.seriesFinish();
            }

            StringBuilder sb = new StringBuilder();
            chainsSizes.forEach(p -> sb.append(p).append(System.lineSeparator()));
            timekeeper.logResult(sb.toString());
            timekeeper.logResult(FINISH_COMMAND);
        } catch (ValidationException e) {
            timekeeper.logResult(e.getMessage());
        }
    }
    
    public void benchmarkFile() throws InterruptedException, FileNotFoundException, IOException {
        try {
            chainsSizes.add(MESSAGES.getString("maxChainLength"));
            chainsSizes.add("   kiekis      " + BENCHMARK_NAMES[0] + "   " + BENCHMARK_NAMES[2]);
            for (int k : COUNTS) {
                File file = new File("C:\\Users\\PC\\Documents\\1.Stuff\\1. KTU\\3 Semestras\\Duomenu strukturos\\Lab3\\Lab3_MaisosLenteles\\data\\zodynas.txt");
                String[] phonesArray = new String[k];
                phonesMap3.clear();
                phonesMap4.clear();
                phonesMap5.clear();
                

                BufferedReader br = new BufferedReader(new FileReader(file), k);
                String st;
                int i = 0;
                while ((st = br.readLine()) != null && i < k) {
                    phonesArray[i] = st;
                    i++;
                }
                timekeeper.startAfterPause();
                timekeeper.start();
                //Arrays.stream(phonesArray).forEach(phonesMap3::put);
                for(int j = 0; j < k; j++) phonesMap3.put(phonesArray[j], phonesArray[j]);
                String str = "   " + k + "          " + phonesMap3.getMaxChainSize();
                timekeeper.finish(BENCHMARK_NAMES[0]);

                //Arrays.stream(phonesArray).forEach(phonesMap4::put);
                for(int j = 0; j < k; j++) phonesMap4.put(phonesArray[j], phonesArray[j]);
                //str += "         " + phonesMap4.getMaxChainSize();
                timekeeper.finish(BENCHMARK_NAMES[1]);

                //Arrays.stream(phonesArray).forEach(phonesMap5::put);
                for(int j = 0; j < k; j++) phonesMap5.put(phonesArray[j], phonesArray[j]);
                str += "         " + phonesMap5.getMaxChainSize();
                chainsSizes.add(str);
                timekeeper.finish(BENCHMARK_NAMES[2]);
                
                Arrays.stream(phonesArray).forEach(phonesMap3::remove);
                timekeeper.finish(BENCHMARK_NAMES[3]);
                
                Arrays.stream(phonesArray).forEach(phonesMap4::remove);
                timekeeper.finish(BENCHMARK_NAMES[4]);
                
                Arrays.stream(phonesArray).forEach(phonesMap5::remove);
                timekeeper.finish(BENCHMARK_NAMES[5]);
                //              Arrays.stream(booksIdsArray).forEach(booksMap2::get);
//                timekeeper.finish(BENCHMARK_NAMES[3]);
                timekeeper.seriesFinish();
            }

            StringBuilder sb = new StringBuilder();
            chainsSizes.forEach(p -> sb.append(p).append(System.lineSeparator()));
            timekeeper.logResult(sb.toString());
            timekeeper.logResult(FINISH_COMMAND);
        } catch (ValidationException e) {
            timekeeper.logResult(e.getMessage());
        }
    }
}
