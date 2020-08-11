/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package projektas;

//import Multiset.MultisetIn;
import Multiset.Multiset;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;
/**
 *
 * @author PC
 */
public class Projektas {

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
        // TODO code application logic here
        test();
    }
    
    public static void test(){
        Multiset<String> set = new Multiset();
        
        set.add("Arnas",3);
        set.add("Minde", 55);
        set.add("Justinas", 20);
        set.add("Vilte",15);
        set.add("Edvis");
        System.out.println(set);
        System.out.println("");
        
        System.out.println("Add");
        set.add("Minde");
        set.add("Arnas", 0);
        set.add("Edvis", 2);
        set.add("Vilte", 4);
        System.out.println(set);
        System.out.println("");
        
        System.out.println("Remove");
        set.remove("Minde");
        set.remove("Arnas", 2);
        set.remove("Edvis", 3);
        System.out.println(set);
        System.out.println("");
        
        System.out.println("Count(Element e)");
        System.out.println(set.getCount("Minde"));
        System.out.println("");
        
        System.out.println("setCount(Element e, int c)");
        set.setCount("Arnas", 22);
        System.out.println(set);
        System.out.println("");
        
        List<String> lis = new ArrayList<>();
        String[] a = {"Don", "Joshua", "Tim", "Tyrone"};
        lis.addAll(Arrays.asList(a));
        System.out.println("addAll");
        set.addAll(lis);
        System.out.println(set);
        System.out.println("");
        System.out.println("addAll again");
        set.addAll(lis);
        System.out.println(set);
        System.out.println("");
        
        System.out.println("removeAll");
        set.removeAll(lis);
        System.out.println(set);
        System.out.println("");
        
        System.out.println("containsAll");
        System.out.println(set.containsAll(lis));
        System.out.println("");
        
        System.out.println("removeAll");
        set.removeAll(lis);
        System.out.println(set);
        System.out.println("");
        
        System.out.println("Contains");
        System.out.println(set.contains("Arnas"));
        System.out.println(set.contains("Lukas"));
        System.out.println("");
        
        System.out.println("containsAll");
        System.out.println(set.containsAll(lis));
        System.out.println("");
        
        System.out.println("isEmpty");
        System.out.println(set.isEmpty());
        System.out.println("");
        
        System.out.println("size(Visu kiekiai sudeti)");
        System.out.println(set.getSetLength());
        System.out.println("");
        
        System.out.println("retainAll");
        set.addAll(lis);
        System.out.println(set);
        System.out.println("");
        set.retainAll(lis);
        System.out.println(set);
        System.out.println("");
    }
    
}
