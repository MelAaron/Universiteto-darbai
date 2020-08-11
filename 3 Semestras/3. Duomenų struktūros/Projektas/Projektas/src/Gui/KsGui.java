package Gui;

import java.util.Random;
import javafx.application.Platform;
import javafx.geometry.Insets;
import javafx.scene.control.TextArea;
import javafx.scene.layout.Background;
import javafx.scene.layout.BackgroundFill;
import javafx.scene.layout.CornerRadii;
import javafx.scene.layout.Region;
import javafx.scene.paint.Color;

/**
 * Klasė, skirta duomenų išvedimui į GUI
 *
 * @author darius
 */
public class KsGui {

    private static int lineNr;
    private static boolean formatStartOfLine = true;

    public static void setFormatStartOfLine(boolean formatStartOfLine) {
        KsGui.formatStartOfLine = formatStartOfLine;
    }

    private static String getStartOfLine() {
        return (formatStartOfLine) ? ++lineNr + "| " : "";
    }

    public static void ou(TextArea ta, Object o) {
        StringBuilder sb = new StringBuilder();
        if (o instanceof Iterable) {
            for (Object iter : (Iterable) o) {
                sb.append(iter.toString()).append(System.lineSeparator());
            }
        } else {
            sb.append(o.toString());
        }
        Platform.runLater(() -> ta.appendText(sb.toString()));
    }

    public static void oun(TextArea ta, Object o) {
        StringBuilder sb = new StringBuilder();
        if (o instanceof Iterable) {
            for (Object iter : (Iterable) o) {
                sb.append(iter.toString()).append(System.lineSeparator());
            }
            sb.append(System.lineSeparator());
        } else {
            sb.append(o.toString()).append(System.lineSeparator());
        }
        Platform.runLater(() -> ta.appendText(sb.toString()));
    }

    public static void ou(TextArea ta, Object o, String msg) {
        String startOfLine = getStartOfLine();
        Platform.runLater(() -> ta.appendText(startOfLine + msg + ": "));
        oun(ta, o);
    }

    public static void oun(TextArea ta, Object o, String msg) {
        String startOfLine = getStartOfLine();
        Platform.runLater(() -> ta.appendText(startOfLine + msg + ": " + System.lineSeparator()));
        oun(ta, o);
    }

    public static void ounerr(TextArea ta, Exception e) {
        Region region = (Region) ta.lookup(".content");
        region.setBackground(new Background(new BackgroundFill(Color.PINK, CornerRadii.EMPTY, Insets.EMPTY)));
        String startOfLine = getStartOfLine();
        Platform.runLater(() -> ta.appendText(startOfLine +
                e.getLocalizedMessage() +
                System.lineSeparator()));
    }

    public static void ounerr(TextArea ta, String msg) {
        Region region = (Region) ta.lookup(".content");
        region.setBackground(new Background(new BackgroundFill(Color.PINK, CornerRadii.EMPTY, Insets.EMPTY)));
        String startOfLine = getStartOfLine();
        Platform.runLater(() -> ta.appendText(startOfLine + msg + ". " + System.lineSeparator()));
    }

    public static void ounerr(TextArea ta, String msg, String parameter) {
        Region region = (Region) ta.lookup(".content");
        region.setBackground(new Background(new BackgroundFill(Color.PINK, CornerRadii.EMPTY, Insets.EMPTY)));
        String startOfLine = getStartOfLine();
        Platform.runLater(() -> ta.appendText(startOfLine + msg + ": " + parameter + System.lineSeparator()));
    }
    
    public static String randomString(int length){
        Random rn = new Random();
        char[] chars = {'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k',
            'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x',
            'y', 'z', '0', '1', '2', '3', '4', '5', '6', '7', '8', '9'};
        String ret = "";
        int a = rn.nextInt();
        while(a == 0)
        for(int i = 0; i < length; i++){
            ret += chars[a];
            a = rn.nextInt();
        }
        return ret;   
    }
}
