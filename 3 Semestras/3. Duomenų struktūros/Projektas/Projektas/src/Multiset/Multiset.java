/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Multiset;

import java.util.*;
import java.util.function.Consumer;
import java.util.stream.Collectors;

/* A class representing a Mutable Multiset */
public class Multiset<E> implements MultisetIn<E>{

    ///List of unique E objects
    private final List<E> values;

    //List of amount of E objects
    private final List<Integer> counts;

    private final String errorMessage = "Count can't be < 0";
    
    /*
    *
    */
    public Multiset() {
        values = new ArrayList<>();
        counts = new ArrayList<>();
    }

    /**
     * Adds an element to this multiset a count number of times
     *
     * @param element The element to be added
     * @param count The number of times
     * @return The previous count of the element
     */
    @Override
    public int add(E element, int count) {
        if (count < 0) {
            throw new IllegalArgumentException(errorMessage + count);
        }

        int index = values.indexOf(element);
        int prevCount = 0;

        if (index != -1) {
            prevCount = counts.get(index);
            counts.set(index, prevCount + count);
        } else if (count != 0) {
            values.add(element);
            counts.add(count);
        }

        return prevCount;
    }

    /**
     * Adds specified element to this multiset once
     *
     * @param element The element to be added
     * @return true if added
     */
    @Override
    public boolean add(E element) {
        return add(element, 1) >= 0;
    }

    /**
     * Adds all elements in the specified collection to this multiset
     *
     * @param c Collection containing elements to be added
     * @return true if all elements are added to this multiset
     */
    @Override
    public boolean addAll(Collection<? extends E> c) {
        for (E element : c) {
            add(element, 1);
        }

        return true;
    }

    /**
     * Adds all elements in the specified array to this multiset
     *
     * @param arr An array containing elements to be added
     */
    public void addAll(E... arr) {

        for (E element : arr) {
            add(element, 1);
        }
    }
    
    /**
     * Removes a specified number of occurrences of the specified element from
     * this multiset
     *
     * @param element the element to removed
     * @param count the number of occurrences to be removed
     * @return the previous count
     */
    @Override
    public int remove(Object element, int count) {
        if (count < 0) {
            throw new IllegalArgumentException(errorMessage + count);
        }

        int index = values.indexOf(element);
        if (index == -1) {
            return 0;
        }

        int prevCount = counts.get(index);

        if (prevCount > count) {
            counts.set(index, prevCount - count);
        } else {
            values.remove(index);
            counts.remove(index);
        }

        return prevCount;
    }
    
    /**
     * Removes a single occurrence of specified element from this multiset
     *
     * @param element the element to removed
     * @return true if an occurrence was removed
     */
    @Override
    public boolean remove(Object element) {
        return remove(element, 1) > 0;
    }
    
    @Override
    public boolean removeAll(Collection<?> c){
        boolean ret = false;
        for(int i = 0; i < values.size(); i++)
            if(c.contains(values.get(i))){
                this.remove(values.get(i));
                ret = true;
            }
        return ret;
    }
    
    /**
     * Check if this multiset contains at least one occurrence of the specified
     * element
     *
     * @param element the element to-be-checked
     * @return true if this multiset contains given element
     */
    @Override
    public boolean contains(Object element) {
        return values.contains(element);
    }
    
    /**
     * Check if this multiset contains at least one occurrence of each element
     * in the specified collection
     *
     * @param c The collection of elements to be checked
     * @return true if this multiset contains at least one occurrence of each
     * element
     */
    @Override
    public boolean containsAll(Collection<?> c) {
        return values.containsAll(c);
    }
    
    /**
     * Change the counts of an element to the specified count or add element
     * to this multiset
     *
     * @param element the element to-be-updated
     * @param count the new count
     * @return the previous count
     */
    @Override
    public int setCount(E element, int count) {
        if (count < 0) {
            throw new IllegalArgumentException(errorMessage + count);
        }

        if (count == 0) {
            remove(element);
            return 0;
        }

        int index = values.indexOf(element);
        if (index == -1) {
            return add(element, count);
        }

        int prevCount = counts.get(index);
        counts.set(index, count);

        return prevCount;
    }
    
    /**
     * Find the counts of an element in this multiset
     *
     * @param element The element of which count will be returned
     * @return The counts of the element
     */
    @Override
    public int getCount(Object element) {
        int index = values.indexOf(element);
        
        if(index == -1) return 0;
        else return counts.get(index);
    }
    /**
    * Change the count of an element if it is equal to the oldC parameter
    *
    * @param e element which is to-be-changed
    * @param oldC old count that is being evaluated
    * @param newC count that could be changed to
    * @return true if changed, otherwise false
    */
    @Override
    public boolean setCount(E e, int oldC, int newC){
        int index = values.indexOf(e);
        if(counts.get(index) == oldC){
            setCount(e, newC);
            return true;
        }
        return false;
    }
    /**
    * Retains all elements that are in the given collection
    *
    * @param e collection of elements
    * @return true if retained at least one element
    */
    @Override
    public boolean retainAll(Collection<?> e){
        boolean ret = false;
        for(int i = 0; i < values.size(); i++)
            if(!e.contains(values.get(i))){
                this.remove(values.get(i));
                ret = true;
            }
        return ret;
    }
    
