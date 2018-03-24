import java.util.ArrayList;
import java.util.Comparator;
import java.util.List;
import java.util.Scanner;
import static java.util.Collections.reverseOrder;
import static java.util.Comparator.comparing;

public class AverageGrades {
    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);
        int n = Integer.parseInt(scan.nextLine());

        List<Student> students = new ArrayList<>();

        for (int i = 0; i < n; i++) {
            String[] tokens = scan.nextLine().split(" ");

            String name = tokens[0];
            List<Double> currentGrades = new ArrayList<>();

            for (int j = 1; j < tokens.length; j++) {
                currentGrades.add(Double.parseDouble(tokens[j]));
            }

            Student currentStudent = new Student(name, currentGrades);
            students.add(currentStudent);

            /* If want to add to existing student
            if(students.stream().anyMatch(o -> o.getName().equals(name))){
                Student currentStudent = students.stream().filter(o -> o.getName().equals(name)).findFirst().get();
                currentStudent.getGrades().addAll(currentGrades);
            } else {
                Student currentStudent = new Student(name, currentGrades);
                students.add(currentStudent);
            }*/
        }

                /* Using Comparator for sorting collection
                Comparator<Student> comparator = Comparator
                .comparing(Student::getName)
                .thenComparing(Student::getAverageGrade, reverseOrder());*/

        Student[] result = students
                .stream()
                .filter(o -> o.getAverageGrade() >= 5.00)
                .sorted(
                        comparing(Student::getName)
                                .thenComparing(comparing(Student::getAverageGrade).reversed()))
                .toArray(Student[]::new);

        for (Student student : result) {
            String name = student.getName();
            double averageGrade = student.getAverageGrade();
            System.out.printf("%s -> %.2f", name, averageGrade);
            System.out.println();
        }
    }
}

class Student {
    private String name;
    private List<Double> grades;

    public Student(String name) {
        this.name = name;
        this.grades = new ArrayList<>();
    }

    public Student(String name, List<Double> grades) {

        this.name = name;
        this.grades = grades;
    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public List<Double> getGrades() {
        return grades;
    }

    public void setGrades(List<Double> grades) {
        this.grades = grades;
    }

    public double getAverageGrade(){
        return this
                .grades
                .stream()
                .mapToDouble(Double::doubleValue)
                .average()
                .getAsDouble();
    }
}