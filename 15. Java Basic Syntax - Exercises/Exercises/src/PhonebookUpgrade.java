import java.util.Scanner;
import java.util.TreeMap;

public class PhonebookUpgrade {
    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);
        TreeMap<String, String> phonebook = new TreeMap<>();

        String inputLine = scan.nextLine();

        while (!inputLine.equals("END")){

            String[] tokens = inputLine.split(" ");
            String command = tokens[0];


            switch (command)
            {
                case "A":
                    String name = tokens[1];
                    String phone = tokens[2];
                    if(phonebook.containsKey(name)){
                        phonebook.computeIfPresent(name, (k, v) -> v = phone);
                    } else {
                        phonebook.put(name, phone);
                    }
                    break;
                case "S":
                    name = tokens[1];
                    if(phonebook.containsKey(name)){
                        System.out.println(name + " -> " + phonebook.get(name));
                    } else {
                        System.out.printf("Contact %s does not exist.", name);
                        System.out.println("");
                    }
                    break;
                case "ListAll":
                    phonebook.forEach((k, v) -> System.out.println(k + " -> " + v));
                    break;
            }

            inputLine = scan.nextLine();
        }
    }
}
