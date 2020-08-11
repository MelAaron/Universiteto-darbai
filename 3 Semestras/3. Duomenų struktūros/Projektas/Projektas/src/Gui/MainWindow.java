package Gui;

//import projektas.MCGenerator;
import Multiset.Multiset;
import java.io.BufferedReader;
import projektas.SimpleBenchmark;
//import edu.ktu.ds.lab2.svencionis.Microcontroller;
//import edu.ktu.ds.lab2.utils.BstSet;
//import edu.ktu.ds.lab2.utils.ParsableAvlSet;
//import edu.ktu.ds.lab2.utils.ParsableBstSet;
//import edu.ktu.ds.lab2.utils.ParsableSortedSet;
import javafx.beans.property.SimpleObjectProperty;
import javafx.collections.FXCollections;
import javafx.event.ActionEvent;
import javafx.event.EventHandler;
import javafx.geometry.Insets;
import javafx.geometry.NodeOrientation;
import javafx.geometry.Pos;
import javafx.scene.Scene;
import javafx.scene.control.*;
import javafx.scene.image.Image;
import javafx.scene.layout.*;
import javafx.scene.paint.Color;
import javafx.scene.text.Font;
import javafx.stage.FileChooser;
import javafx.stage.Stage;
import javafx.stage.StageStyle;

import java.io.File;
import java.io.FileNotFoundException;
import java.io.IOException;
import java.io.UncheckedIOException;
import java.nio.charset.Charset;
import java.nio.file.Files;
import java.nio.file.Paths;
import java.util.*;
import java.util.concurrent.BlockingQueue;
import java.util.concurrent.Semaphore;
import java.util.concurrent.SynchronousQueue;
import projektas.Ks;

/**
 * Lab2 langas su JavaFX
 * <pre>
 *                     MainWindow (BorderPane)
 *  |-------------------------Top-------------------------|
 *  |                   MainWindowMenu                    |
 *  |------------------------Center-----------------------|
 *  |  |-----------------------------------------------|  |
 *  |  |                                               |  |
 *  |  |                                               |  |
 *  |  |                    taOutput                   |  |
 *  |  |                                               |  |
 *  |  |                                               |  |
 *  |  |                                               |  |
 *  |  |                                               |  |
 *  |  |                                               |  |
 *  |  |-----------------------------------------------|  |                                           |
 *  |------------------------Bottom-----------------------|
 *  |  |~~~~~~~~~~~~~~~~~~~paneBottom~~~~~~~~~~~~~~~~~~|  |
 *  |  |                                               |  |
 *  |  |  |-------------||------------||------------|  |  |
 *  |  |  | paneButtons || paneParam1 || paneParam2 |  |  |
 *  |  |  |             ||            ||            |  |  |
 *  |  |  |-------------||------------||------------|  |  |
 *  |  |                                               |  |
 *  |  |~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~|  |
 *  |-----------------------------------------------------|
 * </pre>
 *
 * @author darius.matulis@ktu.lt
 */
public class MainWindow extends BorderPane implements EventHandler<ActionEvent> {

    private static final ResourceBundle MESSAGES = ResourceBundle.getBundle("projektas.messages");

    private static final int TF_WIDTH = 120;
    private static final int TF_WIDTH_SMALLER = 70;

    private static final double SPACING = 5.0;
    private static final Insets INSETS = new Insets(SPACING);
    private static final double SPACING_SMALLER = 2.0;
    private static final Insets INSETS_SMALLER = new Insets(SPACING_SMALLER);

    private final TextArea taOutput = new TextArea();
    
    private final GridPane paneBottom = new GridPane();
//    private final GridPane paneParam2 = new GridPane();
    private final TextField tfDelimiter = new TextField();
    private final TextField tfInput = new TextField();
//    private final ComboBox cmbTreeType = new ComboBox();

    private Panels paneParam1, paneButtons;
    private MainWindowMenu mainWindowMenu;
    private final Stage stage;
    
    private Multiset testset;
//    private static BstSet<Microcontroller> mcSet;
//    private Microcontroller test;
//    private Microcontroller test1;
//    private MCGenerator mcsGenerator = new MCGenerator();

