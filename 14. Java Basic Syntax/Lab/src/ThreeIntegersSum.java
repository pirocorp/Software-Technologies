import java.lang.reflect.Array;
import java.util.Arrays;
import java.util.Scanner;

public class ThreeIntegersSum {
    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);
        String inputLine = scan.nextLine();
        int[] arr = Arrays
                .stream(inputLine.split(" "))
                .mapToInt(Integer::valueOf)
                .sorted()
                .toArray();

        int num1 = Array.getInt(arr, 0);
        int num2 = Array.getInt(arr, 1);
        int num3 = Array.getInt(arr, 2);

        if(num1 + num2 == num3) {
            System.out.println(num1 + " + " + num2 + " = " + num3);
        } else if (num1 == num2 + num3){
            System.out.println(num2 + " + " + num3 + " = " + num1);
        } else if(num2 == num1 + num3){
            System.out.println(num1 + " + " + num3 + " = " + num2);
        } else {
            System.out.println("No");
        }

        //System.out.println(Arrays.toString(arr)); //-> print array
    }
}
