/****************************************************************
 * Šioje klasėje pateikamas įvadas į JavaFX grafiką
 * 
 * Pradžioje vykdykite kodą ir stebėkite atliekamus veiksmus
 * Užduotis atlikite sekdami nurodymus programinio kodo komentaruose
 * Gynimo metu atlikite dėstytojo nurodytas užduotis naujų metodų pagalba.
 *
 * @author Eimutis Karčiauskas, KTU programų inžinerijos katedra 2019 08 05
 **************************************************************************/
package demos.graphics;

import extendsFX.BaseGraphics;
import javafx.scene.paint.Color;
import javafx.scene.shape.ArcType;
import javafx.scene.text.Font;
import javafx.stage.Stage;

public class Demo0_Basic extends BaseGraphics {
        
    // pradžioje brėšime horizontalias ir vertikalias linijas per centrą
    private void drawHVtoCenter() {  
        gc.setLineWidth(3);       // brėžimo linijos plotis
        gc.setStroke(Color.RED);  // ir tos linijos spalva
        gc.strokeLine(0, canvasH / 2, canvasW, canvasH / 2);
        gc.strokeLine(canvasW / 2, 0, canvasW / 2, canvasH);
    }
    // po to brėšime įstrižaines per centrą
    private void drawXtoCenter() {
        gc.setLineWidth(4);         // brėžimo linijos plotis
        gc.setStroke(Color.GREEN);  // ir tos linijos spalva
        gc.strokeLine(0, 0, canvasW, canvasH);
        gc.strokeLine(0, canvasH, canvasW, 0);
    }  
// UŽDUOTIS_1: plonomis linijomis su žingsniu step=50 nubrėžkite tinklelį
    private void drawGrid1() { 
        gc.setStroke(Color.VIOLET);
        for(int step = 0; step <= canvasW; step += 50)
        gc.strokeLine(step, 0, step, canvasW);
        for(int step = 0; step <= canvasH; step += 50)
        gc.strokeLine(0, step, canvasW, step);
    }
// https://examples.javacodegeeks.com/desktop-java/javafx/javafx-canvas-example/    
    private void drawExamples1() {
        double lw = 3.0;
        gc.setLineWidth(lw);        // brėžimo linijos plotis
        gc.setStroke(Color.BLUE);   // ir tos linijos spalva
        gc.setFill(Color.RED);      // dažymo spalva figūroms
        int x=10, y=10, w=80, h=50, 
            d=20, ax=10, ay=20; // d-tarpas tarp elementų, ax,ay-apvalinimai
        gc.strokeRoundRect(x, y, w, h, ax, ay);
        x+=w+d; // sekantis į dešinę
        gc.fillRoundRect(  x, y, w, h, ax, ay);
        gc.setLineWidth(0.5);
        gc.strokeText("Wolf and Bear", x, y+h);
        //-------------------
        gc.setLineWidth(2*lw);    // dvigubai pastoriname liniją      
        gc.setFill(Color.YELLOW);
        x = 10;    // grįžtame horizontaliai
        y += h+d;  // ir pereiname žemyn
        gc.strokeOval(x, y, w, h);
        x += w+d; // sekantis į dešinę
        gc.fillOval( x, y, h, w);
        x = 10;     // grįžtame horizontaliai
        y += h+2*d; // ir pereiname žemyn ir brėžiame lankus
        gc.strokeArc  (x, y, w, w, 30,  90, ArcType.ROUND);
        gc.fillArc(x+w+d, y, w, w, 45, 180, ArcType.OPEN);
    }  
    private void drawUnicode(){
        // išbandykite ir kitus simbolius
        // https://en.wikipedia.org/wiki/List_of_Unicode  skyrius 31
        StringBuilder sb = new StringBuilder();
        StringBuilder sb2 = new StringBuilder();
        for(char ch = '\u2654'; ch <= '\u265F'; ch++)
            sb.append(ch);
        for(char ch = '\u2660'; ch <= '\u2667'; ch++)
            sb2.append(ch);
        gc.setFont(Font.font("Lucida Console", 36));
        gc.setLineWidth(1);
        gc.setStroke(Color.BLACK);
        gc.strokeText(sb.toString(), 50, 350);
        gc.strokeText(sb2.toString(), 50, 300);
    }
// UŽDUOTIS_2: nubrėžkite polilinijas ir poligonus   
// https://www.tutorialspoint.com/javafx/2dshapes_polygon    
    public void drawExamples2() {
        double[] x = new double[]{150.0, 250.0, 350.0, 250.0, 150.0};
        double[] y = new double[]{200.0, 350.0, 200.0, 100.0, 280.0};
        //nodes.add(polygon);
        double lw = 2.0;
        gc.setLineWidth(lw);
        gc.strokePolygon(x, y, 4);
        double[] x2 = new double[]{350, 450, 470, 500, 550};
        double[] y2 = new double[]{250, 350, 200, 130, 100};
        gc.strokePolyline(x2, y2, 5);
    }
// UŽDUOTIS_3: nubrėžkite taisyklingus 3, 4, 5, ..., 9-kampius  
    private void drawExamples3() {
        // Nurodymas: parašykite funkciją, kuri paskaičiuoja skaičių masyvus
        // kuriuose surašomos taisyklingo daugiakampio koordinatės
        double[][] x = new double[][]{Skaiciuoja(3, 'x'), Skaiciuoja(4, 'x'), Skaiciuoja(5, 'x'), Skaiciuoja(6, 'x'), Skaiciuoja(7, 'x'), Skaiciuoja(8, 'x'), Skaiciuoja(9, 'x')};
        double[][] y = new double[][]{Skaiciuoja(3, 'y'), Skaiciuoja(4, 'y'), Skaiciuoja(5, 'y'), Skaiciuoja(6, 'y'), Skaiciuoja(7, 'y'), Skaiciuoja(8, 'y'), Skaiciuoja(9, 'y')};
        for (int i = 0; i < 9; i++) {
            gc.strokePolygon(x[i], y[i], i + 3);
        }

    }

