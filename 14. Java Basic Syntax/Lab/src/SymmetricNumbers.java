import java.util.ArrayList;
import java.util.List;
import java.util.Scanner;

public class SymmetricNumbers {
    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);
        int n = Integer.parseInt(scan.nextLine());
        List<String> symetricNumbers = new ArrayList<>();

        for (int i = 1; i <= n ; i++) {
            String currentNumber = Integer.toString(i);
            String reversedCurrentNumber = new StringBuilder(currentNumber)
                    .reverse()
                    .toString();

            if(currentNumber.equals(reversedCurrentNumber)){
                symetricNumbers.add(currentNumber);
            }
        }

        System.out.println(String.join(", ", symetricNumbers));
    }
}
