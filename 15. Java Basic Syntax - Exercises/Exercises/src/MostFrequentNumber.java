import java.util.Arrays;
import java.util.Scanner;

public class MostFrequentNumber {
    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);
        int[] numbers = Arrays.stream(scan.nextLine().split(" "))
                .mapToInt(Integer::parseInt)
                .toArray();

        int len;
        int mostFrequentNumber = numbers[0];
        int bestLen = 1;

        for (int i = 0; i < numbers.length - 1; i++) {
            len = 1;
            for (int j = i + 1; j < numbers.length; j++) {
                int leftNumber = numbers[i];
                int currentNumber = numbers[j];

                if (leftNumber == currentNumber) {
                    len++;

                    if (len > bestLen) {
                        bestLen = len;
                        mostFrequentNumber = numbers[i];
                    }
                }
            }
        }
        System.out.println(mostFrequentNumber);
    }
}