    private double[] Skaiciuoja(int n, char t) {
        double[] ats = new double[n];
        for (int i = 0; i < n; i++) {
            if (t == 'x') {
                ats[i] = 100 * n + 50 * Math.cos(i * 2 * Math.PI / n);
            }
            if (t == 'y') {
                ats[i] = (100 + 50 * Math.sin(i * 2 * Math.PI / n));
            }
        }
        return ats;
    }
// UŽDUOTIS_4: nubrėžkite žiedus https://en.wikipedia.org/wiki/Olympic_symbols
    private void drawOlympicRings() {
        gc.setLineWidth(9);
        gc.setStroke(Color.BLUE);
        gc.strokeOval(100, 100, 100, 100);
        
        gc.setStroke(Color.BLACK);
        gc.strokeOval(220, 100, 100, 100);
        
        gc.setStroke(Color.RED);
        gc.strokeOval(340, 100, 100, 100);
        
        gc.setStroke(Color.YELLOW);
        gc.strokeOval(160, 150, 100, 100);
        
        gc.setStroke(Color.GREEN);
        gc.strokeOval(280, 150, 100, 100);
    }
// UŽDUOTIS_5: pasirinktinai nubrėžkite savo tematiką:
// kelių valstybių sudėtingesnes vėliavas http://flagpedia.net/index
// pvz: Pietų Afrikos, Makedonijos, Norvegijos, Graikijos, Britanijos, ...
// arba futbolo, krepšinio ar ledo ritulio aikštes su žaidėjų pozicijomis  
    private void drawFreeThema() {
        //Denmark
        gc.setFill(Color.DARKRED);
        gc.fillRect(0, 0, 111, 84);
        gc.setFill(Color.WHITE);
        gc.fillRect(0, 36, 111, 12);
        gc.fillRect(36, 0, 12, 84);
        
        //Norway
        gc.setFill(Color.RED);
        gc.fillRect(0, 100, 111, 84);
        gc.setFill(Color.WHITE);
        gc.fillRect(0, 136, 111, 12);
        gc.fillRect(36, 100, 12, 84);
        gc.setFill(Color.DARKBLUE);
        gc.fillRect(0, 139, 111, 6);
        gc.fillRect(39, 100, 6, 84);
    }    
    private void flagEU(){
        gc.setFill(Color.BLUE);
        gc.fillRect(100, 100, 400, 300); //centras - 250; 200 apskritimo R = 70
        char star = '\u2605';
        StringBuilder sb = new StringBuilder();
        sb.append(star);
        gc.setFont(Font.font("Lucida Console", 6));
        gc.setLineWidth(10);
        gc.setStroke(Color.YELLOW);
        
        for(int deg = 0; deg <= 360; deg +=30){
            double x = 100 * Math.cos(Math.toRadians(deg)) + 300;
            double y = 100 * Math.sin(Math.toRadians(deg)) + 250;
            gc.strokeText(sb.toString(), x, y);
        }
        
        
    }
// kontrolinės užduotys gynimo metu:
// įvairios vėliavos, tiesiog tokios sudėtinės figūros kaip namukas,
// medis, eglė, sniego senio siluetas :-) ir t.t.    
    @Override
    public void createControls(){
        addButton("clear", e -> clearCanvas()); 
        addButton("grid",  e -> baseGrid());
        addButton("HVC",   e -> drawHVtoCenter());
        addButton("XC",    e -> drawXtoCenter());
        addButton("pvz1",  e -> drawExamples1());
        addButton("UniCode",  e -> drawUnicode());
        addButton("Rings", e -> drawOlympicRings());
        addButton("Flag", e -> drawFreeThema());
        addButton("My Grid", e -> drawGrid1());
        addButton("Poly", e -> drawExamples2());
        addButton("Poly2", e -> drawExamples3());
        addButton("EU flag", e -> flagEU());
        addNewHBox();
    }
    @Override
    public void start(Stage stage) throws Exception {
        stage.setTitle("Braižymai Canvas lauke (KTU IF)");        
        setCanvas(Color.CYAN.brighter(), 1000, 900);
        super.start(stage);
    }       
    public static void main(String[] args) {
        launch(args);
    }    
}
