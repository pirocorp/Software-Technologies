import java.util.HashMap;
import java.util.Scanner;

public class Phonebook {
    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);
        HashMap<String, String> phoneBook = new HashMap<>();

        String inputLine = scan.nextLine();

        while (!inputLine.equals("END")){

            String[] tokens = inputLine.split(" ");
            String command = tokens[0];
            String name = tokens[1];

            switch (command)
            {
                case "A":
                    String phone = tokens[2];
                    if(phoneBook.containsKey(name)){
                        phoneBook.computeIfPresent(name, (k, v) -> v = phone);
                    } else {
                        phoneBook.put(name, phone);
                    }
                    break;
                case "S":
                    if(phoneBook.containsKey(name)){
                        System.out.println(name + " -> " + phoneBook.get(name));
                    } else {
                        System.out.printf("Contact %s does not exist.", name);
                        System.out.println("");
                    }
                    break;
            }

            inputLine = scan.nextLine();
        }
    }
}
