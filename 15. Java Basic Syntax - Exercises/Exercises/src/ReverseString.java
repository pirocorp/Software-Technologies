import java.util.Scanner;

public class ReverseString {
    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);
        String inputString = scan.nextLine();
        String result = new StringBuilder(inputString).reverse().toString();
        System.out.println(result);
    }
}