    private int sizeOfInitialSubSet, sizeOfGenSet, sizeOfLeftSubSet;
    private double shuffleCoef;
    private final String[] errors;

    public MainWindow(Stage stage) {
        this.stage = stage;
        errors = new String[]{
                MESSAGES.getString("badSetSize"),
                MESSAGES.getString("badInitialData"),
                MESSAGES.getString("badSetSizes"),
                MESSAGES.getString("badShuffleCoef")
        };
//        taOutput.setBackground(new Background(new BackgroundFill(Color.rgb(69, 69, 69), CornerRadii.EMPTY, Insets.EMPTY)));
        initComponents();
    }

    private void initComponents() {
        //======================================================================
        // Sudaromas rezultatų išvedimo VBox klasės objektas, kuriame
        // talpinamas Label ir TextArea klasės objektai
        //======================================================================        
        VBox vboxTaOutput = new VBox();
        vboxTaOutput.setPadding(INSETS_SMALLER);
        VBox.setVgrow(taOutput, Priority.ALWAYS);
//        vboxTaOutput.setBackground(new Background(new BackgroundFill(Color.rgb(69, 69, 69), CornerRadii.EMPTY, Insets.EMPTY)));
        vboxTaOutput.getChildren().addAll(new Label(MESSAGES.getString("border1")), taOutput);
        //======================================================================
        // Formuojamas mygtukų tinklelis (mėlynas). Naudojama klasė Panels.
        //======================================================================
        paneButtons = new Panels(
                new String[]{
                        MESSAGES.getString("button1"),
                        MESSAGES.getString("button2"),
                        MESSAGES.getString("button3"),
                        MESSAGES.getString("button4"),
                        MESSAGES.getString("button5"),
                        MESSAGES.getString("button6"),
                        MESSAGES.getString("button7"),
                        MESSAGES.getString("button8"),
                        MESSAGES.getString("button9"),
                        MESSAGES.getString("button10"),
                        MESSAGES.getString("button11"),
                        MESSAGES.getString("button12"),
                        MESSAGES.getString("button13"),
                        MESSAGES.getString("button14"),
                        MESSAGES.getString("button17"),
                        MESSAGES.getString("button18"),
                        MESSAGES.getString("button15"),
                        MESSAGES.getString("button16")},
                2, 7);
        disableButtons(true);
        //======================================================================
        // Formuojama pirmoji parametrų lentelė (žalia). Naudojama klasė Panels.
        //======================================================================
        paneParam1 = new Panels(
                new String[]{
                        MESSAGES.getString("lblParam11"),
//                        MESSAGES.getString("lblParam12"),
//                        MESSAGES.getString("lblParam13"),
//                        MESSAGES.getString("lblParam14"),
                        MESSAGES.getString("lblParam15")},
                new String[]{
                        MESSAGES.getString("tfParam11"),
//                        MESSAGES.getString("tfParam12"),
//                        MESSAGES.getString("tfParam13"),
//                        MESSAGES.getString("tfParam14"),
                        MESSAGES.getString("tfParam15")},
                TF_WIDTH_SMALLER);
        //======================================================================
        // Formuojama antroji parametrų lentelė (gelsva).
        //======================================================================
//        paneParam2.setAlignment(Pos.CENTER);
//        paneParam2.setNodeOrientation(NodeOrientation.INHERIT);
//        paneParam2.setVgap(SPACING);
//        paneParam2.setHgap(SPACING);
//        paneParam2.setPadding(INSETS);

//        paneParam2.add(new Label(MESSAGES.getString("lblParam21")), 0, 0);
//        paneParam2.add(new Label(MESSAGES.getString("lblParam22")), 0, 1);
//        paneParam2.add(new Label(MESSAGES.getString("lblParam11")), 0, 0);
        //Cia pridet 
//        paneParam2.add(new Label(MESSAGES.getString("lblParam23")), 0, 2);

//        cmbTreeType.setItems(FXCollections.observableArrayList(
//                MESSAGES.getString("cmbTreeType1"),
//                MESSAGES.getString("cmbTreeType2"),
//                MESSAGES.getString("cmbTreeType3")
//        ));
//        cmbTreeType.setPrefWidth(TF_WIDTH);
//        cmbTreeType.getSelectionModel().select(0);
//        paneParam2.add(cmbTreeType, 1, 0);

        tfDelimiter.setPrefWidth(TF_WIDTH);
        tfDelimiter.setAlignment(Pos.CENTER);
//        paneParam2.add(tfDelimiter, 1, 1);

        // Vėl pirmas stulpelis, tačiau plotis - 2 celės
        tfInput.setEditable(true);
        tfInput.setBackground(new Background(new BackgroundFill(Color.CYAN, CornerRadii.EMPTY, Insets.EMPTY)));
//        paneParam2.add(tfInput, 0, 3, 2, 1);
        //======================================================================
        // Formuojamas bendras parametrų panelis (tamsiai pilkas).
        //======================================================================
        paneBottom.setPadding(INSETS);
        paneBottom.setHgap(SPACING);
        paneBottom.setVgap(SPACING);
        paneBottom.add(paneButtons, 0, 0);
        paneBottom.add(paneParam1, 1, 0);
//        paneBottom.add(paneParam2, 2, 0);
        paneBottom.alignmentProperty().bind(new SimpleObjectProperty<>(Pos.CENTER));

        mainWindowMenu = new MainWindowMenu() {
            @Override
            public void handle(ActionEvent ae) {
                Region region = (Region) taOutput.lookup(".content");
                region.setBackground(new Background(new BackgroundFill(Color.WHITE, CornerRadii.EMPTY, Insets.EMPTY)));

                try {
                    Object source = ae.getSource();
                    if (source.equals(mainWindowMenu.getMenus().get(0).getItems().get(0))) {
                        fileChooseMenu();
                    } else if (source.equals(mainWindowMenu.getMenus().get(0).getItems().get(1))) {
                        KsGui.ounerr(taOutput, MESSAGES.getString("notImplemented"));
                    } else if (source.equals(mainWindowMenu.getMenus().get(0).getItems().get(3))) {
                        System.exit(0);
                    } else if (source.equals(mainWindowMenu.getMenus().get(1).getItems().get(0))) {
                        Alert alert = new Alert(Alert.AlertType.INFORMATION);
                        alert.initStyle(StageStyle.UTILITY);
                        alert.setTitle(MESSAGES.getString("menuItem21"));
                        alert.setHeaderText(MESSAGES.getString("author"));
                        alert.showAndWait();
                    }
                } catch (ValidationException e) {
                    KsGui.ounerr(taOutput, e.getMessage());
                } catch (Exception e) {
                    KsGui.ounerr(taOutput, MESSAGES.getString("systemError"));
                    e.printStackTrace(System.out);
                }
                KsGui.setFormatStartOfLine(false);
            }
        };

        //======================================================================
        // Formuojamas Lab2 langas
        //======================================================================          
        // ..viršuje, centre ir apačioje talpiname objektus..
        setTop(mainWindowMenu);
        setCenter(vboxTaOutput);

        VBox vboxPaneBottom = new VBox();
        VBox.setVgrow(paneBottom, Priority.ALWAYS);
        vboxPaneBottom.getChildren().addAll(new Label(MESSAGES.getString("border2")), paneBottom);
        setBottom(vboxPaneBottom);
        appearance();

        paneButtons.getButtons().forEach(btn -> btn.setOnAction(this));
//        cmbTreeType.setOnAction(this);
    }

