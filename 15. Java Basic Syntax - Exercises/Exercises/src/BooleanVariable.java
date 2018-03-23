import java.util.Scanner;

public class BooleanVariable {
    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);
        boolean res = Boolean.parseBoolean(scan.nextLine());
        if(res){
            System.out.println("Yes");
        } else {
            System.out.println("No");
        }
    }
}
