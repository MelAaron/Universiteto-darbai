/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package edu.ktu.ds.lab1b.svencionis;

import edu.ktu.ds.lab1b.util.ParsableList;
import java.util.Random;
/**
 *
 * @author PC
 */
public class StarList extends ParsableList<Star> {
    
    

    public StarList() {
    }
    
    public StarList(int count) {
        super();
        String[][] makesAndModels = {
            {"Mazda", "121", "323", "626", "MX6"},
            {"Ford", "Fiesta", "Escort", "Focus", "Sierra", "Mondeo"},
            {"Saab", "92", "96"},
            {"Honda", "Accord", "Civic", "Jazz"},
            {"Renault", "Laguna", "Megane", "Twingo", "Scenic"},
            {"Peugeot", "206", "207", "307"}
        };
        Random rnd = new Random();
        rnd.setSeed(2017);
        for (int i = 0; i < count; i++) {
            int makeIndex = rnd.nextInt(makesAndModels.length);
            int modelIndex = rnd.nextInt(makesAndModels[makeIndex].length - 1) + 1;
            add(new Star(makesAndModels[makeIndex][0], makesAndModels[makeIndex][modelIndex].length(),
                    1994 + rnd.nextInt(20),
                    100 + 100_000 * rnd.nextInt(),
                    15 + rnd.nextInt(500)));
        }
    }
    
    @Override
    protected Star createElement(String data) {
        return new Star(data);
    }
}
