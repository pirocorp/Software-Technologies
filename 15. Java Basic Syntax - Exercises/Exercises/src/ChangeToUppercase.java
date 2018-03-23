import java.util.Scanner;

public class ChangeToUppercase {
    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);
        String input = scan.nextLine();

        int startIndex = input.indexOf("<upcase>");
        int endIndex = input.indexOf("</upcase>");

        while (startIndex > -1 && endIndex > -1){
            String substring = input.substring(startIndex, endIndex + 9);

            String toBeReplacedWith = substring.replace("<upcase>", "");
            toBeReplacedWith = toBeReplacedWith.replace("</upcase>", "");
            toBeReplacedWith = toBeReplacedWith.toUpperCase();

            input = input.replace(substring, toBeReplacedWith);

            startIndex = input.indexOf("<upcase>");
            endIndex = input.indexOf("</upcase>");
        }

        System.out.println(input);
    }
}
