import java.util.Arrays;
import java.util.Comparator;
import java.util.Scanner;

public class LargestNumbers {
    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);
        String inputLine = scan.nextLine();
        Arrays.stream(inputLine.split(" "))
                .map(Integer::valueOf)
                .sorted(Comparator.reverseOrder())
                .limit(3)
                .forEach(x -> System.out.println(x));
    }
}
