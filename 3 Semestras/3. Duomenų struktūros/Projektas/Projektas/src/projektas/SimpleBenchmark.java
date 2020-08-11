package projektas;

import Multiset.ExtendedMultiset;
import Multiset.Multiset;
//import edu.ktu.ds.lab2.gui.ValidationException;
//import edu.ktu.ds.lab2.utils.*;

import java.util.Arrays;
import java.util.Collections;
import java.util.Random;
import java.util.HashSet;
import java.util.Locale;
import java.util.ResourceBundle;
import java.util.Set;
import java.util.TreeSet;
import java.util.concurrent.BlockingQueue;
import java.util.concurrent.Semaphore;

public class SimpleBenchmark {

    public static final String FINISH_COMMAND = "                       ";
    private static final ResourceBundle MESSAGES = ResourceBundle.getBundle("projektas.messages");

    private static final String[] BENCHMARK_NAMES = {"add", "remove", "setCount", "removeAll", "addAll", "totalSize"};
    private static final int[] COUNTS = {600000, 100000, 200000, 400000, 800000};

    private final Timekeeper timeKeeper;
    private final String[] errors;

    private ExtendedMultiset<String> testset = /*(ExtendedMultiset<String>)*/ new ExtendedMultiset<String>();
//    private final HashSet<Integer> cSeries2 = new HashSet<>();
    //private final SortedSet<Microcontroller> cSeries3 = new AvlSet<>(Microcontroller.byPrice);

    /**
     * For console benchmark
     */
    public SimpleBenchmark() {
        timeKeeper = new Timekeeper(COUNTS);
        errors = new String[]{
                MESSAGES.getString("badSetSize"),
                MESSAGES.getString("badInitialData"),
                MESSAGES.getString("badSetSizes"),
                MESSAGES.getString("badShuffleCoef")
        };
    }

    /**
     * For Gui benchmark
     *
     * @param resultsLogger
     * @param semaphore
     */
    public SimpleBenchmark(BlockingQueue<String> resultsLogger, Semaphore semaphore) {
        semaphore.release();
        timeKeeper = new Timekeeper(COUNTS, resultsLogger, semaphore);
        errors = new String[]{
                MESSAGES.getString("badSetSize"),
                MESSAGES.getString("badInitialData"),
                MESSAGES.getString("badSetSizes"),
                MESSAGES.getString("badShuffleCoef")
        };
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
            benchmark();
        } catch (InterruptedException e) {
            Thread.currentThread().interrupt();
        } catch (Exception ex) {
            ex.printStackTrace(System.out);
        }
    }
    Random rg = new Random();

    private void benchmark() throws InterruptedException {
        try {
            for (int k : COUNTS) {
//                testset = testset.load("C:\\Users\\PC\\Documents\\1.Stuff\\1. KTU\\3 Semestras\\Duomenu strukturos\\Projektas\\data\\zodynas.txt");
                generateStrings(k);
//                testset = testset.randomStringSet(k);
//                System.out.println(testset);
                Set<String> temp = testset.elementSet();
                
                timeKeeper.startAfterPause();
                timeKeeper.start();
                for(String a : temp)
                    testset.add(a);
//                Arrays.stream(temp).forEach(testset::add);
                timeKeeper.finish(BENCHMARK_NAMES[0]);
                for(String a : temp)
                    testset.remove(a);
//                Arrays.stream(mcs).forEach(cSeries2::add);
                timeKeeper.finish(BENCHMARK_NAMES[1]);
                for(String a : temp)
                    testset.setCount(a, rg.nextInt(100));
//                Arrays.stream(mcs).forEach(cSeries::remove);
                timeKeeper.finish(BENCHMARK_NAMES[2]);
                testset.removeAll(temp);
//                Arrays.stream(mcs).forEach(cSeries2::remove);
                timeKeeper.finish(BENCHMARK_NAMES[3]);
                testset.addAll(temp);
                timeKeeper.finish(BENCHMARK_NAMES[4]);
                testset.totalSize();
                timeKeeper.finish(BENCHMARK_NAMES[5]);
                timeKeeper.seriesFinish();
            }
            timeKeeper.logResult(FINISH_COMMAND);
        } catch (Exception e) {
            timeKeeper.logResult(MESSAGES.getString("Idk"));
//            if (e.getCode() >= 0 && e.getCode() <= 3) {
//                timeKeeper.logResult(errors[e.getCode()] + ": ", e.getMessage());
//            } else if (e.getCode() == 4) {
//                timeKeeper.logResult(MESSAGES.getString("allSetIsPrinted"));
//            } else {
//                timeKeeper.logResult(e.getMessage());
//            }
        }
    }
//    Random rg = new Random();
    String[] strings;
    public void generateStrings(int count){
        String[] ch = {"aa\n",
"aah",
"aahed",
"aahing",
"aahs",
"aal",
"aalii",
"aaliis",
"aals",
"aardvark",
"aardwolf",
"aargh",
"aarrgh",
"aarrghh",
"aas",
"aasvogel",
"ab",
"aba",
"abaca",
"abacas",
"abaci",
"aback",
"abacus",
"abacuses",
"abaft",
"abaka",
"abakas"};
        strings = new String[count];
        for (int i = 0; i < count; i++){
            strings[i] = ch[rg.nextInt(ch.length)];
        }
        Collections.shuffle(Arrays.asList(strings));
        testset.clear();
        for (String c : strings) {
            testset.add(c);
//            System.out.println(testset);
        }
        
    }
    
    public String[] getRandomStringSet(int count){
        generateStrings(count);
        return (String[])testset.elementSet().toArray();
    }
}
