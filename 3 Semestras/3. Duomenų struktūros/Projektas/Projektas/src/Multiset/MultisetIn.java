/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Multiset;

import java.util.Collection;
import java.util.Set;
import java.util.function.Consumer;

/**
 *
 * @author PC
 */
public interface MultisetIn<E> {
    /**
     * Adds a i amount of e elements to the multiset
     *
     * @param e element to be added to
     * @param i amount to be added to the element 
     * @return int, the previous amount of the element
     */
    int add(E e, int i);
    /**
     * Adds one e element to the multiset
     *
     * @param e element to be added to
     * @return true if added
     */
    boolean add(E e);
    /**
     * Adds a collection of e elements to the multiset
     *
     * @param c collection of to-be-added elements
     * @return true, added
     */
    boolean addAll(Collection<? extends E> c);
    
    //boolean addAll(E... e);
    /**
     * Executes a given action for each element in the multiset
     *
     * @param action amount to be added to the element 
     */
    void forEach(Consumer<? super E> action);
    /**
     * removes one occurance of the element from this set
     *
     * @param element element to be removed
     * @return true, if at least one element gets removed
     */
    public boolean remove(Object element);
    /**
     * removes a count amount of element elements from the Multiset
     *
     * @param element the element that is being removed
     * @param count amount of the element that is to be removed
     * @return true, if at least one element gets removed
     */
    int remove(Object element, int count);
    /**
     * Removes all of this collection's elements that are also contained in the specified collection (optional operation).
     *
     * @param c collection of to-remove elements
     * @return true, if at least one element gets removed
     */
    boolean removeAll(Collection<?> c); //-----
    /**
     * Checks if the element exists in this multiset
     *
     * @param element that is being checked
     * @return true, if element exists in the set
     */
    boolean contains(Object element);
    /**
     * Checks if the element exists in this multiset
     *
     * @param c collection of elements
     * @return true, if all elements exist in the set
     */
    boolean containsAll(Collection<?> c);
    /**
     * Changes the amount of the element
     *
     * @param celement the element whitch's count is being changed
     * @param new count of the element
     * @return int old count of the element
     */
    int setCount(E element, int count);
    /**
     * Retreives the count of an element
     *
     * @param element element of which the count will be retreived
     * @return int the count of the element
     */
    int getCount(Object element);
    /**
     * Returns a set of the elements in this multiset
     *
     * @return Set<E> of elements
     */
    Set<E> elementSet();
    /**
     * Checks if this set is empty
     *
     * @return true, if this set is empty
     */
    boolean isEmpty();
    /**
     * Gets the total size of this multiset
     *
     * @return the total amount of elements in this multiset
     */
    int totalSize();
    /**
     * Returns the length of this multiset
     *
     * @return int, amount of unique elements
     */
    int getSetLength();
    
    //String toString();
    
    //Set<Multiset.Entry<E>> entrySet();
    @Override
    boolean equals(Object object); //-------
    /**
     * Retains only the elements in this collection that are contained in the specified collection (optional operation).
     * Deletes everything but the elements that are in the given collection
     * @param c collection of to-retain elements
     * @return true, if at least one element has been retained
     */
    boolean retainAll(Collection<?> c);
    /**
     * Conditionally sets the count of an element to a new value, as described in setCount(Object, int), provided that the element has the expected current count
     * 
     * @param e element
     * @param oldCount old value
     * @param newCount new value
     * @return true, if at least one element has been retained
     */
    boolean setCount(E e, int oldCount, int newCount);
    /**
     * clears this multiset
     *
     */
    void clear();
    /**
     * Returns an array of the elements from this set
     *
     * @return Object array of the elements in this set
     */
    Object[] toArray();
    /**
     * Finds and returns the element with the biggest count
     *
     * @return the E element from this set with the highest count
     */
    E getMostFrequent();
    /**
     * Generates array of random strings
     *
     * @param count array size
     * @return String array of random strings
     */
    String[] randomStringArray(int count);
    /**
     * Generates multiset of random strings
     *
     * @param count multiset size
     * @return String multiset of random strings
     */
    Multiset<String> randomStringSet(int count);
     
     
}
