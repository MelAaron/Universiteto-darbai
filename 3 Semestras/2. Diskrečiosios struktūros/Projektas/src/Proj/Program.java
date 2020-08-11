package Proj;

import java.io.*;
import java.util.*;

import org.apache.poi.hssf.usermodel.HSSFSheet;
import org.apache.poi.hssf.usermodel.HSSFWorkbook;
import org.apache.poi.ss.usermodel.*;
import org.apache.poi.xssf.eventusermodel.XSSFReader;
import org.apache.poi.xssf.usermodel.XSSFSheet;
import org.apache.poi.xssf.usermodel.XSSFWorkbook;
import org.apache.poi.xssf.usermodel.XSSFCell;
import org.apache.poi.xssf.usermodel.XSSFRow;

public class Program {
    public static void main(String args[]) {
//        R1();
//        R2();
//        R3();
//        R4();
//        R5();
//        XSSFReader r = new XSSFReader();
    }

    public static void R1(){
        try {
            //File file = new File("C:\\Users\\PC\\Documents\\1.Stuff\\1. KTU\\3 Semestras\\Diskreciosios strukturos\\Projektas\\Data\\All flows.xlsx");
            FileInputStream fis = new FileInputStream(new File("C:\\Users\\PC\\Documents\\1.Stuff\\1. KTU\\3 Semestras\\Diskreciosios strukturos\\Projektas\\Data\\All flows.xlsx"));
            XSSFWorkbook wb = new XSSFWorkbook(fis);
            XSSFSheet sheet = wb.getSheetAt(0);
            Iterator<Row> rowIterator = sheet.iterator();
            Row row;
            Cell cell;
            while (rowIterator.hasNext()) {
                row = rowIterator.next();
                Iterator<Cell> cellIterator = row.cellIterator();
                while (cellIterator.hasNext()) {
                    cell = cellIterator.next();
                    switch (cell.getCellType()) {
                        case Cell.CELL_TYPE_STRING:
                            System.out.print(cell.getStringCellValue() + "\t\t\t");
                            break;
                        case Cell.CELL_TYPE_NUMERIC:
                            System.out.print(cell.getNumericCellValue() + "\t\t\t");
                            break;
                        default:
                    }
                }
                System.out.println("");
            }
        }
        catch (Exception e){
            e.printStackTrace();
        }
    }

    private static void R2(){
        try {
            File file = new File("C:\\Users\\PC\\Documents\\1.Stuff\\1. KTU\\3 Semestras\\Diskreciosios strukturos\\Projektas\\Data\\Distances NUTS2-NUTS2.xlsx");
            FileInputStream fis = new FileInputStream(file);
            XSSFWorkbook wb = new XSSFWorkbook(fis);
            XSSFSheet sheet = wb.getSheetAt(0);
//            Iterator<Row> rowIterator = sheet.iterator();

            //Map<Integer, List<String>> data = new HashMap<>();
            int i = 0;
            for(Row row : sheet){
               // data.put(i,new ArrayList<String>());
                for(Cell cell : row){
                    switch (cell.getCellTypeEnum()){
                        case STRING:
                            //data.get(new Integer(i)).add(cell.getRichStringCellValue().getString());
                            break;
                        case NUMERIC:
                                //data.get(i).add(cell.getNumericCellValue() + "");
                            break;
                        default:
                            //data.get(i).add(" ");
                    }
                    System.out.print(cell.toString() + " ");
                }
                System.out.println("\n");
                i++;
            }
        }
        catch (Exception e){
            e.printStackTrace();
        }
    }

    public static void R3(){
        try{
            String file = "C:\\Users\\PC\\Desktop\\DistancesNUTS2-NUTS2.xlsx";
            BufferedReader reader = new BufferedReader(new FileReader(file));
            String currentLine = reader.readLine();
            StringBuilder builder = new StringBuilder();
            while(currentLine != null){
                builder.replace(0,currentLine.length(), currentLine);
                //builder.append(currentLine);
                builder.append("n");
                System.out.println(currentLine);
                currentLine = reader.readLine();

            }
            reader.close();
        }
        catch (Exception e){
            e.printStackTrace();
        }
    }

    public static void R4(){
        try{
            String file = "C:\\Users\\PC\\Documents\\1.Stuff\\1. KTU\\3 Semestras\\Diskreciosios strukturos\\Projektas\\Data\\All flows.xlsx";
            Scanner scanner = new Scanner(new File(file));
            scanner.useDelimiter(",");
            while(scanner.hasNext()){
                System.out.println(scanner.next());
            }
        }
        catch (Exception e){
            e.printStackTrace();
        }
    }

    public static void R5(){
        try {
            File file = new File("C:\\Users\\PC\\Documents\\1.Stuff\\1. KTU\\3 Semestras\\Diskreciosios strukturos\\Projektas\\Data\\Distances NUTS2-NUTS2.xlsx");
            FileInputStream fis = new FileInputStream(file);
            XSSFWorkbook wb = new XSSFWorkbook(fis);
            XSSFSheet sheet = wb.getSheetAt(0);
            int temp = 0;
            boolean stop = false;
            Row row;
            while(temp < sheet.getLastRowNum()){
                for(int i = temp; i < temp + 1000; i++){
                    if(i == sheet.getLastRowNum() - 1){
                        stop = true;
                        break;
                    }
                    row = sheet.getRow(i);
                    for(int j = 0; j < row.getLastCellNum(); j++){
                        System.out.print("\"" + row.getCell(j) + "\";");
                    }
                    System.out.println();
                }
                if(stop) break;
                wb = new XSSFWorkbook(fis);
                sheet = wb.getSheetAt(0);
                temp+=1000;
            }
        }
        catch (Exception e){
            e.printStackTrace();
        }
    }
}