    private void appearance() {//175 13 139
        paneButtons.setBackground(new Background(new BackgroundFill(Color.rgb(175, 13, 139)/* Blyškiai mėlyna */, CornerRadii.EMPTY, Insets.EMPTY)));
        paneParam1.setBackground(new Background(new BackgroundFill(Color.rgb(255, 126, 0)/* Šviesiai žalia */, CornerRadii.EMPTY, Insets.EMPTY)));
        taOutput.setBackground(new Background(new BackgroundFill(Color.rgb(69, 69, 69), CornerRadii.EMPTY, Insets.EMPTY)));
//        taOutput.se
//        paneParam1.getTfOfTable().get(2).setEditable(false);
//        paneParam1.getTfOfTable().get(2).setStyle("-fx-text-fill: red");
//        paneParam1.getTfOfTable().get(4).setEditable(false);
//        paneParam1.getTfOfTable().get(4).setBackground(new Background(new BackgroundFill(Color.LIGHTGRAY, CornerRadii.EMPTY, Insets.EMPTY)));
//        paneParam2.setBackground(new Background(new BackgroundFill(Color.rgb(51, 255, 63)/* Gelsva */, CornerRadii.EMPTY, Insets.EMPTY)));
        paneBottom.setBackground(new Background(new BackgroundFill(Color.GRAY, CornerRadii.EMPTY, Insets.EMPTY)));
        taOutput.setFont(Font.font("Monospaced", 12));
        taOutput.setStyle("-fx-text-fill: black;");
        taOutput.setEditable(false);
        taOutput.setBackground(new Background(new BackgroundFill(Color.rgb(69, 69, 69), CornerRadii.EMPTY, Insets.EMPTY)));
    }

