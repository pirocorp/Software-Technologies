import java.util.Scanner;

public class IntegerToHexAndBinary {
    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);
        int n = Integer.parseInt(scan.nextLine());
        System.out.println(Integer.toHexString(n).toUpperCase());
        System.out.println(Integer.toBinaryString(n));
    }
}
