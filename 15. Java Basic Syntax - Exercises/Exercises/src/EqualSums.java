import java.util.Arrays;
import java.util.Scanner;

public class EqualSums {
    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);
        int[] numbers = Arrays.stream(scan.nextLine().split(" "))
                .mapToInt(Integer::parseInt)
                .toArray();

        boolean isFound = false;

        for (int i = 0; i < numbers.length; i++) {
            int currentNumber = numbers[i];

            int sumOfLeftElements = 0;

            for (int j = 0; j < i; j++) {
                int currentLeftElement = numbers[j];
                sumOfLeftElements += currentLeftElement;
            }

            int sumOfRightElements = 0;

            for (int j = i + 1; j < numbers.length; j++) {
                int currentLeftElement = numbers[j];
                sumOfRightElements += currentLeftElement;
            }

            if (sumOfLeftElements == sumOfRightElements){
                System.out.println(i);
                isFound = true;
                break;
            }
        }

        if(!isFound){
            System.out.println("no");
        }
    }
}