    @Override
    public void handle(ActionEvent ae) {
        try {
            System.gc();
            System.gc();
            System.gc();
            Region region = (Region) taOutput.lookup(".content");
//            region.setBackground(new Background(new BackgroundFill(Color.rgb(69, 69, 69), CornerRadii.EMPTY, Insets.EMPTY)));

            Object source = ae.getSource();
            if (source instanceof Button) {
                handleButtons(source);
            } else if (source instanceof ComboBox/* && source.equals(cmbTreeType)*/) {
                disableButtons(true);
            }
        } catch (ValidationException e) {
            if (e.getCode() >= 0 && e.getCode() <= 3) {
                KsGui.ounerr(taOutput, errors[e.getCode()] + ": " + e.getMessage());
                if (e.getCode() == 2) {
                    paneParam1.getTfOfTable().get(0).setBackground(new Background(new BackgroundFill(Color.DARKRED, CornerRadii.EMPTY, Insets.EMPTY)));
                    paneParam1.getTfOfTable().get(1).setBackground(new Background(new BackgroundFill(Color.DARKRED, CornerRadii.EMPTY, Insets.EMPTY)));
                }
            } else if (e.getCode() == 4) {
                KsGui.ounerr(taOutput, MESSAGES.getString("allSetIsPrinted"));
            } else {
                KsGui.ounerr(taOutput, e.getMessage());
            }
        } catch (UnsupportedOperationException e) {
            KsGui.ounerr(taOutput, e.getLocalizedMessage());
        } catch (Exception e) {
            KsGui.ounerr(taOutput, MESSAGES.getString("systemError"));
            e.printStackTrace(System.out);
        }
    }

    private void handleButtons(Object source) throws ValidationException {
        if (source.equals(paneButtons.getButtons().get(0))) {
            treeGeneration(/*"C:\\Users\\PC\\Documents\\1.Stuff\\1. KTU\\3 Semestras\\Duomenu strukturos\\Projektas\\data\\"*/null);
        } else if (source.equals(paneButtons.getButtons().get(1))) { //generuoti multiset
            treeEfficiency();
        } else if (source.equals(paneButtons.getButtons().get(2))) { //benchmark
            MSadd();
        } else if (source.equals(paneButtons.getButtons().get(3))) { //add
            MSaddAll();
        } else if (source.equals(paneButtons.getButtons().get(4))) { // addAll
            MSremove();
        } else if (source.equals(paneButtons.getButtons().get(5))) { //remove
            MSremoveAll();
        } else if (source.equals(paneButtons.getButtons().get(6))) { //removeAll
            MSmostFrequent();
        }else if (source.equals(paneButtons.getButtons().get(7))) { //getMostFrequent
            MSretainAll();
        }else if (source.equals(paneButtons.getButtons().get(8))) { //retainAll
            MSMultisetSize();
        }else if (source.equals(paneButtons.getButtons().get(9))) { //Multiset size
            MSsetCount();
        }else if (source.equals(paneButtons.getButtons().get(10))) { //setCount
            MSgetCount();
        }else if (source.equals(paneButtons.getButtons().get(11))) { //getCount
            MStotalSize();
        }else if (source.equals(paneButtons.getButtons().get(12))) { //totalSize
            MScontains();
        }else if (source.equals(paneButtons.getButtons().get(13))) { //contains
            MSisempty();
        }
//        else if (source.equals(paneButtons.getButtons().get(14))) { //isEmpty
////            treeHeight();
//        }else if (source.equals(paneButtons.getButtons().get(15))) { //saveCurrent
////            saveCurrent();
//        }else if (source.equals(paneButtons.getButtons().get(16))) { //navigavimas <--
////            navigavimas(-1);
//        }else if (source.equals(paneButtons.getButtons().get(17))) { //navigavimas -->
////            navigavimas(1);
//        }
//        else if (source.equals(paneButtons.getButtons().get(5))
//                || source.equals(paneButtons.getButtons().get(6))) {
//            KsGui.setFormatStartOfLine(true);
//            KsGui.ounerr(taOutput, MESSAGES.getString("notImplemented"));
//            KsGui.setFormatStartOfLine(false);
//        }
    }
    
