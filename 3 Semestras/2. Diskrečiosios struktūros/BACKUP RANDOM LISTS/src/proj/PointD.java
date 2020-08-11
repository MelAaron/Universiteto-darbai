package proj;

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
