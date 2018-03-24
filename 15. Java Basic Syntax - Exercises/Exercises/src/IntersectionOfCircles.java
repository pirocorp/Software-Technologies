import java.util.Arrays;
import java.util.Scanner;

public class IntersectionOfCircles {
    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);

        Circle firstCircle = circleParse(scan.nextLine());
        Circle secondCircle = circleParse(scan.nextLine());
        double dist = calcDistBetweenCircleCenter(firstCircle.getCenter(), secondCircle.getCenter());
        double radiuses = firstCircle.getRadius() + secondCircle.getRadius();

        if(dist <= radiuses){
            System.out.println("Yes");
        } else {
            System.out.println("No");
        }
    }

    private static double calcDistBetweenCircleCenter(Point firstCenter, Point secondCenter) {
        int x1 = firstCenter.getX();
        int y1 = firstCenter.getY();
        int x2 = secondCenter.getX();
        int y2 = secondCenter.getY();

        return Math.sqrt(Math.pow((x1 - x2), 2) + Math.pow((y1 - y2), 2));
    }

    private static Circle circleParse(String inputString) {
        int[] tokens = Arrays.stream(inputString.split(" "))
                .mapToInt(Integer::parseInt)
                .toArray();

        int x = tokens[0];
        int y = tokens[1];
        Point center = new Point(x, y);
        int r = tokens[2];
        return new Circle(center, r);
    }
}

class Point{
    private int x;
    private int y;

    public Point(int x, int y) {
        this.x = x;
        this.y = y;
    }

    public int getX() {
        return x;
    }

    public void setX(int x) {
        this.x = x;
    }

    public int getY() {
        return y;
    }

    public void setY(int y) {
        this.y = y;
    }
}

class Circle {
    private Point center;
    private int radius;

    public Circle(Point center, int radius) {
        this.center = center;
        this.radius = radius;
    }

    public Point getCenter() {
        return center;
    }

    public void setCenter(Point center) {
        this.center = center;
    }

    public int getRadius() {
        return radius;
    }

    public void setRadius(int radius) {
        this.radius = radius;
    }
}
