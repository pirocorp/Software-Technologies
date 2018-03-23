import java.util.Scanner;

public class CompareCharArrays {
    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);
        String[] firstArr = scan.nextLine().split(" ");
        String[] secondArr = scan.nextLine().split(" ");

        boolean firstIsShorter = true;

        if(firstArr.length <= secondArr.length){

            for (int i = 0; i < firstArr.length; i++) {
                char currentCharFirstArr = firstArr[i].charAt(0);
                char currentCharSecondArr = secondArr[i].charAt(0);

                if(currentCharFirstArr > currentCharSecondArr){
                    firstIsShorter = false;
                }
            }
        } else if (secondArr.length < firstArr.length) {
            firstIsShorter = false;

            for (int i = 0; i < secondArr.length; i++) {
                char currentCharFirstArr = firstArr[i].charAt(0);
                char currentCharSecondArr = secondArr[i].charAt(0);

                if (currentCharFirstArr < currentCharSecondArr) {
                    firstIsShorter = true;
                }
            }

        }

        if(firstIsShorter){
            System.out.println(String.join("", firstArr));
            System.out.println(String.join("", secondArr));
        } else {
            System.out.println(String.join("", secondArr));
            System.out.println(String.join("", firstArr));
        }
    }
}
