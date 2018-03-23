import java.util.Scanner;

public class CensorEmailAddress {
    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);
        String oldEmail = scan.nextLine();
        String[] emailTokens = oldEmail.split("@");
        String username = emailTokens[0];
        username = new String(new char[username.length()]).replace('\0', '*');
        String newEmail = username + "@" + emailTokens[1];
        String input = scan.nextLine();
        String result = input.replaceAll(oldEmail, newEmail);
        System.out.println(result);
    }
}
