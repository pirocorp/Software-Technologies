import java.util.Arrays;
import java.util.Scanner;
import java.util.TreeMap;

public class SumsByTown {
    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);
        int n = Integer.parseInt(scan.nextLine());
        TreeMap<String, Double> sumsByTown = new TreeMap<>();

        for (int i = 0; i < n; i++) {
            String[] tokens = Arrays
                    .stream(scan.nextLine().split("\\|"))
                    .map(x -> x.trim())
                    .toArray(String[]::new);
            String town = tokens[0];
            double income = Double.parseDouble(tokens[1]);

            if(sumsByTown.containsKey(town)){
                sumsByTown.put(town, sumsByTown.get(town) + income);
            } else {
                sumsByTown.put(town, income);
            }
        }

        for (String key : sumsByTown.keySet()) {
            System.out.println(key + " -> " + sumsByTown.get(key));
        }
    }
}
