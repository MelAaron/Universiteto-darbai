/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package edu.ktu.ds.lab1b.svencionis;

/**
 *
 * @author PC
 */
public class StarSearch {
    
    public StarList allStars = new StarList();
    
    public StarList getByDistance(int fromDistance, int toDistance) {
        StarList stars = new StarList();
        for (Star c : allStars) {
            if (c.getdistance() >= fromDistance && c.getdistance() <= toDistance) {
                stars.add(c);
            }
        }
        return stars;
    }
    public StarList getYoungerStars(int fromAge) {
        StarList stars = new StarList();
        for (Star c : allStars) {
            if (c.getAge()>= fromAge) {
                stars.add(c);
            }
        }
        return stars;
    }
     public StarList getBrightestStars() {
        StarList stars = new StarList();
        // formuojamas sąrašas su maksimalia reikšme vienos peržiūros metu
        double maxLuminocity = 0;
        for (Star c : allStars) {
            double luminocity = c.getLuminocity();
            if (luminocity >= maxLuminocity) {
                if (luminocity > maxLuminocity) {
                    stars.clear();
                    maxLuminocity = luminocity;
                }
                stars.add(c);
            }
        }
        return stars;
    }
     public StarList getByName(String makeAndModel) {
        StarList stars = new StarList();
        for (Star c : allStars) {
            String starMakeAndModel = c.getName();
            if (starMakeAndModel.startsWith(makeAndModel)) {
                stars.add(c);
            }
        }
        return stars;
    }
}