    /**
     * Sum of all element counts in this set
     * 
     * @return total number of elements in this multiset
     */
    @Override
    public int totalSize() {
        int size = 0;
        for (Integer i : counts) {
            size += i;
        }
        return size;
    }
    /**
     * returns the amount of unique elements in this multiset
     * @return amount of unique elements in this multiset(set length)
     */
    @Override
    public int getSetLength(){
        return values.size();
    }
    
    /**
     * Checks if the multiset is empty
     * 
     * @return true if this multiset is empty
     */
    @Override
    public boolean isEmpty() {
        return values.size() == 0;
    }

    /**
     * Performs the given action for each element
     *
     * @param action The action to-be-performed for each element
     */
    @Override
    public void forEach(Consumer<? super E> action) {
        List<E> all = new ArrayList<>();

        for (int i = 0; i < values.size(); i++) {
            for (int j = 0; j < counts.get(i); j++) {
                all.add(values.get(i));
            }
        }

        all.forEach(action);
    }

    /**
     * Creates a Set<E> of the elements in this set
     * 
     * @return A view of the set of elements in this multiset
     */
    @Override
    public Set<E> elementSet() {
        return values.stream().collect(Collectors.toSet());
    }
    /**
     * Clears this set
     */
    @Override
    public void clear(){
        values.clear();
        counts.clear();
    }
    /**
     * Generates a view of this multiset
     * @return formated view of this set
     */
    @Override
    public String toString() {
        StringBuilder sb = new StringBuilder("");
//        int counter = 0;
        for (int i = 0; i < values.size(); i++) {
//            sb.append(values.get(i));
            String myString = String.format("%1$-" + 22 + "s", values.get(i));
            sb.append(myString);
            
            if (counts.get(i) > 1) {
                sb.append(" -> ").append(counts.get(i));
            }
            
            if (i != values.size() - 1) {
//                sb.append(",      ");
                sb.append("\n");
            }
            
//            if(counter == 5){
//                counter = 0;
//                sb.append("\n");
//            }
//            counter++;
        }

        return sb.append("").toString();
    }
    /**
     * Creates and returns an array of elements from this multiset
     * @return array of the elements in this set
     */
    @Override
    public Object[] toArray(){
        return this.elementSet().toArray();
    }
    /**
     * Generates random string String array
     * @param count String array length
     * @return random string String array
     */
    @Override
    public String[] randomStringArray(int count){
        Random rn = new Random();
        char[] chars = {'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k',
             'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x',
              'y', 'z', '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', ' '};
        String[] ret = new String[count];
        StringBuilder sb = new StringBuilder();
        for(int i = 0; i < count; i++){ //set ilgis
            sb.delete(0, sb.length());
            int a = rn.nextInt(20);
            while(a == 0)
                a = rn.nextInt(20);
            for(int j = 0; j < a; j++){ //zodzio ilgis
                sb.append(chars[rn.nextInt(chars.length)]);
//                temp += chars[rn.nextInt(chars.length)];
            }
            ret[i] = sb.toString();
//            ret.add(sb.toString());
        }
        return ret;
    }
    /**
     * Generates random string multiset
     * @param count set length
     * @return string multiset of random strings
     */
    @Override
    public Multiset<String> randomStringSet(int count){
        Multiset<String> ret = new Multiset<>();
        ret.addAll(randomStringArray(count));
        return ret;
    }
    /**
     * Finds the element in this set with the highest count
     * @return the element with the highest count
     */
    @Override
    public E getMostFrequent(){
        int max = 0;
        int maxInd = -1;
        for(int i = 0; i < counts.size(); i++)
            if(counts.get(i) > max){
                max = counts.get(i);
                maxInd = i;
            }
        return values.get(maxInd);
    }
    
//    public void load(String filePath) {
//        if (filePath == null || filePath.length() == 0) {
//            return;
//        }
//        clear();
//        try (BufferedReader fReader = Files.newBufferedReader(Paths.get(filePath), Charset.defaultCharset())) {
//            fReader.lines()
//                    .map(String::trim)
//                    .filter(line -> !line.isEmpty())
//                    .forEach(this::add);
//        } catch (FileNotFoundException e) {
//            Ks.ern("Tinkamas duomenų failas nerastas: " + e.getLocalizedMessage());
//        } catch (IOException | UncheckedIOException e) {
//            Ks.ern("Failo skaitymo klaida: " + e.getLocalizedMessage());
//        }
//    }
}
