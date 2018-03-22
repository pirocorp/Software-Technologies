import java.util.Scanner;
import java.util.stream.IntStream;

public class SumIntegers {
    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);
        int n = Integer.parseInt(scan.nextLine());
        int[] arr = new int[n];

        for (int i = 0; i < n; i++) {
            arr[i] = Integer.parseInt(scan.nextLine());
        }

        int sum = IntStream.of(arr).sum();

        System.out.printf("Sum = %d", sum);
    }
}
