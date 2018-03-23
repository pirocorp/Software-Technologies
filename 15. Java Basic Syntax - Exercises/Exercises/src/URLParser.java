import java.util.Scanner;

public class URLParser {
    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);
        String input = scan.nextLine();
        String protocol = "";

        if(input.contains("://")){
            String[] tokens = input.split(":\\/\\/");
            protocol = tokens[0];
            input = tokens[1];
        }

        String server = "";
        String resource = "";

        if(input.contains("/")){
            int index = input.indexOf('/');
            server = input.substring(0, index);
            resource = input.substring(index + 1);
        } else {
            server = input;
        }

        System.out.printf("[protocol] = \"%s\"", protocol);
        System.out.println();
        System.out.printf("[server] = \"%s\"", server);
        System.out.println();
        System.out.printf("[resource] = \"%s\"", resource);
        System.out.println();

    }
}