    private void MSisempty(){
        taOutput.clear();
        KsGui.oun(taOutput, testset.isEmpty(), MESSAGES.getString("isEmpty"));
        KsGui.oun(taOutput, testset.toString(), MESSAGES.getString("setInTree"));
    }
    
    private void MScontains(){
        taOutput.clear();
        KsGui.oun(taOutput, testset.contains(paneParam1.getParametersOfTable().get(1)), MESSAGES.getString("contains"));
        KsGui.oun(taOutput, testset.toString(), MESSAGES.getString("setInTree"));
    }
    
    private void MStotalSize(){
         taOutput.clear();
        KsGui.oun(taOutput, testset.totalSize(), MESSAGES.getString("totalSize"));
        KsGui.oun(taOutput, testset.toString(), MESSAGES.getString("setInTree"));
    }
    
    private void MSgetCount(){
        taOutput.clear();
        KsGui.oun(taOutput, testset.getCount(paneParam1.getParametersOfTable().get(1)), MESSAGES.getString("getCount"));
        KsGui.oun(taOutput, testset.toString(), MESSAGES.getString("setInTree"));
    }
    
    private void MSsetCount(){
        String [] parts = paneParam1.getParametersOfTable().get(1).split(" ");
        int ha = testset.setCount(parts[0], Integer.parseInt(parts[1]));
        taOutput.clear();
        KsGui.oun(taOutput, ha, MESSAGES.getString("setCount"));
        KsGui.oun(taOutput, parts[0] + " -> " + testset.getCount(parts[0]));
        KsGui.oun(taOutput, testset.toString(), MESSAGES.getString("setInTree"));
    }
    
    private void MSMultisetSize(){
        int ha = testset.getSetLength();
        taOutput.clear();
        KsGui.oun(taOutput, ha, MESSAGES.getString("multisetSize"));
        KsGui.oun(taOutput, testset.toString(), MESSAGES.getString("setInTree"));
    }
    
    private void MSretainAll(){
        Set<String> ta = testset.elementSet();
        taOutput.clear();
        boolean ha = testset.retainAll(ta);
        KsGui.oun(taOutput, ha, MESSAGES.getString("retained"));
        KsGui.oun(taOutput, testset.toString(), MESSAGES.getString("setInTree"));
    }
    
    private void MSmostFrequent(){
        Object ha = testset.getMostFrequent();
        taOutput.clear();
        KsGui.oun(taOutput, ha, MESSAGES.getString("mostFrequent"));
        KsGui.oun(taOutput, testset.toString(), MESSAGES.getString("setInTree"));
    }
    
    private void MSremoveAll(){
        Set<String> ta = testset.elementSet();
        taOutput.clear();
        boolean ha = testset.removeAll(ta);
        KsGui.oun(taOutput, ha, MESSAGES.getString("removed"));
        KsGui.oun(taOutput, testset.toString(), MESSAGES.getString("setInTree"));
    }
    
