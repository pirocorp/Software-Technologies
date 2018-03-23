import java.util.Scanner;

public class FitStringInChars {
    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);
        String input = scan.nextLine();

        if(input.length() >= 20){
            System.out.println(input.substring(0, 20));
        } else {
            System.out.println(padRight(20, '*', input));
        }
    }

    public static String padRight(int size, char symbol, String input){
        int pad = size - input.length();
        String pads = new String(new char[pad]).replace('\0', symbol);
        return input + pads;
    }
}
