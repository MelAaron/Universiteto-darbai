/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package demos.graphics;

import static javafx.application.Application.launch;
import javafx.scene.image.Image;
import extendsFX.BaseGraphics;
import java.text.DecimalFormat;
import java.util.ArrayList;
import java.util.List;
import javafx.animation.AnimationTimer;
import javafx.event.EventHandler;
import javafx.scene.paint.Color;
import javafx.scene.shape.*;
import javafx.stage.Stage;
import javafx.scene.image.Image;
import javafx.scene.image.ImageView;
import javafx.scene.input.MouseButton;
import javafx.scene.input.MouseEvent;
import javafx.scene.text.Text;
/**
 *
 * @author PC
 */
public class Papildoma extends BaseGraphics  {
    
    Image map = new Image( "images\\area-map-of-lithuania.png" );
    
    double click1X;
    double click1Y;
    double click2X;
    double click2Y;
    
    void createMap(){
        gc.drawImage(map, 0, 0 );
        
    }
    
     Polygon polygon = null;      
    List<Ball> balls = new ArrayList<>(); // saugomi kilnojami Ball objektai
    final static double R = 6.0;
    int clickNum; 
    
    private EventHandler<MouseEvent> clickInfo = e -> {
        if(clickNum == 0){ //jei pirmas paspaudimas
        click1X = e.getX();
        click1Y = e.getY();
        Shape shape = new Circle(click1X, click1Y, R);
        shape.setFill(Color.RED);
        nodes.add(shape);
        String info = "" + ++clickNum + ": " + " "+click1X+" "+click1Y; 
        nodes.add(new Text(click1X, click1Y, info));
        }
        else{
            if(clickNum == 1){
                click2X = e.getX();
                click2Y = e.getY();
                
            }
            else{
                clickNum--;
                nodes.clear();
                Shape shape = new Circle(click1X, click1Y, R);
                shape.setFill(Color.RED);
                nodes.add(shape);
                String info = "" + clickNum + ": " + " " + click1X + " " + click1Y;
                nodes.add(new Text(click1X, click1Y, info));
                
                click2X = e.getX();
                click2Y = e.getY();
            }
            Shape shape = new Circle(click2X, click2Y, R);
            shape.setFill(Color.RED);
            nodes.add(shape);
            String info = "" + ++clickNum + ": " + " " + click2X + " " + click2Y;
            nodes.add(new Text(click2X, click2Y, info));
            shape = new Line(click1X, click1Y, click2X, click2Y);
            shape.setStroke(Color.RED);
            shape.setStrokeWidth(2);
            nodes.add(shape);
            
            double distance = Calculations(click1X, click1Y, click2X, click2Y);
            DecimalFormat df = new DecimalFormat("#.#");
            shape = new Text(20, 20, "Atstumas tarp taškų: " + df.format(distance) + " km.");
            nodes.add(shape);
        }
    };
    double Calculations(double c1X, double c1Y, double c2X, double c2Y){
        double dX = Math.abs(c1X - c2X);
        double dY = Math.abs(c1Y - c2Y);
        double distanceP = Math.sqrt(Math.pow(dX, 2) + Math.pow(dY, 2));
        double distance = (distanceP * 50)/126;
        return distance;
    }
    void clear(){
        nodes.clear();
        clickNum = 0;
    }
    public static void main(String[] args) {
        launch(args);
    }
    @Override
    public void createControls() {
        addButton("Sukurti zemelapi", e -> createMap());
        addButton("Pasirinkti 2 taskus",   e -> canvas.setOnMouseClicked(clickInfo));
        addButton("Isvalyti", e -> clear());
        addNewHBox();
        //throw new UnsupportedOperationException("Not supported yet."); //To change body of generated methods, choose Tools | Templates.
    }
    @Override
    public void start(Stage stage) throws Exception {
        stage.setTitle("Braižymai Canvas lauke (KTU IF)");        
        setCanvas(randomColor(1), 1324, 820);
        super.start(stage);
    }
}