    private void MSaddAll(){
        Set<String> ta = testset.elementSet();
        taOutput.clear();
        boolean ha = testset.addAll(ta);
        KsGui.oun(taOutput, ha, MESSAGES.getString("added"));
        KsGui.oun(taOutput, testset.toString(), MESSAGES.getString("setInTree"));
    }
    
    private void MSremove(){
        String[] t = paneParam1.getParametersOfTable().get(1).split(" ");
        if (t.length == 1) {
            taOutput.clear();
            boolean ha = testset.remove(paneParam1.getParametersOfTable().get(1));
            KsGui.oun(taOutput, ha, MESSAGES.getString("removed"));
            KsGui.oun(taOutput, paneParam1.getParametersOfTable().get(1) + " -> " + testset.getCount(paneParam1.getParametersOfTable().get(1)));
            KsGui.oun(taOutput, testset.toString(), MESSAGES.getString("setInTree"));
        } else {
            int ha = testset.remove(t[0], Integer.parseInt(t[1]));
            taOutput.clear();
            KsGui.oun(taOutput, ha, MESSAGES.getString("removed"));
            KsGui.oun(taOutput, t[0] + " -> " + testset.getCount(t[0]));
            KsGui.oun(taOutput, testset.toString(), MESSAGES.getString("setInTree"));
        }
//        taOutput.clear();
//        boolean ha = testset.remove(tfInput.getText());
//        KsGui.oun(taOutput, ha, MESSAGES.getString("removed"));
//        KsGui.oun(taOutput, tfInput.getText() + " -> " + testset.getCount(tfInput.getText()));
//        KsGui.oun(taOutput, testset.toString(), MESSAGES.getString("setInTree"));
    }
    
    private void MSadd(){
        String[] t = paneParam1.getParametersOfTable().get(1).split(" ");
        if(t.length == 1){
            taOutput.clear();
        boolean ha = testset.add(paneParam1.getParametersOfTable().get(1));
        KsGui.oun(taOutput, ha, MESSAGES.getString("added"));
        KsGui.oun(taOutput, paneParam1.getParametersOfTable().get(1) + " -> " + testset.getCount(paneParam1.getParametersOfTable().get(1)));
        KsGui.oun(taOutput, testset.toString(), MESSAGES.getString("setInTree"));
        } else{
            int ha = testset.add(t[0], Integer.parseInt(t[1]));
            taOutput.clear();
            KsGui.oun(taOutput, ha, MESSAGES.getString("added"));
            KsGui.oun(taOutput, t[0] + " -> " + testset.getCount(t[0]));
            KsGui.oun(taOutput, testset.toString(), MESSAGES.getString("setInTree"));
        }
//        String TA = paneParam1.getParametersOfTable().get(1);
//        KsGui.oun(taOutput, TA, MESSAGES.getString("setInTree"));
    }

