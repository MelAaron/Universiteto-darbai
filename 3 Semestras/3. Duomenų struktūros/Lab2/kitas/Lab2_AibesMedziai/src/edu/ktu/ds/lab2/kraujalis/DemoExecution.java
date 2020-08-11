/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package edu.ktu.ds.lab2.kraujalis;

import java.util.Locale;
import javafx.application.Application;
import javafx.stage.Stage;

/**
 *
 * @author Gvidas Kraujalis
 */
/*
 * Darbo atlikimo tvarka - čia yra pradinė klasė.
 */
public class DemoExecution extends Application {

    public static void main(String[] args) {
        DemoExecution.launch(args);
    }

    @Override
    public void start(Stage primaryStage) throws Exception {
        Locale.setDefault(Locale.US); // Suvienodiname skaičių formatus 
//        TestManual.executeTest();
        KitasMainWindow.createAndShowGui(primaryStage);
    }
}
