/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package edu.ktu.ds.lab2.kraujalis;

import edu.ktu.ds.lab2.gui.KsGui;
import edu.ktu.ds.lab2.gui.MainWindowMenu;
import edu.ktu.ds.lab2.gui.Panels;
import edu.ktu.ds.lab2.gui.ValidationException;
import edu.ktu.ds.lab2.utils.BstSet;
import edu.ktu.ds.lab2.utils.ParsableAvlSet;
import edu.ktu.ds.lab2.utils.ParsableBstSet;
import edu.ktu.ds.lab2.utils.ParsableSortedSet;
import java.io.File;
import java.io.FileNotFoundException;
import java.io.IOException;
import java.io.PrintWriter;
import java.util.Arrays;
import java.util.Collections;
import java.util.Locale;
import java.util.Random;
import java.util.ResourceBundle;
import java.util.Scanner;
import java.util.concurrent.BlockingQueue;
import java.util.concurrent.Semaphore;
import java.util.concurrent.SynchronousQueue;
import javafx.beans.property.SimpleObjectProperty;
import javafx.collections.FXCollections;
import javafx.event.ActionEvent;
import javafx.event.EventHandler;
import javafx.geometry.Insets;
import javafx.geometry.NodeOrientation;
import javafx.geometry.Pos;
import javafx.scene.Scene;
import javafx.scene.control.Alert;
import javafx.scene.control.Button;
import javafx.scene.control.ComboBox;
import javafx.scene.control.Label;
import javafx.scene.control.TextArea;
import javafx.scene.control.TextField;
import javafx.scene.image.Image;
import javafx.scene.layout.Background;
import javafx.scene.layout.BackgroundFill;
import javafx.scene.layout.BorderPane;
import javafx.scene.layout.CornerRadii;
import javafx.scene.layout.GridPane;
import javafx.scene.layout.Priority;
import javafx.scene.layout.Region;
import javafx.scene.layout.VBox;
import javafx.scene.paint.Color;
import javafx.scene.text.Font;
import javafx.stage.FileChooser;
import javafx.stage.Stage;
import javafx.stage.StageStyle;

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
public class KitasMainWindow extends BorderPane implements EventHandler<ActionEvent> {

    private static final ResourceBundle MESSAGES = ResourceBundle.getBundle("edu.ktu.ds.lab2.gui.kitasMessages");

    private static final int TF_WIDTH = 120;
    private static final int TF_WIDTH_SMALLER = 70;

    private static final double SPACING = 5.0;
    private static final Insets INSETS = new Insets(SPACING);
    private static final double SPACING_SMALLER = 2.0;
    private static final Insets INSETS_SMALLER = new Insets(SPACING_SMALLER);

    private final TextArea taOutput = new TextArea();
    private final GridPane paneBottom = new GridPane();
    private final GridPane paneParam2 = new GridPane();
    private final TextField tfDelimiter = new TextField();
    private final TextField tfInput = new TextField();
    private final ComboBox cmbTreeType = new ComboBox();

    private Panels paneParam1, paneButtons;
    private MainWindowMenu mainWindowMenu;
    private final Stage stage;

    private Account test;
    private Account test1;
    private BstSet<Account> testSet;
    private static ParsableSortedSet<Account> accountSet;
    private AccountGenerator accountGenerator = new AccountGenerator();

    private int sizeOfInitialSubSet, sizeOfGenSet, sizeOfLeftSubSet;
    private double shuffleCoef;
    private final String[] errors;