    private void treeGeneration(String filePath) throws ValidationException {
        taOutput.clear();
        // Nuskaitomi parametrai
        readTreeParameters();
        // Sukuriamas aibės objektas, priklausomai nuo medžio pasirinkimo
        // cmbTreeType objekte
        createTree();

        String[] setArray;
        // Jei failas nenurodytas - generuojama
        if (filePath == null) {
            testset.randomStringSet(sizeOfGenSet);
//            setArray = projektas.SimpleBenchmark.getRandomStringSet();
            setArray = testset.randomStringArray(sizeOfGenSet);
//            paneParam1.getTfOfTable().get(2).setText(String.valueOf(sizeOfLeftSubSet));
        } else { // Skaitoma is failo
            load(filePath);
            setArray = new String[testset.getSetLength()];
            int i = 0;
            for (Object o : testset.toArray()) {
                setArray[i++] = (String) o;
            }
            // Skaitant iš failo išmaišoma standartiniu Collections.shuffle metodu.
            Collections.shuffle(Arrays.asList(setArray), new Random());
        }

        // Išmaišyto masyvo elementai surašomi i aibę
        testset.clear();
        Arrays.stream(setArray).forEach(testset::add);

        // Išvedami rezultatai
        // Nustatoma, kad eilutės pradžioje neskaičiuotų išvedamų eilučių skaičiaus
        KsGui.setFormatStartOfLine(true);
        KsGui.oun(taOutput, testset.toString(), MESSAGES.getString("setInTree"));
        // Nustatoma, kad eilutės pradžioje skaičiuotų išvedamų eilučių skaičių
        KsGui.setFormatStartOfLine(false);
        disableButtons(false);
//        navA = testset.toArray();
//        k = 0;
        //disableNavB();
    }

//    private void treeAdd() throws ValidationException {
//        KsGui.setFormatStartOfLine(true);
//        String newS = KsGui.randomString(10);
////        Microcontroller car = mcsGenerator.takeMicrocontroller();
//        testset.add(newS);
//        paneParam1.getTfOfTable().get(2).setText(String.valueOf(--sizeOfLeftSubSet));
//        KsGui.oun(taOutput, newS, MESSAGES.getString("setAdd"));
////        KsGui.oun(taOutput, testset.toVisualizedString(tfDelimiter.getText()));
////        KsGui.oun(taOutput, testset.toString());
//        KsGui.setFormatStartOfLine(false);
//    }
//
//    private void treeRemove() {
//        KsGui.setFormatStartOfLine(true);
//        if (testset.isEmpty()) {
//            KsGui.ounerr(taOutput, MESSAGES.getString("setIsEmpty"));
////            KsGui.oun(taOutput, testset.toVisualizedString(tfDelimiter.getText()));
//        } else {
//            int nr = new Random().nextInt(testset.getSetLength());
//            String car = (String) testset.toArray()[nr];
//            testset.remove(car);
//            KsGui.oun(taOutput, car, MESSAGES.getString("setRemoval"));
////            KsGui.oun(taOutput, testset.toVisualizedString(tfDelimiter.getText()));
//        }
//        KsGui.setFormatStartOfLine(false);
//    }
//
//    private void treeIteration() {
//        KsGui.setFormatStartOfLine(true);
//        if (testset.isEmpty()) {
//            KsGui.ounerr(taOutput, MESSAGES.getString("setIsEmpty"));
//        } else {
//            KsGui.oun(taOutput, testset, MESSAGES.getString("setIterator"));
//        }
//        KsGui.setFormatStartOfLine(false);
//    }
    
//    private void removeIteration(){
//        KsGui.setFormatStartOfLine(true);
//        if (testset.isEmpty()) {
//            KsGui.ounerr(taOutput, MESSAGES.getString("setIsEmpty"));
//        } else {
//            Iterator ite = testset.iterator();
//            ite.next();
//            ite.next();
//            ite.remove();
//            KsGui.oun(taOutput, testset, MESSAGES.getString("setIterator"));
//        }
//        KsGui.setFormatStartOfLine(false);
//    }

    private void treeEfficiency() {
        KsGui.setFormatStartOfLine(true);
        KsGui.oun(taOutput, "", MESSAGES.getString("benchmark"));
        paneBottom.setDisable(true);
        mainWindowMenu.setDisable(true);

        BlockingQueue<String> resultsLogger = new SynchronousQueue<>();
        Semaphore semaphore = new Semaphore(-1);
        SimpleBenchmark simpleBenchmark = new SimpleBenchmark(resultsLogger, semaphore);

        // Ši gija paima rezultatus iš greitaveikos tyrimo gijos ir išveda
        // juos į taOutput. Gija baigia darbą kai gaunama FINISH_COMMAND
        new Thread(() -> {
            try {
                String result;
                while (!(result = resultsLogger.take())
                        .equals(SimpleBenchmark.FINISH_COMMAND)) {
                    KsGui.ou(taOutput, result);
                    semaphore.release();
                }
            } catch (InterruptedException e) {
                Thread.currentThread().interrupt();
            }

            semaphore.release();
            paneBottom.setDisable(false);
            mainWindowMenu.setDisable(false);
        }, "Greitaveikos_rezultatu_gija").start();

        //Šioje gijoje atliekamas greitaveikos tyrimas
        new Thread(simpleBenchmark::startBenchmark, "Greitaveikos_tyrimo_gija").start();
    }

