import java.util.Arrays;
import java.util.Scanner;

public class IndexOfLetters {
    public static void main(String[] args) {
        Character[] alphabet = new Character[26];

        for (int i = 0; i < 26; i++) {
            alphabet[i] = (char)('a' + i);
        }

        int[] charFrequency = new int[26];

        Scanner scan = new Scanner(System.in);
        String inputWord = scan.nextLine().toLowerCase();

        for (int i = 0; i < inputWord.length(); i++) {
            char currentChar = inputWord.charAt(i);
            int currentIndex = Arrays.asList(alphabet).indexOf(currentChar);

            System.out.printf("%s -> %d", currentChar, currentIndex);
            System.out.println();
        }
    }
}
