import java.util.Arrays;
import java.util.Scanner;

public class BombNumbers {
    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);
        int[] numbers = Arrays.stream(scan.nextLine().split(" "))
                .mapToInt(Integer::parseInt)
                .toArray();

        int[] tokens = Arrays.stream(scan.nextLine().split(" "))
                .mapToInt(Integer::parseInt)
                .toArray();

        int bomb = tokens[0];
        int power = tokens[1];

        int bombIndex = indexOfElement(numbers, bomb);

        while (bombIndex >= 0){
            int startIndex = Math.max(0, bombIndex - power);
            int endIndex = Math.min(numbers.length - 1, bombIndex + power);
            numbers = removeElementsFromArray(numbers, startIndex, endIndex);
            bombIndex = indexOfElement(numbers, bomb);
        }

        int result = Arrays.stream(numbers).sum();
        System.out.println(result);
    }

    private static int[] removeElementsFromArray(int[] numbers, int startIndex, int endIndex) {
        int elementsInResultArray = numbers.length - (endIndex - startIndex + 1);
        int[]result = new int[elementsInResultArray];

        int j = 0;
        for (int i = 0; i < startIndex; i++, j++) {
            result[j] = numbers[i];
        }

        for (int i = endIndex + 1; i < numbers.length; i++, j++) {
            result[j] = numbers[i];
        }

        return result;
    }

    public static int indexOfElement (int[] numbers, int element){
        for (int i = 0; i < numbers.length; i++) {
            if (element == numbers[i]){
                return i;
            }
        }

        return -1;
    }
}
