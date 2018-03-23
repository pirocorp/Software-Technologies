import java.util.Scanner;

public class VowelOrDigit {
    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);
        char input = scan.nextLine().charAt(0);
        char inputToLower = Character.toLowerCase(input);

        if     (inputToLower == 'a' ||
                inputToLower == 'e' ||
                inputToLower == 'i' ||
                inputToLower == 'o' ||
                inputToLower == 'u'){
            System.out.println("vowel");
        } else if (input == '0' || input == '1' || input == '2' || input == '3' ||
                   input == '4' || input == '5' || input == '6' || input == '7' ||
                   input == '8' || input == '9'){
            System.out.println("digit");
        } else {
            System.out.println("other");
        }
    }
}