    private void readTreeParameters() throws ValidationException {
        // Truputėlis kosmetikos..
        for (int i = 0; i < 2; i++) {
            paneParam1.getTfOfTable().get(i).setStyle("-fx-control-inner-background: white; ");
            paneParam1.getTfOfTable().get(i).applyCss();
        }
        // Nuskaitomos parametrų reiksmės. Jei konvertuojant is String
        // įvyksta klaida, sugeneruojama NumberFormatException situacija. Tam, kad
        // atskirti kuriame JTextfield'e ivyko klaida, panaudojama nuosava
        // situacija MyException
        int i = 0;
        try {
            // Pakeitimas (replace) tam, kad sukelti situaciją esant
            // neigiamam skaičiui        
            sizeOfGenSet = Integer.parseInt(paneParam1.getParametersOfTable().get(i).replace("-", "x")); //prdinis dydis
//            sizeOfInitialSubSet = Integer.parseInt(paneParam1.getParametersOfTable().get(++i).replace("-", "x")); //Mano irasytas
//            sizeOfLeftSubSet = sizeOfGenSet - sizeOfInitialSubSet; //count
            ++i;
//            shuffleCoef = Double.parseDouble(paneParam1.getParametersOfTable().get(++i).replace("-", "x"));
        } catch (NumberFormatException e) {
            // Galima ir taip: pagauti exception'ą ir vėl mesti
//            throw new ValidationException(paneParam1.getParametersOfTable().get(i), e, i);
        }
    }

    private void createTree() throws ValidationException {
        testset = new Multiset<>();
//        switch (cmbTreeType.getSelectionModel().getSelectedIndex()) {
//            case 0:
//                mcSet = new ParsableBstSet<>(Microcontroller::new);
//                break;
//            case 1:
//                mcSet = new ParsableAvlSet<>(Microcontroller::new);
//                break;
//            default:
//                disableButtons(true);
//                throw new ValidationException(MESSAGES.getString("notImplemented"));
//        }
    }

    private void disableButtons(boolean disable) {
        for (int i : new int[]{2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17}) {
            if (i < paneButtons.getButtons().size() && paneButtons.getButtons().get(i) != null) {
                paneButtons.getButtons().get(i).setDisable(disable);
            }
        }
    }
    
//    private void disableNavB(){
//        if(k==1) paneButtons.getButtons().get(16).setDisable(true);
//        else if(k != 1 ) paneButtons.getButtons().get(16).setDisable(false);
//    }

    private void fileChooseMenu() throws ValidationException {
        FileChooser fc = new FileChooser();
        // Papildoma mūsų sukurtais filtrais
        fc.getExtensionFilters().addAll(
                new FileChooser.ExtensionFilter("All Files", "*.*"),
                new FileChooser.ExtensionFilter("txt", "*.txt")
        );
        fc.setTitle((MESSAGES.getString("menuItem11")));
        fc.setInitialDirectory(new File(System.getProperty("user.dir")));
        File file = fc.showOpenDialog(stage);
        if (file != null) {
            treeGeneration(file.getAbsolutePath());
        }
    }

    public static void createAndShowGui(Stage stage) {
        Locale.setDefault(Locale.US); // Suvienodiname skaičių formatus
        MainWindow window = new MainWindow(stage);
        stage.setScene(new Scene(window, 550, 950));
        stage.setTitle(MESSAGES.getString("title"));
        stage.getIcons().add(new Image("file:" + MESSAGES.getString("icon")));
        stage.show();
    }
    
    public void load(String filePath) {
        testset = new Multiset<>();
        if (filePath == null || filePath.length() == 0) {
            return;
        }
        testset.clear();
        try (BufferedReader fReader = Files.newBufferedReader(Paths.get(filePath), Charset.defaultCharset())) {
            fReader.lines()
                    .map(String::trim)
                    .filter(line -> !line.isEmpty())
                    .forEach(testset::add);
        } catch (FileNotFoundException e) {
            Ks.ern("Tinkamas duomenų failas nerastas: " + e.getLocalizedMessage());
        } catch (IOException | UncheckedIOException e) {
            Ks.ern("Failo skaitymo klaida: " + e.getLocalizedMessage());
        }
//        return set;
    }
}
