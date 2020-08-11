package proj;

import java.util.Comparator;

public class PointD {

    public String from;
    public String to;
    public double distance;
    public double flowTons;

    public PointD(String from, String to, double distance){
        this.from = from;
        this.to = to;
        this.distance = distance;
        this.flowTons = 0;
    }

    public PointD(String from, String to, double distance, double flowTons){
        this.from = from;
        this.to = to;
        this.distance = distance;
        this.flowTons = flowTons;
    }

    public PointD(String point, double flowTons){
        this.from = point;
        this.flowTons = flowTons;
    }

    public void addflowTons(double add){
        this.flowTons += add;
    }

    public  void addDistance(double add){
        this.distance += add;
    }

    public PointD addflowTonsIfEquals(String From, String To, double Tons){
        if(this.from.equals(From) && this.to.equals(To))
            this.flowTons += Tons;
        return this;
    }

    public boolean equals(String From, String To){
        if(this.from == From && this.to == To) return true;
        return false;
    }

    public double SSK (double warehouseCost, double variableWarehouseCost, double flow){
        return warehouseCost + variableWarehouseCost * flow;
    }

    @Override
    public String toString(){
        return from + " " + to + " " + distance + " " + flowTons + "\n";
    }
}
class Sortbyroll implements Comparator<PointD>
{
    // Used for sorting in ascending order of
    // roll number
//    public int compare(PointD a, PointD b)
//    {
//        if/*(a.flowTons == b.flowTons)*/(Math.abs(a.flowTons - b.flowTons) < 10000 )
//            return (int) (a.distance - b.distance);
//        return (int) (b.flowTons - a.flowTons);
//    }

    public int compare(PointD a, PointD b)
    {
        if(a.distance == b.distance)/*(Math.abs(a.distance - b.distance) < 100 )*/
            return (int) (b.flowTons - a.flowTons);
        return (int) (a.distance - b.distance);
    }
}
