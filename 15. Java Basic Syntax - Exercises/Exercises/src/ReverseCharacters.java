import java.util.Scanner;

public class ReverseCharacters {
    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);
        char[] res = new char[3];

        for (int i = 0; i < 3; i++) {
            res[i] = scan.nextLine().charAt(0);
        }

        StringBuilder sb = new StringBuilder();

        for (int i = 2; i >= 0; i--) {
            sb.append(res[i]);
        }

        System.out.println(sb);
    }
}
