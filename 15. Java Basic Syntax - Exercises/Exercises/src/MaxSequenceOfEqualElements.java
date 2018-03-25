import java.util.Arrays;
import java.util.Scanner;
import java.util.stream.Collectors;

public class MaxSequenceOfEqualElements {
    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);
        int[] numbers = Arrays.stream(scan.nextLine().split(" "))
                .mapToInt(Integer::parseInt)
                .toArray();

        int start = 0;
        int len = 1;
        int bestStart = 0;
        int bestLen = 1;

        for (int i = 1; i < numbers.length; i++) {
            int currentElement = numbers[i];
            int leftElement = numbers[i - 1];

            if(currentElement == leftElement) {
                len++;

                if(len > bestLen){
                    bestLen = len;
                    bestStart = start;
                }
            }
            else {
                start = i;
                len = 1;
            }
        }

        int[] res = new int[bestLen];

        System.arraycopy(numbers, bestStart, res, 0, bestLen);

        String result = Arrays.stream(res)
                .mapToObj(String::valueOf)
                .collect(Collectors.joining(" "));
        System.out.println(result);
    }
}
