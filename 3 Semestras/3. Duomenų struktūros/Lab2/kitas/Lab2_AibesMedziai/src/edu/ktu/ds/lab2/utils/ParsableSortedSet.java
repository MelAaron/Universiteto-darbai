package edu.ktu.ds.lab2.utils;

public interface ParsableSortedSet<E> extends SortedSet<E> {

    void add(String dataString);

    void load(String fName);
    
    //String toVisualizedString(String dataCodeDelimiter); ar reikalinga

    Object clone() throws CloneNotSupportedException;
}