    public KitasMainWindow(Stage stage) {
        this.stage = stage;
        errors = new String[]{
            MESSAGES.getString("badSetSize"),
            MESSAGES.getString("badInitialData"),
            MESSAGES.getString("badSetSizes"),
            MESSAGES.getString("badShuffleCoef")
        };
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
                    MESSAGES.getString("button14")},
                2, 8);
        disableButtons(true);
        //======================================================================
        // Formuojama pirmoji parametrų lentelė (žalia). Naudojama klasė Panels.
        //======================================================================
        paneParam1 = new Panels(
                new String[]{
                    MESSAGES.getString("lblParam11"),
                    MESSAGES.getString("lblParam12"),
                    MESSAGES.getString("lblParam13"),
                    MESSAGES.getString("lblParam14"),
                    MESSAGES.getString("lblParam15")},
                new String[]{
                    MESSAGES.getString("tfParam11"),
                    MESSAGES.getString("tfParam12"),
                    MESSAGES.getString("tfParam13"),
                    MESSAGES.getString("tfParam14"),
                    MESSAGES.getString("tfParam15")},
                TF_WIDTH_SMALLER);
        //======================================================================
        // Formuojama antroji parametrų lentelė (gelsva).
        //======================================================================
        paneParam2.setAlignment(Pos.CENTER);
        paneParam2.setNodeOrientation(NodeOrientation.INHERIT);
        paneParam2.setVgap(SPACING);
        paneParam2.setHgap(SPACING);
        paneParam2.setPadding(INSETS);

        paneParam2.add(new Label(MESSAGES.getString("lblParam21")), 0, 0);
        paneParam2.add(new Label(MESSAGES.getString("lblParam22")), 0, 1);
        paneParam2.add(new Label(MESSAGES.getString("lblParam23")), 0, 2);

        cmbTreeType.setItems(FXCollections.observableArrayList(
                MESSAGES.getString("cmbTreeType1"),
                MESSAGES.getString("cmbTreeType2"),
                MESSAGES.getString("cmbTreeType3")
        ));
        cmbTreeType.setPrefWidth(TF_WIDTH);
        cmbTreeType.getSelectionModel().select(0);
        paneParam2.add(cmbTreeType, 1, 0);

        tfDelimiter.setPrefWidth(TF_WIDTH);
        tfDelimiter.setAlignment(Pos.CENTER);
        paneParam2.add(tfDelimiter, 1, 1);

        // Vėl pirmas stulpelis, tačiau plotis - 2 celės
        tfInput.setEditable(false);
        tfInput.setBackground(new Background(new BackgroundFill(Color.LIGHTGRAY, CornerRadii.EMPTY, Insets.EMPTY)));
        paneParam2.add(tfInput, 0, 3, 2, 1);
        //======================================================================
        // Formuojamas bendras parametrų panelis (tamsiai pilkas).
        //======================================================================
        paneBottom.setPadding(INSETS);
        paneBottom.setHgap(SPACING);
        paneBottom.setVgap(SPACING);
        paneBottom.add(paneButtons, 0, 0);
        paneBottom.add(paneParam1, 1, 0);
        paneBottom.add(paneParam2, 2, 0);
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
                        fileSaveMenu(0);
                    } else if (source.equals(mainWindowMenu.getMenus().get(0).getItems().get(2))) {
                        fileSaveMenu(1);
                    } else if (source.equals(mainWindowMenu.getMenus().get(0).getItems().get(3))) {
                        fileSaveMenu(2);
                    } else if (source.equals(mainWindowMenu.getMenus().get(0).getItems().get(4))) {
                        TestChooseMenu(false);
                    } else if (source.equals(mainWindowMenu.getMenus().get(0).getItems().get(5))) {
                        TestChooseMenu(true);
                    } else if (source.equals(mainWindowMenu.getMenus().get(0).getItems().get(6))) {
                        TestSetChooseMenu(false);
                    } else if (source.equals(mainWindowMenu.getMenus().get(0).getItems().get(7))) {
                        TestSetChooseMenu(true);
                    } else if (source.equals(mainWindowMenu.getMenus().get(0).getItems().get(9))) {
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
        cmbTreeType.setOnAction(this);
    }

    private void appearance() {
        paneButtons.setBackground(new Background(new BackgroundFill(Color.rgb(112, 162, 255)/* Blyškiai mėlyna */, CornerRadii.EMPTY, Insets.EMPTY)));
        paneParam1.setBackground(new Background(new BackgroundFill(Color.rgb(204, 255, 204)/* Šviesiai žalia */, CornerRadii.EMPTY, Insets.EMPTY)));
        paneParam1.getTfOfTable().get(2).setEditable(false);
        paneParam1.getTfOfTable().get(2).setStyle("-fx-text-fill: red");
        paneParam1.getTfOfTable().get(4).setEditable(false);
        paneParam1.getTfOfTable().get(4).setBackground(new Background(new BackgroundFill(Color.LIGHTGRAY, CornerRadii.EMPTY, Insets.EMPTY)));
        paneParam2.setBackground(new Background(new BackgroundFill(Color.rgb(255, 255, 153)/* Gelsva */, CornerRadii.EMPTY, Insets.EMPTY)));
        paneBottom.setBackground(new Background(new BackgroundFill(Color.GRAY, CornerRadii.EMPTY, Insets.EMPTY)));
        taOutput.setFont(Font.font("Monospaced", 12));
        taOutput.setStyle("-fx-text-fill: black;");
        taOutput.setEditable(false);
    }

    @Override
    public void handle(ActionEvent ae) {
        try {
            System.gc();
            System.gc();
            System.gc();
            Region region = (Region) taOutput.lookup(".content");
            region.setBackground(new Background(new BackgroundFill(Color.WHITE, CornerRadii.EMPTY, Insets.EMPTY)));

            Object source = ae.getSource();
            if (source instanceof Button) {
                handleButtons(source);
            } else if (source instanceof ComboBox && source.equals(cmbTreeType)) {
                disableButtons(true);
            }
        } catch (ValidationException e) {
            if (e.getCode() >= 0 && e.getCode() <= 3) {
                KsGui.ounerr(taOutput, errors[e.getCode()] + ": " + e.getMessage());
                if (e.getCode() == 2) {
                    paneParam1.getTfOfTable().get(0).setBackground(new Background(new BackgroundFill(Color.RED, CornerRadii.EMPTY, Insets.EMPTY)));
                    paneParam1.getTfOfTable().get(1).setBackground(new Background(new BackgroundFill(Color.RED, CornerRadii.EMPTY, Insets.EMPTY)));
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
            treeGeneration(null);
        } else if (source.equals(paneButtons.getButtons().get(1))) {
            treeIteration();
        } else if (source.equals(paneButtons.getButtons().get(2))) {
            treeAdd();
        } else if (source.equals(paneButtons.getButtons().get(3))) {
            treeEfficiency();
        } else if (source.equals(paneButtons.getButtons().get(4))) {
            treeRemove();
        } else if (source.equals(paneButtons.getButtons().get(5))) {
            defSet(0);
        } else if (source.equals(paneButtons.getButtons().get(6))) {
            defSet(1);
        } else if (source.equals(paneButtons.getButtons().get(7))) {
            defSet(2);
        } else if (source.equals(paneButtons.getButtons().get(8))) {
            addAll();
        } else if (source.equals(paneButtons.getButtons().get(9))) {
            containsAll();
        } else if (source.equals(paneButtons.getButtons().get(10))) {
            customSet();
        } else if (source.equals(paneButtons.getButtons().get(11))) {
            higher();
        } else if (source.equals(paneButtons.getButtons().get(12))) {
            pollFirst();
        } else if (source.equals(paneButtons.getButtons().get(13))) {
            pollLast();
        } 
//        else if (source.equals(paneButtons.getButtons().get(12))
//                || source.equals(paneButtons.getButtons().get(13))) {
//            KsGui.setFormatStartOfLine(true);
//            KsGui.ounerr(taOutput, MESSAGES.getString("notImplemented"));
//            KsGui.setFormatStartOfLine(false);
//        }
    }

    private void treeGeneration(String filePath) throws ValidationException {
        // Nuskaitomi parametrai
        readTreeParameters();
        // Sukuriamas aibės objektas, priklausomai nuo medžio pasirinkimo
        // cmbTreeType objekte
        createTree();

        Account[] accountArray;
        // Jei failas nenurodytas - generuojama
        if (filePath == null) {
            accountArray = accountGenerator.generateShuffle(sizeOfGenSet, sizeOfInitialSubSet, shuffleCoef);
            paneParam1.getTfOfTable().get(2).setText(String.valueOf(sizeOfLeftSubSet));
        } else { // Skaitoma is failo
            accountSet.load(filePath);
            accountArray = new Account[accountSet.size()];
            int i = 0;
            for (Object o : accountSet.toArray()) {
                accountArray[i++] = (Account) o;
            }
            // Skaitant iš failo išmaišoma standartiniu Collections.shuffle metodu.
            Collections.shuffle(Arrays.asList(accountArray), new Random());
        }

        // Išmaišyto masyvo elementai surašomi i aibę
        accountSet.clear();
        Arrays.stream(accountArray).forEach(accountSet::add);

        // Išvedami rezultatai
        // Nustatoma, kad eilutės pradžioje neskaičiuotų išvedamų eilučių skaičiaus
        KsGui.setFormatStartOfLine(true);
        KsGui.oun(taOutput, accountSet.toVisualizedString(tfDelimiter.getText()),
                MESSAGES.getString("setInTree"));
        // Nustatoma, kad eilutės pradžioje skaičiuotų išvedamų eilučių skaičių
        KsGui.setFormatStartOfLine(false);
        disableButtons(false);
    }

    private void treeAdd() throws ValidationException {
        KsGui.setFormatStartOfLine(true);
        Account account = accountGenerator.takeCar();
        accountSet.add(account);
        paneParam1.getTfOfTable().get(2).setText(String.valueOf(--sizeOfLeftSubSet));
        KsGui.oun(taOutput, account, MESSAGES.getString("setAdd"));
        KsGui.oun(taOutput, accountSet.toVisualizedString(tfDelimiter.getText()));
        KsGui.setFormatStartOfLine(false);
    }

    private void treeRemove() {
        KsGui.setFormatStartOfLine(true);
        if (accountSet.isEmpty()) {
            KsGui.ounerr(taOutput, MESSAGES.getString("setIsEmpty"));
            KsGui.oun(taOutput, accountSet.toVisualizedString(tfDelimiter.getText()));
        } else {
            int nr = new Random().nextInt(accountSet.size());
            Account account = (Account) accountSet.toArray()[nr];
            accountSet.remove(account);
            KsGui.oun(taOutput, account, MESSAGES.getString("setRemoval"));
            KsGui.oun(taOutput, accountSet.toVisualizedString(tfDelimiter.getText()));
        }
        KsGui.setFormatStartOfLine(false);
    }

    private void treeIteration() {
        KsGui.setFormatStartOfLine(true);
        if (accountSet.isEmpty()) {
            KsGui.ounerr(taOutput, MESSAGES.getString("setIsEmpty"));
        } else {
            KsGui.oun(taOutput, accountSet, MESSAGES.getString("setIterator"));
        }
        KsGui.setFormatStartOfLine(false);
    }

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

    private void defSet(int k) {
        KsGui.setFormatStartOfLine(true);
        edu.ktu.ds.lab2.utils.Set<Account> set;
        if (accountSet.isEmpty()) {
            KsGui.ounerr(taOutput, MESSAGES.getString("setIsEmpty"));
        } else {
            if (k == 0) {
                set = accountSet.headSet(test);
            } else if (k == 1) {
                set = accountSet.tailSet(test);
            } else {
                set = accountSet.subSet(test, test1);
            }

            KsGui.oun(taOutput, set.toVisualizedString(tfDelimiter.getText()));

            KsGui.setFormatStartOfLine(
                    false);
        }
    }

    private void customSet() {

        ParsableBstSet<Account> testing;
        testing = (ParsableBstSet<Account>) accountSet;
        edu.ktu.ds.lab2.utils.SortedSet<Account> set;

        if (accountSet.isEmpty()) {
            KsGui.ounerr(taOutput, MESSAGES.getString("setIsEmpty"));
        } else {
            KsGui.setFormatStartOfLine(true);
            set = testing.headSet(test, true);

            KsGui.oun(taOutput, set.toVisualizedString(tfDelimiter.getText()));
            KsGui.setFormatStartOfLine(false);
        }
    }

    private void higher() {
        ParsableBstSet<Account> testing;
        testing = (ParsableBstSet<Account>) accountSet;
        Account set;

        if (accountSet.isEmpty()) {
            KsGui.ounerr(taOutput, MESSAGES.getString("setIsEmpty"));
        } else {
            KsGui.setFormatStartOfLine(true);
            set = testing.higher(test);

            KsGui.oun(taOutput, set, MESSAGES.getString("testHigher"));
            KsGui.setFormatStartOfLine(false);
        }

    }

    private void pollFirst() {
        ParsableBstSet<Account> testing;
        testing = (ParsableBstSet<Account>) accountSet;
        Account set;
        if (accountSet.isEmpty()) {
            KsGui.ounerr(taOutput, MESSAGES.getString("setIsEmpty"));
        } else {
            KsGui.setFormatStartOfLine(true);
            set = testing.pollFirst();

            KsGui.oun(taOutput, set, MESSAGES.getString("testPollF"));
            KsGui.oun(taOutput, testing.toVisualizedString(tfDelimiter.getText()));
            KsGui.setFormatStartOfLine(false);
        }
    }

    private void pollLast() {
        ParsableBstSet<Account> testing;
        testing = (ParsableBstSet<Account>) accountSet;
        Account set;

        if (accountSet.isEmpty()) {
            KsGui.ounerr(taOutput, MESSAGES.getString("setIsEmpty"));
        } else {
            KsGui.setFormatStartOfLine(true);
            set = testing.pollLast();

            KsGui.oun(taOutput, set, MESSAGES.getString("testPollL"));
            KsGui.oun(taOutput, testing.toVisualizedString(tfDelimiter.getText()));
            KsGui.setFormatStartOfLine(false);
        }
    }

    private void addAll() {
        ParsableBstSet<Account> testing;
        testing = (ParsableBstSet<Account>) accountSet;

        BstSet<Account> beginer;
        beginer = new BstSet<>();
        beginer.add(test);
        beginer.add(test1);
        KsGui.oun(taOutput, beginer.toVisualizedString(tfDelimiter.getText()));

        if (accountSet.isEmpty()) {
            KsGui.ounerr(taOutput, MESSAGES.getString("setIsEmpty"));
        } else {
            testing.addAll(beginer);
            KsGui.oun(taOutput, testing.toVisualizedString(tfDelimiter.getText()));

        }
    }

    private void containsAll() {
        ParsableBstSet<Account> testing;
        testing = (ParsableBstSet<Account>) accountSet;

        boolean contAll = testing.removeAll(testSet);

        if (contAll) {
            KsGui.oun(taOutput, MESSAGES.getString("containsAllTrue"));
        } else {
            KsGui.oun(taOutput, MESSAGES.getString("containsAllFalse"));
        }

    }

//-------------------------------------------------------------------------------------------------------------------------   
//            ParsableBstSet<Account> testing;
//            testing = (ParsableBstSet<Account>) accountSet;  
//-------------------------------------------------------------------------------------------------------------------------  
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
            sizeOfGenSet = Integer.parseInt(paneParam1.getParametersOfTable().get(i).replace("-", "x"));
            sizeOfInitialSubSet = Integer.parseInt(paneParam1.getParametersOfTable().get(++i).replace("-", "x"));
            sizeOfLeftSubSet = sizeOfGenSet - sizeOfInitialSubSet;
            ++i;
            shuffleCoef = Double.parseDouble(paneParam1.getParametersOfTable().get(++i).replace("-", "x"));
        } catch (NumberFormatException e) {
            // Galima ir taip: pagauti exception'ą ir vėl mesti
            throw new ValidationException(paneParam1.getParametersOfTable().get(i), e, i);
        }
    }

    private void createTree() throws ValidationException {
        switch (cmbTreeType.getSelectionModel().getSelectedIndex()) {
            case 0:
                accountSet = new ParsableBstSet<>(Account::new);
                break;
            case 1:
                accountSet = new ParsableAvlSet<>(Account::new);
                break;
            default:
                disableButtons(true);
                throw new ValidationException(MESSAGES.getString("notImplemented"));
        }
    }

    private void disableButtons(boolean disable) {
        for (int i : new int[]{1, 2, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16}) {
            if (i < paneButtons.getButtons().size() && paneButtons.getButtons().get(i) != null) {
                paneButtons.getButtons().get(i).setDisable(disable);
            }
        }
    }

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

    private void TestChooseMenu(boolean type) throws ValidationException, FileNotFoundException {
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
            Scanner input = new Scanner(file.getAbsoluteFile());
            String line = input.nextLine();
            test = new Account(line, type);
            line = input.nextLine();
            test1 = new Account(line, type);

            KsGui.oun(taOutput, test, MESSAGES.getString("testAdd"));
            KsGui.oun(taOutput, test1, MESSAGES.getString("testAdd"));
        }
    }

    private void TestSetChooseMenu(boolean type) throws ValidationException, FileNotFoundException {
        FileChooser fc = new FileChooser();
        // Papildoma mūsų sukurtais filtrais
        fc.getExtensionFilters().addAll(
                new FileChooser.ExtensionFilter("All Files", "*.*"),
                new FileChooser.ExtensionFilter("txt", "*.txt")
        );
        fc.setTitle((MESSAGES.getString("menuItem11")));
        fc.setInitialDirectory(new File(System.getProperty("user.dir")));
        File file = fc.showOpenDialog(stage);
        testSet = new BstSet();

        if (file != null) {
            Scanner input = new Scanner(file.getAbsoluteFile());
            while (input.hasNext()) {
                String line = input.nextLine();
                testSet.add(new Account(line, type));
            }

            KsGui.oun(taOutput, MESSAGES.getString("testSetAdd"));
            KsGui.oun(taOutput, testSet.toVisualizedString(tfDelimiter.getText()));

        }
    }

    private void fileSaveMenu(int i) throws ValidationException, IOException {
//        KsGui.ounerr(taOutput, MESSAGES.getString("notImplemented"));

        FileChooser fc = new FileChooser();
        fc.getExtensionFilters().addAll(
                new FileChooser.ExtensionFilter("All Files", "*.*"),
                new FileChooser.ExtensionFilter("txt", "*.txt")
        );
        fc.setTitle((MESSAGES.getString("menuItem12")));
        fc.setInitialDirectory(new File(System.getProperty("user.dir")));

        File file = fc.showSaveDialog(stage);
        if (file != null) {
            filesaver(file.getAbsolutePath(), i);
        }

    }

    private void filesaver(String filePath, int i) throws ValidationException, IOException {
//            Files.write(Paths.get(filePath), (Iterable)accountSet);
        PrintWriter pw = new PrintWriter(filePath);
        for (Account o : accountSet) {
            switch (i) {
                case 1:
                    pw.println(o.ToString_data1());
                    break;
                case 0:
                    pw.println(o);
                    break;
                default:
                    pw.println(o.ToString_data2());
                    break;
            }
        }
        pw.close();
    }

    public static void createAndShowGui(Stage stage) {
        Locale.setDefault(Locale.US); // Suvienodiname skaičių formatus
        KitasMainWindow window = new KitasMainWindow(stage);
        stage.setScene(new Scene(window, 1100, 650));
        stage.setTitle(MESSAGES.getString("title"));
        stage.getIcons().add(new Image("file:" + MESSAGES.getString("icon")));
        stage.show();
    }
}
